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
            this.tabControl         = new System.Windows.Forms.TabControl();
            this.tabProductos       = new System.Windows.Forms.TabPage();
            this.tabEquipo          = new System.Windows.Forms.TabPage();
            this.tabMovimientos     = new System.Windows.Forms.TabPage();
            this.tabHistorial       = new System.Windows.Forms.TabPage();
            this.tabDefectos        = new System.Windows.Forms.TabPage();
            this.tabAlertas         = new System.Windows.Forms.TabPage();

            // ── Productos ────────────────────────────────────────────
            this.splitProductos     = new System.Windows.Forms.SplitContainer();
            this.dgvProductos       = new System.Windows.Forms.DataGridView();
            this.pnlProdFiltro      = new System.Windows.Forms.Panel();
            this.lblProdFiltro      = new System.Windows.Forms.Label();
            this.cboProdCategoria   = new System.Windows.Forms.ComboBox();
            this.btnProdFiltrar     = new System.Windows.Forms.Button();
            this.btnProdTodos       = new System.Windows.Forms.Button();
            this.pnlProdForm        = new System.Windows.Forms.Panel();
            this.lblProdTitulo      = new System.Windows.Forms.Label();
            this.lblProdCodigo      = new System.Windows.Forms.Label();
            this.txtProdCodigo      = new System.Windows.Forms.TextBox();
            this.btnProdEscanear    = new System.Windows.Forms.Button();
            this.btnProdGenerarCodigo = new System.Windows.Forms.Button();
            this.picCodigoBarras    = new System.Windows.Forms.PictureBox();
            this.lblProdNombre      = new System.Windows.Forms.Label();
            this.txtProdNombre      = new System.Windows.Forms.TextBox();
            this.lblProdCat         = new System.Windows.Forms.Label();
            this.cboProdCat         = new System.Windows.Forms.ComboBox();
            this.lblProdPrecio      = new System.Windows.Forms.Label();
            this.txtProdPrecio      = new System.Windows.Forms.TextBox();
            this.lblProdStockMin    = new System.Windows.Forms.Label();
            this.numProdStockMin    = new System.Windows.Forms.NumericUpDown();
            this.lblProdCaducidad   = new System.Windows.Forms.Label();
            this.lblProdProveedor   = new System.Windows.Forms.Label();
            this.cboProdProveedor   = new System.Windows.Forms.ComboBox();
            this.chkProdCaducidad   = new System.Windows.Forms.CheckBox();
            this.dtpProdCaducidad   = new System.Windows.Forms.DateTimePicker();
            this.btnProdNuevo       = new System.Windows.Forms.Button();
            this.btnProdGuardar     = new System.Windows.Forms.Button();
            this.btnProdEditar      = new System.Windows.Forms.Button();
            this.btnProdBaja        = new System.Windows.Forms.Button();
            this.btnProdCancelar    = new System.Windows.Forms.Button();

            // ── Equipo ───────────────────────────────────────────────
            this.splitEquipo        = new System.Windows.Forms.SplitContainer();
            this.dgvEquipo          = new System.Windows.Forms.DataGridView();
            this.pnlEqFiltro        = new System.Windows.Forms.Panel();
            this.lblEqFiltroEstado  = new System.Windows.Forms.Label();
            this.cboEqFiltroEstado  = new System.Windows.Forms.ComboBox();
            this.btnEqFiltrar       = new System.Windows.Forms.Button();
            this.btnEqTodos         = new System.Windows.Forms.Button();
            this.pnlEqForm          = new System.Windows.Forms.Panel();
            this.lblEqTitulo        = new System.Windows.Forms.Label();
            this.lblEqNombre        = new System.Windows.Forms.Label();
            this.txtEqNombre        = new System.Windows.Forms.TextBox();
            this.lblEqCat           = new System.Windows.Forms.Label();
            this.cboEqCat           = new System.Windows.Forms.ComboBox();
            this.lblEqEstado        = new System.Windows.Forms.Label();
            this.cboEqEstado        = new System.Windows.Forms.ComboBox();
            this.lblEqFecha         = new System.Windows.Forms.Label();
            this.chkEqFecha         = new System.Windows.Forms.CheckBox();
            this.dtpEqFecha         = new System.Windows.Forms.DateTimePicker();
            this.lblEqObs           = new System.Windows.Forms.Label();
            this.txtEqObs           = new System.Windows.Forms.TextBox();
            this.btnEqNuevo         = new System.Windows.Forms.Button();
            this.btnEqGuardar       = new System.Windows.Forms.Button();
            this.btnEqEditar        = new System.Windows.Forms.Button();
            this.btnEqBaja          = new System.Windows.Forms.Button();
            this.btnEqCancelar      = new System.Windows.Forms.Button();

            // ── Movimientos ──────────────────────────────────────────
            this.pnlMovForm         = new System.Windows.Forms.Panel();
            this.lblMovTitulo       = new System.Windows.Forms.Label();
            this.lblMovCodigo       = new System.Windows.Forms.Label();
            this.txtMovCodigo       = new System.Windows.Forms.TextBox();
            this.btnMovBuscar       = new System.Windows.Forms.Button();
            this.lblMovProducto     = new System.Windows.Forms.Label();
            this.txtMovProducto     = new System.Windows.Forms.TextBox();
            this.lblMovStock        = new System.Windows.Forms.Label();
            this.txtMovStock        = new System.Windows.Forms.TextBox();
            this.lblMovAlerta       = new System.Windows.Forms.Label();
            this.picMovAlerta       = new System.Windows.Forms.PictureBox();
            this.lblMovTipo         = new System.Windows.Forms.Label();
            this.rbMovEntrada       = new System.Windows.Forms.RadioButton();
            this.rbMovSalida        = new System.Windows.Forms.RadioButton();
            this.lblMovCantidad     = new System.Windows.Forms.Label();
            this.numMovCantidad     = new System.Windows.Forms.NumericUpDown();
            this.lblMovMotivo       = new System.Windows.Forms.Label();
            this.txtMovMotivo       = new System.Windows.Forms.TextBox();
            this.btnMovRegistrar    = new System.Windows.Forms.Button();
            this.btnMovLimpiar      = new System.Windows.Forms.Button();

            // ── Historial ────────────────────────────────────────────
            this.dgvHistorial       = new System.Windows.Forms.DataGridView();
            this.pnlHistFiltro      = new System.Windows.Forms.Panel();
            this.lblHistDesde       = new System.Windows.Forms.Label();
            this.dtpHistDesde       = new System.Windows.Forms.DateTimePicker();
            this.lblHistHasta       = new System.Windows.Forms.Label();
            this.dtpHistHasta       = new System.Windows.Forms.DateTimePicker();
            this.lblHistProd        = new System.Windows.Forms.Label();
            this.cboHistProd        = new System.Windows.Forms.ComboBox();
            this.btnHistBuscar      = new System.Windows.Forms.Button();
            this.btnHistTodos       = new System.Windows.Forms.Button();

            // ── Defectos ─────────────────────────────────────────────
            this.dgvDefectos        = new System.Windows.Forms.DataGridView();
            this.pnlDefForm         = new System.Windows.Forms.Panel();
            this.lblDefTitulo       = new System.Windows.Forms.Label();
            this.lblDefProd         = new System.Windows.Forms.Label();
            this.cboDefProd         = new System.Windows.Forms.ComboBox();
            this.lblDefDesc         = new System.Windows.Forms.Label();
            this.txtDefDesc         = new System.Windows.Forms.TextBox();
            this.lblDefCant         = new System.Windows.Forms.Label();
            this.numDefCant         = new System.Windows.Forms.NumericUpDown();
            this.btnDefRegistrar    = new System.Windows.Forms.Button();
            this.btnDefLimpiar      = new System.Windows.Forms.Button();
            this.lblDefFiltro       = new System.Windows.Forms.Label();
            this.cboDefFiltro       = new System.Windows.Forms.ComboBox();
            this.btnDefFiltrar      = new System.Windows.Forms.Button();

            // ── Alertas ──────────────────────────────────────────────
            this.dgvAlertas         = new System.Windows.Forms.DataGridView();
            this.pnlAlertasBotones  = new System.Windows.Forms.Panel();
            this.lblAlertaContador  = new System.Windows.Forms.Label();
            this.btnAlertaRefrescar = new System.Windows.Forms.Button();
            this.btnAlertaAtender   = new System.Windows.Forms.Button();

            // ════════════════════════════════════════════════════════
            //  SuspendLayout en todos los contenedores
            // ════════════════════════════════════════════════════════
            this.tabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitProductos)).BeginInit();
            this.splitProductos.Panel1.SuspendLayout();
            this.splitProductos.Panel2.SuspendLayout();
            this.splitProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitEquipo)).BeginInit();
            this.splitEquipo.Panel1.SuspendLayout();
            this.splitEquipo.Panel2.SuspendLayout();
            this.splitEquipo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDefectos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlertas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numProdStockMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMovCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDefCant)).BeginInit();
            this.SuspendLayout();

            // ════════════════════════════════════════════════════════
            //  TAB CONTROL
            // ════════════════════════════════════════════════════════
            this.tabControl.Controls.Add(this.tabProductos);
            this.tabControl.Controls.Add(this.tabEquipo);
            this.tabControl.Controls.Add(this.tabMovimientos);
            this.tabControl.Controls.Add(this.tabHistorial);
            this.tabControl.Controls.Add(this.tabDefectos);
            this.tabControl.Controls.Add(this.tabAlertas);
            this.tabControl.Dock     = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Name     = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);

            this.tabProductos.Text   = "Productos";    this.tabProductos.Name   = "tabProductos";   this.tabProductos.Padding = new System.Windows.Forms.Padding(3);
            this.tabEquipo.Text      = "Equipo";       this.tabEquipo.Name      = "tabEquipo";      this.tabEquipo.Padding = new System.Windows.Forms.Padding(3);
            this.tabMovimientos.Text = "Movimientos";  this.tabMovimientos.Name = "tabMovimientos"; this.tabMovimientos.Padding = new System.Windows.Forms.Padding(3);
            this.tabHistorial.Text   = "Historial";    this.tabHistorial.Name   = "tabHistorial";   this.tabHistorial.Padding = new System.Windows.Forms.Padding(3);
            this.tabDefectos.Text    = "Defectos";     this.tabDefectos.Name    = "tabDefectos";    this.tabDefectos.Padding = new System.Windows.Forms.Padding(3);
            this.tabAlertas.Text     = "Alertas";      this.tabAlertas.Name     = "tabAlertas";     this.tabAlertas.Padding = new System.Windows.Forms.Padding(3);

            // ════════════════════════════════════════════════════════
            //  TAB PRODUCTOS
            // ════════════════════════════════════════════════════════
            // Panel filtro superior
            this.pnlProdFiltro.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlProdFiltro.Height = 40;
            this.pnlProdFiltro.Name = "pnlProdFiltro";
            this.lblProdFiltro.Text = "Categoría:"; this.lblProdFiltro.Location = new System.Drawing.Point(5, 10); this.lblProdFiltro.AutoSize = true;
            this.cboProdCategoria.Location = new System.Drawing.Point(70, 7); this.cboProdCategoria.Width = 160; this.cboProdCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cboProdCategoria.Name = "cboProdCategoria";
            this.btnProdFiltrar.Text = "Filtrar";  this.btnProdFiltrar.Location = new System.Drawing.Point(240, 6); this.btnProdFiltrar.Size = new System.Drawing.Size(70, 26); this.btnProdFiltrar.Name = "btnProdFiltrar"; this.btnProdFiltrar.Click += new System.EventHandler(this.btnProdFiltrar_Click);
            this.btnProdTodos.Text  = "Todos";    this.btnProdTodos.Location  = new System.Drawing.Point(318, 6); this.btnProdTodos.Size  = new System.Drawing.Size(70, 26); this.btnProdTodos.Name  = "btnProdTodos";  this.btnProdTodos.Click  += new System.EventHandler(this.btnProdTodos_Click);
            this.pnlProdFiltro.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblProdFiltro, this.cboProdCategoria, this.btnProdFiltrar, this.btnProdTodos });

            // SplitContainer productos
            this.splitProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitProductos.Name = "splitProductos";
            this.splitProductos.SplitterDistance = 420;

            // Panel1 → grilla
            this.dgvProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.MultiSelect = false;
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.SelectionChanged += new System.EventHandler(this.dgvProductos_SelectionChanged);
            this.splitProductos.Panel1.Controls.Add(this.dgvProductos);

            // Panel2 → formulario producto
            this.pnlProdForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlProdForm.AutoScroll = true;
            this.pnlProdForm.Name = "pnlProdForm";

            this.lblProdTitulo.Text = "Producto"; this.lblProdTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold); this.lblProdTitulo.Location = new System.Drawing.Point(5, 5); this.lblProdTitulo.AutoSize = true;

            this.lblProdCodigo.Text = "Código:";     this.lblProdCodigo.Location  = new System.Drawing.Point(5, 40);  this.lblProdCodigo.AutoSize = true;
            this.txtProdCodigo.Location = new System.Drawing.Point(90, 37); this.txtProdCodigo.Width = 140; this.txtProdCodigo.Name = "txtProdCodigo"; this.txtProdCodigo.ReadOnly = true;
            this.btnProdEscanear.Text = "Escanear"; this.btnProdEscanear.Location = new System.Drawing.Point(238, 36); this.btnProdEscanear.Size = new System.Drawing.Size(75, 24); this.btnProdEscanear.Name = "btnProdEscanear"; this.btnProdEscanear.Click += new System.EventHandler(this.btnProdEscanear_Click);
            this.btnProdGenerarCodigo.Text = "Generar CB"; this.btnProdGenerarCodigo.Location = new System.Drawing.Point(90, 65); this.btnProdGenerarCodigo.Size = new System.Drawing.Size(90, 24); this.btnProdGenerarCodigo.Name = "btnProdGenerarCodigo"; this.btnProdGenerarCodigo.Click += new System.EventHandler(this.btnProdGenerarCodigo_Click);

            this.picCodigoBarras.Location = new System.Drawing.Point(5, 95); this.picCodigoBarras.Size = new System.Drawing.Size(310, 60); this.picCodigoBarras.Name = "picCodigoBarras"; this.picCodigoBarras.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom; this.picCodigoBarras.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.lblProdNombre.Text = "Nombre:";     this.lblProdNombre.Location  = new System.Drawing.Point(5, 168); this.lblProdNombre.AutoSize = true;
            this.txtProdNombre.Location = new System.Drawing.Point(90, 165); this.txtProdNombre.Width = 220; this.txtProdNombre.Name = "txtProdNombre"; this.txtProdNombre.ReadOnly = true;

            this.lblProdCat.Text = "Categoría:";    this.lblProdCat.Location     = new System.Drawing.Point(5, 200); this.lblProdCat.AutoSize = true;
            this.cboProdCat.Location = new System.Drawing.Point(90, 197); this.cboProdCat.Width = 180; this.cboProdCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cboProdCat.Name = "cboProdCat"; this.cboProdCat.Enabled = false;

            this.lblProdPrecio.Text = "Precio:";     this.lblProdPrecio.Location  = new System.Drawing.Point(5, 232); this.lblProdPrecio.AutoSize = true;
            this.txtProdPrecio.Location = new System.Drawing.Point(90, 229); this.txtProdPrecio.Width = 100; this.txtProdPrecio.Name = "txtProdPrecio"; this.txtProdPrecio.Text = "0.00"; this.txtProdPrecio.ReadOnly = true;

            this.lblProdStockMin.Text = "Stock Mín:"; this.lblProdStockMin.Location = new System.Drawing.Point(5, 264); this.lblProdStockMin.AutoSize = true;
            this.numProdStockMin.Location = new System.Drawing.Point(90, 261); this.numProdStockMin.Width = 70; this.numProdStockMin.Minimum = 0; this.numProdStockMin.Maximum = 9999; this.numProdStockMin.Value = 3; this.numProdStockMin.Name = "numProdStockMin"; this.numProdStockMin.Enabled = false;

            this.chkProdCaducidad.Text = "Fecha Cad:"; this.chkProdCaducidad.Location = new System.Drawing.Point(5, 296); this.chkProdCaducidad.AutoSize = true; this.chkProdCaducidad.Name = "chkProdCaducidad"; this.chkProdCaducidad.Enabled = false; this.chkProdCaducidad.CheckedChanged += new System.EventHandler(this.chkProdCaducidad_CheckedChanged);

            this.lblProdProveedor.Text = "Proveedor:"; this.lblProdProveedor.Location = new System.Drawing.Point(5, 328); this.lblProdProveedor.AutoSize = true; this.lblProdProveedor.Name = "lblProdProveedor";
            this.cboProdProveedor.Location = new System.Drawing.Point(90, 325); this.cboProdProveedor.Width = 210; this.cboProdProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cboProdProveedor.Name = "cboProdProveedor"; this.cboProdProveedor.Enabled = false;
            this.lblProdCaducidad.Text = ""; this.lblProdCaducidad.Location = new System.Drawing.Point(5, 296); this.lblProdCaducidad.AutoSize = true; this.lblProdCaducidad.Name = "lblProdCaducidad";
            this.dtpProdCaducidad.Location = new System.Drawing.Point(90, 293); this.dtpProdCaducidad.Width = 140; this.dtpProdCaducidad.Name = "dtpProdCaducidad"; this.dtpProdCaducidad.Enabled = false;

            this.btnProdNuevo.Text    = "Nuevo";    this.btnProdNuevo.Location    = new System.Drawing.Point(5,  335); this.btnProdNuevo.Size    = new System.Drawing.Size(70, 26); this.btnProdNuevo.Name    = "btnProdNuevo";    this.btnProdNuevo.Click    += new System.EventHandler(this.btnProdNuevo_Click);
            this.btnProdEditar.Text   = "Editar";   this.btnProdEditar.Location   = new System.Drawing.Point(82, 335); this.btnProdEditar.Size   = new System.Drawing.Size(70, 26); this.btnProdEditar.Name   = "btnProdEditar";   this.btnProdEditar.Enabled = false; this.btnProdEditar.Click   += new System.EventHandler(this.btnProdEditar_Click);
            this.btnProdGuardar.Text  = "Guardar";  this.btnProdGuardar.Location  = new System.Drawing.Point(5,  368); this.btnProdGuardar.Size  = new System.Drawing.Size(70, 26); this.btnProdGuardar.Name  = "btnProdGuardar";  this.btnProdGuardar.Enabled = false; this.btnProdGuardar.Click  += new System.EventHandler(this.btnProdGuardar_Click);
            this.btnProdCancelar.Text = "Cancelar"; this.btnProdCancelar.Location = new System.Drawing.Point(82, 368); this.btnProdCancelar.Size = new System.Drawing.Size(70, 26); this.btnProdCancelar.Name = "btnProdCancelar"; this.btnProdCancelar.Enabled = false; this.btnProdCancelar.Click += new System.EventHandler(this.btnProdCancelar_Click);
            this.btnProdBaja.Text     = "Dar Baja"; this.btnProdBaja.Location     = new System.Drawing.Point(160,335); this.btnProdBaja.Size     = new System.Drawing.Size(70, 26); this.btnProdBaja.Name     = "btnProdBaja";     this.btnProdBaja.Enabled = false; this.btnProdBaja.Click     += new System.EventHandler(this.btnProdBaja_Click);

            this.pnlProdForm.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblProdTitulo, this.lblProdCodigo, this.txtProdCodigo,
                this.btnProdEscanear, this.btnProdGenerarCodigo, this.picCodigoBarras,
                this.lblProdNombre, this.txtProdNombre, this.lblProdCat, this.cboProdCat,
                this.lblProdPrecio, this.txtProdPrecio, this.lblProdStockMin, this.numProdStockMin,
                this.chkProdCaducidad, this.lblProdCaducidad, this.dtpProdCaducidad,
                this.lblProdProveedor, this.cboProdProveedor,
                this.btnProdNuevo, this.btnProdEditar, this.btnProdGuardar,
                this.btnProdCancelar, this.btnProdBaja });
            this.splitProductos.Panel2.Controls.Add(this.pnlProdForm);

            this.tabProductos.Controls.Add(this.splitProductos);
            this.tabProductos.Controls.Add(this.pnlProdFiltro);

            // ════════════════════════════════════════════════════════
            //  TAB EQUIPO
            // ════════════════════════════════════════════════════════
            this.pnlEqFiltro.Dock = System.Windows.Forms.DockStyle.Top; this.pnlEqFiltro.Height = 40; this.pnlEqFiltro.Name = "pnlEqFiltro";
            this.lblEqFiltroEstado.Text = "Estado:"; this.lblEqFiltroEstado.Location = new System.Drawing.Point(5, 10); this.lblEqFiltroEstado.AutoSize = true;
            this.cboEqFiltroEstado.Location = new System.Drawing.Point(60, 7); this.cboEqFiltroEstado.Width = 120; this.cboEqFiltroEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cboEqFiltroEstado.Name = "cboEqFiltroEstado";
            this.cboEqFiltroEstado.Items.AddRange(new object[] { "BUENO", "DAÑADO", "BAJA" });
            this.btnEqFiltrar.Text = "Filtrar"; this.btnEqFiltrar.Location = new System.Drawing.Point(190, 6); this.btnEqFiltrar.Size = new System.Drawing.Size(70, 26); this.btnEqFiltrar.Name = "btnEqFiltrar"; this.btnEqFiltrar.Click += new System.EventHandler(this.btnEqFiltrar_Click);
            this.btnEqTodos.Text  = "Todos";   this.btnEqTodos.Location  = new System.Drawing.Point(268, 6); this.btnEqTodos.Size  = new System.Drawing.Size(70, 26); this.btnEqTodos.Name  = "btnEqTodos";  this.btnEqTodos.Click  += new System.EventHandler(this.btnEqTodos_Click);
            this.pnlEqFiltro.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblEqFiltroEstado, this.cboEqFiltroEstado, this.btnEqFiltrar, this.btnEqTodos });

            this.splitEquipo.Dock = System.Windows.Forms.DockStyle.Fill; this.splitEquipo.Name = "splitEquipo"; this.splitEquipo.SplitterDistance = 420;

            this.dgvEquipo.Dock = System.Windows.Forms.DockStyle.Fill; this.dgvEquipo.Name = "dgvEquipo"; this.dgvEquipo.ReadOnly = true;
            this.dgvEquipo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect; this.dgvEquipo.MultiSelect = false; this.dgvEquipo.AllowUserToAddRows = false;
            this.dgvEquipo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEquipo.SelectionChanged += new System.EventHandler(this.dgvEquipo_SelectionChanged);
            this.splitEquipo.Panel1.Controls.Add(this.dgvEquipo);

            this.pnlEqForm.Dock = System.Windows.Forms.DockStyle.Fill; this.pnlEqForm.AutoScroll = true; this.pnlEqForm.Name = "pnlEqForm";
            this.lblEqTitulo.Text = "Equipo"; this.lblEqTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold); this.lblEqTitulo.Location = new System.Drawing.Point(5, 5); this.lblEqTitulo.AutoSize = true;
            this.lblEqNombre.Text = "Nombre:";      this.lblEqNombre.Location = new System.Drawing.Point(5, 40);  this.lblEqNombre.AutoSize = true;
            this.txtEqNombre.Location = new System.Drawing.Point(90, 37); this.txtEqNombre.Width = 200; this.txtEqNombre.Name = "txtEqNombre"; this.txtEqNombre.ReadOnly = true;
            this.lblEqCat.Text = "Categoría:";      this.lblEqCat.Location    = new System.Drawing.Point(5, 72);  this.lblEqCat.AutoSize = true;
            this.cboEqCat.Location = new System.Drawing.Point(90, 69); this.cboEqCat.Width = 180; this.cboEqCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cboEqCat.Name = "cboEqCat"; this.cboEqCat.Enabled = false;
            this.lblEqEstado.Text = "Estado:";       this.lblEqEstado.Location = new System.Drawing.Point(5, 104); this.lblEqEstado.AutoSize = true;
            this.cboEqEstado.Location = new System.Drawing.Point(90, 101); this.cboEqEstado.Width = 120; this.cboEqEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cboEqEstado.Name = "cboEqEstado"; this.cboEqEstado.Enabled = false;
            this.cboEqEstado.Items.AddRange(new object[] { "BUENO", "DAÑADO", "BAJA" });
            this.chkEqFecha.Text = "Adquisición:";  this.chkEqFecha.Location  = new System.Drawing.Point(5, 136); this.chkEqFecha.AutoSize = true; this.chkEqFecha.Name = "chkEqFecha"; this.chkEqFecha.Enabled = false; this.chkEqFecha.CheckedChanged += new System.EventHandler(this.chkEqFecha_CheckedChanged);
            this.lblEqFecha.Text = "";               this.lblEqFecha.Location  = new System.Drawing.Point(5, 136); this.lblEqFecha.AutoSize = true; this.lblEqFecha.Name = "lblEqFecha";
            this.dtpEqFecha.Location = new System.Drawing.Point(90, 133); this.dtpEqFecha.Width = 140; this.dtpEqFecha.Name = "dtpEqFecha"; this.dtpEqFecha.Enabled = false;
            this.lblEqObs.Text = "Observaciones:"; this.lblEqObs.Location    = new System.Drawing.Point(5, 168); this.lblEqObs.AutoSize = true;
            this.txtEqObs.Location = new System.Drawing.Point(5, 188); this.txtEqObs.Size = new System.Drawing.Size(290, 60); this.txtEqObs.Multiline = true; this.txtEqObs.Name = "txtEqObs"; this.txtEqObs.ReadOnly = true;
            this.btnEqNuevo.Text    = "Nuevo";    this.btnEqNuevo.Location    = new System.Drawing.Point(5,   260); this.btnEqNuevo.Size    = new System.Drawing.Size(70, 26); this.btnEqNuevo.Name    = "btnEqNuevo";    this.btnEqNuevo.Click    += new System.EventHandler(this.btnEqNuevo_Click);
            this.btnEqEditar.Text   = "Editar";   this.btnEqEditar.Location   = new System.Drawing.Point(82,  260); this.btnEqEditar.Size   = new System.Drawing.Size(70, 26); this.btnEqEditar.Name   = "btnEqEditar";   this.btnEqEditar.Enabled = false; this.btnEqEditar.Click   += new System.EventHandler(this.btnEqEditar_Click);
            this.btnEqGuardar.Text  = "Guardar";  this.btnEqGuardar.Location  = new System.Drawing.Point(5,   293); this.btnEqGuardar.Size  = new System.Drawing.Size(70, 26); this.btnEqGuardar.Name  = "btnEqGuardar";  this.btnEqGuardar.Enabled = false; this.btnEqGuardar.Click  += new System.EventHandler(this.btnEqGuardar_Click);
            this.btnEqCancelar.Text = "Cancelar"; this.btnEqCancelar.Location = new System.Drawing.Point(82,  293); this.btnEqCancelar.Size = new System.Drawing.Size(70, 26); this.btnEqCancelar.Name = "btnEqCancelar"; this.btnEqCancelar.Enabled = false; this.btnEqCancelar.Click += new System.EventHandler(this.btnEqCancelar_Click);
            this.btnEqBaja.Text     = "Dar Baja"; this.btnEqBaja.Location     = new System.Drawing.Point(160, 260); this.btnEqBaja.Size     = new System.Drawing.Size(70, 26); this.btnEqBaja.Name     = "btnEqBaja";     this.btnEqBaja.Enabled = false; this.btnEqBaja.Click     += new System.EventHandler(this.btnEqBaja_Click);

            this.pnlEqForm.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblEqTitulo, this.lblEqNombre, this.txtEqNombre,
                this.lblEqCat, this.cboEqCat, this.lblEqEstado, this.cboEqEstado,
                this.chkEqFecha, this.lblEqFecha, this.dtpEqFecha,
                this.lblEqObs, this.txtEqObs,
                this.btnEqNuevo, this.btnEqEditar, this.btnEqGuardar,
                this.btnEqCancelar, this.btnEqBaja });
            this.splitEquipo.Panel2.Controls.Add(this.pnlEqForm);

            this.tabEquipo.Controls.Add(this.splitEquipo);
            this.tabEquipo.Controls.Add(this.pnlEqFiltro);

            // ════════════════════════════════════════════════════════
            //  TAB MOVIMIENTOS
            // ════════════════════════════════════════════════════════
            this.pnlMovForm.Dock = System.Windows.Forms.DockStyle.Fill; this.pnlMovForm.AutoScroll = true; this.pnlMovForm.Name = "pnlMovForm";
            this.lblMovTitulo.Text = "Registrar Movimiento"; this.lblMovTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold); this.lblMovTitulo.Location = new System.Drawing.Point(10, 10); this.lblMovTitulo.AutoSize = true;
            this.lblMovCodigo.Text = "Código:";    this.lblMovCodigo.Location   = new System.Drawing.Point(10, 50);  this.lblMovCodigo.AutoSize = true;
            this.txtMovCodigo.Location = new System.Drawing.Point(110, 47); this.txtMovCodigo.Width = 180; this.txtMovCodigo.Name = "txtMovCodigo"; this.txtMovCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMovCodigo_KeyDown);
            this.btnMovBuscar.Text = "Buscar"; this.btnMovBuscar.Location = new System.Drawing.Point(298, 46); this.btnMovBuscar.Size = new System.Drawing.Size(70, 26); this.btnMovBuscar.Name = "btnMovBuscar"; this.btnMovBuscar.Click += new System.EventHandler(this.btnMovBuscar_Click);
            this.lblMovProducto.Text = "Producto:"; this.lblMovProducto.Location = new System.Drawing.Point(10, 85);  this.lblMovProducto.AutoSize = true;
            this.txtMovProducto.Location = new System.Drawing.Point(110, 82); this.txtMovProducto.Width = 300; this.txtMovProducto.Name = "txtMovProducto"; this.txtMovProducto.ReadOnly = true;
            this.lblMovStock.Text = "Stock actual:"; this.lblMovStock.Location = new System.Drawing.Point(10, 118); this.lblMovStock.AutoSize = true;
            this.txtMovStock.Location = new System.Drawing.Point(110, 115); this.txtMovStock.Width = 80; this.txtMovStock.Name = "txtMovStock"; this.txtMovStock.ReadOnly = true;
            this.lblMovAlerta.Text = ""; this.lblMovAlerta.Location = new System.Drawing.Point(200, 118); this.lblMovAlerta.AutoSize = true; this.lblMovAlerta.ForeColor = System.Drawing.Color.Red; this.lblMovAlerta.Name = "lblMovAlerta"; this.lblMovAlerta.Visible = false;
            this.picMovAlerta.Location = new System.Drawing.Point(110, 140); this.picMovAlerta.Size = new System.Drawing.Size(0, 0); this.picMovAlerta.Name = "picMovAlerta";
            this.lblMovTipo.Text = "Tipo:";       this.lblMovTipo.Location     = new System.Drawing.Point(10, 150); this.lblMovTipo.AutoSize = true;
            this.rbMovEntrada.Text = "Entrada"; this.rbMovEntrada.Location = new System.Drawing.Point(110, 148); this.rbMovEntrada.AutoSize = true; this.rbMovEntrada.Name = "rbMovEntrada"; this.rbMovEntrada.Checked = true;
            this.rbMovSalida.Text  = "Salida";  this.rbMovSalida.Location  = new System.Drawing.Point(185, 148); this.rbMovSalida.AutoSize  = true; this.rbMovSalida.Name  = "rbMovSalida";
            this.lblMovCantidad.Text = "Cantidad:"; this.lblMovCantidad.Location = new System.Drawing.Point(10, 183); this.lblMovCantidad.AutoSize = true;
            this.numMovCantidad.Location = new System.Drawing.Point(110, 180); this.numMovCantidad.Width = 80; this.numMovCantidad.Minimum = 1; this.numMovCantidad.Maximum = 9999; this.numMovCantidad.Value = 1; this.numMovCantidad.Name = "numMovCantidad";
            this.lblMovMotivo.Text = "Motivo:";    this.lblMovMotivo.Location   = new System.Drawing.Point(10, 215); this.lblMovMotivo.AutoSize = true;
            this.txtMovMotivo.Location = new System.Drawing.Point(110, 212); this.txtMovMotivo.Width = 300; this.txtMovMotivo.Name = "txtMovMotivo";
            this.btnMovRegistrar.Text = "Registrar"; this.btnMovRegistrar.Location = new System.Drawing.Point(110, 248); this.btnMovRegistrar.Size = new System.Drawing.Size(90, 28); this.btnMovRegistrar.Name = "btnMovRegistrar"; this.btnMovRegistrar.Click += new System.EventHandler(this.btnMovRegistrar_Click);
            this.btnMovLimpiar.Text   = "Limpiar";   this.btnMovLimpiar.Location   = new System.Drawing.Point(208, 248); this.btnMovLimpiar.Size   = new System.Drawing.Size(90, 28); this.btnMovLimpiar.Name   = "btnMovLimpiar";   this.btnMovLimpiar.Click   += new System.EventHandler(this.btnMovLimpiar_Click);

            this.pnlMovForm.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblMovTitulo, this.lblMovCodigo, this.txtMovCodigo, this.btnMovBuscar,
                this.lblMovProducto, this.txtMovProducto, this.lblMovStock, this.txtMovStock,
                this.lblMovAlerta, this.picMovAlerta, this.lblMovTipo, this.rbMovEntrada, this.rbMovSalida,
                this.lblMovCantidad, this.numMovCantidad, this.lblMovMotivo, this.txtMovMotivo,
                this.btnMovRegistrar, this.btnMovLimpiar });
            this.tabMovimientos.Controls.Add(this.pnlMovForm);

            // ════════════════════════════════════════════════════════
            //  TAB HISTORIAL
            // ════════════════════════════════════════════════════════
            this.pnlHistFiltro.Dock = System.Windows.Forms.DockStyle.Top; this.pnlHistFiltro.Height = 45; this.pnlHistFiltro.Name = "pnlHistFiltro";
            this.lblHistDesde.Text = "Desde:"; this.lblHistDesde.Location = new System.Drawing.Point(5, 12);  this.lblHistDesde.AutoSize = true;
            this.dtpHistDesde.Location = new System.Drawing.Point(55, 9);  this.dtpHistDesde.Width = 120; this.dtpHistDesde.Name = "dtpHistDesde";
            this.lblHistHasta.Text = "Hasta:"; this.lblHistHasta.Location = new System.Drawing.Point(185, 12); this.lblHistHasta.AutoSize = true;
            this.dtpHistHasta.Location = new System.Drawing.Point(230, 9);  this.dtpHistHasta.Width = 120; this.dtpHistHasta.Name = "dtpHistHasta";
            this.lblHistProd.Text  = "Producto:"; this.lblHistProd.Location  = new System.Drawing.Point(360, 12); this.lblHistProd.AutoSize = true;
            this.cboHistProd.Location = new System.Drawing.Point(420, 9); this.cboHistProd.Width = 160; this.cboHistProd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cboHistProd.Name = "cboHistProd";
            this.btnHistBuscar.Text = "Buscar"; this.btnHistBuscar.Location = new System.Drawing.Point(590, 8); this.btnHistBuscar.Size = new System.Drawing.Size(70, 26); this.btnHistBuscar.Name = "btnHistBuscar"; this.btnHistBuscar.Click += new System.EventHandler(this.btnHistBuscar_Click);
            this.btnHistTodos.Text  = "Todos";  this.btnHistTodos.Location  = new System.Drawing.Point(668, 8); this.btnHistTodos.Size  = new System.Drawing.Size(70, 26); this.btnHistTodos.Name  = "btnHistTodos";  this.btnHistTodos.Click  += new System.EventHandler(this.btnHistTodos_Click);
            this.pnlHistFiltro.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblHistDesde, this.dtpHistDesde, this.lblHistHasta, this.dtpHistHasta,
                this.lblHistProd, this.cboHistProd, this.btnHistBuscar, this.btnHistTodos });
            this.dgvHistorial.Dock = System.Windows.Forms.DockStyle.Fill; this.dgvHistorial.Name = "dgvHistorial"; this.dgvHistorial.ReadOnly = true; this.dgvHistorial.AllowUserToAddRows = false; this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabHistorial.Controls.Add(this.dgvHistorial);
            this.tabHistorial.Controls.Add(this.pnlHistFiltro);

            // ════════════════════════════════════════════════════════
            //  TAB DEFECTOS
            // ════════════════════════════════════════════════════════
            this.pnlDefForm.Dock = System.Windows.Forms.DockStyle.Top; this.pnlDefForm.Height = 130; this.pnlDefForm.Name = "pnlDefForm";
            this.lblDefTitulo.Text = "Registrar Defecto"; this.lblDefTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold); this.lblDefTitulo.Location = new System.Drawing.Point(5, 5); this.lblDefTitulo.AutoSize = true;
            this.lblDefProd.Text  = "Producto:";     this.lblDefProd.Location  = new System.Drawing.Point(5,  35); this.lblDefProd.AutoSize = true;
            this.cboDefProd.Location = new System.Drawing.Point(90, 32); this.cboDefProd.Width = 200; this.cboDefProd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cboDefProd.Name = "cboDefProd";
            this.lblDefDesc.Text  = "Descripción:";  this.lblDefDesc.Location  = new System.Drawing.Point(5,  65); this.lblDefDesc.AutoSize = true;
            this.txtDefDesc.Location = new System.Drawing.Point(90, 62); this.txtDefDesc.Width = 300; this.txtDefDesc.Name = "txtDefDesc";
            this.lblDefCant.Text  = "Cantidad:";     this.lblDefCant.Location  = new System.Drawing.Point(5,  95); this.lblDefCant.AutoSize = true;
            this.numDefCant.Location = new System.Drawing.Point(90, 92); this.numDefCant.Width = 70; this.numDefCant.Minimum = 1; this.numDefCant.Maximum = 9999; this.numDefCant.Value = 1; this.numDefCant.Name = "numDefCant";
            this.btnDefRegistrar.Text = "Registrar"; this.btnDefRegistrar.Location = new System.Drawing.Point(170, 91); this.btnDefRegistrar.Size = new System.Drawing.Size(80, 26); this.btnDefRegistrar.Name = "btnDefRegistrar"; this.btnDefRegistrar.Click += new System.EventHandler(this.btnDefRegistrar_Click);
            this.btnDefLimpiar.Text   = "Limpiar";   this.btnDefLimpiar.Location   = new System.Drawing.Point(258, 91); this.btnDefLimpiar.Size   = new System.Drawing.Size(80, 26); this.btnDefLimpiar.Name   = "btnDefLimpiar";   this.btnDefLimpiar.Click   += new System.EventHandler(this.btnDefLimpiar_Click);
            this.lblDefFiltro.Text = "Ver por producto:"; this.lblDefFiltro.Location = new System.Drawing.Point(350, 35); this.lblDefFiltro.AutoSize = true;
            this.cboDefFiltro.Location = new System.Drawing.Point(470, 32); this.cboDefFiltro.Width = 180; this.cboDefFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cboDefFiltro.Name = "cboDefFiltro";
            this.btnDefFiltrar.Text = "Filtrar"; this.btnDefFiltrar.Location = new System.Drawing.Point(658, 31); this.btnDefFiltrar.Size = new System.Drawing.Size(70, 26); this.btnDefFiltrar.Name = "btnDefFiltrar"; this.btnDefFiltrar.Click += new System.EventHandler(this.btnDefFiltrar_Click);
            this.pnlDefForm.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblDefTitulo, this.lblDefProd, this.cboDefProd, this.lblDefDesc, this.txtDefDesc,
                this.lblDefCant, this.numDefCant, this.btnDefRegistrar, this.btnDefLimpiar,
                this.lblDefFiltro, this.cboDefFiltro, this.btnDefFiltrar });
            this.dgvDefectos.Dock = System.Windows.Forms.DockStyle.Fill; this.dgvDefectos.Name = "dgvDefectos"; this.dgvDefectos.ReadOnly = true; this.dgvDefectos.AllowUserToAddRows = false; this.dgvDefectos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabDefectos.Controls.Add(this.dgvDefectos);
            this.tabDefectos.Controls.Add(this.pnlDefForm);

            // ════════════════════════════════════════════════════════
            //  TAB ALERTAS
            // ════════════════════════════════════════════════════════
            this.pnlAlertasBotones.Dock = System.Windows.Forms.DockStyle.Top; this.pnlAlertasBotones.Height = 40; this.pnlAlertasBotones.Name = "pnlAlertasBotones";
            this.lblAlertaContador.Text = "Alertas pendientes: 0"; this.lblAlertaContador.Location = new System.Drawing.Point(5, 12); this.lblAlertaContador.AutoSize = true; this.lblAlertaContador.Name = "lblAlertaContador";
            this.btnAlertaRefrescar.Text = "Refrescar"; this.btnAlertaRefrescar.Location = new System.Drawing.Point(200, 8); this.btnAlertaRefrescar.Size = new System.Drawing.Size(80, 26); this.btnAlertaRefrescar.Name = "btnAlertaRefrescar"; this.btnAlertaRefrescar.Click += new System.EventHandler(this.btnAlertaRefrescar_Click);
            this.btnAlertaAtender.Text   = "Atendida";  this.btnAlertaAtender.Location   = new System.Drawing.Point(288, 8); this.btnAlertaAtender.Size   = new System.Drawing.Size(80, 26); this.btnAlertaAtender.Name   = "btnAlertaAtender";   this.btnAlertaAtender.Click   += new System.EventHandler(this.btnAlertaAtender_Click);
            this.pnlAlertasBotones.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblAlertaContador, this.btnAlertaRefrescar, this.btnAlertaAtender });
            this.dgvAlertas.Dock = System.Windows.Forms.DockStyle.Fill; this.dgvAlertas.Name = "dgvAlertas"; this.dgvAlertas.ReadOnly = true; this.dgvAlertas.AllowUserToAddRows = false; this.dgvAlertas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabAlertas.Controls.Add(this.dgvAlertas);
            this.tabAlertas.Controls.Add(this.pnlAlertasBotones);

            // ════════════════════════════════════════════════════════
            //  FORM PRINCIPAL
            // ════════════════════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.None;
            this.Name                = "FrmInventario";
            this.Text                = "Inventario";
            this.Load               += new System.EventHandler(this.FrmInventario_Load);

            // ── ResumeLayout ─────────────────────────────────────────
            this.splitProductos.Panel1.ResumeLayout(false);
            this.splitProductos.Panel2.ResumeLayout(false);
            this.splitProductos.ResumeLayout(false);
            this.splitEquipo.Panel1.ResumeLayout(false);
            this.splitEquipo.Panel2.ResumeLayout(false);
            this.splitEquipo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDefectos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlertas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numProdStockMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMovCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDefCant)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        #endregion

        // ── Declaración de controles ─────────────────────────────────
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabProductos, tabEquipo, tabMovimientos,
                                              tabHistorial, tabDefectos, tabAlertas;
        private System.Windows.Forms.SplitContainer splitProductos, splitEquipo;
        private System.Windows.Forms.Panel pnlProdFiltro, pnlProdForm;
        private System.Windows.Forms.Label lblProdFiltro, lblProdTitulo, lblProdCodigo,
                                            lblProdNombre, lblProdCat, lblProdPrecio,
                                            lblProdStockMin, lblProdCaducidad;
        private System.Windows.Forms.ComboBox cboProdCategoria, cboProdCat;
        private System.Windows.Forms.TextBox txtProdCodigo, txtProdNombre, txtProdPrecio;
        private System.Windows.Forms.NumericUpDown numProdStockMin;
        private System.Windows.Forms.DateTimePicker dtpProdCaducidad;
        private System.Windows.Forms.CheckBox chkProdCaducidad;
        private System.Windows.Forms.Label lblProdProveedor;
        private System.Windows.Forms.ComboBox cboProdProveedor;
        private System.Windows.Forms.Button btnProdFiltrar, btnProdTodos, btnProdEscanear,
                                             btnProdNuevo, btnProdGuardar, btnProdEditar,
                                             btnProdBaja, btnProdCancelar, btnProdGenerarCodigo;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.PictureBox picCodigoBarras;
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
        private System.Windows.Forms.Panel pnlMovForm;
        private System.Windows.Forms.Label lblMovTitulo, lblMovCodigo, lblMovProducto,
                                            lblMovStock, lblMovTipo, lblMovCantidad,
                                            lblMovMotivo, lblMovAlerta;
        private System.Windows.Forms.TextBox txtMovCodigo, txtMovProducto, txtMovStock, txtMovMotivo;
        private System.Windows.Forms.RadioButton rbMovEntrada, rbMovSalida;
        private System.Windows.Forms.NumericUpDown numMovCantidad;
        private System.Windows.Forms.Button btnMovBuscar, btnMovRegistrar, btnMovLimpiar;
        private System.Windows.Forms.PictureBox picMovAlerta;
        private System.Windows.Forms.Panel pnlHistFiltro;
        private System.Windows.Forms.Label lblHistDesde, lblHistHasta, lblHistProd;
        private System.Windows.Forms.DateTimePicker dtpHistDesde, dtpHistHasta;
        private System.Windows.Forms.ComboBox cboHistProd;
        private System.Windows.Forms.Button btnHistBuscar, btnHistTodos;
        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.Panel pnlDefForm;
        private System.Windows.Forms.Label lblDefTitulo, lblDefProd, lblDefDesc,
                                            lblDefCant, lblDefFiltro;
        private System.Windows.Forms.ComboBox cboDefProd, cboDefFiltro;
        private System.Windows.Forms.TextBox txtDefDesc;
        private System.Windows.Forms.NumericUpDown numDefCant;
        private System.Windows.Forms.Button btnDefRegistrar, btnDefLimpiar, btnDefFiltrar;
        private System.Windows.Forms.DataGridView dgvDefectos;
        private System.Windows.Forms.Panel pnlAlertasBotones;
        private System.Windows.Forms.Label lblAlertaContador;
        private System.Windows.Forms.Button btnAlertaRefrescar, btnAlertaAtender;
        private System.Windows.Forms.DataGridView dgvAlertas;
    }
}
