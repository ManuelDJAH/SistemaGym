using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class UsuarioDAO
    {
        // ── LISTAR TODOS ─────────────────────────────────────────────
        public DataTable ListarUsuarios()
        {
            using (var cn = Conexion.ObtenerConexion())
            {
                var cmd = new SqlCommand(@"
                    SELECT u.id_usuario,
                           u.nombre,
                           u.edad,
                           u.correo,
                           u.telefono,
                           u.fecha_registro,
                           u.fecha_vencimiento,
                           u.id_membresia,
                           m.nombre        AS nombre_membresia,
                           m.duracion_meses,
                           CASE WHEN u.fecha_vencimiento < CAST(GETDATE() AS DATE)
                                THEN 'VENCIDA' ELSE 'ACTIVA' END AS estado_membresia
                    FROM Usuarios u
                    LEFT JOIN Membresias m ON u.id_membresia = m.id_membresia
                    ORDER BY u.nombre", cn);

                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                cn.Open();
                da.Fill(dt);
                return dt;
            }
        }

        // ── BUSCAR POR NOMBRE ────────────────────────────────────────
        public DataTable BuscarPorNombre(string texto)
        {
            using (var cn = Conexion.ObtenerConexion())
            {
                var cmd = new SqlCommand(@"
                    SELECT u.id_usuario,
                           u.nombre,
                           u.edad,
                           u.correo,
                           u.telefono,
                           u.fecha_registro,
                           u.fecha_vencimiento,
                           u.id_membresia,
                           m.nombre        AS nombre_membresia,
                           m.duracion_meses,
                           CASE WHEN u.fecha_vencimiento < CAST(GETDATE() AS DATE)
                                THEN 'VENCIDA' ELSE 'ACTIVA' END AS estado_membresia
                    FROM Usuarios u
                    LEFT JOIN Membresias m ON u.id_membresia = m.id_membresia
                    WHERE u.nombre LIKE @txt
                    ORDER BY u.nombre", cn);

                cmd.Parameters.AddWithValue("@txt", $"%{texto}%");
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                cn.Open();
                da.Fill(dt);
                return dt;
            }
        }

        // ── REGISTRAR (usa SP que calcula vencimiento) ───────────────
        public string RegistrarUsuario(string nombre, int edad, string correo,
                                       string telefono, DateTime fechaRegistro, int idMembresia)
        {
            try
            {
                using (var cn = Conexion.ObtenerConexion())
                {
                    var cmd = new SqlCommand("sp_RegistrarUsuario", cn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@edad", edad);
                    cmd.Parameters.AddWithValue("@correo", correo);
                    cmd.Parameters.AddWithValue("@telefono", telefono);
                    cmd.Parameters.AddWithValue("@fecha_registro", fechaRegistro.Date);
                    cmd.Parameters.AddWithValue("@id_membresia", idMembresia);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                return "Usuario registrado correctamente.";
            }
            catch (SqlException ex) { return ex.Message; }
        }

        // ── ACTUALIZAR (usa SP que recalcula vencimiento) ────────────
        public string ActualizarUsuario(int idUsuario, string nombre, int edad,
                                        string correo, string telefono, int idMembresia)
        {
            try
            {
                using (var cn = Conexion.ObtenerConexion())
                {
                    var cmd = new SqlCommand("sp_ActualizarUsuario", cn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@id_usuario", idUsuario);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@edad", edad);
                    cmd.Parameters.AddWithValue("@correo", correo);
                    cmd.Parameters.AddWithValue("@telefono", telefono);
                    cmd.Parameters.AddWithValue("@id_membresia", idMembresia);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                return "Usuario actualizado correctamente.";
            }
            catch (SqlException ex) { return ex.Message; }
        }

        // ── ELIMINAR ─────────────────────────────────────────────────
        public string EliminarUsuario(int idUsuario)
        {
            try
            {
                using (var cn = Conexion.ObtenerConexion())
                {
                    var cmd = new SqlCommand(
                        "DELETE FROM Usuarios WHERE id_usuario = @id", cn);
                    cmd.Parameters.AddWithValue("@id", idUsuario);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                return "Usuario eliminado correctamente.";
            }
            catch (SqlException ex) { return ex.Message; }
        }

        // ── RENOVAR MEMBRESÍA (desde hoy) ───────────────────────────
        public string RenovarMembresia(int idUsuario, int idMembresia)
        {
            try
            {
                using (var cn = Conexion.ObtenerConexion())
                {
                    var cmd = new SqlCommand("sp_RenovarMembresia", cn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@id_usuario", idUsuario);
                    cmd.Parameters.AddWithValue("@id_membresia", idMembresia);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                return "Membresía renovada correctamente.";
            }
            catch (SqlException ex) { return ex.Message; }
        }

        // ── LISTAR MEMBRESIAS (para combo) ───────────────────────────
        public DataTable ListarMembresias()
        {
            using (var cn = Conexion.ObtenerConexion())
            {
                var cmd = new SqlCommand(
                    "SELECT id_membresia, nombre AS nombre_membresia, duracion_meses, costo FROM Membresias ORDER BY duracion_meses", cn);
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                cn.Open();
                da.Fill(dt);
                return dt;
            }
        }

        // ── LOGIN ────────────────────────────────────────────────────
        public string ValidarLogin(string usuario, string clave)
        {
            try
            {
                using (var cn = Conexion.ObtenerConexion())
                {
                    var cmd = new SqlCommand(
                        "SELECT rol FROM UsuariosSistema WHERE usuario = @u AND clave = @c", cn);
                    cmd.Parameters.AddWithValue("@u", usuario);
                    cmd.Parameters.AddWithValue("@c", clave);
                    cn.Open();
                    return cmd.ExecuteScalar()?.ToString();
                }
            }
            catch { return null; }
        }

        // ── OBTENER ID POR USUARIO ───────────────────────────────────
        public int ObtenerIdPorUsuario(string usuario)
        {
            using (var cn = Conexion.ObtenerConexion())
            {
                var cmd = new SqlCommand(
                    "SELECT id_usuario FROM UsuariosSistema WHERE usuario = @u", cn);
                cmd.Parameters.AddWithValue("@u", usuario);
                cn.Open();
                return (int)(cmd.ExecuteScalar() ?? 0);
            }
        }

        // ── OBTENER BITÁCORA ─────────────────────────────────────────
        public DataTable ObtenerBitacora()
        {
            using (var cn = Conexion.ObtenerConexion())
            {
                var cmd = new SqlCommand("SELECT * FROM BitacoraSesion ORDER BY FechaEntrada DESC", cn);
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                cn.Open();
                da.Fill(dt);
                return dt;
            }
        }
    }
}