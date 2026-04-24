using CapaDatos;
using CapaWeb.Filters;
using CapaWeb.Helpers;
using ClaseNegocio;
using Microsoft.AspNetCore.Mvc;

namespace CapaWeb.Controllers
{
    [AuthRequired]
    public class ProveedoresController : Controller
    {
        // ════════════════════════════════════════════════════════════
        //  PROVEEDORES
        // ════════════════════════════════════════════════════════════
        public IActionResult Index(string buscar, string criterio)
        {
            System.Data.DataTable dt;

            if (!string.IsNullOrWhiteSpace(buscar))
                dt = criterio == "contacto"
                    ? CNProveedor.BuscarContacto(buscar)
                    : CNProveedor.BuscarNombre(buscar);
            else
                dt = CNProveedor.Listar();

            ViewBag.Proveedores = dt;
            ViewBag.Categorias = CNProveedor.ListarCategorias();
            ViewBag.Buscar = buscar;
            ViewBag.Criterio = criterio ?? "nombre";
            ViewData["Title"] = "Proveedores";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(string nombre, string contacto, string telefono,
                                    string correo, string direccion, int idCategoria)
        {
            string msg = CNProveedor.Insertar(nombre, contacto, telefono, correo, direccion, idCategoria);
            bool ok = msg.Contains("correctamente");
            return Json(new { ok, mensaje = msg });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Actualizar(int idProveedor, string nombre, string contacto,
                                         string telefono, string correo, string direccion,
                                         int idCategoria)
        {
            string msg = CNProveedor.Actualizar(idProveedor, nombre, contacto, telefono,
                                                 correo, direccion, idCategoria);
            bool ok = msg.Contains("correctamente");
            return Json(new { ok, mensaje = msg });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(int idProveedor)
        {
            string msg = CNProveedor.Eliminar(idProveedor);
            bool ok = msg.Contains("correctamente");
            return Json(new { ok, mensaje = msg });
        }

        // ════════════════════════════════════════════════════════════
        //  ÓRDENES DE RESTOCK
        // ════════════════════════════════════════════════════════════
        public IActionResult Restock(string estado)
        {
            var bl = new RestockBL();
            var ordenes = bl.ListarOrdenes(string.IsNullOrEmpty(estado) ? null : estado);

            ViewBag.Ordenes = ordenes;
            ViewBag.Estado = estado;
            ViewData["Title"] = "Órdenes de Restock";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MarcarEnviada(int idOrden, int cantidad)
        {
            var bl = new RestockBL();
            if (cantidad > 0) bl.ActualizarCantidad(idOrden, cantidad);
            var (ok, msg) = bl.MarcarEnviada(idOrden);
            return Json(new { ok, mensaje = msg });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MarcarRecibida(int idOrden)
        {
            var (ok, msg) = new RestockBL().MarcarRecibida(idOrden);
            return Json(new { ok, mensaje = msg });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CancelarOrden(int idOrden, string motivo)
        {
            var (ok, msg) = new RestockBL().CancelarOrden(idOrden, motivo);
            return Json(new { ok, mensaje = msg });
        }
    
    [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ProductosDeProveedor(int idProveedor)
        {
            try
            {
                using (var cn = CapaDatos.Conexion.ObtenerConexion())
                {
                    cn.Open();
                    var cmd = new System.Data.SqlClient.SqlCommand(@"
                SELECT p.ProductoID, p.Nombre, p.Precio,
                       p.StockActual, p.StockMinimo,
                       c.Nombre AS Categoria
                FROM   Inv_Productos p
                JOIN   Inv_Categorias c ON p.CategoriaID = c.CategoriaID
                WHERE  p.id_proveedor = @id AND p.Activo = 1
                ORDER  BY p.Nombre", cn);

                    cmd.Parameters.AddWithValue("@id", idProveedor);

                    var productos = new System.Collections.Generic.List<object>();
                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            productos.Add(new
                            {
                                productoID = r["ProductoID"],
                                nombre = r["Nombre"].ToString(),
                                precio = string.Format("{0:N2}", r["Precio"]),
                                stockActual = (int)r["StockActual"],
                                stockMinimo = (int)r["StockMinimo"],
                                categoria = r["Categoria"].ToString()
                            });
                        }
                    }
                    return Json(new { ok = true, productos });
                }
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, productos = new object[0], mensaje = ex.Message });
            }
        }

    }
}
