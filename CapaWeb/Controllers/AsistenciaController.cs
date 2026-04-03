using CapaNegocio;
using CapaWeb.Filters;
using CapaWeb.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace CapaWeb.Controllers
{
    [AuthRequired]
    public class AsistenciaController : Controller
    {
        private readonly AsistenciaBL _bl = new AsistenciaBL();

        public IActionResult Index()
        {
            ViewData["Title"] = "Registrar Asistencia";
            return View();
        }

        // ── Buscar usuario por nombre o ID ───────────────────────────
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BuscarUsuario(string termino)
        {
            if (string.IsNullOrWhiteSpace(termino))
                return Json(new { ok = false, mensaje = "Ingresa un nombre o ID." });

            try
            {
                var bl = new ClaseNegocio.UsuariosBL();
                var res = bl.BuscarUsuarios(termino);

                if (res == null || res.Rows.Count == 0)
                    return Json(new { ok = false, mensaje = "No se encontraron usuarios." });

                var lista = new List<object>();
                foreach (System.Data.DataRow row in res.Rows)
                {
                    lista.Add(new
                    {
                        idUsuario = row["id_usuario"],
                        nombre = row["nombre"],
                        correo = row["correo"] == System.DBNull.Value ? "" : row["correo"],
                        telefono = row["telefono"] == System.DBNull.Value ? "" : row["telefono"]
                    });
                }

                return Json(new { ok = true, usuarios = lista });
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, mensaje = ex.Message });
            }
        }

        // ── Registrar asistencia ─────────────────────────────────────
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registrar(int idUsuario)
        {
            if (idUsuario <= 0)
                return Json(new { ok = false, mensaje = "ID de usuario inválido." });

            string msg = _bl.RegistrarAsistencia(idUsuario);
            bool ok = msg.Contains("correctamente");
            return Json(new { ok, mensaje = msg });
        }
    }
}