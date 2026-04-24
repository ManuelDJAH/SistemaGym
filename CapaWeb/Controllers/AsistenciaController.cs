using CapaNegocio;
using CapaWeb.Filters;
using CapaWeb.Helpers;
using ClaseNegocio;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace CapaWeb.Controllers
{
    [AuthRequired]
    public class AsistenciaController : Controller
    {
        private readonly AsistenciaBL _bl = new AsistenciaBL();

        public IActionResult Index()
        {
            ViewData["Title"] = "Registrar Asistencia";
            ViewBag.EsAdmin = SesionWeb.EsAdmin(HttpContext.Session);
            return View();
        }

        // ── Buscar miembro por nombre o ID ────────────────────
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BuscarUsuario(string termino)
        {
            if (string.IsNullOrWhiteSpace(termino))
                return Json(new { ok = false, mensaje = "Ingresa un nombre o ID." });

            try
            {
                var bl = new UsuariosBL();
                var dt = int.TryParse(termino, out int id)
                    ? bl.ListarUsuarios() // buscar por ID
                    : bl.BuscarPorNombre(termino);

                if (dt == null || dt.Rows.Count == 0)
                    return Json(new { ok = false, mensaje = "No se encontraron miembros." });

                var lista = new List<object>();
                foreach (System.Data.DataRow row in dt.Rows)
                {
                    // Si buscó por ID, filtrar
                    if (int.TryParse(termino, out int busqId) &&
                        Convert.ToInt32(row["id_usuario"]) != busqId) continue;

                    lista.Add(new
                    {
                        idUsuario = row["id_usuario"],
                        nombre = row["nombre"],
                        membresia = row["nombre_membresia"] == System.DBNull.Value ? "" : row["nombre_membresia"].ToString(),
                        estadoMembresia = row["estado_membresia"] == System.DBNull.Value ? "" : row["estado_membresia"].ToString()
                    });
                }

                if (!lista.Any())
                    return Json(new { ok = false, mensaje = "No se encontraron miembros." });

                return Json(new { ok = true, usuarios = lista });
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, mensaje = ex.Message });
            }
        }

        // ── Registrar asistencia ──────────────────────────────
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registrar(int idUsuario)
        {
            string msg = _bl.RegistrarAsistencia(idUsuario);
            bool ok = msg.Contains("correctamente");
            return Json(new { ok, mensaje = msg });
        }

        // ── Historial de asistencias ──────────────────────────
        [HttpGet]
        public IActionResult Historial(string fecha = null)
        {
            ViewData["Title"] = "Historial de Asistencias";
            ViewBag.EsAdmin = SesionWeb.EsAdmin(HttpContext.Session);

            var fechaFiltro = string.IsNullOrEmpty(fecha)
                ? DateTime.Today
                : DateTime.Parse(fecha);

            ViewBag.Fecha = fechaFiltro.ToString("yyyy-MM-dd");

            try
            {
                using (var cn = CapaDatos.Conexion.ObtenerConexion())
                {
                    cn.Open();
                    var cmd = new SqlCommand(@"
                        SELECT a.id_asistencia,
                               u.nombre        AS NombreMiembro,
                               a.fecha,
                               a.hora_entrada,
                               m.nombre        AS Membresia
                        FROM   Asistencias a
                        JOIN   Usuarios    u ON a.id_usuario   = u.id_usuario
                        LEFT JOIN Membresias m ON u.id_membresia = m.id_membresia
                        WHERE  CAST(a.fecha AS DATE) = @fecha
                        ORDER  BY a.hora_entrada DESC", cn);

                    cmd.Parameters.AddWithValue("@fecha", fechaFiltro.Date);

                    var da = new System.Data.SqlClient.SqlDataAdapter(cmd);
                    var dt = new System.Data.DataTable();
                    da.Fill(dt);
                    ViewBag.Asistencias = dt;
                    ViewBag.Total = dt.Rows.Count;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Asistencias = new System.Data.DataTable();
                ViewBag.Total = 0;
                ViewBag.Error = ex.Message;
            }

            return View();
        }
    }
}