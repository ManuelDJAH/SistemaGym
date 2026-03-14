namespace CapaPresentacion
{
    partial class FrmInventario
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            // ── Tab Control ──────────────────────────────────────
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabProductos = new System.Windows.Forms.TabPage();
            this.tabEquipo = new System.Windows.Forms.TabPage();
            this.tabMovimientos = new System.Windows.Forms.TabPage();
            this.tabHistorial = new System.Windows.Forms.TabPage();
            this.tabDefectos = new System.Windows.Forms.TabPage();
            this.tabAlertas = new System.Windows.Forms.TabPage();

            // ── TAB PRODUCTOS ────────────────────────────────────
            this.pnlProdFiltro = new System.Windows.Forms.Panel();
            this.lblProdFiltro = new System.Windows.Forms.Label();
            this.cboProdCategoria = new System.Windows.Forms.ComboBox();
            this.btnProdFiltrar = new System.Windows.Forms.Button();
            this.btnProdTodos = new System.Windows.Forms.Button();
            this.splitProductos = new System.Windows.Forms.SplitContainer();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.pnlProdForm = new System.Windows.Forms.Panel();
            this.lblProdTitulo = new System.Windows.Forms.Label();
            this.lblProdCodigo = new System.Windows.Forms.Label();
            this.txtProdCodigo = new System.Windows.Forms.TextBox();
            this.btnProdEscanear = new System.Windows.Forms.Button();
            this.lblProdNombre = new System.Windows.Forms.Label();
            this.txtProdNombre = new System.Windows.Forms.TextBox();
            this.lblProdCat = new System.Windows.Forms.Label();
            this.cboProdCat = new System.Windows.Forms.ComboBox();
            this.lblProdPrecio = new System.Windows.Forms.Label();
            this.txtProdPrecio = new System.Windows.Forms.TextBox();
            this.lblProdStockMin = new System.Windows.Forms.Label();
            this.numProdStockMin = new System.Windows.Forms.NumericUpDown();
            this.chkProdCaducidad = new System.Windows.Forms.CheckBox();
            this.lblProdCaducidad = new System.Windows.Forms.Label();
            this.dtpProdCaducidad = new System.Windows.Forms.DateTimePicker();
            this.btnProdNuevo = new System.Windows.Forms.Button();
            this.btnProdGuardar = new System.Windows.Forms.Button();
            this.btnProdEditar = new System.Windows.Forms.Button();
            this.btnProdBaja = new System.Windows.Forms.Button();
            this.btnProdCancelar = new System.Windows.Forms.Button();

            // ── TAB EQUIPO ───────────────────────────────────────
            this.pnlEqFiltro = new System.Windows.Forms.Panel();
            this.lblEqFiltroEstado = new System.Windows.Forms.Label();
            this.cboEqFiltroEstado = new System.Windows.Forms.ComboBox();
            this.btnEqFiltrar = new System.Windows.Forms.Button();
            this.btnEqTodos = new System.Windows.Forms.Button();
            this.splitEquipo = new System.Windows.Forms.SplitContainer();
            this.dgvEquipo = new System.Windows.Forms.DataGridView();
            this.pnlEqForm = new System.Windows.Forms.Panel();
            this.lblEqTitulo = new System.Windows.Forms.Label();
            this.lblEqNombre = new System.Windows.Forms.Label();
            this.txtEqNombre = new System.Windows.Forms.TextBox();
            this.lblEqCat = new System.Windows.Forms.Label();
            this.cboEqCat = new System.Windows.Forms.ComboBox();
            this.lblEqEstado = new System.Windows.Forms.Label();
            this.cboEqEstado = new System.Windows.Forms.ComboBox();
            this.chkEqFecha = new System.Windows.Forms.CheckBox();
            this.lblEqFecha = new System.Windows.Forms.Label();
            this.dtpEqFecha = new System.Windows.Forms.DateTimePicker();
            this.lblEqObs = new System.Windows.Forms.Label();
            this.txtEqObs = new System.Windows.Forms.TextBox();
            this.btnEqNuevo = new System.Windows.Forms.Button();
            this.btnEqGuardar = new System.Windows.Forms.Button();
            this.btnEqEditar = new System.Windows.Forms.Button();
            this.btnEqBaja = new System.Windows.Forms.Button();
            this.btnEqCancelar = new System.Windows.Forms.Button();

            // ── TAB MOVIMIENTOS ──────────────────────────────────
            this.pnlMovForm = new System.Windows.Forms.Panel();
            this.lblMovTitulo = new System.Windows.Forms.Label();
            this.lblMovCodigo = new System.Windows.Forms.Label();
            this.txtMovCodigo = new System.Windows.Forms.TextBox();
            this.btnMovBuscar = new System.Windows.Forms.Button();
            this.lblMovProducto = new System.Windows.Forms.Label();
            this.txtMovProducto = new System.Windows.Forms.TextBox();
            this.lblMovStock = new System.Windows.Forms.Label();
            this.txtMovStock = new System.Windows.Forms.TextBox();
            this.lblMovTipo = new System.Windows.Forms.Label();
            this.rbMovEntrada = new System.Windows.Forms.RadioButton();
            this.rbMovSalida = new System.Windows.Forms.RadioButton();
            this.lblMovCantidad = new System.Windows.Forms.Label();
            this.numMovCantidad = new System.Windows.Forms.NumericUpDown();
            this.lblMovMotivo = new System.Windows.Forms.Label();
            this.txtMovMotivo = new System.Windows.Forms.TextBox();
            this.btnMovRegistrar = new System.Windows.Forms.Button();
            this.btnMovLimpiar = new System.Windows.Forms.Button();
            this.picMovAlerta = new System.Windows.Forms.PictureBox();
            this.lblMovAlerta = new System.Windows.Forms.Label();

            // ── TAB HISTORIAL ────────────────────────────────────
            this.pnlHistFiltro = new System.Windows.Forms.Panel();
            this.lblHistDesde = new System.Windows.Forms.Label();
            this.dtpHistDesde = new System.Windows.Forms.DateTimePicker();
            this.lblHistHasta = new System.Windows.Forms.Label();
            this.dtpHistHasta = new System.Windows.Forms.DateTimePicker();
            this.lblHistProd = new System.Windows.Forms.Label();
            this.cboHistProd = new System.Windows.Forms.ComboBox();
            this.btnHistBuscar = new System.Windows.Forms.Button();
            this.btnHistTodos = new System.Windows.Forms.Button();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();

            // ── TAB DEFECTOS ─────────────────────────────────────
            this.pnlDefForm = new System.Windows.Forms.Panel();
            this.lblDefTitulo = new System.Windows.Forms.Label();
            this.lblDefProd = new System.Windows.Forms.Label();
            this.cboDefProd = new System.Windows.Forms.ComboBox();
            this.lblDefDesc = new System.Windows.Forms.Label();
            this.txtDefDesc = new System.Windows.Forms.TextBox();
            this.lblDefCant = new System.Windows.Forms.Label();
            this.numDefCant = new System.Windows.Forms.NumericUpDown();
            this.btnDefRegistrar = new System.Windows.Forms.Button();
            this.btnDefLimpiar = new System.Windows.Forms.Button();
            this.lblDefFiltro = new System.Windows.Forms.Label();
            this.cboDefFiltro = new System.Windows.Forms.ComboBox();
            this.btnDefFiltrar = new System.Windows.Forms.Button();
            this.dgvDefectos = new System.Windows.Forms.DataGridView();

            // ── TAB ALERTAS ──────────────────────────────────────
            this.pnlAlertasBotones = new System.Windows.Forms.Panel();
            this.lblAlertaContador = new System.Windows.Forms.Label();
            this.btnAlertaRefrescar = new System.Windows.Forms.Button();
            this.btnAlertaAtender = new System.Windows.Forms.Button();
            this.dgvAlertas = new System.Windows.Forms.DataGridView();

            // ════════════════════════════════════════════════════
            //  BEGIN INIT
            // ════════════════════════════════════════════════════
            this.tabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.splitProductos).BeginInit();
            this.splitProductos.Panel1.SuspendLayout();
            this.splitProductos.Panel2.SuspendLayout();
            this.splitProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.splitEquipo).BeginInit();
            this.splitEquipo.Panel1.SuspendLayout();
            this.splitEquipo.Panel2.SuspendLayout();
            this.splitEquipo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.dgvEquipo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.dgvHistorial).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.dgvDefectos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.dgvAlertas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.numProdStockMin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.numMovCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.numDefCant).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.picMovAlerta).BeginInit();
            this.SuspendLayout();

            // ── FORM ─────────────────────────────────────────────
            this.Text = "Inventario — Sistema Gym";
            this.Size = new System.Drawing.Size(850, 500);
            this.MinimumSize = new System.Drawing.Size(850, 500);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Load += new System.EventHandler(this.FrmInventario_Load);

            // ── TAB CONTROL ──────────────────────────────────────
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tabControl.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.tabProductos, this.tabEquipo, this.tabMovimientos,
                this.tabHistorial, this.tabDefectos, this.tabAlertas });
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);

            this.tabProductos.Text = "📦  Productos";
            this.tabEquipo.Text = "🏋  Equipo";
            this.tabMovimientos.Text = "↕  Movimientos";
            this.tabHistorial.Text = "📋  Historial";
            this.tabDefectos.Text = "⚠  Defectos";
            this.tabAlertas.Text = "🔔  Alertas";

            this.tabProductos.UseVisualStyleBackColor = true;
            this.tabEquipo.UseVisualStyleBackColor = true;
            this.tabMovimientos.UseVisualStyleBackColor = true;
            this.tabHistorial.UseVisualStyleBackColor = true;
            this.tabDefectos.UseVisualStyleBackColor = true;
            this.tabAlertas.UseVisualStyleBackColor = true;

            // ════════════════════════════════════════════════════
            //  TAB PRODUCTOS
            // ════════════════════════════════════════════════════

            // Panel filtro
            this.pnlProdFiltro.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlProdFiltro.Height = 38;

            this.lblProdFiltro.Text = "Categoría:";
            this.lblProdFiltro.Location = new System.Drawing.Point(6, 12);
            this.lblProdFiltro.AutoSize = true;

            this.cboProdCategoria.Location = new System.Drawing.Point(70, 8);
            this.cboProdCategoria.Width = 160;
            this.cboProdCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.btnProdFiltrar.Text = "Filtrar";
            this.btnProdFiltrar.Location = new System.Drawing.Point(238, 7);
            this.btnProdFiltrar.Size = new System.Drawing.Size(65, 24);
            this.btnProdFiltrar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnProdFiltrar.ForeColor = System.Drawing.Color.White;
            this.btnProdFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProdFiltrar.Click += new System.EventHandler(this.btnProdFiltrar_Click);

            this.btnProdTodos.Text = "Ver todos";
            this.btnProdTodos.Location = new System.Drawing.Point(311, 7);
            this.btnProdTodos.Size = new System.Drawing.Size(70, 24);
            this.btnProdTodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProdTodos.Click += new System.EventHandler(this.btnProdTodos_Click);

            this.pnlProdFiltro.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblProdFiltro, this.cboProdCategoria, this.btnProdFiltrar, this.btnProdTodos });

            // SplitContainer productos
            this.splitProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitProductos.Panel1MinSize = 10;
            this.splitProductos.Panel2MinSize = 10;

            // Panel1 = DGV
            this.dgvProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.BackgroundColor = System.Drawing.Color.White;
            this.dgvProductos.RowHeadersVisible = false;
            this.dgvProductos.SelectionChanged += new System.EventHandler(this.dgvProductos_SelectionChanged);
            this.splitProductos.Panel1.Controls.Add(this.dgvProductos);

            // Panel2 = Form panel
            this.pnlProdForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlProdForm.Padding = new System.Windows.Forms.Padding(8);
            this.pnlProdForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            int py = 8;
            this.lblProdTitulo.Text = "Datos del Producto";
            this.lblProdTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblProdTitulo.Location = new System.Drawing.Point(8, py);
            this.lblProdTitulo.AutoSize = true;
            py += 28;

            this.lblProdCodigo.Text = "Código de barras:";
            this.lblProdCodigo.Location = new System.Drawing.Point(8, py);
            this.lblProdCodigo.AutoSize = true;
            py += 18;
            this.txtProdCodigo.Location = new System.Drawing.Point(8, py);
            this.txtProdCodigo.Size = new System.Drawing.Size(160, 23);
            this.btnProdEscanear.Text = "📷 Scan";
            this.btnProdEscanear.Location = new System.Drawing.Point(174, py - 1);
            this.btnProdEscanear.Size = new System.Drawing.Size(75, 25);
            this.btnProdEscanear.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnProdEscanear.ForeColor = System.Drawing.Color.White;
            this.btnProdEscanear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProdEscanear.Click += new System.EventHandler(this.btnProdEscanear_Click);
            py += 30;

            this.lblProdNombre.Text = "Nombre:";
            this.lblProdNombre.Location = new System.Drawing.Point(8, py);
            this.lblProdNombre.AutoSize = true;
            py += 18;
            this.txtProdNombre.Location = new System.Drawing.Point(8, py);
            this.txtProdNombre.Size = new System.Drawing.Size(258, 23);
            py += 30;

            this.lblProdCat.Text = "Categoría:";
            this.lblProdCat.Location = new System.Drawing.Point(8, py);
            this.lblProdCat.AutoSize = true;
            py += 18;
            this.cboProdCat.Location = new System.Drawing.Point(8, py);
            this.cboProdCat.Size = new System.Drawing.Size(258, 23);
            this.cboProdCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            py += 30;

            this.lblProdPrecio.Text = "Precio ($):";
            this.lblProdPrecio.Location = new System.Drawing.Point(8, py);
            this.lblProdPrecio.AutoSize = true;
            py += 18;
            this.txtProdPrecio.Location = new System.Drawing.Point(8, py);
            this.txtProdPrecio.Size = new System.Drawing.Size(120, 23);
            py += 30;

            this.lblProdStockMin.Text = "Stock mínimo:";
            this.lblProdStockMin.Location = new System.Drawing.Point(8, py);
            this.lblProdStockMin.AutoSize = true;
            py += 18;
            this.numProdStockMin.Location = new System.Drawing.Point(8, py);
            this.numProdStockMin.Size = new System.Drawing.Size(80, 23);
            this.numProdStockMin.Minimum = 0;
            this.numProdStockMin.Maximum = 9999;
            py += 30;

            this.chkProdCaducidad.Text = "Tiene fecha de caducidad";
            this.chkProdCaducidad.Location = new System.Drawing.Point(8, py);
            this.chkProdCaducidad.AutoSize = true;
            this.chkProdCaducidad.CheckedChanged += new System.EventHandler(this.chkProdCaducidad_CheckedChanged);
            py += 22;
            this.lblProdCaducidad.Text = "Fecha caducidad:";
            this.lblProdCaducidad.Location = new System.Drawing.Point(8, py);
            this.lblProdCaducidad.AutoSize = true;
            py += 18;
            this.dtpProdCaducidad.Location = new System.Drawing.Point(8, py);
            this.dtpProdCaducidad.Size = new System.Drawing.Size(160, 23);
            this.dtpProdCaducidad.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpProdCaducidad.Enabled = false;
            py += 35;

            this.btnProdNuevo.Text = "➕ Nuevo";
            this.btnProdNuevo.Location = new System.Drawing.Point(8, py);
            this.btnProdNuevo.Size = new System.Drawing.Size(78, 28);
            this.btnProdNuevo.BackColor = System.Drawing.Color.SeaGreen;
            this.btnProdNuevo.ForeColor = System.Drawing.Color.White;
            this.btnProdNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProdNuevo.Click += new System.EventHandler(this.btnProdNuevo_Click);

            this.btnProdGuardar.Text = "💾 Guardar";
            this.btnProdGuardar.Location = new System.Drawing.Point(92, py);
            this.btnProdGuardar.Size = new System.Drawing.Size(85, 28);
            this.btnProdGuardar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnProdGuardar.ForeColor = System.Drawing.Color.White;
            this.btnProdGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProdGuardar.Enabled = false;
            this.btnProdGuardar.Click += new System.EventHandler(this.btnProdGuardar_Click);

            this.btnProdEditar.Text = "✏ Editar";
            this.btnProdEditar.Location = new System.Drawing.Point(183, py);
            this.btnProdEditar.Size = new System.Drawing.Size(78, 28);
            this.btnProdEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProdEditar.Enabled = false;
            this.btnProdEditar.Click += new System.EventHandler(this.btnProdEditar_Click);
            py += 34;

            this.btnProdBaja.Text = "🗑 Dar de baja";
            this.btnProdBaja.Location = new System.Drawing.Point(8, py);
            this.btnProdBaja.Size = new System.Drawing.Size(110, 28);
            this.btnProdBaja.BackColor = System.Drawing.Color.Firebrick;
            this.btnProdBaja.ForeColor = System.Drawing.Color.White;
            this.btnProdBaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProdBaja.Enabled = false;
            this.btnProdBaja.Click += new System.EventHandler(this.btnProdBaja_Click);

            this.btnProdCancelar.Text = "✖ Cancelar";
            this.btnProdCancelar.Location = new System.Drawing.Point(124, py);
            this.btnProdCancelar.Size = new System.Drawing.Size(85, 28);
            this.btnProdCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProdCancelar.Enabled = false;
            this.btnProdCancelar.Click += new System.EventHandler(this.btnProdCancelar_Click);

            this.pnlProdForm.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblProdTitulo, this.lblProdCodigo, this.txtProdCodigo, this.btnProdEscanear,
                this.lblProdNombre, this.txtProdNombre, this.lblProdCat, this.cboProdCat,
                this.lblProdPrecio, this.txtProdPrecio, this.lblProdStockMin, this.numProdStockMin,
                this.chkProdCaducidad, this.lblProdCaducidad, this.dtpProdCaducidad,
                this.btnProdNuevo, this.btnProdGuardar, this.btnProdEditar,
                this.btnProdBaja, this.btnProdCancelar });
            this.splitProductos.Panel2.Controls.Add(this.pnlProdForm);

            this.tabProductos.Controls.Add(this.splitProductos);
            this.tabProductos.Controls.Add(this.pnlProdFiltro);

            // ════════════════════════════════════════════════════
            //  TAB EQUIPO
            // ════════════════════════════════════════════════════
            this.pnlEqFiltro.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEqFiltro.Height = 38;

            this.lblEqFiltroEstado.Text = "Estado:";
            this.lblEqFiltroEstado.Location = new System.Drawing.Point(6, 12);
            this.lblEqFiltroEstado.AutoSize = true;

            this.cboEqFiltroEstado.Location = new System.Drawing.Point(58, 8);
            this.cboEqFiltroEstado.Width = 120;
            this.cboEqFiltroEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEqFiltroEstado.Items.AddRange(new object[] { "BUENO", "DAÑADO", "BAJA" });

            this.btnEqFiltrar.Text = "Filtrar";
            this.btnEqFiltrar.Location = new System.Drawing.Point(186, 7);
            this.btnEqFiltrar.Size = new System.Drawing.Size(65, 24);
            this.btnEqFiltrar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnEqFiltrar.ForeColor = System.Drawing.Color.White;
            this.btnEqFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEqFiltrar.Click += new System.EventHandler(this.btnEqFiltrar_Click);

            this.btnEqTodos.Text = "Ver todos";
            this.btnEqTodos.Location = new System.Drawing.Point(259, 7);
            this.btnEqTodos.Size = new System.Drawing.Size(70, 24);
            this.btnEqTodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEqTodos.Click += new System.EventHandler(this.btnEqTodos_Click);

            this.pnlEqFiltro.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblEqFiltroEstado, this.cboEqFiltroEstado, this.btnEqFiltrar, this.btnEqTodos });

            this.splitEquipo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitEquipo.Panel1MinSize = 10;
            this.splitEquipo.Panel2MinSize = 10;

            this.dgvEquipo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEquipo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEquipo.ReadOnly = true;
            this.dgvEquipo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEquipo.AllowUserToAddRows = false;
            this.dgvEquipo.BackgroundColor = System.Drawing.Color.White;
            this.dgvEquipo.RowHeadersVisible = false;
            this.dgvEquipo.SelectionChanged += new System.EventHandler(this.dgvEquipo_SelectionChanged);
            this.splitEquipo.Panel1.Controls.Add(this.dgvEquipo);

            this.pnlEqForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEqForm.Padding = new System.Windows.Forms.Padding(8);
            this.pnlEqForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            int ey = 8;
            this.lblEqTitulo.Text = "Datos del Equipo";
            this.lblEqTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblEqTitulo.Location = new System.Drawing.Point(8, ey);
            this.lblEqTitulo.AutoSize = true;
            ey += 28;

            this.lblEqNombre.Text = "Nombre:";
            this.lblEqNombre.Location = new System.Drawing.Point(8, ey);
            this.lblEqNombre.AutoSize = true;
            ey += 18;
            this.txtEqNombre.Location = new System.Drawing.Point(8, ey);
            this.txtEqNombre.Size = new System.Drawing.Size(258, 23);
            ey += 30;

            this.lblEqCat.Text = "Categoría:";
            this.lblEqCat.Location = new System.Drawing.Point(8, ey);
            this.lblEqCat.AutoSize = true;
            ey += 18;
            this.cboEqCat.Location = new System.Drawing.Point(8, ey);
            this.cboEqCat.Size = new System.Drawing.Size(258, 23);
            this.cboEqCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            ey += 30;

            this.lblEqEstado.Text = "Estado:";
            this.lblEqEstado.Location = new System.Drawing.Point(8, ey);
            this.lblEqEstado.AutoSize = true;
            ey += 18;
            this.cboEqEstado.Location = new System.Drawing.Point(8, ey);
            this.cboEqEstado.Size = new System.Drawing.Size(160, 23);
            this.cboEqEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEqEstado.Items.AddRange(new object[] { "BUENO", "DAÑADO", "BAJA" });
            ey += 30;

            this.chkEqFecha.Text = "Tiene fecha de adquisición";
            this.chkEqFecha.Location = new System.Drawing.Point(8, ey);
            this.chkEqFecha.AutoSize = true;
            this.chkEqFecha.CheckedChanged += new System.EventHandler(this.chkEqFecha_CheckedChanged);
            ey += 22;
            this.lblEqFecha.Text = "Fecha adquisición:";
            this.lblEqFecha.Location = new System.Drawing.Point(8, ey);
            this.lblEqFecha.AutoSize = true;
            ey += 18;
            this.dtpEqFecha.Location = new System.Drawing.Point(8, ey);
            this.dtpEqFecha.Size = new System.Drawing.Size(160, 23);
            this.dtpEqFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEqFecha.Enabled = false;
            ey += 30;

            this.lblEqObs.Text = "Observaciones:";
            this.lblEqObs.Location = new System.Drawing.Point(8, ey);
            this.lblEqObs.AutoSize = true;
            ey += 18;
            this.txtEqObs.Location = new System.Drawing.Point(8, ey);
            this.txtEqObs.Size = new System.Drawing.Size(258, 45);
            this.txtEqObs.Multiline = true;
            ey += 53;

            this.btnEqNuevo.Text = "➕ Nuevo";
            this.btnEqNuevo.Location = new System.Drawing.Point(8, ey);
            this.btnEqNuevo.Size = new System.Drawing.Size(78, 28);
            this.btnEqNuevo.BackColor = System.Drawing.Color.SeaGreen;
            this.btnEqNuevo.ForeColor = System.Drawing.Color.White;
            this.btnEqNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEqNuevo.Click += new System.EventHandler(this.btnEqNuevo_Click);

            this.btnEqGuardar.Text = "💾 Guardar";
            this.btnEqGuardar.Location = new System.Drawing.Point(92, ey);
            this.btnEqGuardar.Size = new System.Drawing.Size(85, 28);
            this.btnEqGuardar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnEqGuardar.ForeColor = System.Drawing.Color.White;
            this.btnEqGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEqGuardar.Enabled = false;
            this.btnEqGuardar.Click += new System.EventHandler(this.btnEqGuardar_Click);

            this.btnEqEditar.Text = "✏ Editar";
            this.btnEqEditar.Location = new System.Drawing.Point(183, ey);
            this.btnEqEditar.Size = new System.Drawing.Size(78, 28);
            this.btnEqEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEqEditar.Enabled = false;
            this.btnEqEditar.Click += new System.EventHandler(this.btnEqEditar_Click);
            ey += 34;

            this.btnEqBaja.Text = "🗑 Dar de baja";
            this.btnEqBaja.Location = new System.Drawing.Point(8, ey);
            this.btnEqBaja.Size = new System.Drawing.Size(110, 28);
            this.btnEqBaja.BackColor = System.Drawing.Color.Firebrick;
            this.btnEqBaja.ForeColor = System.Drawing.Color.White;
            this.btnEqBaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEqBaja.Enabled = false;
            this.btnEqBaja.Click += new System.EventHandler(this.btnEqBaja_Click);

            this.btnEqCancelar.Text = "✖ Cancelar";
            this.btnEqCancelar.Location = new System.Drawing.Point(124, ey);
            this.btnEqCancelar.Size = new System.Drawing.Size(85, 28);
            this.btnEqCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEqCancelar.Enabled = false;
            this.btnEqCancelar.Click += new System.EventHandler(this.btnEqCancelar_Click);

            this.pnlEqForm.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblEqTitulo, this.lblEqNombre, this.txtEqNombre,
                this.lblEqCat, this.cboEqCat, this.lblEqEstado, this.cboEqEstado,
                this.chkEqFecha, this.lblEqFecha, this.dtpEqFecha,
                this.lblEqObs, this.txtEqObs,
                this.btnEqNuevo, this.btnEqGuardar, this.btnEqEditar,
                this.btnEqBaja, this.btnEqCancelar });
            this.splitEquipo.Panel2.Controls.Add(this.pnlEqForm);

            this.tabEquipo.Controls.Add(this.splitEquipo);
            this.tabEquipo.Controls.Add(this.pnlEqFiltro);

            // ════════════════════════════════════════════════════
            //  TAB MOVIMIENTOS
            // ════════════════════════════════════════════════════
            this.pnlMovForm.Location = new System.Drawing.Point(20, 10);
            this.pnlMovForm.Size = new System.Drawing.Size(480, 390);
            this.pnlMovForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            int mv = 12;
            this.lblMovTitulo.Text = "Registrar Movimiento";
            this.lblMovTitulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblMovTitulo.Location = new System.Drawing.Point(12, mv);
            this.lblMovTitulo.AutoSize = true;
            mv += 32;

            this.lblMovCodigo.Text = "Código de barras:";
            this.lblMovCodigo.Location = new System.Drawing.Point(12, mv);
            this.lblMovCodigo.AutoSize = true;
            mv += 20;
            this.txtMovCodigo.Location = new System.Drawing.Point(12, mv);
            this.txtMovCodigo.Size = new System.Drawing.Size(240, 23);
            this.txtMovCodigo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMovCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMovCodigo_KeyDown);
            this.btnMovBuscar.Text = "🔍 Buscar";
            this.btnMovBuscar.Location = new System.Drawing.Point(258, mv - 1);
            this.btnMovBuscar.Size = new System.Drawing.Size(85, 25);
            this.btnMovBuscar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnMovBuscar.ForeColor = System.Drawing.Color.White;
            this.btnMovBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMovBuscar.Click += new System.EventHandler(this.btnMovBuscar_Click);
            mv += 32;

            this.lblMovProducto.Text = "Producto encontrado:";
            this.lblMovProducto.Location = new System.Drawing.Point(12, mv);
            this.lblMovProducto.AutoSize = true;
            mv += 20;
            this.txtMovProducto.Location = new System.Drawing.Point(12, mv);
            this.txtMovProducto.Size = new System.Drawing.Size(340, 23);
            this.txtMovProducto.ReadOnly = true;
            this.txtMovProducto.BackColor = System.Drawing.Color.WhiteSmoke;
            mv += 32;

            this.lblMovStock.Text = "Stock actual:";
            this.lblMovStock.Location = new System.Drawing.Point(12, mv);
            this.lblMovStock.AutoSize = true;
            mv += 20;
            this.txtMovStock.Location = new System.Drawing.Point(12, mv);
            this.txtMovStock.Size = new System.Drawing.Size(80, 23);
            this.txtMovStock.ReadOnly = true;
            this.txtMovStock.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtMovStock.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            mv += 35;

            this.lblMovTipo.Text = "Tipo:";
            this.lblMovTipo.Location = new System.Drawing.Point(12, mv);
            this.lblMovTipo.AutoSize = true;
            mv += 22;
            this.rbMovEntrada.Text = "📥 Entrada (suma stock)";
            this.rbMovEntrada.Location = new System.Drawing.Point(22, mv);
            this.rbMovEntrada.AutoSize = true;
            this.rbMovEntrada.Checked = true;
            mv += 24;
            this.rbMovSalida.Text = "📤 Salida (resta stock)";
            this.rbMovSalida.Location = new System.Drawing.Point(22, mv);
            this.rbMovSalida.AutoSize = true;
            mv += 32;

            this.lblMovCantidad.Text = "Cantidad:";
            this.lblMovCantidad.Location = new System.Drawing.Point(12, mv);
            this.lblMovCantidad.AutoSize = true;
            mv += 20;
            this.numMovCantidad.Location = new System.Drawing.Point(12, mv);
            this.numMovCantidad.Size = new System.Drawing.Size(90, 23);
            this.numMovCantidad.Minimum = 1;
            this.numMovCantidad.Maximum = 9999;
            mv += 32;

            this.lblMovMotivo.Text = "Motivo (opcional):";
            this.lblMovMotivo.Location = new System.Drawing.Point(12, mv);
            this.lblMovMotivo.AutoSize = true;
            mv += 20;
            this.txtMovMotivo.Location = new System.Drawing.Point(12, mv);
            this.txtMovMotivo.Size = new System.Drawing.Size(340, 23);
            mv += 35;

            this.btnMovRegistrar.Text = "✔ Registrar";
            this.btnMovRegistrar.Location = new System.Drawing.Point(12, mv);
            this.btnMovRegistrar.Size = new System.Drawing.Size(130, 32);
            this.btnMovRegistrar.BackColor = System.Drawing.Color.SeaGreen;
            this.btnMovRegistrar.ForeColor = System.Drawing.Color.White;
            this.btnMovRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMovRegistrar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnMovRegistrar.Click += new System.EventHandler(this.btnMovRegistrar_Click);

            this.btnMovLimpiar.Text = "✖ Limpiar";
            this.btnMovLimpiar.Location = new System.Drawing.Point(150, mv);
            this.btnMovLimpiar.Size = new System.Drawing.Size(80, 32);
            this.btnMovLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMovLimpiar.Click += new System.EventHandler(this.btnMovLimpiar_Click);

            this.picMovAlerta.Location = new System.Drawing.Point(12, mv + 40);
            this.picMovAlerta.Size = new System.Drawing.Size(16, 16);
            this.picMovAlerta.Visible = false;
            this.lblMovAlerta.Location = new System.Drawing.Point(32, mv + 41);
            this.lblMovAlerta.AutoSize = true;
            this.lblMovAlerta.ForeColor = System.Drawing.Color.Firebrick;
            this.lblMovAlerta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMovAlerta.Visible = false;

            this.pnlMovForm.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblMovTitulo, this.lblMovCodigo, this.txtMovCodigo, this.btnMovBuscar,
                this.lblMovProducto, this.txtMovProducto, this.lblMovStock, this.txtMovStock,
                this.lblMovTipo, this.rbMovEntrada, this.rbMovSalida,
                this.lblMovCantidad, this.numMovCantidad,
                this.lblMovMotivo, this.txtMovMotivo,
                this.btnMovRegistrar, this.btnMovLimpiar,
                this.picMovAlerta, this.lblMovAlerta });
            this.tabMovimientos.Controls.Add(this.pnlMovForm);

            // ════════════════════════════════════════════════════
            //  TAB HISTORIAL
            // ════════════════════════════════════════════════════
            this.pnlHistFiltro.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHistFiltro.Height = 38;

            this.lblHistDesde.Text = "Desde:";
            this.lblHistDesde.Location = new System.Drawing.Point(6, 12);
            this.lblHistDesde.AutoSize = true;
            this.dtpHistDesde.Location = new System.Drawing.Point(52, 8);
            this.dtpHistDesde.Size = new System.Drawing.Size(110, 23);
            this.dtpHistDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHistDesde.Value = System.DateTime.Today.AddMonths(-1);

            this.lblHistHasta.Text = "Hasta:";
            this.lblHistHasta.Location = new System.Drawing.Point(170, 12);
            this.lblHistHasta.AutoSize = true;
            this.dtpHistHasta.Location = new System.Drawing.Point(212, 8);
            this.dtpHistHasta.Size = new System.Drawing.Size(110, 23);
            this.dtpHistHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            this.lblHistProd.Text = "Producto:";
            this.lblHistProd.Location = new System.Drawing.Point(330, 12);
            this.lblHistProd.AutoSize = true;
            this.cboHistProd.Location = new System.Drawing.Point(390, 8);
            this.cboHistProd.Width = 180;
            this.cboHistProd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.btnHistBuscar.Text = "🔍 Buscar";
            this.btnHistBuscar.Location = new System.Drawing.Point(578, 7);
            this.btnHistBuscar.Size = new System.Drawing.Size(75, 24);
            this.btnHistBuscar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnHistBuscar.ForeColor = System.Drawing.Color.White;
            this.btnHistBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistBuscar.Click += new System.EventHandler(this.btnHistBuscar_Click);

            this.btnHistTodos.Text = "Ver todos";
            this.btnHistTodos.Location = new System.Drawing.Point(661, 7);
            this.btnHistTodos.Size = new System.Drawing.Size(70, 24);
            this.btnHistTodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistTodos.Click += new System.EventHandler(this.btnHistTodos_Click);

            this.pnlHistFiltro.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblHistDesde, this.dtpHistDesde, this.lblHistHasta, this.dtpHistHasta,
                this.lblHistProd, this.cboHistProd, this.btnHistBuscar, this.btnHistTodos });

            this.dgvHistorial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistorial.ReadOnly = true;
            this.dgvHistorial.AllowUserToAddRows = false;
            this.dgvHistorial.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistorial.RowHeadersVisible = false;
            this.dgvHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.tabHistorial.Controls.Add(this.dgvHistorial);
            this.tabHistorial.Controls.Add(this.pnlHistFiltro);

            // ════════════════════════════════════════════════════
            //  TAB DEFECTOS
            // ════════════════════════════════════════════════════
            this.pnlDefForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDefForm.Height = 175;
            this.pnlDefForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDefForm.Padding = new System.Windows.Forms.Padding(8);

            int df = 8;
            this.lblDefTitulo.Text = "Registrar Defecto";
            this.lblDefTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDefTitulo.Location = new System.Drawing.Point(8, df);
            this.lblDefTitulo.AutoSize = true;
            df += 28;

            this.lblDefProd.Text = "Producto:";
            this.lblDefProd.Location = new System.Drawing.Point(8, df);
            this.lblDefProd.AutoSize = true;
            this.cboDefProd.Location = new System.Drawing.Point(72, df - 2);
            this.cboDefProd.Width = 260;
            this.cboDefProd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            df += 30;

            this.lblDefDesc.Text = "Descripción:";
            this.lblDefDesc.Location = new System.Drawing.Point(8, df);
            this.lblDefDesc.AutoSize = true;
            this.txtDefDesc.Location = new System.Drawing.Point(80, df - 2);
            this.txtDefDesc.Size = new System.Drawing.Size(450, 23);
            df += 30;

            this.lblDefCant.Text = "Cant. afectada:";
            this.lblDefCant.Location = new System.Drawing.Point(8, df);
            this.lblDefCant.AutoSize = true;
            this.numDefCant.Location = new System.Drawing.Point(105, df - 2);
            this.numDefCant.Size = new System.Drawing.Size(70, 23);
            this.numDefCant.Minimum = 1;
            this.numDefCant.Maximum = 9999;

            this.btnDefRegistrar.Text = "⚠ Registrar Defecto";
            this.btnDefRegistrar.Location = new System.Drawing.Point(190, df - 2);
            this.btnDefRegistrar.Size = new System.Drawing.Size(145, 26);
            this.btnDefRegistrar.BackColor = System.Drawing.Color.OrangeRed;
            this.btnDefRegistrar.ForeColor = System.Drawing.Color.White;
            this.btnDefRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDefRegistrar.Click += new System.EventHandler(this.btnDefRegistrar_Click);

            this.btnDefLimpiar.Text = "✖ Limpiar";
            this.btnDefLimpiar.Location = new System.Drawing.Point(342, df - 2);
            this.btnDefLimpiar.Size = new System.Drawing.Size(75, 26);
            this.btnDefLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDefLimpiar.Click += new System.EventHandler(this.btnDefLimpiar_Click);
            df += 36;

            this.lblDefFiltro.Text = "Filtrar por producto:";
            this.lblDefFiltro.Location = new System.Drawing.Point(8, df);
            this.lblDefFiltro.AutoSize = true;
            this.cboDefFiltro.Location = new System.Drawing.Point(135, df - 2);
            this.cboDefFiltro.Width = 220;
            this.cboDefFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.btnDefFiltrar.Text = "Filtrar";
            this.btnDefFiltrar.Location = new System.Drawing.Point(362, df - 2);
            this.btnDefFiltrar.Size = new System.Drawing.Size(60, 24);
            this.btnDefFiltrar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnDefFiltrar.ForeColor = System.Drawing.Color.White;
            this.btnDefFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDefFiltrar.Click += new System.EventHandler(this.btnDefFiltrar_Click);

            this.pnlDefForm.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblDefTitulo, this.lblDefProd, this.cboDefProd,
                this.lblDefDesc, this.txtDefDesc, this.lblDefCant, this.numDefCant,
                this.btnDefRegistrar, this.btnDefLimpiar,
                this.lblDefFiltro, this.cboDefFiltro, this.btnDefFiltrar });

            this.dgvDefectos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDefectos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDefectos.ReadOnly = true;
            this.dgvDefectos.AllowUserToAddRows = false;
            this.dgvDefectos.BackgroundColor = System.Drawing.Color.White;
            this.dgvDefectos.RowHeadersVisible = false;
            this.dgvDefectos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.tabDefectos.Controls.Add(this.dgvDefectos);
            this.tabDefectos.Controls.Add(this.pnlDefForm);

            // ════════════════════════════════════════════════════
            //  TAB ALERTAS
            // ════════════════════════════════════════════════════
            this.pnlAlertasBotones.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAlertasBotones.Height = 42;

            this.lblAlertaContador.Text = "Alertas pendientes: 0";
            this.lblAlertaContador.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAlertaContador.ForeColor = System.Drawing.Color.Firebrick;
            this.lblAlertaContador.Location = new System.Drawing.Point(8, 13);
            this.lblAlertaContador.AutoSize = true;

            this.btnAlertaRefrescar.Text = "🔄 Refrescar";
            this.btnAlertaRefrescar.Location = new System.Drawing.Point(200, 9);
            this.btnAlertaRefrescar.Size = new System.Drawing.Size(100, 26);
            this.btnAlertaRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlertaRefrescar.Click += new System.EventHandler(this.btnAlertaRefrescar_Click);

            this.btnAlertaAtender.Text = "✔ Marcar atendida";
            this.btnAlertaAtender.Location = new System.Drawing.Point(308, 9);
            this.btnAlertaAtender.Size = new System.Drawing.Size(140, 26);
            this.btnAlertaAtender.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAlertaAtender.ForeColor = System.Drawing.Color.White;
            this.btnAlertaAtender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlertaAtender.Click += new System.EventHandler(this.btnAlertaAtender_Click);

            this.pnlAlertasBotones.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblAlertaContador, this.btnAlertaRefrescar, this.btnAlertaAtender });

            this.dgvAlertas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAlertas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAlertas.ReadOnly = true;
            this.dgvAlertas.AllowUserToAddRows = false;
            this.dgvAlertas.BackgroundColor = System.Drawing.Color.White;
            this.dgvAlertas.RowHeadersVisible = false;
            this.dgvAlertas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.tabAlertas.Controls.Add(this.dgvAlertas);
            this.tabAlertas.Controls.Add(this.pnlAlertasBotones);

            // ── Agregar TabControl al Form ────────────────────────
            this.Controls.Add(this.tabControl);

            // ════════════════════════════════════════════════════
            //  END INIT
            // ════════════════════════════════════════════════════
            ((System.ComponentModel.ISupportInitialize)this.splitProductos).EndInit();
            this.splitProductos.Panel1.ResumeLayout(false);
            this.splitProductos.Panel2.ResumeLayout(false);
            this.splitProductos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.splitEquipo).EndInit();
            this.splitEquipo.Panel1.ResumeLayout(false);
            this.splitEquipo.Panel2.ResumeLayout(false);
            this.splitEquipo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.dgvProductos).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.dgvEquipo).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.dgvHistorial).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.dgvDefectos).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.dgvAlertas).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.numProdStockMin).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.numMovCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.numDefCant).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.picMovAlerta).EndInit();
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        #endregion

        // ── Controles ────────────────────────────────────────────
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabProductos, tabEquipo, tabMovimientos,
                                              tabHistorial, tabDefectos, tabAlertas;
        private System.Windows.Forms.SplitContainer splitProductos, splitEquipo;
        // Productos
        private System.Windows.Forms.Panel pnlProdFiltro, pnlProdForm;
        private System.Windows.Forms.Label lblProdFiltro, lblProdTitulo, lblProdCodigo,
                                                 lblProdNombre, lblProdCat, lblProdPrecio,
                                                 lblProdStockMin, lblProdCaducidad;
        private System.Windows.Forms.ComboBox cboProdCategoria, cboProdCat;
        private System.Windows.Forms.TextBox txtProdCodigo, txtProdNombre, txtProdPrecio;
        private System.Windows.Forms.NumericUpDown numProdStockMin;
        private System.Windows.Forms.DateTimePicker dtpProdCaducidad;
        private System.Windows.Forms.CheckBox chkProdCaducidad;
        private System.Windows.Forms.Button btnProdFiltrar, btnProdTodos, btnProdEscanear,
                                                 btnProdNuevo, btnProdGuardar, btnProdEditar,
                                                 btnProdBaja, btnProdCancelar;
        private System.Windows.Forms.DataGridView dgvProductos;
        // Equipo
        private System.Windows.Forms.Panel pnlEqFiltro, pnlEqForm;
        private System.Windows.Forms.Label lblEqFiltroEstado, lblEqTitulo, lblEqNombre,
                                                 lblEqCat, lblEqEstado, lblEqFecha, lblEqObs;
        private System.Windows.Forms.ComboBox cboEqFiltroEstado, cboEqCat, cboEqEstado;
        private System.Windows.Forms.TextBox txtEqNombre, txtEqObs;
        private System.Windows.Forms.DateTimePicker dtpEqFecha;
        private System.Windows.Forms.CheckBox chkEqFecha;
        private System.Windows.Forms.Button btnEqFiltrar, btnEqTodos, btnEqNuevo,
                                                 btnEqGuardar, btnEqEditar, btnEqBaja, btnEqCancelar;
        private System.Windows.Forms.DataGridView dgvEquipo;
        // Movimientos
        private System.Windows.Forms.Panel pnlMovForm;
        private System.Windows.Forms.Label lblMovTitulo, lblMovCodigo, lblMovProducto,
                                                 lblMovStock, lblMovTipo, lblMovCantidad,
                                                 lblMovMotivo, lblMovAlerta;
        private System.Windows.Forms.TextBox txtMovCodigo, txtMovProducto, txtMovStock, txtMovMotivo;
        private System.Windows.Forms.RadioButton rbMovEntrada, rbMovSalida;
        private System.Windows.Forms.NumericUpDown numMovCantidad;
        private System.Windows.Forms.Button btnMovBuscar, btnMovRegistrar, btnMovLimpiar;
        private System.Windows.Forms.PictureBox picMovAlerta;
        // Historial
        private System.Windows.Forms.Panel pnlHistFiltro;
        private System.Windows.Forms.Label lblHistDesde, lblHistHasta, lblHistProd;
        private System.Windows.Forms.DateTimePicker dtpHistDesde, dtpHistHasta;
        private System.Windows.Forms.ComboBox cboHistProd;
        private System.Windows.Forms.Button btnHistBuscar, btnHistTodos;
        private System.Windows.Forms.DataGridView dgvHistorial;
        // Defectos
        private System.Windows.Forms.Panel pnlDefForm;
        private System.Windows.Forms.Label lblDefTitulo, lblDefProd, lblDefDesc,
                                                 lblDefCant, lblDefFiltro;
        private System.Windows.Forms.ComboBox cboDefProd, cboDefFiltro;
        private System.Windows.Forms.TextBox txtDefDesc;
        private System.Windows.Forms.NumericUpDown numDefCant;
        private System.Windows.Forms.Button btnDefRegistrar, btnDefLimpiar, btnDefFiltrar;
        private System.Windows.Forms.DataGridView dgvDefectos;
        // Alertas
        private System.Windows.Forms.Panel pnlAlertasBotones;
        private System.Windows.Forms.Label lblAlertaContador;
        private System.Windows.Forms.Button btnAlertaRefrescar, btnAlertaAtender;
        private System.Windows.Forms.DataGridView dgvAlertas;
    }
}