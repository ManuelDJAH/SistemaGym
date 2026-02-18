using CapaDatos;
using System.Data;
using System.Data.SqlClient;

public class MembresiaDAO
{
    public DataTable ListarMembresias()
    {
        DataTable dt = new DataTable();

        using (SqlConnection cn = new SqlConnection(Conexion.cadena))
        {
            SqlCommand cmd = new SqlCommand("ListarMembresias", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }

        return dt;
    }
}

