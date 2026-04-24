using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CapaDatos;

using Categoria = CapaDatos.Categoria;
using Producto = CapaDatos.Producto;
using Equipo = CapaDatos.Equipo;
using Movimiento = CapaDatos.Movimiento;
using Defecto = CapaDatos.Defecto;
using AlertaInventario = CapaDatos.AlertaInventario;

namespace ClaseNegocio
{
    public class InventarioBL
    {
        private readonly InventarioDAO _dao = new InventarioDAO();

        // ════════════════════════════════════════════════════════════
        //  CATEGORÍAS
        // ════════════════════════════════════════════════════════════
        public List<Categoria> ObtenerCategoriasProducto() => _dao.ObtenerCategorias("PRODUCTO");
        public List<Categoria> ObtenerCategoriasEquipo() => _dao.ObtenerCategorias("EQUIPO");

        // ════════════════════════════════════════════════════════════
        //  PRODUCTOS
        // ════════════════════════════════════════════════════════════
        public List<Producto> ObtenerProductos(int? categoriaID = null) =>
            _dao.ObtenerProductos(categoriaID);

        public Producto BuscarPorCodigoBarras(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                throw new ArgumentException("El código de barras no puede estar vacío.");

            // Solo buscar entre productos ACTIVOS
            return _dao.ObtenerProductoPorCodigoActivo(codigo.Trim());
        }

        public (bool ok, string mensaje, int id) AltaProducto(Producto p)
        {
            try
            {
                Validar(p);

                // Verificar duplicado SOLO entre productos activos
                if (_dao.CodigoExisteActivo(p.Codigo))
                    return (false, $"Ya existe un producto activo con el código '{p.Codigo}'.", 0);

                int id = _dao.InsertarProducto(p);
                return (true, "Producto registrado correctamente.", id);
            }
            catch (ArgumentException ex) { return (false, ex.Message, 0); }
            catch (SqlException ex) { return (false, $"Error de base de datos: {ex.Message}", 0); }
        }

        public (bool ok, string mensaje) ActualizarProducto(Producto p)
        {
            try
            {
                Validar(p);
                bool ok = _dao.ActualizarProducto(p);
                return ok
                    ? (true, "Producto actualizado correctamente.")
                    : (false, "No se encontró el producto a actualizar.");
            }
            catch (ArgumentException ex) { return (false, ex.Message); }
            catch (SqlException ex) { return (false, $"Error de base de datos: {ex.Message}"); }
        }

        public (bool ok, string mensaje) BajaProducto(int productoID)
        {
            try
            {
                bool ok = _dao.EliminarProducto(productoID);
                return ok
                    ? (true, "Producto dado de baja correctamente.")
                    : (false, "No se encontró el producto.");
            }
            catch (SqlException ex) { return (false, $"Error de base de datos: {ex.Message}"); }
        }

        // ════════════════════════════════════════════════════════════
        //  GENERACIÓN DE CÓDIGO EAN-13
        // ════════════════════════════════════════════════════════════
        /// <summary>
        /// Genera un código EAN-13 único que no colisione con ningún producto
        /// (activo o inactivo) en la BD.
        /// Prefijo 750 (México) + 9 dígitos aleatorios + dígito verificador.
        /// </summary>
        public string GenerarCodigoEAN13Unico()
        {
            var rnd = new Random();
            string codigo;
            int intentos = 0;

            do
            {
                // 750 (prefijo México) + 9 dígitos
                string base12 = "750" + rnd.Next(100000000, 999999999).ToString();
                codigo = base12 + CalcularDigitoEAN13(base12);
                intentos++;

                if (intentos > 100)
                    throw new Exception("No se pudo generar un código único tras 100 intentos.");

            } while (_dao.CodigoExisteCualquier(codigo)); // evitar colisión con activos E inactivos

            return codigo;
        }

        /// <summary>Calcula el dígito verificador EAN-13.</summary>
        private string CalcularDigitoEAN13(string base12)
        {
            int suma = 0;
            for (int i = 0; i < 12; i++)
                suma += (base12[i] - '0') * (i % 2 == 0 ? 1 : 3);
            int digito = (10 - (suma % 10)) % 10;
            return digito.ToString();
        }

        // ════════════════════════════════════════════════════════════
        //  EQUIPO
        // ════════════════════════════════════════════════════════════
        public List<Equipo> ObtenerEquipos(string estado = null) => _dao.ObtenerEquipos(estado);

        public (bool ok, string mensaje, int id) AltaEquipo(Equipo e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(e.Nombre))
                    throw new ArgumentException("El nombre del equipo es obligatorio.");
                int id = _dao.InsertarEquipo(e);
                return (true, "Equipo registrado correctamente.", id);
            }
            catch (ArgumentException ex) { return (false, ex.Message, 0); }
            catch (SqlException ex) { return (false, $"Error de base de datos: {ex.Message}", 0); }
        }

        public (bool ok, string mensaje) ActualizarEquipo(Equipo e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(e.Nombre))
                    throw new ArgumentException("El nombre del equipo es obligatorio.");
                bool ok = _dao.ActualizarEquipo(e);
                return ok
                    ? (true, "Equipo actualizado correctamente.")
                    : (false, "No se encontró el equipo a actualizar.");
            }
            catch (ArgumentException ex) { return (false, ex.Message); }
            catch (SqlException ex) { return (false, $"Error de base de datos: {ex.Message}"); }
        }

        public (bool ok, string mensaje) BajaEquipo(int equipoID)
        {
            try
            {
                bool ok = _dao.EliminarEquipo(equipoID);
                return ok
                    ? (true, "Equipo dado de baja correctamente.")
                    : (false, "No se encontró el equipo.");
            }
            catch (SqlException ex) { return (false, $"Error de base de datos: {ex.Message}"); }
        }

        // ════════════════════════════════════════════════════════════
        //  MOVIMIENTOS
        // ════════════════════════════════════════════════════════════
        public (bool ok, string mensaje) RegistrarEntrada(int productoID, int cantidad,
                                                           string motivo, int usuarioID)
        {
            try
            {
                if (cantidad <= 0) return (false, "La cantidad debe ser mayor a cero.");
                _dao.RegistrarMovimiento(productoID, "E", cantidad, motivo, usuarioID);
                return (true, $"Entrada de {cantidad} unidad(es) registrada correctamente.");
            }
            catch (SqlException ex) { return (false, $"Error: {ex.Message}"); }
        }

        public (bool ok, string mensaje) RegistrarSalida(int productoID, int cantidad,
                                                          string motivo, int usuarioID)
        {
            try
            {
                if (cantidad <= 0) return (false, "La cantidad debe ser mayor a cero.");
                _dao.RegistrarMovimiento(productoID, "S", cantidad, motivo, usuarioID);
                return (true, $"Salida de {cantidad} unidad(es) registrada correctamente.");
            }
            catch (SqlException ex)
            {
                return (false, ex.Message.Contains("Stock insuficiente")
                    ? ex.Message : $"Error: {ex.Message}");
            }
        }

        public (bool ok, string mensaje) RegistrarVenta(int productoID, int cantidad,
                                                         string motivo, int usuarioID)
        {
            try
            {
                if (cantidad <= 0) return (false, "La cantidad debe ser mayor a cero.");
                _dao.RegistrarMovimiento(productoID, "S", cantidad, motivo, usuarioID, esVenta: true);
                return (true, $"Venta de {cantidad} unidad(es) registrada. Precios ajustados.");
            }
            catch (SqlException ex)
            {
                return (false, ex.Message.Contains("Stock insuficiente")
                    ? ex.Message : $"Error: {ex.Message}");
            }
        }

        public List<Movimiento> ObtenerHistorial(int? productoID = null,
                                                  DateTime? desde = null,
                                                  DateTime? hasta = null) =>
            _dao.ObtenerHistorial(productoID, desde, hasta);

        // ════════════════════════════════════════════════════════════
        //  DEFECTOS
        // ════════════════════════════════════════════════════════════
        public (bool ok, string mensaje) RegistrarDefecto(Defecto d)
        {
            try
            {
                if (d.ProductoID <= 0) return (false, "Selecciona un producto.");
                if (string.IsNullOrWhiteSpace(d.Descripcion))
                    return (false, "La descripción es obligatoria.");
                if (d.CantidadAfectada <= 0) return (false, "La cantidad debe ser mayor a cero.");

                bool ok = _dao.RegistrarDefecto(d);
                return ok ? (true, "Defecto registrado.") : (false, "No se pudo registrar.");
            }
            catch (SqlException ex) { return (false, $"Error: {ex.Message}"); }
        }

        public List<Defecto> ObtenerDefectos(int? productoID = null) =>
            _dao.ObtenerDefectos(productoID);

        // ════════════════════════════════════════════════════════════
        //  ALERTAS
        // ════════════════════════════════════════════════════════════
        public List<AlertaInventario> ObtenerAlertasPendientes() =>
            _dao.ObtenerAlertas(soloNoAtendidas: true);

        public (bool ok, string mensaje) AtenderAlerta(int alertaID)
        {
            try
            {
                bool ok = _dao.AtenderAlerta(alertaID);
                return ok
                    ? (true, "Alerta marcada como atendida.")
                    : (false, "No se encontró la alerta.");
            }
            catch (SqlException ex) { return (false, $"Error: {ex.Message}"); }
        }

        // ════════════════════════════════════════════════════════════
        //  VALIDACIÓN INTERNA
        // ════════════════════════════════════════════════════════════
        private void Validar(Producto p)
        {
            // Solo validar código al crear (ProductoID == 0)
            if (p.ProductoID == 0 && string.IsNullOrWhiteSpace(p.Codigo))
                throw new ArgumentException("El código de barras es obligatorio.");
            if (string.IsNullOrWhiteSpace(p.Nombre))
                throw new ArgumentException("El nombre del producto es obligatorio.");
            if (p.CategoriaID <= 0)
                throw new ArgumentException("Selecciona una categoría.");
            if (p.Precio < 0)
                throw new ArgumentException("El precio no puede ser negativo.");
            if (p.StockMinimo < 0)
                throw new ArgumentException("El stock mínimo no puede ser negativo.");
        }
    }
}