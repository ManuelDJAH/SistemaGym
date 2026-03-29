using CapaWeb.Helpers;
using CapaWeb.Filters;
using ClaseNegocio;
using Microsoft.AspNetCore.Mvc;

namespace CapaWeb.Controllers
{
    public class AccountController : Controller
    {
        // ── GET /Account/Login ────────────────────────────────────────
        public IActionResult Login()
        {
            // Si ya está autenticado, redirigir al inicio
            if (SesionWeb.EstaAutenticado(HttpContext.Session))
                return RedirectToAction("Index", "Home");

            return View();
        }

        // ── POST /Account/Login ───────────────────────────────────────
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string usuario, string clave)
        {
            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(clave))
            {
                ViewBag.Error = "Usuario y contraseña son obligatorios.";
                return View();
            }

            try
            {
                var bl = new UsuariosBL();
                string rol = bl.Login(usuario, clave);

                if (rol == null)
                {
                    ViewBag.Error = "Usuario o contraseña incorrectos.";
                    return View();
                }

                // Obtener ID del usuario
                int idUsuario = bl.ObtenerIdPorUsuario(usuario);

                // Iniciar sesión web
                SesionWeb.Iniciar(HttpContext.Session, usuario, rol, idUsuario);

                // Registrar entrada en bitácora
                var bitacoraBL = new BitacoraBL();
                bitacoraBL.RegistrarEntrada(usuario);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Error al iniciar sesión: {ex.Message}";
                return View();
            }
        }

        // ── GET /Account/Logout ───────────────────────────────────────
        [AuthRequired]
        public IActionResult Logout()
        {
            SesionWeb.Cerrar(HttpContext.Session);
            return RedirectToAction("Login");
        }
    }
}