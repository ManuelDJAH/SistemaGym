using CapaWeb.Filters;
using CapaWeb.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace CapaWeb.Controllers
{
    [AuthRequired]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Usuario = SesionWeb.GetUsuario(HttpContext.Session);
            ViewBag.Rol = SesionWeb.GetRol(HttpContext.Session);
            ViewBag.EsAdmin = SesionWeb.EsAdmin(HttpContext.Session);
            return View();
        }
    }
}