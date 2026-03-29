using System.IO;
using CapaDatos;

namespace ClaseNegocio
{
    public class RespaldoBL
    {
        private readonly RespaldoDAO _dao = new RespaldoDAO();

        public (bool ok, string mensaje, string rutaFinal) GenerarRespaldo(string carpetaDestino)
        {
            if (string.IsNullOrWhiteSpace(carpetaDestino))
                return (false, "Selecciona una carpeta destino.", null);

            if (!Directory.Exists(carpetaDestino))
                return (false, "La carpeta seleccionada no existe.", null);

            return _dao.GenerarRespaldo(carpetaDestino);
        }
    }
}