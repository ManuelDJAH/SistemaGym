using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class RestockDAO
    {
        // ── ÓRDENES ──────────────────────────────────────────────────

        /// <summary>Lista todas las órdenes usando la vista vw_OrdenesRestock.</summary>
        public List<OrdenRestock> ListarOrdenes(string filtroEstado = null)
        {
            var lista = new List<OrdenRestock>();

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                string sql = "SELECT * FROM vw_OrdenesRestock";
                if (!string.IsNullOrEmpty(filtroEstado))
                    sql += " WHERE estado = @estado";
                sql += " ORDER BY fechaGenerada DESC";

                SqlCommand cmd = new SqlCommand(sql, con);
                if (!string.IsNullOrEmpty(filtroEstado))
                    cmd.Parameters.AddWithValue("@estado", filtroEstado);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new OrdenRestock
                    {
                        IdOrden           = (int)dr["idorden"],
                        Estado            = dr["estado"].ToString(),
                        FechaGenerada     = (DateTime)dr["fechaGenerada"],
                        FechaAtendida     = dr["fechaAtendida"] as DateTime?,
                        CantidadSolicit   = (int)dr["cantidadSolicit"],
                        StockAlMomento    = (int)dr["stockAlMomento"],
                        StockMinimo       = (int)dr["stockMinimo"],
                        Notas             = dr["notas"]?.ToString(),
                        Producto          = dr["producto"].ToString(),
                        CodigoProducto    = dr["codigoProducto"].ToString(),
                        StockActual       = (int)dr["stockActual"],
                        Proveedor         = dr["proveedor"].ToString(),
                        TelProveedor      = dr["telProveedor"]?.ToString(),
                        CorreoProveedor   = dr["correoProveedor"]?.ToString(),
                        ContactoProveedor = dr["contactoProveedor"]?.ToString()
                    });
                }
            }

            return lista;
        }

        /// <summary>Genera una orden de restock manualmente desde el sistema.</summary>
        public (bool ok, string msg) GenerarOrden(int idProducto, int idProveedor,
            int cantidad, int stockActual, int stockMinimo, string notas)
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    // Verificar que no haya orden pendiente
                    SqlCommand chk = new SqlCommand(
                        "SELECT COUNT(1) FROM OrdenesRestock WHERE idproducto = @id AND estado = 'PENDIENTE'", con);
                    chk.Parameters.AddWithValue("@id", idProducto);
                    con.Open();
                    int pendientes = (int)chk.ExecuteScalar();

                    if (pendientes > 0)
                        return (false, "Ya existe una orden PENDIENTE para este producto.");

                    SqlCommand cmd = new SqlCommand(@"
                        INSERT INTO OrdenesRestock
                            (idproducto, idproveedor, cantidadSolicit, stockAlMomento, stockMinimo, notas)
                        VALUES
                            (@idprod, @idprov, @cantidad, @stockActual, @stockMin, @notas)", con);

                    cmd.Parameters.AddWithValue("@idprod",      idProducto);
                    cmd.Parameters.AddWithValue("@idprov",      idProveedor);
                    cmd.Parameters.AddWithValue("@cantidad",    cantidad);
                    cmd.Parameters.AddWithValue("@stockActual", stockActual);
                    cmd.Parameters.AddWithValue("@stockMin",    stockMinimo);
                    cmd.Parameters.AddWithValue("@notas",       (object)notas ?? DBNull.Value);

                    cmd.ExecuteNonQuery();
                }

                return (true, "Orden de restock generada correctamente.");
            }
            catch (SqlException ex)
            {
                return (false, "Error: " + ex.Message);
            }
        }

        /// <summary>Actualiza la cantidad a pedir de una orden PENDIENTE.</summary>
        public (bool ok, string msg) ActualizarCantidad(int idOrden, int nuevaCantidad)
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand(
                        "UPDATE OrdenesRestock SET cantidadSolicit = @cant WHERE idorden = @id AND estado = 'PENDIENTE'", con);
                    cmd.Parameters.AddWithValue("@cant", nuevaCantidad);
                    cmd.Parameters.AddWithValue("@id",   idOrden);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                return (true, "Cantidad actualizada.");
            }
            catch (SqlException ex)
            {
                return (false, "Error: " + ex.Message);
            }
        }

        /// <summary>Cambia el estado de una orden (ENVIADA, RECIBIDA, CANCELADA).</summary>
        public (bool ok, string msg) CambiarEstado(int idOrden, string nuevoEstado, string notas)
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand(@"
                        UPDATE OrdenesRestock
                        SET estado        = @estado,
                            fechaAtendida = CASE WHEN @estado IN ('RECIBIDA','CANCELADA')
                                                 THEN GETDATE() ELSE fechaAtendida END,
                            notas         = @notas
                        WHERE idorden = @id", con);

                    cmd.Parameters.AddWithValue("@estado", nuevoEstado);
                    cmd.Parameters.AddWithValue("@notas",  (object)notas ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@id",     idOrden);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                return (true, $"Orden marcada como {nuevoEstado}.");
            }
            catch (SqlException ex)
            {
                return (false, "Error: " + ex.Message);
            }
        }

        // ── RELACIÓN PRODUCTO ↔ PROVEEDOR ────────────────────────────

        /// <summary>Asigna un proveedor a un producto.</summary>
        public (bool ok, string msg) AsignarProveedor(int idProducto, int idProveedor)
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    // idProveedor = 0 significa quitar el proveedor (NULL)
                    SqlCommand cmd = new SqlCommand(
                        "UPDATE Inv_Productos SET idproveedor = @idprov WHERE ProductoID = @idprod", con);
                    cmd.Parameters.AddWithValue("@idprov",
                        idProveedor > 0 ? (object)idProveedor : DBNull.Value);
                    cmd.Parameters.AddWithValue("@idprod", idProducto);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                return (true, "Proveedor asignado correctamente.");
            }
            catch (SqlException ex)
            {
                return (false, "Error: " + ex.Message);
            }
        }

        /// <summary>Obtiene el proveedor asignado a un producto.</summary>
        public DataTable ObtenerProveedorDeProducto(int idProducto)
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter(@"
                    SELECT pr.idproveedor, pr.nombre, pr.contacto, pr.telefono, pr.correo
                    FROM   Productos p
                    JOIN   Proveedores pr ON pr.idproveedor = p.idproveedor
                    WHERE  p.ProductoID = @id", con);
                da.SelectCommand.Parameters.AddWithValue("@id", idProducto);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
