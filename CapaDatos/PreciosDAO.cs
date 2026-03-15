// ================================================================
//  CapaDatos/PreciosDAO.cs
//  Ajusta precios tras una venta:
//    - Producto vendido: +10%
//    - Resto de productos: -10% (mínimo $1.00)
// ================================================================
using System;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class PreciosDAO
    {
        /// <summary>
        /// Aplica el ajuste de precios después de una venta.
        /// Se ejecuta en una sola transacción para garantizar consistencia.
        /// </summary>
        /// <param name="productoVendidoID">ID del producto que se vendió.</param>
        public void AjustarPreciosPorVenta(int productoVendidoID)
        {
            using (var con = Conexion.ObtenerConexion())
            {
                con.Open();
                using (var tx = con.BeginTransaction())
                {
                    try
                    {
                        // 1. Subir 10% al producto vendido
                        string sqlSubir = @"
                            UPDATE Inv_Productos
                            SET    Precio = ROUND(Precio * 1.10, 2)
                            WHERE  ProductoID = @ID
                              AND  Activo     = 1";

                        using (var cmd = new SqlCommand(sqlSubir, con, tx))
                        {
                            cmd.Parameters.AddWithValue("@ID", productoVendidoID);
                            cmd.ExecuteNonQuery();
                        }

                        // 2. Bajar 10% al resto, con piso de $1.00
                        string sqlBajar = @"
                            UPDATE Inv_Productos
                            SET    Precio = CASE
                                               WHEN ROUND(Precio * 0.90, 2) < 1.00
                                               THEN 1.00
                                               ELSE ROUND(Precio * 0.90, 2)
                                           END
                            WHERE  ProductoID <> @ID
                              AND  Activo      = 1";

                        using (var cmd = new SqlCommand(sqlBajar, con, tx))
                        {
                            cmd.Parameters.AddWithValue("@ID", productoVendidoID);
                            cmd.ExecuteNonQuery();
                        }

                        tx.Commit();
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Actualiza el código de barras (campo Codigo) de un producto.
        /// </summary>
        public bool ActualizarCodigo(int productoID, string nuevoCodigo)
        {
            using (var con = Conexion.ObtenerConexion())
            {
                con.Open();
                string sql = @"
                    UPDATE Inv_Productos
                    SET    Codigo = @Codigo
                    WHERE  ProductoID = @ID";

                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Codigo", nuevoCodigo);
                    cmd.Parameters.AddWithValue("@ID", productoID);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}