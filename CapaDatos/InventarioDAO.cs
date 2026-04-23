using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class InventarioDAO
    {
        // ════════════════════════════════════════════════════════════
        //  CATEGORÍAS
        // ════════════════════════════════════════════════════════════
        public List<Categoria> ObtenerCategorias(string tipoArea = null)
        {
            var lista = new List<Categoria>();
            using (var con = Conexion.ObtenerConexion())
            {
                con.Open();
                string sql = tipoArea == null
                    ? "SELECT CategoriaID, Nombre, TipoArea, Activo FROM Inv_Categorias WHERE Activo = 1"
                    : "SELECT CategoriaID, Nombre, TipoArea, Activo FROM Inv_Categorias WHERE Activo = 1 AND TipoArea = @Tipo";

                using (var cmd = new SqlCommand(sql, con))
                {
                    if (tipoArea != null)
                        cmd.Parameters.AddWithValue("@Tipo", tipoArea);

                    using (var dr = cmd.ExecuteReader())
                        while (dr.Read())
                            lista.Add(new Categoria
                            {
                                CategoriaID = (int)dr["CategoriaID"],
                                Nombre = dr["Nombre"].ToString(),
                                TipoArea = dr["TipoArea"].ToString(),
                                Activo = (bool)dr["Activo"]
                            });
                }
            }
            return lista;
        }

        // ════════════════════════════════════════════════════════════
        //  PRODUCTOS
        // ════════════════════════════════════════════════════════════
        public List<Producto> ObtenerProductos(int? categoriaID = null)
        {
            var lista = new List<Producto>();
            using (var con = Conexion.ObtenerConexion())
            {
                con.Open();
                string sql = @"
                    SELECT p.ProductoID, p.Codigo, p.Nombre, p.CategoriaID,
                           c.Nombre AS CategoriaNombre,
                           p.Precio, p.StockActual, p.StockMinimo,
                           p.FechaCaducidad, p.Activo, p.FechaRegistro,
                           p.id_proveedor, pr.nombre AS ProveedorNombre
                    FROM   Inv_Productos p
                    JOIN   Inv_Categorias c  ON p.CategoriaID   = c.CategoriaID
                    LEFT JOIN Proveedores pr ON p.id_proveedor  = pr.id_proveedor
                    WHERE  p.Activo = 1"
                    + (categoriaID.HasValue ? " AND p.CategoriaID = @CatID" : "")
                    + " ORDER BY c.Nombre, p.Nombre";

                using (var cmd = new SqlCommand(sql, con))
                {
                    if (categoriaID.HasValue)
                        cmd.Parameters.AddWithValue("@CatID", categoriaID.Value);

                    using (var dr = cmd.ExecuteReader())
                        while (dr.Read())
                            lista.Add(MapearProducto(dr));
                }
            }
            return lista;
        }

        public Producto ObtenerProductoPorCodigo(string codigo)
        {
            using (var con = Conexion.ObtenerConexion())
            {
                con.Open();
                string sql = @"
                    SELECT p.ProductoID, p.Codigo, p.Nombre, p.CategoriaID,
                           c.Nombre AS CategoriaNombre,
                           p.Precio, p.StockActual, p.StockMinimo,
                           p.FechaCaducidad, p.Activo, p.FechaRegistro,
                           p.id_proveedor, pr.nombre AS ProveedorNombre
                    FROM   Inv_Productos p
                    JOIN   Inv_Categorias c  ON p.CategoriaID  = c.CategoriaID
                    LEFT JOIN Proveedores pr ON p.id_proveedor = pr.id_proveedor
                    WHERE  p.Codigo = @Codigo";

                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Codigo", codigo);
                    using (var dr = cmd.ExecuteReader())
                        if (dr.Read()) return MapearProducto(dr);
                }
            }
            return null;
        }


        /// <summary>Busca un producto ACTIVO por código.</summary>
        public Producto ObtenerProductoPorCodigoActivo(string codigo)
        {
            using (var con = Conexion.ObtenerConexion())
            {
                con.Open();
                string sql = @"
            SELECT p.ProductoID, p.Codigo, p.Nombre, p.CategoriaID,
                   c.Nombre AS CategoriaNombre,
                   p.Precio, p.StockActual, p.StockMinimo,
                   p.FechaCaducidad, p.Activo, p.FechaRegistro,
                   p.id_proveedor, pr.nombre AS ProveedorNombre
            FROM   Inv_Productos p
            JOIN   Inv_Categorias c  ON p.CategoriaID  = c.CategoriaID
            LEFT JOIN Proveedores pr ON p.id_proveedor = pr.id_proveedor
            WHERE  p.Codigo = @Codigo AND p.Activo = 1";

                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Codigo", codigo);
                    using (var dr = cmd.ExecuteReader())
                        if (dr.Read()) return MapearProducto(dr);
                }
            }
            return null;
        }

        /// <summary>Verifica si el código existe entre productos ACTIVOS solamente.</summary>
        public bool CodigoExisteActivo(string codigo)
        {
            using (var con = Conexion.ObtenerConexion())
            {
                con.Open();
                using (var cmd = new SqlCommand(
                    "SELECT COUNT(1) FROM Inv_Productos WHERE Codigo = @c AND Activo = 1", con))
                {
                    cmd.Parameters.AddWithValue("@c", codigo);
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
        }

        /// <summary>Verifica si el código existe en CUALQUIER producto (activo o no) — para EAN-13 único.</summary>
        public bool CodigoExisteCualquier(string codigo)
        {
            using (var con = Conexion.ObtenerConexion())
            {
                con.Open();
                using (var cmd = new SqlCommand(
                    "SELECT COUNT(1) FROM Inv_Productos WHERE Codigo = @c", con))
                {
                    cmd.Parameters.AddWithValue("@c", codigo);
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
        }

        public int InsertarProducto(Producto p)
        {
            using (var con = Conexion.ObtenerConexion())
            {
                con.Open();
                string sql = @"
                    INSERT INTO Inv_Productos
                        (Codigo, Nombre, CategoriaID, Precio, StockActual, StockMinimo,
                         FechaCaducidad, id_proveedor)
                    OUTPUT INSERTED.ProductoID
                    VALUES
                        (@Codigo, @Nombre, @CatID, @Precio, @Stock, @StockMin,
                         @Caducidad, @IdProveedor)";

                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Codigo", p.Codigo);
                    cmd.Parameters.AddWithValue("@Nombre", p.Nombre);
                    cmd.Parameters.AddWithValue("@CatID", p.CategoriaID);
                    cmd.Parameters.AddWithValue("@Precio", p.Precio);
                    cmd.Parameters.AddWithValue("@Stock", p.StockActual);
                    cmd.Parameters.AddWithValue("@StockMin", p.StockMinimo);
                    cmd.Parameters.AddWithValue("@Caducidad",
                        p.FechaCaducidad.HasValue ? (object)p.FechaCaducidad.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@IdProveedor",
                        p.IdProveedor > 0 ? (object)p.IdProveedor : DBNull.Value);

                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public bool ActualizarProducto(Producto p)
        {
            using (var con = Conexion.ObtenerConexion())
            {
                con.Open();
                string sql = @"
                    UPDATE Inv_Productos SET
                        Nombre         = @Nombre,
                        CategoriaID    = @CatID,
                        Precio         = @Precio,
                        StockMinimo    = @StockMin,
                        FechaCaducidad = @Caducidad,
                        id_proveedor   = @IdProveedor
                    WHERE ProductoID   = @ID";

                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", p.Nombre);
                    cmd.Parameters.AddWithValue("@CatID", p.CategoriaID);
                    cmd.Parameters.AddWithValue("@Precio", p.Precio);
                    cmd.Parameters.AddWithValue("@StockMin", p.StockMinimo);
                    cmd.Parameters.AddWithValue("@Caducidad",
                        p.FechaCaducidad.HasValue ? (object)p.FechaCaducidad.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@IdProveedor",
                        p.IdProveedor > 0 ? (object)p.IdProveedor : DBNull.Value);
                    cmd.Parameters.AddWithValue("@ID", p.ProductoID);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool EliminarProducto(int productoID)
        {
            using (var con = Conexion.ObtenerConexion())
            {
                con.Open();
                string sql = "UPDATE Inv_Productos SET Activo = 0 WHERE ProductoID = @ID";
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@ID", productoID);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // ════════════════════════════════════════════════════════════
        //  EQUIPO
        // ════════════════════════════════════════════════════════════
        public List<Equipo> ObtenerEquipos(string estado = null)
        {
            var lista = new List<Equipo>();
            using (var con = Conexion.ObtenerConexion())
            {
                con.Open();
                string sql = @"
                    SELECT e.EquipoID, e.Nombre, e.CategoriaID,
                           c.Nombre AS CategoriaNombre,
                           e.Estado, e.FechaAdquisicion, e.Observaciones,
                           e.Activo, e.FechaRegistro
                    FROM   Inv_Equipo e
                    JOIN   Inv_Categorias c ON e.CategoriaID = c.CategoriaID
                    WHERE  e.Activo = 1"
                    + (estado != null ? " AND e.Estado = @Estado" : "")
                    + " ORDER BY c.Nombre, e.Nombre";

                using (var cmd = new SqlCommand(sql, con))
                {
                    if (estado != null)
                        cmd.Parameters.AddWithValue("@Estado", estado);

                    using (var dr = cmd.ExecuteReader())
                        while (dr.Read())
                            lista.Add(MapearEquipo(dr));
                }
            }
            return lista;
        }

        public int InsertarEquipo(Equipo e)
        {
            using (var con = Conexion.ObtenerConexion())
            {
                con.Open();
                string sql = @"
                    INSERT INTO Inv_Equipo
                        (Nombre, CategoriaID, Estado, FechaAdquisicion, Observaciones)
                    OUTPUT INSERTED.EquipoID
                    VALUES (@Nombre, @CatID, @Estado, @Fecha, @Obs)";

                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", e.Nombre);
                    cmd.Parameters.AddWithValue("@CatID", e.CategoriaID);
                    cmd.Parameters.AddWithValue("@Estado", e.Estado);
                    cmd.Parameters.AddWithValue("@Fecha",
                        e.FechaAdquisicion.HasValue ? (object)e.FechaAdquisicion.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@Obs",
                        e.Observaciones != null ? (object)e.Observaciones : DBNull.Value);

                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public bool ActualizarEquipo(Equipo e)
        {
            using (var con = Conexion.ObtenerConexion())
            {
                con.Open();
                string sql = @"
                    UPDATE Inv_Equipo SET
                        Nombre           = @Nombre,
                        CategoriaID      = @CatID,
                        Estado           = @Estado,
                        FechaAdquisicion = @Fecha,
                        Observaciones    = @Obs
                    WHERE EquipoID       = @ID";

                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", e.Nombre);
                    cmd.Parameters.AddWithValue("@CatID", e.CategoriaID);
                    cmd.Parameters.AddWithValue("@Estado", e.Estado);
                    cmd.Parameters.AddWithValue("@Fecha",
                        e.FechaAdquisicion.HasValue ? (object)e.FechaAdquisicion.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@Obs",
                        e.Observaciones != null ? (object)e.Observaciones : DBNull.Value);
                    cmd.Parameters.AddWithValue("@ID", e.EquipoID);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool EliminarEquipo(int equipoID)
        {
            using (var con = Conexion.ObtenerConexion())
            {
                con.Open();
                string sql = "UPDATE Inv_Equipo SET Activo = 0 WHERE EquipoID = @ID";
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@ID", equipoID);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // ════════════════════════════════════════════════════════════
        //  MOVIMIENTOS
        // ════════════════════════════════════════════════════════════
        public bool RegistrarMovimiento(int productoID, string tipo, int cantidad,
                                        string motivo, int usuarioID, bool esVenta = false)
        {
            string sp = tipo == "E" ? "sp_Inv_Entrada" : "sp_Inv_Salida";

            using (var con = Conexion.ObtenerConexion())
            {
                con.Open();
                using (var cmd = new SqlCommand(sp, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductoID", productoID);
                    cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@Motivo",
                        motivo != null ? (object)motivo : DBNull.Value);
                    cmd.Parameters.AddWithValue("@UsuarioID", usuarioID);

                    // sp_Inv_Salida acepta @EsVenta para el trigger de precios
                    if (tipo == "S")
                        cmd.Parameters.AddWithValue("@EsVenta", esVenta ? 1 : 0);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
        }

        public List<Movimiento> ObtenerHistorial(int? productoID = null,
                                                  DateTime? desde = null,
                                                  DateTime? hasta = null)
        {
            var lista = new List<Movimiento>();
            using (var con = Conexion.ObtenerConexion())
            {
                con.Open();
                string sql = @"
                    SELECT m.MovimientoID, m.ProductoID,
                           p.Nombre  AS ProductoNombre,
                           p.Codigo  AS ProductoCodigo,
                           c.Nombre  AS CategoriaNombre,
                           m.TipoMovimiento, m.Cantidad, m.Motivo,
                           m.FechaMovimiento, m.UsuarioID,
                           u.usuario AS UsuarioNombre
                    FROM   Inv_Movimientos m
                    JOIN   Inv_Productos   p ON m.ProductoID  = p.ProductoID
                    JOIN   Inv_Categorias  c ON p.CategoriaID = c.CategoriaID
                    JOIN   UsuariosSistema u ON m.UsuarioID   = u.id_usuario
                    WHERE  1 = 1"
                    + (productoID.HasValue ? " AND m.ProductoID        = @ProdID" : "")
                    + (desde.HasValue ? " AND m.FechaMovimiento  >= @Desde" : "")
                    + (hasta.HasValue ? " AND m.FechaMovimiento  <= @Hasta" : "")
                    + " ORDER BY m.FechaMovimiento DESC";

                using (var cmd = new SqlCommand(sql, con))
                {
                    if (productoID.HasValue) cmd.Parameters.AddWithValue("@ProdID", productoID.Value);
                    if (desde.HasValue) cmd.Parameters.AddWithValue("@Desde", desde.Value);
                    if (hasta.HasValue) cmd.Parameters.AddWithValue("@Hasta", hasta.Value);

                    using (var dr = cmd.ExecuteReader())
                        while (dr.Read())
                            lista.Add(new Movimiento
                            {
                                MovimientoID = (int)dr["MovimientoID"],
                                ProductoID = (int)dr["ProductoID"],
                                ProductoNombre = dr["ProductoNombre"].ToString(),
                                ProductoCodigo = dr["ProductoCodigo"].ToString(),
                                CategoriaNombre = dr["CategoriaNombre"].ToString(),
                                TipoMovimiento = dr["TipoMovimiento"].ToString(),
                                Cantidad = (int)dr["Cantidad"],
                                Motivo = dr["Motivo"] as string,
                                FechaMovimiento = (DateTime)dr["FechaMovimiento"],
                                UsuarioID = (int)dr["UsuarioID"],
                                UsuarioNombre = dr["UsuarioNombre"].ToString()
                            });
                }
            }
            return lista;
        }

        // ════════════════════════════════════════════════════════════
        //  DEFECTOS
        // ════════════════════════════════════════════════════════════
        public bool RegistrarDefecto(Defecto d)
        {
            using (var con = Conexion.ObtenerConexion())
            {
                con.Open();
                string sql = @"
                    INSERT INTO Inv_Defectos
                        (ProductoID, Descripcion, CantidadAfectada, UsuarioID)
                    VALUES (@ProdID, @Desc, @Cant, @UsrID)";

                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@ProdID", d.ProductoID);
                    cmd.Parameters.AddWithValue("@Desc", d.Descripcion);
                    cmd.Parameters.AddWithValue("@Cant", d.CantidadAfectada);
                    cmd.Parameters.AddWithValue("@UsrID", d.UsuarioID);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public List<Defecto> ObtenerDefectos(int? productoID = null)
        {
            var lista = new List<Defecto>();
            using (var con = Conexion.ObtenerConexion())
            {
                con.Open();
                string sql = @"
                    SELECT d.DefectoID, d.ProductoID,
                           p.Nombre  AS ProductoNombre,
                           p.Codigo  AS ProductoCodigo,
                           c.Nombre  AS CategoriaNombre,
                           d.Descripcion, d.CantidadAfectada,
                           d.FechaRegistro, d.UsuarioID,
                           u.usuario AS UsuarioNombre
                    FROM   Inv_Defectos    d
                    JOIN   Inv_Productos   p ON d.ProductoID  = p.ProductoID
                    JOIN   Inv_Categorias  c ON p.CategoriaID = c.CategoriaID
                    JOIN   UsuariosSistema u ON d.UsuarioID   = u.id_usuario"
                    + (productoID.HasValue ? " WHERE d.ProductoID = @ProdID" : "")
                    + " ORDER BY d.FechaRegistro DESC";

                using (var cmd = new SqlCommand(sql, con))
                {
                    if (productoID.HasValue)
                        cmd.Parameters.AddWithValue("@ProdID", productoID.Value);

                    using (var dr = cmd.ExecuteReader())
                        while (dr.Read())
                            lista.Add(new Defecto
                            {
                                DefectoID = (int)dr["DefectoID"],
                                ProductoID = (int)dr["ProductoID"],
                                ProductoNombre = dr["ProductoNombre"].ToString(),
                                ProductoCodigo = dr["ProductoCodigo"].ToString(),
                                CategoriaNombre = dr["CategoriaNombre"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                CantidadAfectada = (int)dr["CantidadAfectada"],
                                FechaRegistro = (DateTime)dr["FechaRegistro"],
                                UsuarioID = (int)dr["UsuarioID"],
                                UsuarioNombre = dr["UsuarioNombre"].ToString()
                            });
                }
            }
            return lista;
        }

        // ════════════════════════════════════════════════════════════
        //  ALERTAS
        // ════════════════════════════════════════════════════════════
        public List<AlertaInventario> ObtenerAlertas(bool soloNoAtendidas = true)
        {
            var lista = new List<AlertaInventario>();
            using (var con = Conexion.ObtenerConexion())
            {
                con.Open();
                string sql = @"
                    SELECT a.AlertaID, a.ProductoID,
                           p.Nombre AS Producto,
                           a.TipoAlerta, a.Mensaje, a.Atendida, a.FechaAlerta
                    FROM   Inv_Alertas   a
                    JOIN   Inv_Productos p ON a.ProductoID = p.ProductoID"
                    + (soloNoAtendidas ? " WHERE a.Atendida = 0" : "")
                    + " ORDER BY a.FechaAlerta DESC";

                using (var cmd = new SqlCommand(sql, con))
                using (var dr = cmd.ExecuteReader())
                    while (dr.Read())
                        lista.Add(new AlertaInventario
                        {
                            AlertaID = (int)dr["AlertaID"],
                            ProductoID = (int)dr["ProductoID"],
                            Producto = dr["Producto"].ToString(),
                            TipoAlerta = dr["TipoAlerta"].ToString(),
                            Mensaje = dr["Mensaje"].ToString(),
                            Atendida = (bool)dr["Atendida"],
                            FechaAlerta = (DateTime)dr["FechaAlerta"]
                        });
            }
            return lista;
        }

        public bool AtenderAlerta(int alertaID)
        {
            using (var con = Conexion.ObtenerConexion())
            {
                con.Open();
                string sql = "UPDATE Inv_Alertas SET Atendida = 1 WHERE AlertaID = @ID";
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@ID", alertaID);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // ════════════════════════════════════════════════════════════
        //  MAPEO
        // ════════════════════════════════════════════════════════════
        private Producto MapearProducto(SqlDataReader dr) => new Producto
        {
            ProductoID = (int)dr["ProductoID"],
            Codigo = dr["Codigo"].ToString(),
            Nombre = dr["Nombre"].ToString(),
            CategoriaID = (int)dr["CategoriaID"],
            CategoriaNombre = dr["CategoriaNombre"].ToString(),
            Precio = (decimal)dr["Precio"],
            StockActual = (int)dr["StockActual"],
            StockMinimo = (int)dr["StockMinimo"],
            FechaCaducidad = dr["FechaCaducidad"] as DateTime?,
            Activo = (bool)dr["Activo"],
            FechaRegistro = (DateTime)dr["FechaRegistro"],
            IdProveedor = dr["id_proveedor"] == DBNull.Value ? 0 : (int)dr["id_proveedor"],
            ProveedorNombre = dr["ProveedorNombre"] as string
        };

        private Equipo MapearEquipo(SqlDataReader dr) => new Equipo
        {
            EquipoID = (int)dr["EquipoID"],
            Nombre = dr["Nombre"].ToString(),
            CategoriaID = (int)dr["CategoriaID"],
            CategoriaNombre = dr["CategoriaNombre"].ToString(),
            Estado = dr["Estado"].ToString(),
            FechaAdquisicion = dr["FechaAdquisicion"] as DateTime?,
            Observaciones = dr["Observaciones"] as string,
            Activo = (bool)dr["Activo"],
            FechaRegistro = (DateTime)dr["FechaRegistro"]
        };
    }
}