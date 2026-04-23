using System;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace CapaDatos
{
    public class RespaldoDAO
    {
        // Tablas en orden para respetar FKs
        private static readonly string[] Tablas = {
            "Membresias", "Usuarios", "UsuariosSistema",
            "CategoriasProveedor", "Proveedores",
            "Inv_Categorias", "Inv_Productos", "Inv_Equipo",
            "Inv_Movimientos", "Inv_Alertas", "Inv_Defectos",
            "OrdenesRestock", "Asistencias",
            "BitacoraSesion", "Cambios"
        };

        public (bool ok, string mensaje, string rutaFinal) GenerarRespaldo(string carpetaDestino)
        {
            string nombreBD = ObtenerNombreBD();
            string nombreArch = $"{nombreBD}_{DateTime.Now:yyyyMMdd_HHmmss}.sql";
            string rutaFinal = Path.Combine(carpetaDestino, nombreArch);

            try
            {
                var sb = new StringBuilder();
                sb.AppendLine("-- ══════════════════════════════════════════════════");
                sb.AppendLine($"-- Respaldo: {nombreBD}");
                sb.AppendLine($"-- Fecha: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                sb.AppendLine($"-- Sistema: SistemaGym — Ctrl Fitness");
                sb.AppendLine("-- ══════════════════════════════════════════════════");
                sb.AppendLine("SET NOCOUNT ON;");
                sb.AppendLine();

                using (var cn = Conexion.ObtenerConexion())
                {
                    cn.Open();
                    foreach (var tabla in Tablas)
                    {
                        if (!TablaExiste(cn, tabla)) continue;
                        var cols = ObtenerColumnas(cn, tabla);
                        if (cols.Count == 0) continue;

                        bool tieneIdentity = TieneIdentity(cn, tabla);
                        string colsList = string.Join(", ", cols.ConvertAll(c => $"[{c}]"));

                        sb.AppendLine($"-- {tabla}");
                        sb.AppendLine($"DELETE FROM [{tabla}];");
                        if (tieneIdentity)
                            sb.AppendLine($"SET IDENTITY_INSERT [{tabla}] ON;");

                        using (var cmd = new SqlCommand($"SELECT {colsList} FROM [{tabla}]", cn))
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var vals = new List<string>();
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    if (reader.IsDBNull(i)) { vals.Add("NULL"); continue; }
                                    var tipo = reader.GetFieldType(i);
                                    var val = reader.GetValue(i);
                                    if (tipo == typeof(string))
                                        vals.Add($"N'{val.ToString().Replace("'", "''")}'");
                                    else if (tipo == typeof(DateTime))
                                        vals.Add($"'{((DateTime)val):yyyy-MM-dd HH:mm:ss}'");
                                    else if (tipo == typeof(bool))
                                        vals.Add((bool)val ? "1" : "0");
                                    else if (tipo == typeof(byte[]))
                                        vals.Add("NULL");
                                    else
                                        vals.Add(val.ToString().Replace("'", "''"));
                                }
                                sb.AppendLine($"INSERT INTO [{tabla}] ({colsList}) VALUES ({string.Join(", ", vals)});");
                            }
                        }

                        if (tieneIdentity)
                            sb.AppendLine($"SET IDENTITY_INSERT [{tabla}] OFF;");
                        sb.AppendLine();
                    }
                }

                sb.AppendLine("-- Fin del respaldo");
                File.WriteAllText(rutaFinal, sb.ToString(), Encoding.UTF8);
                return (true, "Respaldo generado correctamente.", rutaFinal);
            }
            catch (Exception ex)
            {
                return (false, $"Error: {ex.Message}", null);
            }
        }

        private string ObtenerNombreBD()
        {
            try
            {
                using (var cn = Conexion.ObtenerConexion())
                { cn.Open(); return cn.Database; }
            }
            catch { return "GymDB"; }
        }

        private bool TablaExiste(SqlConnection cn, string tabla)
        {
            using (var cmd = new SqlCommand(
                "SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME=@t", cn))
            {
                cmd.Parameters.AddWithValue("@t", tabla);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        private List<string> ObtenerColumnas(SqlConnection cn, string tabla)
        {
            var cols = new List<string>();
            using (var cmd = new SqlCommand(
                "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME=@t ORDER BY ORDINAL_POSITION", cn))
            {
                cmd.Parameters.AddWithValue("@t", tabla);
                using (var r = cmd.ExecuteReader())
                    while (r.Read()) cols.Add(r.GetString(0));
            }
            return cols;
        }

        private bool TieneIdentity(SqlConnection cn, string tabla)
        {
            using (var cmd = new SqlCommand(
                "SELECT COUNT(1) FROM sys.identity_columns WHERE OBJECT_NAME(object_id)=@t", cn))
            {
                cmd.Parameters.AddWithValue("@t", tabla);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }
    }
}