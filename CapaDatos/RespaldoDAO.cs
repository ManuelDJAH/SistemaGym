using System;
using System.Data.SqlClient;
using System.IO;

namespace CapaDatos
{
    public class RespaldoDAO
    {
        /// <summary>
        /// Obtiene la carpeta de backups oficial de SQL Server.
        /// Esta carpeta siempre tiene permisos para el servicio MSSQL.
        /// </summary>
        private string ObtenerCarpetaBackupSQLServer()
        {
            try
            {
                using (var con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    // Consulta la ruta de backups configurada en SQL Server
                    string sql = @"
                        SELECT SERVERPROPERTY('InstanceDefaultBackupPath') AS BackupPath";

                    using (var cmd = new SqlCommand(sql, con))
                    {
                        object resultado = cmd.ExecuteScalar();
                        if (resultado != null && resultado != DBNull.Value)
                        {
                            string ruta = resultado.ToString().TrimEnd('\\');
                            if (Directory.Exists(ruta))
                                return ruta;
                        }
                    }
                }
            }
            catch { }

            // Fallback: ruta estándar de SQL Express
            string[] rutasPosibles = {
                @"C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\Backup",
                @"C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\Backup",
                @"C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\Backup",
                @"C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\Backup",
            };

            foreach (var ruta in rutasPosibles)
                if (Directory.Exists(ruta)) return ruta;

            // Último fallback: raíz del disco C
            return @"C:\RespaldosGymDB";
        }

        public (bool ok, string mensaje, string rutaFinal) GenerarRespaldo(string carpetaDestino)
        {
            string nombreArchivo = $"GymDB_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
            string carpetaTemporal = ObtenerCarpetaBackupSQLServer();
            string rutaTemporal = Path.Combine(carpetaTemporal, nombreArchivo);
            string rutaFinal = Path.Combine(carpetaDestino, nombreArchivo);

            try
            {
                // Asegurar que la carpeta temporal exista
                if (!Directory.Exists(carpetaTemporal))
                    Directory.CreateDirectory(carpetaTemporal);

                // Paso 1: SQL Server escribe en SU carpeta (tiene permisos)
                bool ok = EjecutarBackup(rutaTemporal);
                if (!ok) return (false, "El backup no generó el archivo esperado.", null);

                // Paso 2: C# copia el archivo a la carpeta elegida por el usuario
                File.Copy(rutaTemporal, rutaFinal, overwrite: true);

                // Paso 3: Limpiar temporal
                try { File.Delete(rutaTemporal); } catch { }

                return (true, "Respaldo generado exitosamente.", rutaFinal);
            }
            catch (SqlException ex)
            {
                LimpiarTemporal(rutaTemporal);
                return (false, $"Error SQL: {ex.Message}", null);
            }
            catch (Exception ex)
            {
                LimpiarTemporal(rutaTemporal);
                return (false, $"Error: {ex.Message}", null);
            }
        }

        private bool EjecutarBackup(string rutaTemporal)
        {
            // Intentar con COMPRESSION primero (Standard/Enterprise)
            // Si falla, reintentar sin ella (Express)
            string[] scripts = {
                @"BACKUP DATABASE GymDB TO DISK = @ruta
                  WITH FORMAT, INIT, NAME = N'GymDB Respaldo Completo',
                       COMPRESSION, STATS = 10;",
                @"BACKUP DATABASE GymDB TO DISK = @ruta
                  WITH FORMAT, INIT, NAME = N'GymDB Respaldo Completo',
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
                            cmd.Parameters.AddWithValue("@ruta", rutaTemporal);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    return File.Exists(rutaTemporal);
                }
                catch (SqlException ex) when (ex.Message.Contains("COMPRESSION"))
                {
                    // Reintentar sin compresión
                    continue;
                }
            }
            return false;
        }

        private void LimpiarTemporal(string ruta)
        {
            try { if (File.Exists(ruta)) File.Delete(ruta); } catch { }
        }
    }
}