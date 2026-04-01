using CapaDatos;
using CapaWeb.Filters;
using CapaWeb.Helpers;
using ClaseNegocio;
using Microsoft.AspNetCore.Mvc;

namespace CapaWeb.Controllers
{
    [AuthRequired]
    public class InventarioController : Controller
    {
        private readonly InventarioBL _bl = new InventarioBL();

        // ════════════════════════════════════════════════════════════
        //  INDEX — Catálogo de Productos
        // ════════════════════════════════════════════════════════════
        public IActionResult Index(int? categoriaID)
        {
            var productos = _bl.ObtenerProductos(categoriaID);
            var categorias = _bl.ObtenerCategoriasProducto();

            ViewBag.Productos = productos;
            ViewBag.Categorias = categorias;
            ViewBag.CategoriaActual = categoriaID;
            ViewBag.EsAdmin = SesionWeb.EsAdmin(HttpContext.Session);
            ViewData["Title"] = "Inventario — Productos";

            return View();
        }

        // ════════════════════════════════════════════════════════════
        //  MOVIMIENTOS
        // ════════════════════════════════════════════════════════════
        public IActionResult Movimientos()
        {
            ViewData["Title"] = "Registrar Movimiento";
            ViewBag.EsAdmin = SesionWeb.EsAdmin(HttpContext.Session);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BuscarProducto(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                return Json(new { ok = false, mensaje = "Ingresa un código." });

            var producto = _bl.BuscarPorCodigoBarras(codigo.Trim());
            if (producto == null)
                return Json(new { ok = false, mensaje = "Producto no encontrado." });

            return Json(new
            {
                ok = true,
                productoID = producto.ProductoID,
                nombre = producto.Nombre,
                categoria = producto.CategoriaNombre,
                stockActual = producto.StockActual,
                stockMinimo = producto.StockMinimo,
                precio = producto.Precio,
                estadoAlerta = producto.EstadoAlerta
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegistrarMovimiento(int productoID, string tipo,
                                                  int cantidad, string motivo, bool esVenta)
        {
            int usuarioID = SesionWeb.GetIdUsuario(HttpContext.Session);

            try
            {
                bool ok; string msg;

                if (tipo == "E")
                    (ok, msg) = _bl.RegistrarEntrada(productoID, cantidad, motivo, usuarioID);
                else if (esVenta)
                    (ok, msg) = _bl.RegistrarVenta(productoID, cantidad, motivo, usuarioID);
                else
                    (ok, msg) = _bl.RegistrarSalida(productoID, cantidad, motivo, usuarioID);

                return Json(new { ok, mensaje = msg });
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, mensaje = ex.Message });
            }
        }

        // ════════════════════════════════════════════════════════════
        //  HISTORIAL
        // ════════════════════════════════════════════════════════════
        public IActionResult Historial(int? productoID, DateTime? desde, DateTime? hasta)
        {
            var historial = _bl.ObtenerHistorial(productoID, desde, hasta);
            var productos = _bl.ObtenerProductos();

            ViewBag.Historial = historial;
            ViewBag.Productos = productos;
            ViewBag.ProductoActual = productoID;
            ViewBag.Desde = desde?.ToString("yyyy-MM-dd") ?? DateTime.Today.AddMonths(-1).ToString("yyyy-MM-dd");
            ViewBag.Hasta = hasta?.ToString("yyyy-MM-dd") ?? DateTime.Today.ToString("yyyy-MM-dd");
            ViewData["Title"] = "Historial de Movimientos";
            return View();
        }

        // ════════════════════════════════════════════════════════════
        //  ALERTAS
        // ════════════════════════════════════════════════════════════
        public IActionResult Alertas()
        {
            var alertas = _bl.ObtenerAlertasPendientes();
            ViewBag.Alertas = alertas;
            ViewData["Title"] = "Alertas de Inventario";
            ViewBag.EsAdmin = SesionWeb.EsAdmin(HttpContext.Session);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AtenderAlerta(int alertaID)
        {
            var (ok, msg) = _bl.AtenderAlerta(alertaID);
            return Json(new { ok, mensaje = msg });
        }

        // ════════════════════════════════════════════════════════════
        //  DEFECTOS
        // ════════════════════════════════════════════════════════════
        public IActionResult Defectos(int? productoID)
        {
            var defectos = _bl.ObtenerDefectos(productoID);
            var productos = _bl.ObtenerProductos();

            ViewBag.Defectos = defectos;
            ViewBag.Productos = productos;
            ViewBag.ProductoActual = productoID;
            ViewData["Title"] = "Defectos de Productos";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegistrarDefecto(int productoID, string descripcion, int cantidadAfectada)
        {
            int usuarioID = SesionWeb.GetIdUsuario(HttpContext.Session);

            var defecto = new Defecto
            {
                ProductoID = productoID,
                Descripcion = descripcion,
                CantidadAfectada = cantidadAfectada,
                UsuarioID = usuarioID
            };

            var (ok, msg) = _bl.RegistrarDefecto(defecto);
            return Json(new { ok, mensaje = msg });
        }
    }
}