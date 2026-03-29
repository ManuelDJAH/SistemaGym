using System.Data.SqlClient;

namespace CapaDatos
{

    public static class Conexion
    {
        // ── Cadena fija para Windows Forms ───────────────────────────
        private static string _connectionString =
            @"Server=localhost\SQLEXPRESS;Database=GymDB;Trusted_Connection=True;";

        public static void SetConnectionString(string connectionString)
        {
            if (!string.IsNullOrWhiteSpace(connectionString))
                _connectionString = connectionString;
        }

        public static string cadena => _connectionString;

        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(_connectionString);
        }
    }
}