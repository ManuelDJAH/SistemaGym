using System;
using System.Data;

public class UsuariosBL
{
    UsuarioDAO dao = new UsuarioDAO();

    public string RegistrarUsuario(string nombre, int edad, string correo,
                                   string telefono, DateTime fechaRegistro, int idMembresia)
    {
        if (string.IsNullOrWhiteSpace(nombre))
            return "El nombre es obligatorio";

        if (edad <= 0)
            return "La edad no es válida";

        return dao.RegistrarUsuario(nombre, edad, correo, telefono, fechaRegistro, idMembresia);
    }
    public string ActualizarUsuario(int idUsuario, string nombre, int edad,
                                    string correo, string telefono, int idMembresia)
    {
        if (idUsuario <= 0)
            return "Usuario inválido";

        if (string.IsNullOrWhiteSpace(nombre))
            return "El nombre es obligatorio";

        if (edad <= 0)
            return "La edad no es válida";

        return dao.ActualizarUsuario(idUsuario, nombre, edad, correo, telefono, idMembresia);
    }
    public string EliminarUsuario(int idUsuario)
    {
        if (idUsuario <= 0)
            return "Seleccione un usuario válido";

        return dao.EliminarUsuario(idUsuario);
    }

    public DataTable ListarUsuarios()
    {
        return dao.ListarUsuarios();
    }

    public string Login(string usuario, string clave)
    {
        UsuarioDAO dao = new UsuarioDAO();
        return dao.ValidarLogin(usuario, clave);
    }

}
