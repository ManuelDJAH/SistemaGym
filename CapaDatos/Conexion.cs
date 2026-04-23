using System.Data.SqlClient;

namespace CapaDatos
{
    public class Conexion
    {
        // Cadena local para Windows Forms (sin cambios)
        private static readonly string _cadenaLocal =
            "Server=localhost\\SQLEXPRESS;Database=GymDB;Trusted_Connection=True;TrustServerCertificate=True;";

        // Cadena inyectada desde ASP.NET Core (appsettings)
        private static string _cadenaWeb = null;

        /// <summary>
        /// Llamado desde Program.cs al iniciar la app web.
        /// </summary>
        public static void SetCadenaWeb(string cadena)
        {
            _cadenaWeb = cadena;
        }

        /// <summary>
        /// Devuelve la conexión correcta según el contexto.
        /// </summary>
        public static SqlConnection ObtenerConexion()
        {
            string cadena = !string.IsNullOrEmpty(_cadenaWeb)
                ? _cadenaWeb
                : _cadenaLocal;

            return new SqlConnection(cadena);
        }
    }
}