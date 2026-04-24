using CapaDatos;
using CapaWeb.Filters;
using CapaWeb.Helpers;
using ClaseNegocio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Linq;

namespace CapaWeb.Controllers
{
    [AuthRequired]
    public class NotificacionesController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Notificaciones";
            ViewBag.EsAdmin = SesionWeb.EsAdmin(HttpContext.Session);

            var invBL = new InventarioBL();
            ViewBag.AlertasInventario = invBL.ObtenerAlertasPendientes();

            var restockBL = new RestockBL();
            ViewBag.OrdenesRestock = restockBL.ListarOrdenes("Pendiente");

            var usuariosBL = new UsuariosBL();
            var todos = usuariosBL.ListarUsuarios();
            var hoy = DateTime.Today;

            var rowsVencidas = todos.AsEnumerable()
                .Where(r => r["fecha_vencimiento"] != DBNull.Value &&
                            Convert.ToDateTime(r["fecha_vencimiento"]) < hoy)
                .ToList();

            var rowsPorVencer = todos.AsEnumerable()
                .Where(r => r["fecha_vencimiento"] != DBNull.Value &&
                            Convert.ToDateTime(r["fecha_vencimiento"]) >= hoy &&
                            Convert.ToDateTime(r["fecha_vencimiento"]) <= hoy.AddDays(7))
                .ToList();

            var memVencidas = rowsVencidas.Count > 0 ? rowsVencidas.CopyToDataTable() : todos.Clone();
            var memPorVencer = rowsPorVencer.Count > 0 ? rowsPorVencer.CopyToDataTable() : todos.Clone();

            ViewBag.MemVencidas = memVencidas;
            ViewBag.MemPorVencer = memPorVencer;

            var listaAlertas = ViewBag.AlertasInventario as List<AlertaInventario> ?? new List<AlertaInventario>();
            var listaOrdenes = ViewBag.OrdenesRestock as List<OrdenRestock> ?? new List<OrdenRestock>();

            ViewBag.TotalNotif = listaAlertas.Count
                               + listaOrdenes.Count
                               + memVencidas.Rows.Count
                               + memPorVencer.Rows.Count;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AtenderAlerta(int alertaID)
        {
            var (ok, msg) = new InventarioBL().AtenderAlerta(alertaID);
            return Json(new { ok, mensaje = msg });
        }

        [HttpGet]
        public IActionResult Conteo()
        {
            try
            {
                var invBL = new InventarioBL();
                var restockBL = new RestockBL();
                var usuariosBL = new UsuariosBL();

                int alertasInv = (invBL.ObtenerAlertasPendientes() ?? new List<AlertaInventario>()).Count;
                int restock = (restockBL.ListarOrdenes("Pendiente") ?? new List<OrdenRestock>()).Count;

                var todos = usuariosBL.ListarUsuarios();
                var hoy = DateTime.Today;

                int memVencidas = todos.AsEnumerable()
                    .Count(r => r["fecha_vencimiento"] != DBNull.Value &&
                                Convert.ToDateTime(r["fecha_vencimiento"]) < hoy);

                int memPorVencer = todos.AsEnumerable()
                    .Count(r => r["fecha_vencimiento"] != DBNull.Value &&
                                Convert.ToDateTime(r["fecha_vencimiento"]) >= hoy &&
                                Convert.ToDateTime(r["fecha_vencimiento"]) <= hoy.AddDays(7));

                int total = alertasInv + restock + memVencidas + memPorVencer;
                return Json(new { total });
            }
            catch
            {
                return Json(new { total = 0 });
            }
        }
    }
}