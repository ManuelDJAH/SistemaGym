using System.Data;
using CapaDatos;

namespace ClaseNegocio
{
    public class CNProveedor
    {
        private static readonly ProveedorDAO dao = new ProveedorDAO();

        public static DataTable Listar() => dao.ListarProveedores();

        public static DataTable ListarCategorias() => dao.ListarCategorias();

        public static DataTable BuscarNombre(string nombre) => dao.BuscarNombre(nombre);

        public static DataTable BuscarContacto(string contacto) => dao.BuscarContacto(contacto);

        public static string Insertar(string nombre, string contacto,
            string telefono, string correo, string direccion, int idCategoria)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return "El nombre es obligatorio.";
            if (string.IsNullOrWhiteSpace(telefono))
                return "El teléfono es obligatorio.";

            return dao.Insertar(nombre, contacto, telefono, correo, direccion, idCategoria);
        }

        public static string Actualizar(int idProveedor, string nombre, string contacto,
            string telefono, string correo, string direccion, int idCategoria)
        {
            if (idProveedor <= 0) return "ID de proveedor inválido.";
            if (string.IsNullOrWhiteSpace(nombre)) return "El nombre es obligatorio.";
            if (string.IsNullOrWhiteSpace(telefono)) return "El teléfono es obligatorio.";

            return dao.Actualizar(idProveedor, nombre, contacto, telefono, correo, direccion, idCategoria);
        }

        public static string Eliminar(int idProveedor)
        {
            if (idProveedor <= 0) return "Seleccione un proveedor válido.";
            return dao.Eliminar(idProveedor);
        }
    }
}