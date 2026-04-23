using CapaWeb.Filters;
using CapaWeb.Helpers;
using ClaseNegocio;
using Microsoft.AspNetCore.Mvc;

namespace CapaWeb.Controllers
{
    [AuthRequired(soloAdmin: true)]
    public class AdminController : Controller
    {
        private readonly UsuarioSistemaBL _usBL = new UsuarioSistemaBL();

        // ════════════════════════════════════════════════════════════
        //  INDEX — Panel admin con tabs
        // ════════════════════════════════════════════════════════════
        public IActionResult Index()
        {
            CargarBitacora();
            ViewBag.UsuariosSistema = _usBL.Listar();
            ViewBag.EsAdmin = SesionWeb.EsAdmin(HttpContext.Session);
            ViewData["Title"] = "Panel de Administracion";
            return View();
        }

        private void CargarBitacora()
        {
            try
            {
                var bl = new BitacoraBL();
                ViewBag.Cambios = bl.ObtenerCambios();
                ViewBag.Sesiones = bl.ObtenerSesiones();
            }
            catch
            {
                ViewBag.Cambios = new System.Data.DataTable();
                ViewBag.Sesiones = new System.Data.DataTable();
            }
        }

        // ════════════════════════════════════════════════════════════
        //  USUARIOS DEL SISTEMA
        // ════════════════════════════════════════════════════════════
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearUsuarioSistema(string usuario, string clave,
                                                  string nombre, string rol)
        {
            var (ok, msg) = _usBL.Crear(usuario, clave, nombre, rol);
            return Json(new { ok, mensaje = msg });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ActualizarUsuarioSistema(int idUsuario, string nombre,
                                                       string rol, string nuevaClave)
        {
            var (ok, msg) = _usBL.Actualizar(idUsuario, nombre, rol,
                string.IsNullOrWhiteSpace(nuevaClave) ? null : nuevaClave);
            return Json(new { ok, mensaje = msg });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EliminarUsuarioSistema(int idUsuario)
        {
            var (ok, msg) = _usBL.Eliminar(idUsuario);
            return Json(new { ok, mensaje = msg });
        }

        // ════════════════════════════════════════════════════════════
        //  RESPALDO
        // ════════════════════════════════════════════════════════════
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GenerarRespaldo()
        {
            try
            {
                var bl = new RespaldoBL();
                bool esLinux = System.Runtime.InteropServices.RuntimeInformation
                                    .IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Linux);
                string carpeta = esLinux ? "/tmp" : Path.GetTempPath();

                var (ok, mensaje, rutaFinal) = bl.GenerarRespaldo(carpeta);

                if (!ok)
                    return Json(new { ok = false, mensaje });

                // Leer bytes y devolver como descarga
                byte[] bytes = System.IO.File.ReadAllBytes(rutaFinal);
                string nombre = Path.GetFileName(rutaFinal);

                // Limpiar el temporal
                try { System.IO.File.Delete(rutaFinal); } catch { }

                return File(bytes, "application/octet-stream", nombre);
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, mensaje = ex.Message });
            }
        }
    }
}