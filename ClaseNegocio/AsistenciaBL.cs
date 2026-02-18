using CapaDatos;

namespace CapaNegocio
{
    public class AsistenciaBL
    {
        private AsistenciaDAO dao = new AsistenciaDAO();

        public string RegistrarAsistencia(int idUsuario)
        {
            if (idUsuario <= 0)
                return "ID de usuario inválido.";

            return dao.RegistrarAsistencia(idUsuario);
        }
    }
}
