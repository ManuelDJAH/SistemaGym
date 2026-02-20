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
    }
}