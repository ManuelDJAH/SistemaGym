using System;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;

public class UsuarioDAO
{
    public string RegistrarUsuario(string nombre, int edad, string correo,
                                   string telefono, DateTime fechaRegistro, int idMembresia)
    {
        try
        {
            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("RegistrarUsuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@edad", edad);
                cmd.Parameters.AddWithValue("@correo", correo);
                cmd.Parameters.AddWithValue("@telefono", telefono);
                cmd.Parameters.AddWithValue("@fecha_registro", fechaRegistro);
                cmd.Parameters.AddWithValue("@id_membresia", idMembresia);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
            return "Usuario registrado correctamente";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public string ActualizarUsuario(int idUsuario, string nombre, int edad,
                                    string correo, string telefono, int idMembresia)
    {
        try
        {
            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("ActualizarUsuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_usuario", idUsuario);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@edad", edad);
                cmd.Parameters.AddWithValue("@correo", correo);
                cmd.Parameters.AddWithValue("@telefono", telefono);
                cmd.Parameters.AddWithValue("@id_membresia", idMembresia);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
            return "Usuario actualizado correctamente";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public string EliminarUsuario(int idUsuario)
    {
        try
        {
            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("EliminarUsuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_usuario", idUsuario);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
            return "Usuario eliminado correctamente";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public DataTable ListarUsuarios()
    {
        DataTable dt = new DataTable();

        using (SqlConnection cn = new SqlConnection(Conexion.cadena))
        {
            SqlCommand cmd = new SqlCommand("ListarUsuarios", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }

        return dt;
    }

    public string ValidarLogin(string usuario, string clave)
    {
        string rol = null;

        using (SqlConnection conn = new SqlConnection(Conexion.cadena))
        {
            conn.Open();
            string query = "SELECT rol FROM UsuariosSistema WHERE usuario = @usuario AND clave = @clave";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@usuario", usuario);
            cmd.Parameters.AddWithValue("@clave", clave);

            object result = cmd.ExecuteScalar();

            if (result != null)
            {
                rol = result.ToString();
            }
        }

        return rol;
    }
    public DataTable ObtenerBitacora()
    {
        DataTable dt = new DataTable();

        using (SqlConnection conn = new SqlConnection(Conexion.cadena))
        {
            conn.Open();
            string query = "SELECT * FROM Cambios ORDER BY fecha DESC";

            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            da.Fill(dt);
        }

        return dt;
    }

}
