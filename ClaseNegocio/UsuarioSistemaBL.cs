using System.Data;
using CapaDatos;

namespace ClaseNegocio
{
    public class UsuarioSistemaBL
    {
        private readonly UsuarioSistemaDAO _dao = new UsuarioSistemaDAO();

        public DataTable Listar() => _dao.Listar();

        public (bool ok, string mensaje) Crear(string usuario, string clave,
                                                string nombre, string rol)
        {
            if (string.IsNullOrWhiteSpace(usuario))
                return (false, "El nombre de usuario es obligatorio.");
            if (string.IsNullOrWhiteSpace(clave) || clave.Length < 4)
                return (false, "La contraseña debe tener al menos 4 caracteres.");
            if (string.IsNullOrWhiteSpace(nombre))
                return (false, "El nombre completo es obligatorio.");

            return _dao.Crear(usuario.Trim(), clave, nombre.Trim(), rol);
        }

        public (bool ok, string mensaje) Actualizar(int idUsuario, string nombre,
                                                     string rol, string nuevaClave = null)
        {
            if (idUsuario <= 0)
                return (false, "Usuario inválido.");
            if (string.IsNullOrWhiteSpace(nombre))
                return (false, "El nombre completo es obligatorio.");
            if (!string.IsNullOrWhiteSpace(nuevaClave) && nuevaClave.Length < 4)
                return (false, "La nueva contraseña debe tener al menos 4 caracteres.");

            return _dao.Actualizar(idUsuario, nombre.Trim(), rol, nuevaClave);
        }

        public (bool ok, string mensaje) Eliminar(int idUsuario)
        {
            if (idUsuario <= 0)
                return (false, "Usuario inválido.");
            return _dao.Eliminar(idUsuario);
        }
    }
}