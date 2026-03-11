using System.Data.SqlClient;

namespace CapaDatos
{
    public class Conexion
    {
        public static string cadena =
            "Server=localhost\\SQLEXPRESS;Database=GymDB;Trusted_Connection=True;";

        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadena);
        }
    }
}
