using System.Data;
using CapaDatos;

namespace ClaseNegocio
{
    public class BitacoraBL
    {
        BitacoraDAO dao = new BitacoraDAO();

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
    }
}