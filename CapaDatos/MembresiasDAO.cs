using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class MembresiaDAO
    {
        public DataTable ListarMembresias()
        {
            var dt = new DataTable();
            using (var cn = Conexion.ObtenerConexion())
            {
                var cmd = new SqlCommand("SELECT id_membresia, nombre AS nombre_membresia, duracion_meses, costo FROM Membresias ORDER BY duracion_meses", cn);
                var da = new SqlDataAdapter(cmd);
                cn.Open();
                da.Fill(dt);
            }
            return dt;
        }
    }
}