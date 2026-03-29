using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class BitacoraDAO
    {
        public int RegistrarEntrada(string usuario)
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO BitacoraSesion (Usuario, FechaEntrada) OUTPUT INSERTED.IdBitacora VALUES (@usuario, @fecha)",
                    con);

                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@fecha", DateTime.Now);

                return (int)cmd.ExecuteScalar();
            }
        }

        public void RegistrarSalida(int idBitacora)
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                    "UPDATE BitacoraSesion SET FechaSalida = @fecha WHERE IdBitacora = @id",
                    con);

                cmd.Parameters.AddWithValue("@fecha", DateTime.Now);
                cmd.Parameters.AddWithValue("@id", idBitacora);

                cmd.ExecuteNonQuery();
            }
        }

        public DataTable MostrarBitacora()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();

                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT * FROM BitacoraSesion ORDER BY FechaEntrada DESC",
                    con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }
        public System.Data.DataTable ObtenerSesiones()
        {
            using (var con = Conexion.ObtenerConexion())
            {
                con.Open();
                string sql = @"
            SELECT IdBitacora     AS 'ID',
                   Usuario        AS 'Usuario',
                   FechaEntrada   AS 'Fecha Entrada',
                   FechaSalida    AS 'Fecha Salida'
            FROM   BitacoraSesion
            ORDER  BY FechaEntrada DESC";

                var da = new System.Data.SqlClient.SqlDataAdapter(sql, con);
                var dt = new System.Data.DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public System.Data.DataTable ObtenerCambios()
        {
            using (var con = Conexion.ObtenerConexion())
            {
                con.Open();
                string sql = @"
            SELECT c.id_cambio      AS 'ID',
                   u.usuario        AS 'Usuario',
                   c.accion         AS 'Accion',
                   c.campo          AS 'Campo',
                   c.valor_anterior AS 'Valor Anterior',
                   c.valor_nuevo    AS 'Valor Nuevo',
                   c.fecha          AS 'Fecha'
            FROM   Cambios c
            LEFT JOIN UsuariosSistema u ON c.id_usuario = u.id_usuario
            ORDER  BY c.fecha DESC";

                var da = new System.Data.SqlClient.SqlDataAdapter(sql, con);
                var dt = new System.Data.DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}