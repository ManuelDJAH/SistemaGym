using System.Collections.Generic;
using System.Data;
using CapaDatos;

namespace ClaseNegocio
{
    public class RestockBL
    {
        private readonly RestockDAO dao = new RestockDAO();

        // ── ÓRDENES ──────────────────────────────────────────────────

        public List<OrdenRestock> ListarOrdenes(string filtroEstado = null)
            => dao.ListarOrdenes(filtroEstado);

        public (bool ok, string msg) GenerarOrden(int idProducto, int idProveedor,
            int cantidad, int stockActual, int stockMinimo, string notas)
        {
            if (cantidad <= 0)
                return (false, "La cantidad debe ser mayor a 0.");
            if (idProveedor <= 0)
                return (false, "Seleccione un proveedor válido.");

            return dao.GenerarOrden(idProducto, idProveedor,
                                    cantidad, stockActual, stockMinimo, notas);
        }

        public (bool ok, string msg) ActualizarCantidad(int idOrden, int nuevaCantidad)
        {
            if (nuevaCantidad <= 0) return (false, "La cantidad debe ser mayor a 0.");
            return dao.ActualizarCantidad(idOrden, nuevaCantidad);
        }

        public (bool ok, string msg) MarcarEnviada(int idOrden)
            => dao.CambiarEstado(idOrden, "ENVIADA", null);

        public (bool ok, string msg) MarcarRecibida(int idOrden)
            => dao.CambiarEstado(idOrden, "RECIBIDA", null);

        public (bool ok, string msg) CancelarOrden(int idOrden, string motivo)
            => dao.CambiarEstado(idOrden, "CANCELADA", motivo);

        // ── PRODUCTO ↔ PROVEEDOR ─────────────────────────────────────

        public (bool ok, string msg) AsignarProveedor(int idProducto, int idProveedor)
        {
            if (idProducto <= 0)  return (false, "Seleccione un producto.");
            if (idProveedor <= 0) return (false, "Seleccione un proveedor.");
            return dao.AsignarProveedor(idProducto, idProveedor);
        }

        public DataTable ObtenerProveedorDeProducto(int idProducto)
            => dao.ObtenerProveedorDeProducto(idProducto);
    }
}
