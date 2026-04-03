using CapaNegocio;
using CapaWeb.Filters;
using ClaseNegocio;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BuscarUsuario(string termino)
        {
            if (string.IsNullOrWhiteSpace(termino))
                return Json(new { ok = false, mensaje = "Ingresa un nombre o ID." });

            try
            {
                var bl = new UsuariosBL();
                var dt = bl.BuscarPorNombre(termino);

                if (dt == null || dt.Rows.Count == 0)
                    return Json(new { ok = false, mensaje = "No se encontraron usuarios." });

                var lista = new List<object>();
                foreach (System.Data.DataRow row in dt.Rows)
                {
                    lista.Add(new
                    {
                        idUsuario = row["id_usuario"],
                        nombre = row["nombre"],
                        correo = row["correo"] == System.DBNull.Value ? "" : row["correo"].ToString(),
                        telefono = row["telefono"] == System.DBNull.Value ? "" : row["telefono"].ToString()
                    });
                }

                return Json(new { ok = true, usuarios = lista });
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, mensaje = ex.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registrar(int idUsuario)
        {
            string msg = _bl.RegistrarAsistencia(idUsuario);
            bool ok = msg.Contains("correctamente");
            return Json(new { ok, mensaje = msg });
        }
    }
}