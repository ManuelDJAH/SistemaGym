using System;

namespace CapaDatos
{
    // ================================================================
    //  CATEGORÍA
    // ================================================================
    public class Categoria
    {
        public int CategoriaID { get; set; }
        public string Nombre { get; set; }
        public string TipoArea { get; set; }  // "PRODUCTO" | "EQUIPO"
        public bool Activo { get; set; }

        public override string ToString() => Nombre;
    }

    // ================================================================
    //  PRODUCTO  (Proteína, Creatina, Colágeno)
    // ================================================================
    public class Producto
    {
        public int ProductoID { get; set; }
        public string Codigo { get; set; }  // Código de barras
        public string Nombre { get; set; }
        public int CategoriaID { get; set; }
        public string CategoriaNombre { get; set; }  // Solo lectura (JOIN)
        public decimal Precio { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public DateTime? FechaCaducidad { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdProveedor { get; set; }
        public string ProveedorNombre { get; set; }  // Solo lectura (JOIN)


        // Propiedad calculada para mostrar en UI
        public string EstadoAlerta
        {
            get
            {
                if (StockActual <= StockMinimo)
                    return "STOCK_BAJO";
                if (FechaCaducidad.HasValue &&
                    FechaCaducidad.Value <= DateTime.Today.AddDays(30))
                    return "POR_CADUCAR";
                return "OK";
            }
        }

        public override string ToString() => Nombre;
    }

    // ================================================================
    //  EQUIPO  (Mancuernas, ligas, etc.)
    // ================================================================
    public class Equipo
    {
        public int EquipoID { get; set; }
        public string Nombre { get; set; }
        public int CategoriaID { get; set; }
        public string CategoriaNombre { get; set; }
        public string Estado { get; set; }  // BUENO | DAÑADO | BAJA
        public DateTime? FechaAdquisicion { get; set; }
        public string Observaciones { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaRegistro { get; set; }

        public override string ToString() => Nombre;
    }

    // ================================================================
    //  MOVIMIENTO DE INVENTARIO  (Entrada / Salida)
    // ================================================================
    public class Movimiento
    {
        public int MovimientoID { get; set; }
        public int ProductoID { get; set; }
        public string ProductoNombre { get; set; }
        public string ProductoCodigo { get; set; }
        public string CategoriaNombre { get; set; }
        public string TipoMovimiento { get; set; }  // "E" | "S"
        public string TipoDescripcion => TipoMovimiento == "E" ? "Entrada" : "Salida";
        public int Cantidad { get; set; }
        public string Motivo { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public int UsuarioID { get; set; }
        public string UsuarioNombre { get; set; }
    }

    // ================================================================
    //  DEFECTO
    // ================================================================
    public class Defecto
    {
        public int DefectoID { get; set; }
        public int ProductoID { get; set; }
        public string ProductoNombre { get; set; }
        public string ProductoCodigo { get; set; }
        public string CategoriaNombre { get; set; }
        public string Descripcion { get; set; }
        public int CantidadAfectada { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int UsuarioID { get; set; }
        public string UsuarioNombre { get; set; }
    }

    // ================================================================
    //  ALERTA DE INVENTARIO
    // ================================================================
    public class AlertaInventario
    {
        public int AlertaID { get; set; }
        public int ProductoID { get; set; }
        public string Producto { get; set; }
        public string TipoAlerta { get; set; }  // STOCK_BAJO | POR_CADUCAR
        public string Mensaje { get; set; }
        public bool Atendida { get; set; }
        public DateTime FechaAlerta { get; set; }

        public string TipoDescripcion =>
            TipoAlerta == "STOCK_BAJO" ? "⚠ Stock Bajo" : "📅 Por Caducar";
    }
}