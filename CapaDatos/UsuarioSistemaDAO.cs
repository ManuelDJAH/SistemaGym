using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class UsuarioSistemaDAO
    {
        // ── Listar ───────────────────────────────────────────────────
        public DataTable Listar()
        {
            DataTable dt = new DataTable();
            using (var con = Conexion.ObtenerConexion())
            {
                con.Open();
                var cmd = new SqlCommand("sp_ListarUsuariosSistema", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                new SqlDataAdapter(cmd).Fill(dt);
            }
            return dt;
        }

        // ── Crear ────────────────────────────────────────────────────
        public (bool ok, string mensaje) Crear(string usuario, string clave,
                                                string nombre, string rol)
        {
            try
            {
                using (var con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    var cmd = new SqlCommand("sp_CrearUsuarioSistema", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@clave", clave);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@rol", rol);
                    cmd.ExecuteNonQuery();
                }
                return (true, "Usuario creado correctamente.");
            }
            catch (SqlException ex)
            {
                return (false, ex.Message);
            }
        }

        // ── Actualizar ───────────────────────────────────────────────
        public (bool ok, string mensaje) Actualizar(int idUsuario, string nombre,
                                                     string rol, string nuevaClave = null)
        {
            try
            {
                using (var con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    var cmd = new SqlCommand("sp_ActualizarUsuarioSistema", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@id_usuario", idUsuario);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@rol", rol);
                    cmd.Parameters.AddWithValue("@clave",
                        string.IsNullOrWhiteSpace(nuevaClave)
                            ? (object)DBNull.Value
                            : nuevaClave);
                    cmd.ExecuteNonQuery();
                }
                return (true, "Usuario actualizado correctamente.");
            }
            catch (SqlException ex)
            {
                return (false, ex.Message);
            }
        }

        // ── Eliminar ─────────────────────────────────────────────────
        public (bool ok, string mensaje) Eliminar(int idUsuario)
        {
            try
            {
                using (var con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    var cmd = new SqlCommand("sp_EliminarUsuarioSistema", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@id_usuario", idUsuario);
                    cmd.ExecuteNonQuery();
                }
                return (true, "Usuario eliminado correctamente.");
            }
            catch (SqlException ex)
            {
                return (false, ex.Message);
            }
        }
    }
}