using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CapaDatos;
using ClaseNegocio;

// Alias para evitar ambigüedad con los modelos en CapaDatos
using Categoria = CapaDatos.Categoria;
using Producto = CapaDatos.Producto;
using Equipo = CapaDatos.Equipo;
using Movimiento = CapaDatos.Movimiento;
using Defecto = CapaDatos.Defecto;
using AlertaInventario = CapaDatos.AlertaInventario;

namespace CapaPresentacion
{
    public partial class FrmInventario : Form
    {
        // Codigo de barras 
        private readonly CodigoBarrasBL _cbBL = new CodigoBarrasBL();
        // BL 
        private readonly InventarioBL _bl = new InventarioBL();

        // Estado de edición de Productos 
        private int _prodIDSeleccionado = 0;
        private bool _prodModoEdicion = false;

        //  Estado de edición de Equipo 
        private int _eqIDSeleccionado = 0;
        private bool _eqModoEdicion = false;

        // Producto encontrado en Movimientos 
        private Producto _prodMovimiento = null;

        // ════════════════════════════════════════════════════════════
        //  CONSTRUCTOR
        // ════════════════════════════════════════════════════════════
        public FrmInventario()
        {
            InitializeComponent();

            // Establecer splitter después de que el form tiene tamaño real
            this.Shown += (s, e) => {
                splitProductos.SplitterDistance = (int)(splitProductos.Width * 0.58);
                splitEquipo.SplitterDistance = (int)(splitEquipo.Width * 0.58);
            };

            CargarCatsFiltro();
            CargarProductos();
            CargarAlertasContador();
        }

        private void FrmInventario_Load(object sender, EventArgs e)
        {
            // Ya no se necesita aquí
        }

        // ════════════════════════════════════════════════════════════
        //  TAB CHANGE  — carga datos al cambiar de pestaña
        // ════════════════════════════════════════════════════════════
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl.SelectedIndex)
            {
                case 0: CargarProductos(); break;
                case 1: CargarEquipos(); break;
                case 2: PrepararMovimientos(); break;
                case 3: CargarHistorial(); break;
                case 4: CargarDefectos(); break;
                case 5: CargarAlertas(); break;
            }
        }

        // ════════════════════════════════════════════════════════════
        //  HELPERS GENERALES
        // ════════════════════════════════════════════════════════════
        private void CargarCatsFiltro()
        {
            if (cboProdCategoria == null) return;

            var cats = _bl.ObtenerCategoriasProducto();
            cboProdCategoria.DataSource = null;
            cboProdCategoria.DataSource = cats;
            cboProdCategoria.DisplayMember = "Nombre";
            cboProdCategoria.ValueMember = "CategoriaID";

            var catsProd = _bl.ObtenerCategoriasProducto();
            cboProdCat.DataSource = null;
            cboProdCat.DataSource = catsProd;
            cboProdCat.DisplayMember = "Nombre";
            cboProdCat.ValueMember = "CategoriaID";
        }

        // ════════════════════════════════════════════════════════════
        //  TAB 1 — PRODUCTOS
        // ════════════════════════════════════════════════════════════
        private void CargarProductos(int? catID = null)
        {
            if (dgvProductos == null) return;

            var lista = _bl.ObtenerProductos(catID);
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = lista;

            // Columnas visibles
            foreach (DataGridViewColumn col in dgvProductos.Columns)
                col.Visible = false;

            MostrarCol(dgvProductos, "Codigo", "Código", 80);
            MostrarCol(dgvProductos, "Nombre", "Nombre", 200);
            MostrarCol(dgvProductos, "CategoriaNombre", "Categoría", 100);
            MostrarCol(dgvProductos, "Precio", "Precio", 70);
            MostrarCol(dgvProductos, "StockActual", "Stock", 60);
            MostrarCol(dgvProductos, "StockMinimo", "Mín.", 50);
            MostrarCol(dgvProductos, "FechaCaducidad", "Caduca", 90);
            MostrarCol(dgvProductos, "EstadoAlerta", "Estado", 90);

            // Colorear filas según alerta
            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                string alerta = row.Cells["EstadoAlerta"].Value?.ToString();
                if (alerta == "STOCK_BAJO")
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 220, 220);
                else if (alerta == "POR_CADUCAR")
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 245, 190);
            }

            ProdModoLectura();
        }

        private void btnProdFiltrar_Click(object sender, EventArgs e)
        {
            if (cboProdCategoria.SelectedValue is int catID)
                CargarProductos(catID);
        }

        private void btnProdTodos_Click(object sender, EventArgs e) => CargarProductos();

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow?.DataBoundItem is Producto p)
            {
                _prodIDSeleccionado = p.ProductoID;
                txtProdCodigo.Text = p.Codigo;
                txtProdNombre.Text = p.Nombre;
                cboProdCat.SelectedValue = p.CategoriaID;
                txtProdPrecio.Text = p.Precio.ToString("F2");
                numProdStockMin.Value = p.StockMinimo;

                if (p.FechaCaducidad.HasValue)
                {
                    chkProdCaducidad.Checked = true;
                    dtpProdCaducidad.Value = p.FechaCaducidad.Value;
                }
                else
                {
                    chkProdCaducidad.Checked = false;
                    dtpProdCaducidad.Enabled = false;
                }

                btnProdEditar.Enabled = true;
                btnProdBaja.Enabled = true;
                _prodModoEdicion = false;
                ProdModoLectura();

                // ── Mostrar imagen del código de barras ──────────────
                MostrarCodigoBarras(p.Codigo);
            }
        }

        private void btnProdNuevo_Click(object sender, EventArgs e)
        {
            _prodIDSeleccionado = 0;
            _prodModoEdicion = false;
            LimpiarFormProd();
            ProdModoCaptura();
        }

        private void btnProdEditar_Click(object sender, EventArgs e)
        {
            if (_prodIDSeleccionado == 0) return;
            _prodModoEdicion = true;
            ProdModoCaptura();
            txtProdCodigo.ReadOnly = true; // El código no se puede cambiar
        }

        private void btnProdGuardar_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtProdPrecio.Text, out decimal precio))
            {
                MessageBox.Show("Ingresa un precio válido.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var p = new Producto
            {
                ProductoID = _prodIDSeleccionado,
                Codigo = txtProdCodigo.Text.Trim(),
                Nombre = txtProdNombre.Text.Trim(),
                CategoriaID = (int)cboProdCat.SelectedValue,
                Precio = precio,
                StockMinimo = (int)numProdStockMin.Value,
                FechaCaducidad = chkProdCaducidad.Checked ? dtpProdCaducidad.Value : (DateTime?)null
            };

            if (_prodModoEdicion)
            {
                var (ok, msg) = _bl.ActualizarProducto(p);
                MessageBox.Show(msg, ok ? "Éxito" : "Error",
                    MessageBoxButtons.OK,
                    ok ? MessageBoxIcon.Information : MessageBoxIcon.Error);
            }
            else
            {
                var (ok, msg, _) = _bl.AltaProducto(p);
                MessageBox.Show(msg, ok ? "Éxito" : "Error",
                    MessageBoxButtons.OK,
                    ok ? MessageBoxIcon.Information : MessageBoxIcon.Error);
            }

            CargarProductos();
        }

        private void btnProdBaja_Click(object sender, EventArgs e)
        {
            if (_prodIDSeleccionado == 0) return;
            var confirm = MessageBox.Show(
                "¿Dar de baja este producto? (baja lógica, no se elimina)",
                "Confirmar baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                var (ok, msg) = _bl.BajaProducto(_prodIDSeleccionado);
                MessageBox.Show(msg, ok ? "Éxito" : "Error",
                    MessageBoxButtons.OK,
                    ok ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                CargarProductos();
            }
        }

        private void btnProdCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormProd();
            ProdModoLectura();
        }

        private void MostrarCodigoBarras(string codigo)
        {
            if (picCodigoBarras == null) return;
            if (string.IsNullOrWhiteSpace(codigo)) { picCodigoBarras.Image = null; return; }

            var (ok, msg, bmp) = _cbBL.GenerarImagen(codigo);
            picCodigoBarras.Image = ok ? bmp : null;
            picCodigoBarras.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        }
        private void btnProdGenerarCodigo_Click(object sender, EventArgs e)
        {
            if (_prodIDSeleccionado == 0)
            {
                MessageBox.Show("Primero guarda el producto para generar su código.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Obtener categoría del producto seleccionado
            var prod = _bl.BuscarPorCodigoBarras(txtProdCodigo.Text);
            int catID = prod?.CategoriaID ?? 1;

            var (ok, msg, codigo) = _cbBL.GenerarYGuardarCodigo(_prodIDSeleccionado, catID);

            if (ok)
            {
                txtProdCodigo.Text = codigo;
                MostrarCodigoBarras(codigo);
                MessageBox.Show(msg, "Código generado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarProductos(); // Refrescar tabla
            }
            else
            {
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void chkProdCaducidad_CheckedChanged(object sender, EventArgs e)
        {
            dtpProdCaducidad.Enabled = chkProdCaducidad.Checked;
            lblProdCaducidad.Enabled = chkProdCaducidad.Checked;
        }

        private void btnProdEscanear_Click(object sender, EventArgs e)
        {
            // El foco va al txtProdCodigo para que el escáner escriba ahí
            txtProdCodigo.Clear();
            txtProdCodigo.Focus();
            MessageBox.Show(
                "Apunta el escáner al código de barras del producto.\n" +
                "El código aparecerá automáticamente en el campo.",
                "Escanear código", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Helpers productos
        private void ProdModoCaptura()
        {
            txtProdCodigo.ReadOnly = false;
            txtProdNombre.ReadOnly = false;
            txtProdPrecio.ReadOnly = false;
            cboProdCat.Enabled = true;
            numProdStockMin.Enabled = true;
            chkProdCaducidad.Enabled = true;
            btnProdGuardar.Enabled = true;
            btnProdCancelar.Enabled = true;
            btnProdNuevo.Enabled = false;
            btnProdEditar.Enabled = false;
            btnProdBaja.Enabled = false;
        }

        private void ProdModoLectura()
        {
            txtProdCodigo.ReadOnly = true;
            txtProdNombre.ReadOnly = true;
            txtProdPrecio.ReadOnly = true;
            cboProdCat.Enabled = false;
            numProdStockMin.Enabled = false;
            chkProdCaducidad.Enabled = false;
            dtpProdCaducidad.Enabled = false;
            btnProdGuardar.Enabled = false;
            btnProdCancelar.Enabled = false;
            btnProdNuevo.Enabled = true;
        }

        private void LimpiarFormProd()
        {
            _prodIDSeleccionado = 0;
            txtProdCodigo.Clear();
            txtProdNombre.Clear();
            txtProdPrecio.Text = "0.00";
            numProdStockMin.Value = 3;
            chkProdCaducidad.Checked = false;
            dtpProdCaducidad.Value = DateTime.Today;
            if (cboProdCat.Items.Count > 0) cboProdCat.SelectedIndex = 0;
        }

        // ════════════════════════════════════════════════════════════
        //  TAB 2 — EQUIPO
        // ════════════════════════════════════════════════════════════
        private void CargarEquipos(string estado = null)
        {
            var cats = _bl.ObtenerCategoriasEquipo();
            cboEqCat.DataSource = null;
            cboEqCat.DataSource = cats;
            cboEqCat.DisplayMember = "Nombre";
            cboEqCat.ValueMember = "CategoriaID";

            var lista = _bl.ObtenerEquipos(estado);
            dgvEquipo.DataSource = null;
            dgvEquipo.DataSource = lista;

            foreach (DataGridViewColumn col in dgvEquipo.Columns)
                col.Visible = false;

            MostrarCol(dgvEquipo, "Nombre", "Nombre", 220);
            MostrarCol(dgvEquipo, "CategoriaNombre", "Categoría", 130);
            MostrarCol(dgvEquipo, "Estado", "Estado", 90);
            MostrarCol(dgvEquipo, "FechaAdquisicion", "Adquisición", 100);
            MostrarCol(dgvEquipo, "Observaciones", "Observaciones", 200);

            // Colorear filas según estado
            foreach (DataGridViewRow row in dgvEquipo.Rows)
            {
                string est = row.Cells["Estado"].Value?.ToString();
                if (est == "DAÑADO")
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 245, 190);
                else if (est == "BAJA")
                    row.DefaultCellStyle.BackColor = Color.FromArgb(220, 220, 220);
            }

            EqModoLectura();
        }

        private void btnEqFiltrar_Click(object sender, EventArgs e)
        {
            if (cboEqFiltroEstado.SelectedItem is string estado)
                CargarEquipos(estado);
        }

        private void btnEqTodos_Click(object sender, EventArgs e) => CargarEquipos();

        private void dgvEquipo_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEquipo.CurrentRow?.DataBoundItem is Equipo eq)
            {
                _eqIDSeleccionado = eq.EquipoID;
                txtEqNombre.Text = eq.Nombre;
                cboEqCat.SelectedValue = eq.CategoriaID;
                cboEqEstado.Text = eq.Estado;
                txtEqObs.Text = eq.Observaciones ?? "";

                if (eq.FechaAdquisicion.HasValue)
                {
                    chkEqFecha.Checked = true;
                    dtpEqFecha.Value = eq.FechaAdquisicion.Value;
                }
                else
                    chkEqFecha.Checked = false;

                btnEqEditar.Enabled = true;
                btnEqBaja.Enabled = true;
                EqModoLectura();
            }
        }

        private void btnEqNuevo_Click(object sender, EventArgs e)
        {
            _eqIDSeleccionado = 0;
            _eqModoEdicion = false;
            LimpiarFormEq();
            EqModoCaptura();
        }

        private void btnEqEditar_Click(object sender, EventArgs e)
        {
            if (_eqIDSeleccionado == 0) return;
            _eqModoEdicion = true;
            EqModoCaptura();
        }

        private void btnEqGuardar_Click(object sender, EventArgs e)
        {
            var eq = new Equipo
            {
                EquipoID = _eqIDSeleccionado,
                Nombre = txtEqNombre.Text.Trim(),
                CategoriaID = (int)cboEqCat.SelectedValue,
                Estado = cboEqEstado.SelectedItem?.ToString() ?? "BUENO",
                FechaAdquisicion = chkEqFecha.Checked ? dtpEqFecha.Value : (DateTime?)null,
                Observaciones = string.IsNullOrWhiteSpace(txtEqObs.Text) ? null : txtEqObs.Text.Trim()
            };

            if (_eqModoEdicion)
            {
                var (ok, msg) = _bl.ActualizarEquipo(eq);
                MessageBox.Show(msg, ok ? "Éxito" : "Error",
                    MessageBoxButtons.OK,
                    ok ? MessageBoxIcon.Information : MessageBoxIcon.Error);
            }
            else
            {
                var (ok, msg, _) = _bl.AltaEquipo(eq);
                MessageBox.Show(msg, ok ? "Éxito" : "Error",
                    MessageBoxButtons.OK,
                    ok ? MessageBoxIcon.Information : MessageBoxIcon.Error);
            }

            CargarEquipos();
        }

        private void btnEqBaja_Click(object sender, EventArgs e)
        {
            if (_eqIDSeleccionado == 0) return;
            var confirm = MessageBox.Show(
                "¿Dar de baja este equipo?",
                "Confirmar baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                var (ok, msg) = _bl.BajaEquipo(_eqIDSeleccionado);
                MessageBox.Show(msg, ok ? "Éxito" : "Error",
                    MessageBoxButtons.OK,
                    ok ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                CargarEquipos();
            }
        }

        private void btnEqCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormEq();
            EqModoLectura();
        }

        private void chkEqFecha_CheckedChanged(object sender, EventArgs e)
        {
            dtpEqFecha.Enabled = chkEqFecha.Checked;
            lblEqFecha.Enabled = chkEqFecha.Checked;
        }

        private void EqModoCaptura()
        {
            txtEqNombre.ReadOnly = false;
            cboEqCat.Enabled = true;
            cboEqEstado.Enabled = true;
            chkEqFecha.Enabled = true;
            txtEqObs.ReadOnly = false;
            btnEqGuardar.Enabled = true;
            btnEqCancelar.Enabled = true;
            btnEqNuevo.Enabled = false;
            btnEqEditar.Enabled = false;
            btnEqBaja.Enabled = false;
        }

        private void EqModoLectura()
        {
            txtEqNombre.ReadOnly = true;
            cboEqCat.Enabled = false;
            cboEqEstado.Enabled = false;
            chkEqFecha.Enabled = false;
            dtpEqFecha.Enabled = false;
            txtEqObs.ReadOnly = true;
            btnEqGuardar.Enabled = false;
            btnEqCancelar.Enabled = false;
            btnEqNuevo.Enabled = true;
        }

        private void LimpiarFormEq()
        {
            _eqIDSeleccionado = 0;
            txtEqNombre.Clear();
            txtEqObs.Clear();
            chkEqFecha.Checked = false;
            dtpEqFecha.Value = DateTime.Today;
            if (cboEqCat.Items.Count > 0) cboEqCat.SelectedIndex = 0;
            if (cboEqEstado.Items.Count > 0) cboEqEstado.SelectedIndex = 0;
        }

        // ════════════════════════════════════════════════════════════
        //  TAB 3 — MOVIMIENTOS
        // ════════════════════════════════════════════════════════════
        private void PrepararMovimientos()
        {
            LimpiarMovimiento();
            txtMovCodigo.Focus();
        }

        private void txtMovCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            // Enter o Tab dispara la búsqueda (comportamiento natural del escáner)
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                BuscarProductoMovimiento();
        }

        private void btnMovBuscar_Click(object sender, EventArgs e) =>
            BuscarProductoMovimiento();

        private void BuscarProductoMovimiento()
        {
            string codigo = txtMovCodigo.Text.Trim();
            if (string.IsNullOrEmpty(codigo)) return;

            _prodMovimiento = _bl.BuscarPorCodigoBarras(codigo);

            if (_prodMovimiento == null)
            {
                txtMovProducto.Text = "❌ Producto no encontrado";
                txtMovStock.Text = "";
                lblMovAlerta.Visible = false;
                return;
            }

            txtMovProducto.Text = _prodMovimiento.Nombre + " — " + _prodMovimiento.CategoriaNombre;
            txtMovStock.Text = _prodMovimiento.StockActual.ToString();

            // Mostrar alerta si stock ya está bajo
            if (_prodMovimiento.EstadoAlerta == "STOCK_BAJO")
            {
                lblMovAlerta.Text = $"⚠ Stock bajo (mínimo: {_prodMovimiento.StockMinimo})";
                lblMovAlerta.Visible = true;
            }
            else
            {
                lblMovAlerta.Visible = false;
            }
        }

        private void btnMovRegistrar_Click(object sender, EventArgs e)
        {
            if (_prodMovimiento == null)
            {
                MessageBox.Show("Primero busca un producto por código.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tipo = rbMovEntrada.Checked ? "E" : "S";
            int cantidad = (int)numMovCantidad.Value;
            string motivo = txtMovMotivo.Text.Trim();

            if (tipo == "E")
            {
                // Entrada normal — sin ajuste de precios
                var (ok, msg) = _bl.RegistrarEntrada(
                    _prodMovimiento.ProductoID, cantidad, motivo, Sesion.IdUsuario);

                MessageBox.Show(msg, ok ? "Entrada registrada" : "Error",
                    MessageBoxButtons.OK,
                    ok ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (ok) LimpiarMovimiento();
            }
            else
            {
                // Salida — preguntar si es venta (ajusta precios) o salida normal
                var resp = MessageBox.Show(
                    "¿Esta salida es una VENTA?\n\n" +
                    "• SÍ → registra venta y ajusta precios (+10% este producto, -10% resto)\n" +
                    "• NO → salida normal sin cambio de precios",
                    "Tipo de salida",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                bool esVenta = (resp == DialogResult.Yes);
                bool ok; string msg;

                if (esVenta)
                {
                    (ok, msg) = _cbBL.RegistrarVentaConAjustePrecio(
                        _prodMovimiento.ProductoID, cantidad, motivo, Sesion.IdUsuario);
                }
                else
                {
                    (ok, msg) = _bl.RegistrarSalida(
                        _prodMovimiento.ProductoID, cantidad, motivo, Sesion.IdUsuario);
                }

                MessageBox.Show(msg, ok ? "Salida registrada" : "Error",
                    MessageBoxButtons.OK,
                    ok ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (ok) LimpiarMovimiento();
            }
        }

        private void btnMovLimpiar_Click(object sender, EventArgs e) => LimpiarMovimiento();

        private void LimpiarMovimiento()
        {
            _prodMovimiento = null;
            txtMovCodigo.Clear();
            txtMovProducto.Clear();
            txtMovStock.Clear();
            txtMovMotivo.Clear();
            numMovCantidad.Value = 1;
            rbMovEntrada.Checked = true;
            lblMovAlerta.Visible = false;
        }

        // ════════════════════════════════════════════════════════════
        //  TAB 4 — HISTORIAL
        // ════════════════════════════════════════════════════════════
        private void CargarHistorial(int? prodID = null, DateTime? desde = null, DateTime? hasta = null)
        {
            // Llenar combo de productos si está vacío
            if (cboHistProd.Items.Count == 0)
            {
                var prods = _bl.ObtenerProductos();
                cboHistProd.Items.Add(new { ProductoID = (int?)null, Nombre = "(Todos)" });
                foreach (var p in prods)
                    cboHistProd.Items.Add(new { ProductoID = (int?)p.ProductoID, Nombre = p.Nombre });
                cboHistProd.DisplayMember = "Nombre";
                cboHistProd.ValueMember = "ProductoID";
                cboHistProd.SelectedIndex = 0;
            }

            var lista = _bl.ObtenerHistorial(prodID, desde, hasta);
            dgvHistorial.DataSource = null;
            dgvHistorial.DataSource = lista;

            foreach (DataGridViewColumn col in dgvHistorial.Columns)
                col.Visible = false;

            MostrarCol(dgvHistorial, "FechaMovimiento", "Fecha", 130);
            MostrarCol(dgvHistorial, "ProductoCodigo", "Código", 80);
            MostrarCol(dgvHistorial, "ProductoNombre", "Producto", 200);
            MostrarCol(dgvHistorial, "TipoDescripcion", "Tipo", 70);
            MostrarCol(dgvHistorial, "Cantidad", "Cantidad", 70);
            MostrarCol(dgvHistorial, "Motivo", "Motivo", 180);
            MostrarCol(dgvHistorial, "UsuarioNombre", "Registró", 110);

            // Colorear filas
            foreach (DataGridViewRow row in dgvHistorial.Rows)
            {
                string tipo = row.Cells["TipoDescripcion"].Value?.ToString();
                row.DefaultCellStyle.BackColor = tipo == "Entrada"
                    ? Color.FromArgb(220, 255, 220)
                    : Color.FromArgb(255, 220, 220);
            }
        }

        private void btnHistBuscar_Click(object sender, EventArgs e)
        {
            int? prodID = null;
            dynamic sel = cboHistProd.SelectedItem;
            if (sel?.ProductoID != null) prodID = (int?)sel.ProductoID;

            CargarHistorial(prodID, dtpHistDesde.Value.Date, dtpHistHasta.Value.Date.AddDays(1));
        }

        private void btnHistTodos_Click(object sender, EventArgs e)
        {
            cboHistProd.SelectedIndex = 0;
            CargarHistorial();
        }

        // ════════════════════════════════════════════════════════════
        //  TAB 5 — DEFECTOS
        // ════════════════════════════════════════════════════════════
        private void CargarDefectos(int? prodID = null)
        {
            var prods = _bl.ObtenerProductos();

            // ComboBox registro
            cboDefProd.DataSource = null;
            cboDefProd.DataSource = prods;
            cboDefProd.DisplayMember = "Nombre";
            cboDefProd.ValueMember = "ProductoID";

            // ComboBox filtro
            var prodsConTodos = new List<dynamic> { new { ProductoID = (int?)null, Nombre = "(Todos)" } };
            foreach (var p in prods)
                prodsConTodos.Add(new { ProductoID = (int?)p.ProductoID, Nombre = p.Nombre });
            cboDefFiltro.DataSource = null;
            cboDefFiltro.DataSource = prodsConTodos;
            cboDefFiltro.DisplayMember = "Nombre";
            cboDefFiltro.ValueMember = "ProductoID";

            var lista = _bl.ObtenerDefectos(prodID);
            dgvDefectos.DataSource = null;
            dgvDefectos.DataSource = lista;

            foreach (DataGridViewColumn col in dgvDefectos.Columns)
                col.Visible = false;

            MostrarCol(dgvDefectos, "FechaRegistro", "Fecha", 130);
            MostrarCol(dgvDefectos, "ProductoNombre", "Producto", 200);
            MostrarCol(dgvDefectos, "Descripcion", "Defecto", 280);
            MostrarCol(dgvDefectos, "CantidadAfectada", "Cant.", 60);
            MostrarCol(dgvDefectos, "UsuarioNombre", "Registró", 110);
        }

        private void btnDefRegistrar_Click(object sender, EventArgs e)
        {
            if (cboDefProd.SelectedValue == null) return;

            var d = new Defecto
            {
                ProductoID = (int)cboDefProd.SelectedValue,
                Descripcion = txtDefDesc.Text.Trim(),
                CantidadAfectada = (int)numDefCant.Value,
                UsuarioID = Sesion.IdUsuario
            };

            var (ok, msg) = _bl.RegistrarDefecto(d);
            MessageBox.Show(msg, ok ? "Éxito" : "Error",
                MessageBoxButtons.OK,
                ok ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            if (ok) LimpiarDefecto();
            CargarDefectos();
        }

        private void btnDefFiltrar_Click(object sender, EventArgs e)
        {
            dynamic sel = cboDefFiltro.SelectedItem;
            int? prodID = sel?.ProductoID;
            CargarDefectos(prodID);
        }

        private void btnDefLimpiar_Click(object sender, EventArgs e) => LimpiarDefecto();

        private void LimpiarDefecto()
        {
            txtDefDesc.Clear();
            numDefCant.Value = 1;
            if (cboDefProd.Items.Count > 0) cboDefProd.SelectedIndex = 0;
        }

        // ════════════════════════════════════════════════════════════
        //  TAB 6 — ALERTAS
        // ════════════════════════════════════════════════════════════
        private void CargarAlertas()
        {
            var lista = _bl.ObtenerAlertasPendientes();
            dgvAlertas.DataSource = null;
            dgvAlertas.DataSource = lista;

            foreach (DataGridViewColumn col in dgvAlertas.Columns)
                col.Visible = false;

            MostrarCol(dgvAlertas, "FechaAlerta", "Fecha", 130);
            MostrarCol(dgvAlertas, "TipoDescripcion", "Tipo", 110);
            MostrarCol(dgvAlertas, "Producto", "Producto", 200);
            MostrarCol(dgvAlertas, "Mensaje", "Mensaje", 370);

            // Colorear
            foreach (DataGridViewRow row in dgvAlertas.Rows)
            {
                string tipo = row.Cells["TipoDescripcion"].Value?.ToString();
                row.DefaultCellStyle.BackColor = tipo?.Contains("Stock") == true
                    ? Color.FromArgb(255, 220, 220)
                    : Color.FromArgb(255, 245, 190);
            }

            lblAlertaContador.Text = $"Alertas pendientes: {lista.Count}";
        }

        private void CargarAlertasContador()
        {
            if (tabAlertas == null) return;

            int count = _bl.ObtenerAlertasPendientes().Count;
            if (count > 0)
                tabAlertas.Text = $"🔔  Alertas ({count})";
        }

        private void btnAlertaRefrescar_Click(object sender, EventArgs e) => CargarAlertas();

        private void btnAlertaAtender_Click(object sender, EventArgs e)
        {
            if (dgvAlertas.CurrentRow?.DataBoundItem is AlertaInventario alerta)
            {
                var (ok, msg) = _bl.AtenderAlerta(alerta.AlertaID);
                if (ok) CargarAlertas();
                else MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ════════════════════════════════════════════════════════════
        //  UTILITY — mostrar columna en DataGridView
        // ════════════════════════════════════════════════════════════
        private static void MostrarCol(DataGridView dgv, string name, string header, int fillWeight)
        {
            if (dgv.Columns[name] == null) return;
            dgv.Columns[name].Visible = true;
            dgv.Columns[name].HeaderText = header;
            dgv.Columns[name].FillWeight = fillWeight; // ← usa FillWeight en vez de Width
        }

    }
}