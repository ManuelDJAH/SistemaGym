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
        //  PRODUCTOS — Catálogo
        // ════════════════════════════════════════════════════════════
        public IActionResult Index(int? categoriaID)
        {
            ViewBag.Productos = _bl.ObtenerProductos(categoriaID);
            ViewBag.Categorias = _bl.ObtenerCategoriasProducto();
            ViewBag.CategoriaActual = categoriaID;
            ViewBag.EsAdmin = SesionWeb.EsAdmin(HttpContext.Session);

            // Cargar proveedores para el selector del modal
            using (var cn = CapaDatos.Conexion.ObtenerConexion())
            {
                cn.Open();
                var cmd = new System.Data.SqlClient.SqlCommand(
                    "SELECT id_proveedor, nombre FROM Proveedores ORDER BY nombre", cn);
                var da = new System.Data.SqlClient.SqlDataAdapter(cmd);
                var dt = new System.Data.DataTable();
                da.Fill(dt);
                ViewBag.Proveedores = dt;
            }

            ViewData["Title"] = "Inventario — Productos";
            return View();
        }

        // ── Alta ─────────────────────────────────────────────────────
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearProducto(string codigo, string nombre, int categoriaID,
                                    decimal precio, int stockMinimo,
                                    string fechaCaducidad, int idProveedor = 0)
        {
            DateTime? caducidad = null;
            if (!string.IsNullOrEmpty(fechaCaducidad))
                caducidad = DateTime.Parse(fechaCaducidad);

            var p = new CapaDatos.Producto
            {
                Codigo = codigo?.Trim(),
                Nombre = nombre?.Trim(),
                CategoriaID = categoriaID,
                Precio = precio,
                StockMinimo = stockMinimo,
                StockActual = 0,
                FechaCaducidad = caducidad,
                IdProveedor = idProveedor
            };

            var (ok, msg, _) = _bl.AltaProducto(p);
            return Json(new { ok, mensaje = msg });
        }

        // ── Actualizar ───────────────────────────────────────────────
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ActualizarProducto(int productoID, string nombre, int categoriaID,
                                         decimal precio, int stockMinimo,
                                         string fechaCaducidad, int idProveedor = 0)
        {
            DateTime? caducidad = null;
            if (!string.IsNullOrEmpty(fechaCaducidad))
                caducidad = DateTime.Parse(fechaCaducidad);

            var p = new CapaDatos.Producto
            {
                ProductoID = productoID,
                Nombre = nombre?.Trim(),
                CategoriaID = categoriaID,
                Precio = precio,
                StockMinimo = stockMinimo,
                FechaCaducidad = caducidad,
                IdProveedor = idProveedor
            };

            var (ok, msg) = _bl.ActualizarProducto(p);
            return Json(new { ok, mensaje = msg });
        }

        // ── Baja lógica ──────────────────────────────────────────────
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BajaProducto(int productoID)
        {
            var (ok, msg) = _bl.BajaProducto(productoID);
            return Json(new { ok, mensaje = msg });
        }

        // ── Buscar por código ────────────────────────────────────────
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
        public IActionResult BuscarProductosPorNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre) || nombre.Length < 2)
                return Json(new { ok = false, productos = new object[0] });

            var productos = _bl.ObtenerProductos()
                .Where(p => p.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase)
                         || p.Codigo.Contains(nombre, StringComparison.OrdinalIgnoreCase))
                .Take(8)
                .Select(p => new {
                    p.ProductoID,
                    p.Codigo,
                    p.Nombre,
                    Categoria = p.CategoriaNombre,
                    p.StockActual,
                    p.StockMinimo,
                    p.EstadoAlerta
                });

            return Json(new { ok = true, productos });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GenerarCodigo()
        {
            try
            {
                string codigo = _bl.GenerarCodigoEAN13Unico();
                return Json(new { ok = true, codigo });
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, mensaje = ex.Message });
            }
        }


        // ════════════════════════════════════════════════════════════
        //  EQUIPO
        // ════════════════════════════════════════════════════════════
        public IActionResult Equipo(string estado)
        {
            ViewBag.Equipos = _bl.ObtenerEquipos(string.IsNullOrEmpty(estado) ? null : estado);
            ViewBag.Categorias = _bl.ObtenerCategoriasEquipo();
            ViewBag.Estado = estado;
            ViewData["Title"] = "Inventario — Equipo";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearEquipo(string nombre, int categoriaID, string estadoEquipo,
                                          string fechaAdquisicion, string observaciones)
        {
            DateTime? fecha = null;
            if (!string.IsNullOrEmpty(fechaAdquisicion))
                fecha = DateTime.Parse(fechaAdquisicion);

            var e = new Equipo
            {
                Nombre = nombre?.Trim(),
                CategoriaID = categoriaID,
                Estado = estadoEquipo,
                FechaAdquisicion = fecha,
                Observaciones = observaciones?.Trim()
            };

            var (ok, msg, _) = _bl.AltaEquipo(e);
            return Json(new { ok, mensaje = msg });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ActualizarEquipo(int equipoID, string nombre, int categoriaID,
                                               string estadoEquipo, string fechaAdquisicion,
                                               string observaciones)
        {
            DateTime? fecha = null;
            if (!string.IsNullOrEmpty(fechaAdquisicion))
                fecha = DateTime.Parse(fechaAdquisicion);

            var e = new Equipo
            {
                EquipoID = equipoID,
                Nombre = nombre?.Trim(),
                CategoriaID = categoriaID,
                Estado = estadoEquipo,
                FechaAdquisicion = fecha,
                Observaciones = observaciones?.Trim()
            };

            var (ok, msg) = _bl.ActualizarEquipo(e);
            return Json(new { ok, mensaje = msg });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BajaEquipo(int equipoID)
        {
            var (ok, msg) = _bl.BajaEquipo(equipoID);
            return Json(new { ok, mensaje = msg });
        }

        // ════════════════════════════════════════════════════════════
        //  MOVIMIENTOS
        // ════════════════════════════════════════════════════════════
        public IActionResult Movimientos()
        {
            ViewData["Title"] = "Registrar Movimiento";
            return View();
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
            catch (Exception ex) { return Json(new { ok = false, mensaje = ex.Message }); }
        }

        // ════════════════════════════════════════════════════════════
        //  HISTORIAL
        // ════════════════════════════════════════════════════════════
        public IActionResult Historial(int? productoID, DateTime? desde, DateTime? hasta)
        {
            ViewBag.Historial = _bl.ObtenerHistorial(productoID, desde, hasta);
            ViewBag.Productos = _bl.ObtenerProductos();
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
            ViewBag.Alertas = _bl.ObtenerAlertasPendientes();
            ViewData["Title"] = "Alertas de Inventario";
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
            ViewBag.Defectos = _bl.ObtenerDefectos(productoID);
            ViewBag.Productos = _bl.ObtenerProductos();
            ViewBag.ProductoActual = productoID;
            ViewData["Title"] = "Defectos de Productos";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegistrarDefecto(int productoID, string descripcion, int cantidadAfectada)
        {
            int usuarioID = SesionWeb.GetIdUsuario(HttpContext.Session);
            var d = new Defecto
            {
                ProductoID = productoID,
                Descripcion = descripcion,
                CantidadAfectada = cantidadAfectada,
                UsuarioID = usuarioID
            };
            var (ok, msg) = _bl.RegistrarDefecto(d);
            return Json(new { ok, mensaje = msg });
        }
    }
}