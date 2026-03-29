using System.Data;
using CapaDatos;

namespace ClaseNegocio
{
    public class BitacoraBL
    {
        BitacoraDAO dao = new BitacoraDAO();

        // ── Métodos existentes (no tocar) ────────────────────────────
        public int RegistrarEntrada(string usuario)
        {
            return dao.RegistrarEntrada(usuario);
        }

        public void RegistrarSalida(int idBitacora)
        {
            dao.RegistrarSalida(idBitacora);
        }

        public DataTable MostrarBitacora()
        {
            return dao.MostrarBitacora();
        }

        // ── Métodos nuevos para FrmAdmin ─────────────────────────────
        public DataTable ObtenerSesiones()
        {
            return dao.ObtenerSesiones();
        }

        public DataTable ObtenerCambios()
        {
            return dao.ObtenerCambios();
        }
    }
}