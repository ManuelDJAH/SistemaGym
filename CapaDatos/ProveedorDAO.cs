using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class ProveedorDAO
    {
        private const string SELECT_BASE = @"
            SELECT p.idproveedor, p.nombre, p.contacto, p.rfc,
                   p.telefono,   p.correo,  p.direccion,
                   p.estado,     p.idcategoria,
                   c.nombre AS categoria
            FROM   Proveedores p
            LEFT JOIN CategoriasProveedor c ON p.idcategoria = c.idcategoria";

        // ── LISTAR TODOS ─────────────────────────────────────────────
        public DataTable ListarProveedores()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter(SELECT_BASE, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // ── LISTAR CATEGORÍAS ────────────────────────────────────────
        public DataTable ListarCategorias()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT idcategoria, nombre FROM CategoriasProveedor ORDER BY nombre", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // ── BUSCAR POR NOMBRE ────────────────────────────────────────
        public DataTable BuscarNombre(string nombre)
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                string sql = SELECT_BASE + " WHERE p.nombre LIKE @nombre";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.SelectCommand.Parameters.AddWithValue("@nombre", "%" + nombre + "%");
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // ── BUSCAR POR RFC ───────────────────────────────────────────
        public DataTable BuscarRfc(string rfc)
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                string sql = SELECT_BASE + " WHERE p.rfc LIKE @rfc";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.SelectCommand.Parameters.AddWithValue("@rfc", "%" + rfc + "%");
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // ── INSERTAR ─────────────────────────────────────────────────
        public string Insertar(string nombre, string contacto, string rfc,
            string telefono, string correo, string direccion,
            string estado, int idCategoria)
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    string sql = @"INSERT INTO Proveedores
                                   (nombre, contacto, rfc, telefono, correo,
                                    direccion, estado, idcategoria)
                                   VALUES
                                   (@nombre, @contacto, @rfc, @telefono, @correo,
                                    @direccion, @estado, @idcategoria)";

                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@nombre",      nombre);
                    cmd.Parameters.AddWithValue("@contacto",    contacto);
                    cmd.Parameters.AddWithValue("@rfc",         rfc);
                    cmd.Parameters.AddWithValue("@telefono",    telefono);
                    cmd.Parameters.AddWithValue("@correo",      correo);
                    cmd.Parameters.AddWithValue("@direccion",   direccion);
                    cmd.Parameters.AddWithValue("@estado",      estado);
                    cmd.Parameters.AddWithValue("@idcategoria", idCategoria);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                return "Proveedor registrado correctamente.";
            }
            catch (SqlException ex)
            {
                return "Error al registrar: " + ex.Message;
            }
        }

        // ── ACTUALIZAR ───────────────────────────────────────────────
        public string Actualizar(int idProveedor, string nombre, string contacto,
            string rfc, string telefono, string correo, string direccion,
            string estado, int idCategoria)
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    string sql = @"UPDATE Proveedores SET
                                   nombre      = @nombre,
                                   contacto    = @contacto,
                                   rfc         = @rfc,
                                   telefono    = @telefono,
                                   correo      = @correo,
                                   direccion   = @direccion,
                                   estado      = @estado,
                                   idcategoria = @idcategoria
                                   WHERE idproveedor = @idproveedor";

                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@idproveedor", idProveedor);
                    cmd.Parameters.AddWithValue("@nombre",      nombre);
                    cmd.Parameters.AddWithValue("@contacto",    contacto);
                    cmd.Parameters.AddWithValue("@rfc",         rfc);
                    cmd.Parameters.AddWithValue("@telefono",    telefono);
                    cmd.Parameters.AddWithValue("@correo",      correo);
                    cmd.Parameters.AddWithValue("@direccion",   direccion);
                    cmd.Parameters.AddWithValue("@estado",      estado);
                    cmd.Parameters.AddWithValue("@idcategoria", idCategoria);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                return "Proveedor actualizado correctamente.";
            }
            catch (SqlException ex)
            {
                return "Error al actualizar: " + ex.Message;
            }
        }

        // ── ELIMINAR ─────────────────────────────────────────────────
        public string Eliminar(int idProveedor)
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand(
                        "DELETE FROM Proveedores WHERE idproveedor = @id", con);
                    cmd.Parameters.AddWithValue("@id", idProveedor);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                return "Proveedor eliminado correctamente.";
            }
            catch (SqlException ex)
            {
                return "Error al eliminar: " + ex.Message;
            }
        }
    }
}
