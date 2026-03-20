using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class CNProveedor
    {
        private static readonly ProveedorDAO dao = new ProveedorDAO();

        // ── LISTAR TODOS ─────────────────────────────────────────────
        public static DataTable Listar()
        {
            return dao.ListarProveedores();
        }

        // ── LISTAR CATEGORÍAS ────────────────────────────────────────
        public static DataTable ListarCategorias()
        {
            return dao.ListarCategorias();
        }

        // ── BUSCAR POR NOMBRE ────────────────────────────────────────
        public static DataTable BuscarNombre(string nombre)
        {
            return dao.BuscarNombre(nombre);
        }

        // ── BUSCAR POR RFC ───────────────────────────────────────────
        public static DataTable BuscarRfc(string rfc)
        {
            return dao.BuscarRfc(rfc);
        }

        // ── INSERTAR ─────────────────────────────────────────────────
        public static string Insertar(string nombre, string contacto, string rfc,
            string telefono, string correo, string direccion,
            string estado, int idCategoria)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return "El nombre es obligatorio.";
            if (string.IsNullOrWhiteSpace(telefono))
                return "El teléfono es obligatorio.";

            return dao.Insertar(nombre, contacto, rfc,
                                telefono, correo, direccion,
                                estado, idCategoria);
        }

        // ── ACTUALIZAR ───────────────────────────────────────────────
        public static string Actualizar(int idProveedor, string nombre, string contacto,
            string rfc, string telefono, string correo, string direccion,
            string estado, int idCategoria)
        {
            if (idProveedor <= 0)   return "ID de proveedor inválido.";
            if (string.IsNullOrWhiteSpace(nombre)) return "El nombre es obligatorio.";

            return dao.Actualizar(idProveedor, nombre, contacto, rfc,
                                  telefono, correo, direccion,
                                  estado, idCategoria);
        }

        // ── ELIMINAR ─────────────────────────────────────────────────
        public static string Eliminar(int idProveedor)
        {
            if (idProveedor <= 0) return "Seleccione un proveedor válido.";
            return dao.Eliminar(idProveedor);
        }
    }
}
