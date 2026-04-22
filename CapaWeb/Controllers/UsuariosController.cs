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

        public IActionResult Index(string buscar = "")
        {
            ViewBag.Usuario = SesionWeb.GetUsuario(HttpContext.Session);
            ViewBag.Rol = SesionWeb.GetRol(HttpContext.Session);
            ViewBag.EsAdmin = SesionWeb.EsAdmin(HttpContext.Session);

            ViewBag.Usuarios = string.IsNullOrWhiteSpace(buscar)
                                    ? _bl.ListarUsuarios()
                                    : _bl.BuscarPorNombre(buscar);
            ViewBag.Membresias = _bl.ListarMembresias();
            ViewBag.Buscar = buscar;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(string nombre, int edad, string correo,
                                   string telefono, int idMembresia)
        {
            var msg = _bl.RegistrarUsuario(nombre, edad, correo ?? "",
                                           telefono ?? "", System.DateTime.Today, idMembresia);
            return Json(new { ok = msg.Contains("correctamente"), mensaje = msg });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Actualizar(int idUsuario, string nombre, int edad,
                                        string correo, string telefono, int idMembresia)
        {
            var msg = _bl.ActualizarUsuario(idUsuario, nombre, edad,
                                            correo ?? "", telefono ?? "", idMembresia);
            return Json(new { ok = msg.Contains("correctamente"), mensaje = msg });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Renovar(int idUsuario, int idMembresia)
        {
            var msg = _bl.RenovarMembresia(idUsuario, idMembresia);
            return Json(new { ok = msg.Contains("correctamente"), mensaje = msg });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(int idUsuario)
        {
            var msg = _bl.EliminarUsuario(idUsuario);
            return Json(new { ok = msg.Contains("correctamente"), mensaje = msg });
        }
    }
}