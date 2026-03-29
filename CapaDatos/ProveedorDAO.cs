using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class ProveedorDAO
    {
        // Columnas reales: id_proveedor, nombre, contacto, correo,
        //                  telefono, direccion, id_categoria, fecha_registro
        private const string SELECT_BASE = @"
            SELECT p.id_proveedor, p.nombre, p.contacto,
                   p.telefono,    p.correo,  p.direccion,
                   p.id_categoria,
                   p.fecha_registro,
                   c.nombre AS categoria
            FROM   Proveedores p
            LEFT JOIN CategoriasProveedor c ON p.id_categoria = c.id_categoria";

        // ── LISTAR TODOS ─────────────────────────────────────────────
        public DataTable ListarProveedores()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();
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
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT id_categoria, nombre FROM CategoriasProveedor ORDER BY nombre", con);
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
                con.Open();
                string sql = SELECT_BASE + " WHERE p.nombre LIKE @nombre";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.SelectCommand.Parameters.AddWithValue("@nombre", "%" + nombre + "%");
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // ── BUSCAR POR CONTACTO (reemplaza BuscarRfc) ────────────────
        public DataTable BuscarContacto(string contacto)
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();
                string sql = SELECT_BASE + " WHERE p.contacto LIKE @contacto";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.SelectCommand.Parameters.AddWithValue("@contacto", "%" + contacto + "%");
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // ── INSERTAR ─────────────────────────────────────────────────
        public string Insertar(string nombre, string contacto,
            string telefono, string correo, string direccion, int idCategoria)
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    string sql = @"INSERT INTO Proveedores
                                   (nombre, contacto, telefono, correo, direccion, id_categoria)
                                   VALUES
                                   (@nombre, @contacto, @telefono, @correo, @direccion, @idcategoria)";

                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@contacto", contacto);
                    cmd.Parameters.AddWithValue("@telefono", telefono);
                    cmd.Parameters.AddWithValue("@correo", correo);
                    cmd.Parameters.AddWithValue("@direccion", direccion);
                    cmd.Parameters.AddWithValue("@idcategoria", idCategoria);

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
            string telefono, string correo, string direccion, int idCategoria)
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    string sql = @"UPDATE Proveedores SET
                                   nombre       = @nombre,
                                   contacto     = @contacto,
                                   telefono     = @telefono,
                                   correo       = @correo,
                                   direccion    = @direccion,
                                   id_categoria = @idcategoria
                                   WHERE id_proveedor = @idproveedor";

                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@idproveedor", idProveedor);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@contacto", contacto);
                    cmd.Parameters.AddWithValue("@telefono", telefono);
                    cmd.Parameters.AddWithValue("@correo", correo);
                    cmd.Parameters.AddWithValue("@direccion", direccion);
                    cmd.Parameters.AddWithValue("@idcategoria", idCategoria);

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
                    con.Open();
                    SqlCommand cmd = new SqlCommand(
                        "DELETE FROM Proveedores WHERE id_proveedor = @id", con);
                    cmd.Parameters.AddWithValue("@id", idProveedor);
                    cmd.ExecuteNonQuery();
                }
                return "Proveedor eliminado correctamente.";
            }
            catch (SqlException ex)
            {
                return "Error al eliminar: " + ex.Message;
            }
        }

        // ── OBTENER POR ID ───────────────────────────────────────────
        public DataTable ObtenerPorId(int idProveedor)
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();
                string sql = SELECT_BASE + " WHERE p.id_proveedor = @id";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.SelectCommand.Parameters.AddWithValue("@id", idProveedor);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}