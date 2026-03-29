using Microsoft.AspNetCore.Http;

namespace CapaWeb.Helpers
{

    public static class SesionWeb
    {
        private const string KeyUsuario = "sw_usuario";
        private const string KeyRol = "sw_rol";
        private const string KeyIdUsuario = "sw_idusuario";

        // ── Guardar ──────────────────────────────────────────────────
        public static void Iniciar(ISession session, string usuario, string rol, int idUsuario)
        {
            session.SetString("sw_usuario", usuario);
            session.SetString("sw_rol", rol);
            session.SetInt32("sw_idusuario", idUsuario);
        }

        // ── Leer ─────────────────────────────────────────────────────
        public static string GetUsuario(ISession session) =>
            session.GetString(KeyUsuario) ?? "";

        public static string GetRol(ISession session) =>
            session.GetString(KeyRol) ?? "";

        public static int GetIdUsuario(ISession session) =>
            session.GetInt32(KeyIdUsuario) ?? 0;

        // ── Validar ──────────────────────────────────────────────────
        public static bool EstaAutenticado(ISession session) =>
            !string.IsNullOrEmpty(session.GetString(KeyUsuario));

        public static bool EsAdmin(ISession session) =>
            session.GetString(KeyRol) == "ADMIN";

        // ── Cerrar sesión ────────────────────────────────────────────
        public static void Cerrar(ISession session) =>
            session.Clear();
    }
}