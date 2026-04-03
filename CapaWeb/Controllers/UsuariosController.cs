using CapaWeb.Filters;
using CapaWeb.Helpers;
using ClaseNegocio;
using Microsoft.AspNetCore.Mvc;

namespace CapaWeb.Controllers
{
    [AuthRequired]
    public class UsuariosController : Controller
    {
        private readonly UsuariosBL _bl = new UsuariosBL();

        public IActionResult Index(string buscar)
        {
            var dt = string.IsNullOrWhiteSpace(buscar)
                ? _bl.ListarUsuarios()
                : _bl.BuscarPorNombre(buscar);

            ViewBag.Usuarios = dt;
            ViewBag.Buscar = buscar;
            ViewData["Title"] = "Usuarios / Miembros";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(string nombre, int edad, string correo,
                                    string telefono, int idMembresia)
        {
            string msg = _bl.RegistrarUsuario(nombre, edad, correo,
                                              telefono, DateTime.Today, idMembresia);
            bool ok = msg.Contains("correctamente");
            return Json(new { ok, mensaje = msg });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Actualizar(int idUsuario, string nombre, int edad,
                                         string correo, string telefono, int idMembresia)
        {
            string msg = _bl.ActualizarUsuario(idUsuario, nombre, edad, correo, telefono, idMembresia);
            bool ok = msg.Contains("correctamente");
            return Json(new { ok, mensaje = msg });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(int idUsuario)
        {
            string msg = _bl.EliminarUsuario(idUsuario);
            bool ok = msg.Contains("correctamente");
            return Json(new { ok, mensaje = msg });
        }
    }
}