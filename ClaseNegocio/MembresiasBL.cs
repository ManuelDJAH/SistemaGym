using System.Data;
using CapaDatos;

namespace ClaseNegocio
{
    public class MembresiaBL
    {
        private readonly MembresiaDAO dao = new MembresiaDAO();

        public DataTable ListarMembresias()
        {
            return dao.ListarMembresias();
        }
    }
}