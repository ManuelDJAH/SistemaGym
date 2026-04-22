using CapaDatos;
using System;
using System.Data;

namespace ClaseNegocio
{
    public class UsuariosBL
    {
        UsuarioDAO dao = new UsuarioDAO();

        public string RegistrarUsuario(string nombre, int edad, string correo,
                                       string telefono, DateTime fechaRegistro, int idMembresia)
        {
            if (string.IsNullOrWhiteSpace(nombre)) return "El nombre es obligatorio.";
            if (edad <= 0) return "La edad no es válida.";
            if (idMembresia <= 0) return "Selecciona una membresía.";
            return dao.RegistrarUsuario(nombre, edad, correo, telefono, fechaRegistro, idMembresia);
        }

        public string ActualizarUsuario(int idUsuario, string nombre, int edad,
                                        string correo, string telefono, int idMembresia)
        {
            if (idUsuario <= 0) return "Usuario inválido.";
            if (string.IsNullOrWhiteSpace(nombre)) return "El nombre es obligatorio.";
            if (edad <= 0) return "La edad no es válida.";
            if (idMembresia <= 0) return "Selecciona una membresía.";
            return dao.ActualizarUsuario(idUsuario, nombre, edad, correo, telefono, idMembresia);
        }

        public string EliminarUsuario(int idUsuario)
        {
            if (idUsuario <= 0) return "Seleccione un usuario válido.";
            return dao.EliminarUsuario(idUsuario);
        }

        public DataTable ListarUsuarios() => dao.ListarUsuarios();
        public DataTable BuscarPorNombre(string texto) => dao.BuscarPorNombre(texto);
        public DataTable ListarMembresias() => dao.ListarMembresias();

        public string RenovarMembresia(int idUsuario, int idMembresia)
        {
            if (idUsuario <= 0) return "Usuario inválido.";
            if (idMembresia <= 0) return "Selecciona una membresía.";
            return dao.RenovarMembresia(idUsuario, idMembresia);
        }

        public string Login(string usuario, string clave)
        {
            return new UsuarioDAO().ValidarLogin(usuario, clave);
        }

        public DataTable MostrarBitacora()
        {
            return new UsuarioDAO().ObtenerBitacora();
        }

        public int ObtenerIdPorUsuario(string usuario)
        {
            return new UsuarioDAO().ObtenerIdPorUsuario(usuario);
        }
    }
}