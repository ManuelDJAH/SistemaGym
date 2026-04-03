using CapaWeb.Filters;
using CapaWeb.Helpers;
using ClaseNegocio;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CapaWeb.Controllers
{
    [AuthRequired]
    public class UsuariosController : Controller
    {
        private readonly UsuariosBL _bl = new UsuariosBL();

        // ════════════════════════════════════════════════════════════
        //  INDEX — Listado de usuarios/miembros
        // ════════════════════════════════════════════════════════════
        public IActionResult Index(string buscar)
        {
            var usuarios = string.IsNullOrWhiteSpace(buscar)
                ? _bl.ObtenerUsuarios()
                : _bl.BuscarUsuarios(buscar);

            ViewBag.Usuarios = usuarios;
            ViewBag.Buscar = buscar;
            ViewBag.EsAdmin = SesionWeb.EsAdmin(HttpContext.Session);
            ViewData["Title"] = "Usuarios / Miembros";
            return View();
        }

        // ── Crear ────────────────────────────────────────────────────
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(string nombre, int edad, string correo,
                                    string telefono, int idMembresia)
        {
            var (ok, msg) = _bl.RegistrarUsuario(nombre, edad, correo, telefono, idMembresia);
            return Json(new { ok, mensaje = msg });
        }

        // ── Actualizar ───────────────────────────────────────────────
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Actualizar(int idUsuario, string nombre, int edad,
                                         string correo, string telefono, int idMembresia)
        {
            var (ok, msg) = _bl.ActualizarUsuario(idUsuario, nombre, edad, correo, telefono, idMembresia);
            return Json(new { ok, mensaje = msg });
        }

        // ── Eliminar ─────────────────────────────────────────────────
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(int idUsuario)
        {
            var (ok, msg) = _bl.EliminarUsuario(idUsuario);
            return Json(new { ok, mensaje = msg });
        }
    }
}