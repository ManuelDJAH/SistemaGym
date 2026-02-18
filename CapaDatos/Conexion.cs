using System.Data.SqlClient;

namespace CapaDatos
{
    public class Conexion
    {
        public static string cadena =
            "Server=LAPTOP-36HHFTU4\\SQLEXPRESS;Database=GymDB;Trusted_Connection=True;";

        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadena);
        }
    }
}
