using CapaWeb.Filters;
using CapaWeb.Helpers;
using ClaseNegocio;
using Microsoft.AspNetCore.Mvc;

namespace CapaWeb.Controllers
{
    [AuthRequired(soloAdmin: true)]
    public class AdminController : Controller
    {
        // ════════════════════════════════════════════════════════════
        //  INDEX — Panel admin con tabs
        // ════════════════════════════════════════════════════════════
        public IActionResult Index()
        {
            CargarBitacora();
            ViewData["Title"] = "Panel de Administracion";
            ViewBag.EsAdmin = SesionWeb.EsAdmin(HttpContext.Session);
            return View();
        }

        // ════════════════════════════════════════════════════════════
        //  BITÁCORA
        // ════════════════════════════════════════════════════════════
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
        //  RESPALDO
        // ════════════════════════════════════════════════════════════
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GenerarRespaldo()
        {
            try
            {
                var bl = new RespaldoBL();

                // En web, guardamos en la carpeta de backups de SQL Server
                // y devolvemos el archivo para descarga directa
                string carpetaTemp = Path.Combine(Path.GetTempPath(), "RespaldosGymWeb");
                Directory.CreateDirectory(carpetaTemp);

                var (ok, mensaje, rutaFinal) = bl.GenerarRespaldo(carpetaTemp);

                if (!ok)
                    return Json(new { ok = false, mensaje });

                // Leer el archivo y enviarlo como descarga
                byte[] bytes = System.IO.File.ReadAllBytes(rutaFinal);

                // Limpiar temporal
                try { System.IO.File.Delete(rutaFinal); } catch { }

                string nombreArchivo = Path.GetFileName(rutaFinal);
                return File(bytes, "application/octet-stream", nombreArchivo);
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, mensaje = ex.Message });
            }
        }
    }
}