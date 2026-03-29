using System;
using System.Data.SqlClient;
using System.IO;

namespace CapaDatos
{
    public class RespaldoDAO
    {
        /// <summary>
        /// Genera un respaldo .bak de GymDB en la ruta indicada.
        /// SQL Server escribe el archivo directamente — la ruta debe
        /// ser accesible por el servicio de SQL Server (local funciona).
        /// </summary>
        public (bool ok, string mensaje, string rutaFinal) GenerarRespaldo(string carpetaDestino)
        {
            try
            {
                // Nombre con timestamp: GymDB_20260328_143022.bak
                string nombreArchivo = $"GymDB_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
                string rutaCompleta = Path.Combine(carpetaDestino, nombreArchivo);

                string sql = @"
                    BACKUP DATABASE GymDB
                    TO DISK = @ruta
                    WITH FORMAT,
                         INIT,
                         NAME        = N'GymDB - Respaldo Completo',
                         COMPRESSION,
                         STATS       = 10;";

                using (var con = Conexion.ObtenerConexion())
                {
                    con.Open();

                    // El backup puede tardar — aumentar timeout
                    using (var cmd = new SqlCommand(sql, con))
                    {
                        cmd.CommandTimeout = 300; // 5 minutos
                        cmd.Parameters.AddWithValue("@ruta", rutaCompleta);
                        cmd.ExecuteNonQuery();
                    }
                }

                return (true, $"Respaldo generado exitosamente.", rutaCompleta);
            }
            catch (SqlException ex)
            {
                // Error común: COMPRESSION no disponible en Express
                // Reintentar sin compresión
                if (ex.Message.Contains("COMPRESSION"))
                    return GenerarRespaldoSinCompresion(carpetaDestino);

                return (false, $"Error SQL: {ex.Message}", null);
            }
            catch (Exception ex)
            {
                return (false, $"Error: {ex.Message}", null);
            }
        }

        // SQL Server Express no soporta COMPRESSION — fallback
        private (bool ok, string mensaje, string rutaFinal) GenerarRespaldoSinCompresion(string carpetaDestino)
        {
            try
            {
                string nombreArchivo = $"GymDB_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
                string rutaCompleta = Path.Combine(carpetaDestino, nombreArchivo);

                string sql = @"
                    BACKUP DATABASE GymDB
                    TO DISK = @ruta
                    WITH FORMAT, INIT,
                         NAME  = N'GymDB - Respaldo Completo',
                         STATS = 10;";

                using (var con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    using (var cmd = new SqlCommand(sql, con))
                    {
                        cmd.CommandTimeout = 300;
                        cmd.Parameters.AddWithValue("@ruta", rutaCompleta);
                        cmd.ExecuteNonQuery();
                    }
                }

                return (true, "Respaldo generado exitosamente.", rutaCompleta);
            }
            catch (Exception ex)
            {
                return (false, $"Error: {ex.Message}", null);
            }
        }
    }
}