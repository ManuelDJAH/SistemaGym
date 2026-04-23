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

                int idUsuario = bl.ObtenerIdPorUsuario(usuario);
                SesionWeb.Iniciar(HttpContext.Session, usuario, rol, idUsuario);

                // Registrar entrada en bitácora y guardar ID para el logout
                var bitacoraBL = new BitacoraBL();
                int idBitacora = bitacoraBL.RegistrarEntrada(usuario);
                HttpContext.Session.SetInt32("sw_idbita", idBitacora);

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
            // Registrar salida en bitácora antes de cerrar sesión
            int? idBitacora = HttpContext.Session.GetInt32("sw_idbita");
            if (idBitacora.HasValue && idBitacora.Value > 0)
            {
                try
                {
                    var bitacoraBL = new BitacoraBL();
                    bitacoraBL.RegistrarSalida(idBitacora.Value);
                }
                catch { /* no interrumpir el logout si falla */ }
            }

            SesionWeb.Cerrar(HttpContext.Session);
            return RedirectToAction("Login");
        }
    }
}