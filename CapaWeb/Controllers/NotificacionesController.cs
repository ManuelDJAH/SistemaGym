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

            // ── 1. Alertas de inventario (stock bajo / caducidad) ────
            var invBL = new InventarioBL();
            ViewBag.AlertasInventario = invBL.ObtenerAlertasPendientes();

            // ── 2. Órdenes de restock pendientes ─────────────────────
            var restockBL = new RestockBL();
            ViewBag.OrdenesRestock = restockBL.ListarOrdenes("Pendiente");

            // ── 3. Membresías vencidas o por vencer (7 días) ─────────
            var usuariosBL = new UsuariosBL();
            var todos = usuariosBL.ListarUsuarios();
            var hoy = DateTime.Today;

            // Filtrar en memoria — con guarda para evitar crash si no hay filas
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

            // ── Totales para badge ────────────────────────────────────
            var listaAlertas = ViewBag.AlertasInventario as List<AlertaInventario> ?? new List<AlertaInventario>();
            var listaOrdenes = ViewBag.OrdenesRestock as List<OrdenRestock> ?? new List<OrdenRestock>();

            ViewBag.TotalNotif = listaAlertas.Count
                               + listaOrdenes.Count
                               + memVencidas.Rows.Count
                               + memPorVencer.Rows.Count;

            return View();
        }

        // Atender alerta de inventario desde notificaciones
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AtenderAlerta(int alertaID)
        {
            var (ok, msg) = new InventarioBL().AtenderAlerta(alertaID);
            return Json(new { ok, mensaje = msg });
        }
    }
}