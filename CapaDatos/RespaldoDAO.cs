using System;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;

namespace CapaDatos
{
    public class RespaldoDAO
    {
        /// <summary>
        /// Extrae el nombre de la BD desde la cadena de conexión activa.
        /// </summary>
        private string ObtenerNombreBD()
        {
            try
            {
                using (var con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    // El nombre real de la BD conectada
                    return con.Database;
                }
            }
            catch { return "GymDB"; }
        }

        /// <summary>
        /// Detecta si estamos en Linux (producción Railway).
        /// </summary>
        private bool EsLinux() =>
            System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(
                System.Runtime.InteropServices.OSPlatform.Linux);

        public (bool ok, string mensaje, string rutaFinal) GenerarRespaldo(string carpetaDestino)
        {
            string nombreBD = ObtenerNombreBD();
            string nombreArch = $"{nombreBD}_{DateTime.Now:yyyyMMdd_HHmmss}.bak";

            if (EsLinux())
            {
                // En producción (Railway/Linux): guardar en /tmp
                string rutaTmp = Path.Combine("/tmp", nombreArch);
                try
                {
                    bool ok = EjecutarBackup(nombreBD, rutaTmp);
                    if (!ok) return (false, "El backup no generó el archivo esperado.", null);
                    return (true, "Respaldo generado.", rutaTmp);
                }
                catch (SqlException ex)
                {
                    return (false, $"Error SQL: {ex.Message}", null);
                }
                catch (Exception ex)
                {
                    return (false, $"Error: {ex.Message}", null);
                }
            }
            else
            {
                // En local (Windows): usar carpeta de SQL Server
                string carpetaTemp = ObtenerCarpetaBackupSQLServer();
                string rutaTemp = Path.Combine(carpetaTemp, nombreArch);
                string rutaFinal = Path.Combine(carpetaDestino, nombreArch);

                try
                {
                    if (!Directory.Exists(carpetaTemp))
                        Directory.CreateDirectory(carpetaTemp);

                    bool ok = EjecutarBackup(nombreBD, rutaTemp);
                    if (!ok) return (false, "El backup no generó el archivo esperado.", null);

                    File.Copy(rutaTemp, rutaFinal, overwrite: true);
                    try { File.Delete(rutaTemp); } catch { }

                    return (true, "Respaldo generado exitosamente.", rutaFinal);
                }
                catch (SqlException ex)
                {
                    LimpiarTemp(rutaTemp);
                    return (false, $"Error SQL: {ex.Message}", null);
                }
                catch (Exception ex)
                {
                    LimpiarTemp(rutaTemp);
                    return (false, $"Error: {ex.Message}", null);
                }
            }
        }

        private bool EjecutarBackup(string nombreBD, string rutaDestino)
        {
            string[] scripts = {
                $@"BACKUP DATABASE [{nombreBD}] TO DISK = @ruta
                   WITH FORMAT, INIT, NAME = N'{nombreBD} Respaldo',
                        COMPRESSION, STATS = 10;",
                $@"BACKUP DATABASE [{nombreBD}] TO DISK = @ruta
                   WITH FORMAT, INIT, NAME = N'{nombreBD} Respaldo',
                        STATS = 10;"
            };

            foreach (string sql in scripts)
            {
                try
                {
                    using (var con = Conexion.ObtenerConexion())
                    {
                        con.Open();
                        using (var cmd = new SqlCommand(sql, con))
                        {
                            cmd.CommandTimeout = 300;
                            cmd.Parameters.AddWithValue("@ruta", rutaDestino);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    return File.Exists(rutaDestino);
                }
                catch (SqlException ex) when (ex.Message.Contains("COMPRESSION"))
                {
                    continue;
                }
            }
            return false;
        }

        private string ObtenerCarpetaBackupSQLServer()
        {
            try
            {
                using (var con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    using (var cmd = new SqlCommand(
                        "SELECT SERVERPROPERTY('InstanceDefaultBackupPath')", con))
                    {
                        var res = cmd.ExecuteScalar()?.ToString().TrimEnd('\\');
                        if (!string.IsNullOrEmpty(res) && Directory.Exists(res)) return res;
                    }
                }
            }
            catch { }

            string[] rutas = {
                @"C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\Backup",
                @"C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\Backup",
                @"C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\Backup",
            };

            foreach (var r in rutas)
                if (Directory.Exists(r)) return r;

            return @"C:\RespaldosGymDB";
        }

        private void LimpiarTemp(string ruta)
        {
            try { if (File.Exists(ruta)) File.Delete(ruta); } catch { }
        }
    }
}