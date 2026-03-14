using System;

namespace CapaPresentacion
{
    public static class Sesion
    {
        public static string Usuario { get; set; }
        public static string Rol { get; set; }
        public static int IdUsuario { get; set; }  // ← NUEVO: id_usuario de UsuariosSistema

        public static int IdBitacoraActual;
        public static string UsuarioActual;
    }
}