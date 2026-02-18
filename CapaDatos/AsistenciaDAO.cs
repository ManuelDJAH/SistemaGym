using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class AsistenciaDAO
    {
        public string RegistrarAsistencia(int idUsuario)
        {
            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("RegistrarAsistencia", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }

                return "Asistencia registrada correctamente.";
            }
            catch (SqlException ex)
            {
                return ex.Message;
            }

        }
    }
}
