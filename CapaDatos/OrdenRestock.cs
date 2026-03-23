using System;

namespace CapaDatos
{
    public class OrdenRestock
    {
        public int      IdOrden          { get; set; }
        public string   Estado           { get; set; }   // PENDIENTE|ENVIADA|RECIBIDA|CANCELADA
        public DateTime FechaGenerada    { get; set; }
        public DateTime? FechaAtendida   { get; set; }
        public int      CantidadSolicit  { get; set; }
        public int      StockAlMomento   { get; set; }
        public int      StockMinimo      { get; set; }
        public string   Notas            { get; set; }

        // Datos del producto (desde la vista)
        public string   Producto         { get; set; }
        public string   CodigoProducto   { get; set; }
        public int      StockActual      { get; set; }

        // Datos del proveedor (desde la vista)
        public string   Proveedor        { get; set; }
        public string   TelProveedor     { get; set; }
        public string   CorreoProveedor  { get; set; }
        public string   ContactoProveedor{ get; set; }
    }
}
