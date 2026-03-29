using CapaWeb.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CapaWeb.Filters
{
    /// <summary>
    /// Atributo que protege controllers/actions que requieren login.
    /// Uso: [AuthRequired] sobre el controller o action.
    /// Para requerir rol admin: [AuthRequired(soloAdmin: true)]
    /// </summary>
    public class AuthRequiredAttribute : ActionFilterAttribute
    {
        private readonly bool _soloAdmin;

        public AuthRequiredAttribute(bool soloAdmin = false)
        {
            _soloAdmin = soloAdmin;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var session = context.HttpContext.Session;

            // No autenticado → redirigir a Login
            if (!SesionWeb.EstaAutenticado(session))
            {
                context.Result = new RedirectToActionResult("Login", "Account", null);
                return;
            }

            // Requiere admin pero no lo es → redirigir a inicio
            if (_soloAdmin && !SesionWeb.EsAdmin(session))
            {
                context.Result = new RedirectToActionResult("Index", "Home", null);
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}