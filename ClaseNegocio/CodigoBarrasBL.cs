using System;
using System.Drawing;
using System.Data.SqlClient;
using CapaDatos;

// Alias para evitar ambigüedad
using Producto = CapaDatos.Producto;

namespace ClaseNegocio
{
    /// <summary>
    /// Lógica de negocio para generación de códigos de barras EAN-13
    /// y ajuste de precios por venta.
    /// </summary>
    public class CodigoBarrasBL
    {
        private readonly InventarioDAO _invDAO = new InventarioDAO();
        private readonly PreciosDAO _preDAO = new PreciosDAO();

        // ════════════════════════════════════════════════════════
        //  CÓDIGOS DE BARRAS
        // ════════════════════════════════════════════════════════

        /// <summary>
        /// Genera un EAN-13 para el producto y lo guarda en la BD.
        /// Devuelve el código generado.
        /// </summary>
        public (bool ok, string mensaje, string codigo) GenerarYGuardarCodigo(int productoID, int categoriaID)
        {
            try
            {
                // Generar código basado en IDs
                string codigo = CodigoBarrasHelper.GenerarEAN13(productoID, categoriaID);

                // Verificar que no exista ya ese código en otro producto
                var existente = _invDAO.ObtenerProductoPorCodigo(codigo);
                if (existente != null && existente.ProductoID != productoID)
                {
                    // Generar uno aleatorio si hay colisión
                    codigo = CodigoBarrasHelper.GenerarEAN13Aleatorio();
                }

                bool ok = _preDAO.ActualizarCodigo(productoID, codigo);
                return ok
                    ? (true, "Código EAN-13 generado y guardado correctamente.", codigo)
                    : (false, "No se pudo guardar el código en la base de datos.", null);
            }
            catch (SqlException ex)
            {
                return (false, $"Error de base de datos: {ex.Message}", null);
            }
        }

        /// <summary>
        /// Genera la imagen Bitmap del código EAN-13 de un producto.
        /// </summary>
        public (bool ok, string mensaje, Bitmap imagen) GenerarImagen(string codigoEAN13)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(codigoEAN13))
                    return (false, "El producto no tiene código asignado.", null);

                if (!CodigoBarrasHelper.EsEAN13Valido(codigoEAN13))
                    return (false, $"'{codigoEAN13}' no es un EAN-13 válido.", null);

                var bmp = CodigoBarrasHelper.GenerarImagen(codigoEAN13);
                return (true, "OK", bmp);
            }
            catch (Exception ex)
            {
                return (false, $"Error al generar imagen: {ex.Message}", null);
            }
        }

        // ════════════════════════════════════════════════════════
        //  AJUSTE DE PRECIOS POR VENTA
        // ════════════════════════════════════════════════════════

        /// <summary>
        /// Registra una venta (salida de inventario) y ajusta precios:
        ///   • Producto vendido  → +10%
        ///   • Resto productos   → -10%  (mínimo $1.00)
        /// </summary>
        public (bool ok, string mensaje) RegistrarVentaConAjustePrecio(
            int productoID, int cantidad, string motivo, int usuarioID)
        {
            try
            {
                if (cantidad <= 0)
                    return (false, "La cantidad debe ser mayor a cero.");

                // 1. Registrar salida de inventario
                var invBL = new InventarioBL();
                var (okSalida, msgSalida) = invBL.RegistrarSalida(productoID, cantidad, motivo, usuarioID);

                if (!okSalida)
                    return (false, msgSalida);

                // 2. Ajustar precios
                _preDAO.AjustarPreciosPorVenta(productoID);

                return (true, $"Venta registrada. Precios actualizados: +10% al producto vendido, -10% al resto.");
            }
            catch (SqlException ex)
            {
                return (false, $"Error de base de datos: {ex.Message}");
            }
            catch (Exception ex)
            {
                return (false, $"Error: {ex.Message}");
            }
        }
    }
}