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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabProductos = new System.Windows.Forms.TabPage();
            this.splitProductos = new System.Windows.Forms.SplitContainer();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.pnlProdForm = new System.Windows.Forms.Panel();
            this.lblProdTitulo = new System.Windows.Forms.Label();
            this.lblProdCodigo = new System.Windows.Forms.Label();
            this.txtProdCodigo = new System.Windows.Forms.TextBox();
            this.btnProdEscanear = new System.Windows.Forms.Button();
            this.btnProdGenerarCodigo = new System.Windows.Forms.Button();
            this.picCodigoBarras = new System.Windows.Forms.PictureBox();
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
            this.lblProdProveedor = new System.Windows.Forms.Label();
            this.cboProdProveedor = new System.Windows.Forms.ComboBox();
            this.btnProdNuevo = new System.Windows.Forms.Button();
            this.btnProdEditar = new System.Windows.Forms.Button();
            this.btnProdGuardar = new System.Windows.Forms.Button();
            this.btnProdCancelar = new System.Windows.Forms.Button();
            this.btnProdBaja = new System.Windows.Forms.Button();
            this.pnlProdFiltro = new System.Windows.Forms.Panel();
            this.lblProdFiltro = new System.Windows.Forms.Label();
            this.cboProdCategoria = new System.Windows.Forms.ComboBox();
            this.btnProdFiltrar = new System.Windows.Forms.Button();
            this.btnProdTodos = new System.Windows.Forms.Button();
            this.tabEquipo = new System.Windows.Forms.TabPage();
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
            this.btnEqEditar = new System.Windows.Forms.Button();
            this.btnEqGuardar = new System.Windows.Forms.Button();
            this.btnEqCancelar = new System.Windows.Forms.Button();
            this.btnEqBaja = new System.Windows.Forms.Button();
            this.pnlEqFiltro = new System.Windows.Forms.Panel();
            this.lblEqFiltroEstado = new System.Windows.Forms.Label();
            this.cboEqFiltroEstado = new System.Windows.Forms.ComboBox();
            this.btnEqFiltrar = new System.Windows.Forms.Button();
            this.btnEqTodos = new System.Windows.Forms.Button();
            this.tabMovimientos = new System.Windows.Forms.TabPage();
            this.pnlMovForm = new System.Windows.Forms.Panel();
            this.lblMovTitulo = new System.Windows.Forms.Label();
            this.lblMovCodigo = new System.Windows.Forms.Label();
            this.txtMovCodigo = new System.Windows.Forms.TextBox();
            this.btnMovBuscar = new System.Windows.Forms.Button();
            this.lblMovProducto = new System.Windows.Forms.Label();
            this.txtMovProducto = new System.Windows.Forms.TextBox();
            this.lblMovStock = new System.Windows.Forms.Label();
            this.txtMovStock = new System.Windows.Forms.TextBox();
            this.lblMovAlerta = new System.Windows.Forms.Label();
            this.picMovAlerta = new System.Windows.Forms.PictureBox();
            this.lblMovTipo = new System.Windows.Forms.Label();
            this.rbMovEntrada = new System.Windows.Forms.RadioButton();
            this.rbMovSalida = new System.Windows.Forms.RadioButton();
            this.lblMovCantidad = new System.Windows.Forms.Label();
            this.numMovCantidad = new System.Windows.Forms.NumericUpDown();
            this.lblMovMotivo = new System.Windows.Forms.Label();
            this.txtMovMotivo = new System.Windows.Forms.TextBox();
            this.btnMovRegistrar = new System.Windows.Forms.Button();
            this.btnMovLimpiar = new System.Windows.Forms.Button();
            this.tabHistorial = new System.Windows.Forms.TabPage();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.pnlHistFiltro = new System.Windows.Forms.Panel();
            this.lblHistDesde = new System.Windows.Forms.Label();
            this.dtpHistDesde = new System.Windows.Forms.DateTimePicker();
            this.lblHistHasta = new System.Windows.Forms.Label();
            this.dtpHistHasta = new System.Windows.Forms.DateTimePicker();
            this.lblHistProd = new System.Windows.Forms.Label();
            this.cboHistProd = new System.Windows.Forms.ComboBox();
            this.btnHistBuscar = new System.Windows.Forms.Button();
            this.btnHistTodos = new System.Windows.Forms.Button();
            this.tabDefectos = new System.Windows.Forms.TabPage();
            this.dgvDefectos = new System.Windows.Forms.DataGridView();
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
            this.tabAlertas = new System.Windows.Forms.TabPage();
            this.dgvAlertas = new System.Windows.Forms.DataGridView();
            this.pnlAlertasBotones = new System.Windows.Forms.Panel();
            this.lblAlertaContador = new System.Windows.Forms.Label();
            this.btnAlertaRefrescar = new System.Windows.Forms.Button();
            this.btnAlertaAtender = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitProductos)).BeginInit();
            this.splitProductos.Panel1.SuspendLayout();
            this.splitProductos.Panel2.SuspendLayout();
            this.splitProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.pnlProdForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCodigoBarras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numProdStockMin)).BeginInit();
            this.pnlProdFiltro.SuspendLayout();
            this.tabEquipo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitEquipo)).BeginInit();
            this.splitEquipo.Panel1.SuspendLayout();
            this.splitEquipo.Panel2.SuspendLayout();
            this.splitEquipo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipo)).BeginInit();
            this.pnlEqForm.SuspendLayout();
            this.pnlEqFiltro.SuspendLayout();
            this.tabMovimientos.SuspendLayout();
            this.pnlMovForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMovAlerta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMovCantidad)).BeginInit();
            this.tabHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.pnlHistFiltro.SuspendLayout();
            this.tabDefectos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDefectos)).BeginInit();
            this.pnlDefForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDefCant)).BeginInit();
            this.tabAlertas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlertas)).BeginInit();
            this.pnlAlertasBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabProductos);
            this.tabControl.Controls.Add(this.tabEquipo);
            this.tabControl.Controls.Add(this.tabMovimientos);
            this.tabControl.Controls.Add(this.tabHistorial);
            this.tabControl.Controls.Add(this.tabDefectos);
            this.tabControl.Controls.Add(this.tabAlertas);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1100, 650);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabProductos
            // 
            this.tabProductos.Controls.Add(this.splitProductos);
            this.tabProductos.Controls.Add(this.pnlProdFiltro);
            this.tabProductos.Location = new System.Drawing.Point(4, 25);
            this.tabProductos.Name = "tabProductos";
            this.tabProductos.Padding = new System.Windows.Forms.Padding(3);
            this.tabProductos.Size = new System.Drawing.Size(1092, 621);
            this.tabProductos.TabIndex = 0;
            this.tabProductos.Text = "Productos";
            // 
            // splitProductos
            // 
            this.splitProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitProductos.Location = new System.Drawing.Point(3, 43);
            this.splitProductos.Name = "splitProductos";
            // 
            // splitProductos.Panel1
            // 
            this.splitProductos.Panel1.Controls.Add(this.dgvProductos);
            // 
            // splitProductos.Panel2
            // 
            this.splitProductos.Panel2.Controls.Add(this.pnlProdForm);
            this.splitProductos.Size = new System.Drawing.Size(1086, 575);
            this.splitProductos.SplitterDistance = 876;
            this.splitProductos.TabIndex = 0;
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductos.Location = new System.Drawing.Point(0, 0);
            this.dgvProductos.MultiSelect = false;
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.RowHeadersWidth = 51;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(876, 575);
            this.dgvProductos.TabIndex = 0;
            this.dgvProductos.SelectionChanged += new System.EventHandler(this.dgvProductos_SelectionChanged);
            // 
            // pnlProdForm
            // 
            this.pnlProdForm.AutoScroll = true;
            this.pnlProdForm.Controls.Add(this.lblProdTitulo);
            this.pnlProdForm.Controls.Add(this.lblProdCodigo);
            this.pnlProdForm.Controls.Add(this.txtProdCodigo);
            this.pnlProdForm.Controls.Add(this.btnProdEscanear);
            this.pnlProdForm.Controls.Add(this.btnProdGenerarCodigo);
            this.pnlProdForm.Controls.Add(this.picCodigoBarras);
            this.pnlProdForm.Controls.Add(this.lblProdNombre);
            this.pnlProdForm.Controls.Add(this.txtProdNombre);
            this.pnlProdForm.Controls.Add(this.lblProdCat);
            this.pnlProdForm.Controls.Add(this.cboProdCat);
            this.pnlProdForm.Controls.Add(this.lblProdPrecio);
            this.pnlProdForm.Controls.Add(this.txtProdPrecio);
            this.pnlProdForm.Controls.Add(this.lblProdStockMin);
            this.pnlProdForm.Controls.Add(this.numProdStockMin);
            this.pnlProdForm.Controls.Add(this.chkProdCaducidad);
            this.pnlProdForm.Controls.Add(this.lblProdCaducidad);
            this.pnlProdForm.Controls.Add(this.dtpProdCaducidad);
            this.pnlProdForm.Controls.Add(this.lblProdProveedor);
            this.pnlProdForm.Controls.Add(this.cboProdProveedor);
            this.pnlProdForm.Controls.Add(this.btnProdNuevo);
            this.pnlProdForm.Controls.Add(this.btnProdEditar);
            this.pnlProdForm.Controls.Add(this.btnProdGuardar);
            this.pnlProdForm.Controls.Add(this.btnProdCancelar);
            this.pnlProdForm.Controls.Add(this.btnProdBaja);
            this.pnlProdForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlProdForm.Location = new System.Drawing.Point(0, 0);
            this.pnlProdForm.Name = "pnlProdForm";
            this.pnlProdForm.Size = new System.Drawing.Size(206, 575);
            this.pnlProdForm.TabIndex = 0;
            // 
            // lblProdTitulo
            // 
            this.lblProdTitulo.AutoSize = true;
            this.lblProdTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lblProdTitulo.Location = new System.Drawing.Point(5, 5);
            this.lblProdTitulo.Name = "lblProdTitulo";
            this.lblProdTitulo.Size = new System.Drawing.Size(94, 24);
            this.lblProdTitulo.TabIndex = 0;
            this.lblProdTitulo.Text = "Producto";
            // 
            // lblProdCodigo
            // 
            this.lblProdCodigo.AutoSize = true;
            this.lblProdCodigo.Location = new System.Drawing.Point(5, 40);
            this.lblProdCodigo.Name = "lblProdCodigo";
            this.lblProdCodigo.Size = new System.Drawing.Size(54, 16);
            this.lblProdCodigo.TabIndex = 1;
            this.lblProdCodigo.Text = "Código:";
            // 
            // txtProdCodigo
            // 
            this.txtProdCodigo.Location = new System.Drawing.Point(90, 37);
            this.txtProdCodigo.Name = "txtProdCodigo";
            this.txtProdCodigo.ReadOnly = true;
            this.txtProdCodigo.Size = new System.Drawing.Size(140, 22);
            this.txtProdCodigo.TabIndex = 2;
            // 
            // btnProdEscanear
            // 
            this.btnProdEscanear.Location = new System.Drawing.Point(238, 36);
            this.btnProdEscanear.Name = "btnProdEscanear";
            this.btnProdEscanear.Size = new System.Drawing.Size(75, 24);
            this.btnProdEscanear.TabIndex = 3;
            this.btnProdEscanear.Text = "Escanear";
            this.btnProdEscanear.Click += new System.EventHandler(this.btnProdEscanear_Click);
            // 
            // btnProdGenerarCodigo
            // 
            this.btnProdGenerarCodigo.Location = new System.Drawing.Point(90, 65);
            this.btnProdGenerarCodigo.Name = "btnProdGenerarCodigo";
            this.btnProdGenerarCodigo.Size = new System.Drawing.Size(90, 24);
            this.btnProdGenerarCodigo.TabIndex = 4;
            this.btnProdGenerarCodigo.Text = "Generar CB";
            this.btnProdGenerarCodigo.Click += new System.EventHandler(this.btnProdGenerarCodigo_Click);
            // 
            // picCodigoBarras
            // 
            this.picCodigoBarras.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCodigoBarras.Location = new System.Drawing.Point(5, 95);
            this.picCodigoBarras.Name = "picCodigoBarras";
            this.picCodigoBarras.Size = new System.Drawing.Size(310, 60);
            this.picCodigoBarras.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCodigoBarras.TabIndex = 5;
            this.picCodigoBarras.TabStop = false;
            // 
            // lblProdNombre
            // 
            this.lblProdNombre.AutoSize = true;
            this.lblProdNombre.Location = new System.Drawing.Point(5, 168);
            this.lblProdNombre.Name = "lblProdNombre";
            this.lblProdNombre.Size = new System.Drawing.Size(59, 16);
            this.lblProdNombre.TabIndex = 6;
            this.lblProdNombre.Text = "Nombre:";
            // 
            // txtProdNombre
            // 
            this.txtProdNombre.Location = new System.Drawing.Point(90, 165);
            this.txtProdNombre.Name = "txtProdNombre";
            this.txtProdNombre.ReadOnly = true;
            this.txtProdNombre.Size = new System.Drawing.Size(220, 22);
            this.txtProdNombre.TabIndex = 7;
            // 
            // lblProdCat
            // 
            this.lblProdCat.AutoSize = true;
            this.lblProdCat.Location = new System.Drawing.Point(5, 200);
            this.lblProdCat.Name = "lblProdCat";
            this.lblProdCat.Size = new System.Drawing.Size(69, 16);
            this.lblProdCat.TabIndex = 8;
            this.lblProdCat.Text = "Categoría:";
            // 
            // cboProdCat
            // 
            this.cboProdCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProdCat.Enabled = false;
            this.cboProdCat.Location = new System.Drawing.Point(90, 197);
            this.cboProdCat.Name = "cboProdCat";
            this.cboProdCat.Size = new System.Drawing.Size(180, 24);
            this.cboProdCat.TabIndex = 9;
            // 
            // lblProdPrecio
            // 
            this.lblProdPrecio.AutoSize = true;
            this.lblProdPrecio.Location = new System.Drawing.Point(5, 232);
            this.lblProdPrecio.Name = "lblProdPrecio";
            this.lblProdPrecio.Size = new System.Drawing.Size(49, 16);
            this.lblProdPrecio.TabIndex = 10;
            this.lblProdPrecio.Text = "Precio:";
            // 
            // txtProdPrecio
            // 
            this.txtProdPrecio.Location = new System.Drawing.Point(90, 229);
            this.txtProdPrecio.Name = "txtProdPrecio";
            this.txtProdPrecio.ReadOnly = true;
            this.txtProdPrecio.Size = new System.Drawing.Size(100, 22);
            this.txtProdPrecio.TabIndex = 11;
            this.txtProdPrecio.Text = "0.00";
            // 
            // lblProdStockMin
            // 
            this.lblProdStockMin.AutoSize = true;
            this.lblProdStockMin.Location = new System.Drawing.Point(5, 264);
            this.lblProdStockMin.Name = "lblProdStockMin";
            this.lblProdStockMin.Size = new System.Drawing.Size(68, 16);
            this.lblProdStockMin.TabIndex = 12;
            this.lblProdStockMin.Text = "Stock Mín:";
            // 
            // numProdStockMin
            // 
            this.numProdStockMin.Enabled = false;
            this.numProdStockMin.Location = new System.Drawing.Point(90, 261);
            this.numProdStockMin.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numProdStockMin.Name = "numProdStockMin";
            this.numProdStockMin.Size = new System.Drawing.Size(70, 22);
            this.numProdStockMin.TabIndex = 13;
            this.numProdStockMin.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // chkProdCaducidad
            // 
            this.chkProdCaducidad.AutoSize = true;
            this.chkProdCaducidad.Enabled = false;
            this.chkProdCaducidad.Location = new System.Drawing.Point(5, 296);
            this.chkProdCaducidad.Name = "chkProdCaducidad";
            this.chkProdCaducidad.Size = new System.Drawing.Size(98, 20);
            this.chkProdCaducidad.TabIndex = 14;
            this.chkProdCaducidad.Text = "Fecha Cad:";
            this.chkProdCaducidad.CheckedChanged += new System.EventHandler(this.chkProdCaducidad_CheckedChanged);
            // 
            // lblProdCaducidad
            // 
            this.lblProdCaducidad.AutoSize = true;
            this.lblProdCaducidad.Location = new System.Drawing.Point(5, 296);
            this.lblProdCaducidad.Name = "lblProdCaducidad";
            this.lblProdCaducidad.Size = new System.Drawing.Size(0, 16);
            this.lblProdCaducidad.TabIndex = 15;
            // 
            // dtpProdCaducidad
            // 
            this.dtpProdCaducidad.Enabled = false;
            this.dtpProdCaducidad.Location = new System.Drawing.Point(90, 293);
            this.dtpProdCaducidad.Name = "dtpProdCaducidad";
            this.dtpProdCaducidad.Size = new System.Drawing.Size(140, 22);
            this.dtpProdCaducidad.TabIndex = 16;
            // 
            // lblProdProveedor
            // 
            this.lblProdProveedor.AutoSize = true;
            this.lblProdProveedor.Location = new System.Drawing.Point(5, 328);
            this.lblProdProveedor.Name = "lblProdProveedor";
            this.lblProdProveedor.Size = new System.Drawing.Size(74, 16);
            this.lblProdProveedor.TabIndex = 17;
            this.lblProdProveedor.Text = "Proveedor:";
            // 
            // cboProdProveedor
            // 
            this.cboProdProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProdProveedor.Enabled = false;
            this.cboProdProveedor.Location = new System.Drawing.Point(90, 325);
            this.cboProdProveedor.Name = "cboProdProveedor";
            this.cboProdProveedor.Size = new System.Drawing.Size(210, 24);
            this.cboProdProveedor.TabIndex = 18;
            // 
            // btnProdNuevo
            // 
            this.btnProdNuevo.Location = new System.Drawing.Point(5, 335);
            this.btnProdNuevo.Name = "btnProdNuevo";
            this.btnProdNuevo.Size = new System.Drawing.Size(70, 26);
            this.btnProdNuevo.TabIndex = 19;
            this.btnProdNuevo.Text = "Nuevo";
            this.btnProdNuevo.Click += new System.EventHandler(this.btnProdNuevo_Click);
            // 
            // btnProdEditar
            // 
            this.btnProdEditar.Enabled = false;
            this.btnProdEditar.Location = new System.Drawing.Point(82, 335);
            this.btnProdEditar.Name = "btnProdEditar";
            this.btnProdEditar.Size = new System.Drawing.Size(70, 26);
            this.btnProdEditar.TabIndex = 20;
            this.btnProdEditar.Text = "Editar";
            this.btnProdEditar.Click += new System.EventHandler(this.btnProdEditar_Click);
            // 
            // btnProdGuardar
            // 
            this.btnProdGuardar.Enabled = false;
            this.btnProdGuardar.Location = new System.Drawing.Point(5, 368);
            this.btnProdGuardar.Name = "btnProdGuardar";
            this.btnProdGuardar.Size = new System.Drawing.Size(70, 26);
            this.btnProdGuardar.TabIndex = 21;
            this.btnProdGuardar.Text = "Guardar";
            this.btnProdGuardar.Click += new System.EventHandler(this.btnProdGuardar_Click);
            // 
            // btnProdCancelar
            // 
            this.btnProdCancelar.Enabled = false;
            this.btnProdCancelar.Location = new System.Drawing.Point(82, 368);
            this.btnProdCancelar.Name = "btnProdCancelar";
            this.btnProdCancelar.Size = new System.Drawing.Size(70, 26);
            this.btnProdCancelar.TabIndex = 22;
            this.btnProdCancelar.Text = "Cancelar";
            this.btnProdCancelar.Click += new System.EventHandler(this.btnProdCancelar_Click);
            // 
            // btnProdBaja
            // 
            this.btnProdBaja.Enabled = false;
            this.btnProdBaja.Location = new System.Drawing.Point(160, 335);
            this.btnProdBaja.Name = "btnProdBaja";
            this.btnProdBaja.Size = new System.Drawing.Size(70, 26);
            this.btnProdBaja.TabIndex = 23;
            this.btnProdBaja.Text = "Dar Baja";
            this.btnProdBaja.Click += new System.EventHandler(this.btnProdBaja_Click);
            // 
            // pnlProdFiltro
            // 
            this.pnlProdFiltro.Controls.Add(this.lblProdFiltro);
            this.pnlProdFiltro.Controls.Add(this.cboProdCategoria);
            this.pnlProdFiltro.Controls.Add(this.btnProdFiltrar);
            this.pnlProdFiltro.Controls.Add(this.btnProdTodos);
            this.pnlProdFiltro.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlProdFiltro.Location = new System.Drawing.Point(3, 3);
            this.pnlProdFiltro.Name = "pnlProdFiltro";
            this.pnlProdFiltro.Size = new System.Drawing.Size(1086, 40);
            this.pnlProdFiltro.TabIndex = 1;
            // 
            // lblProdFiltro
            // 
            this.lblProdFiltro.AutoSize = true;
            this.lblProdFiltro.Location = new System.Drawing.Point(5, 10);
            this.lblProdFiltro.Name = "lblProdFiltro";
            this.lblProdFiltro.Size = new System.Drawing.Size(69, 16);
            this.lblProdFiltro.TabIndex = 0;
            this.lblProdFiltro.Text = "Categoría:";
            // 
            // cboProdCategoria
            // 
            this.cboProdCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProdCategoria.Location = new System.Drawing.Point(70, 7);
            this.cboProdCategoria.Name = "cboProdCategoria";
            this.cboProdCategoria.Size = new System.Drawing.Size(160, 24);
            this.cboProdCategoria.TabIndex = 1;
            // 
            // btnProdFiltrar
            // 
            this.btnProdFiltrar.Location = new System.Drawing.Point(240, 6);
            this.btnProdFiltrar.Name = "btnProdFiltrar";
            this.btnProdFiltrar.Size = new System.Drawing.Size(70, 26);
            this.btnProdFiltrar.TabIndex = 2;
            this.btnProdFiltrar.Text = "Filtrar";
            this.btnProdFiltrar.Click += new System.EventHandler(this.btnProdFiltrar_Click);
            // 
            // btnProdTodos
            // 
            this.btnProdTodos.Location = new System.Drawing.Point(318, 6);
            this.btnProdTodos.Name = "btnProdTodos";
            this.btnProdTodos.Size = new System.Drawing.Size(70, 26);
            this.btnProdTodos.TabIndex = 3;
            this.btnProdTodos.Text = "Todos";
            this.btnProdTodos.Click += new System.EventHandler(this.btnProdTodos_Click);
            // 
            // tabEquipo
            // 
            this.tabEquipo.Controls.Add(this.splitEquipo);
            this.tabEquipo.Controls.Add(this.pnlEqFiltro);
            this.tabEquipo.Location = new System.Drawing.Point(4, 25);
            this.tabEquipo.Name = "tabEquipo";
            this.tabEquipo.Padding = new System.Windows.Forms.Padding(3);
            this.tabEquipo.Size = new System.Drawing.Size(1092, 621);
            this.tabEquipo.TabIndex = 1;
            this.tabEquipo.Text = "Equipo";
            // 
            // splitEquipo
            // 
            this.splitEquipo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitEquipo.Location = new System.Drawing.Point(3, 43);
            this.splitEquipo.Name = "splitEquipo";
            // 
            // splitEquipo.Panel1
            // 
            this.splitEquipo.Panel1.Controls.Add(this.dgvEquipo);
            // 
            // splitEquipo.Panel2
            // 
            this.splitEquipo.Panel2.Controls.Add(this.pnlEqForm);
            this.splitEquipo.Size = new System.Drawing.Size(1086, 575);
            this.splitEquipo.SplitterDistance = 876;
            this.splitEquipo.TabIndex = 0;
            // 
            // dgvEquipo
            // 
            this.dgvEquipo.AllowUserToAddRows = false;
            this.dgvEquipo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEquipo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEquipo.Location = new System.Drawing.Point(0, 0);
            this.dgvEquipo.MultiSelect = false;
            this.dgvEquipo.Name = "dgvEquipo";
            this.dgvEquipo.ReadOnly = true;
            this.dgvEquipo.RowHeadersWidth = 51;
            this.dgvEquipo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEquipo.Size = new System.Drawing.Size(876, 575);
            this.dgvEquipo.TabIndex = 0;
            this.dgvEquipo.SelectionChanged += new System.EventHandler(this.dgvEquipo_SelectionChanged);
            // 
            // pnlEqForm
            // 
            this.pnlEqForm.AutoScroll = true;
            this.pnlEqForm.Controls.Add(this.lblEqTitulo);
            this.pnlEqForm.Controls.Add(this.lblEqNombre);
            this.pnlEqForm.Controls.Add(this.txtEqNombre);
            this.pnlEqForm.Controls.Add(this.lblEqCat);
            this.pnlEqForm.Controls.Add(this.cboEqCat);
            this.pnlEqForm.Controls.Add(this.lblEqEstado);
            this.pnlEqForm.Controls.Add(this.cboEqEstado);
            this.pnlEqForm.Controls.Add(this.chkEqFecha);
            this.pnlEqForm.Controls.Add(this.lblEqFecha);
            this.pnlEqForm.Controls.Add(this.dtpEqFecha);
            this.pnlEqForm.Controls.Add(this.lblEqObs);
            this.pnlEqForm.Controls.Add(this.txtEqObs);
            this.pnlEqForm.Controls.Add(this.btnEqNuevo);
            this.pnlEqForm.Controls.Add(this.btnEqEditar);
            this.pnlEqForm.Controls.Add(this.btnEqGuardar);
            this.pnlEqForm.Controls.Add(this.btnEqCancelar);
            this.pnlEqForm.Controls.Add(this.btnEqBaja);
            this.pnlEqForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEqForm.Location = new System.Drawing.Point(0, 0);
            this.pnlEqForm.Name = "pnlEqForm";
            this.pnlEqForm.Size = new System.Drawing.Size(206, 575);
            this.pnlEqForm.TabIndex = 0;
            // 
            // lblEqTitulo
            // 
            this.lblEqTitulo.AutoSize = true;
            this.lblEqTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lblEqTitulo.Location = new System.Drawing.Point(5, 5);
            this.lblEqTitulo.Name = "lblEqTitulo";
            this.lblEqTitulo.Size = new System.Drawing.Size(77, 24);
            this.lblEqTitulo.TabIndex = 0;
            this.lblEqTitulo.Text = "Equipo";
            // 
            // lblEqNombre
            // 
            this.lblEqNombre.AutoSize = true;
            this.lblEqNombre.Location = new System.Drawing.Point(5, 40);
            this.lblEqNombre.Name = "lblEqNombre";
            this.lblEqNombre.Size = new System.Drawing.Size(59, 16);
            this.lblEqNombre.TabIndex = 1;
            this.lblEqNombre.Text = "Nombre:";
            // 
            // txtEqNombre
            // 
            this.txtEqNombre.Location = new System.Drawing.Point(90, 37);
            this.txtEqNombre.Name = "txtEqNombre";
            this.txtEqNombre.ReadOnly = true;
            this.txtEqNombre.Size = new System.Drawing.Size(200, 22);
            this.txtEqNombre.TabIndex = 2;
            // 
            // lblEqCat
            // 
            this.lblEqCat.AutoSize = true;
            this.lblEqCat.Location = new System.Drawing.Point(5, 72);
            this.lblEqCat.Name = "lblEqCat";
            this.lblEqCat.Size = new System.Drawing.Size(69, 16);
            this.lblEqCat.TabIndex = 3;
            this.lblEqCat.Text = "Categoría:";
            // 
            // cboEqCat
            // 
            this.cboEqCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEqCat.Enabled = false;
            this.cboEqCat.Location = new System.Drawing.Point(90, 69);
            this.cboEqCat.Name = "cboEqCat";
            this.cboEqCat.Size = new System.Drawing.Size(180, 24);
            this.cboEqCat.TabIndex = 4;
            // 
            // lblEqEstado
            // 
            this.lblEqEstado.AutoSize = true;
            this.lblEqEstado.Location = new System.Drawing.Point(5, 104);
            this.lblEqEstado.Name = "lblEqEstado";
            this.lblEqEstado.Size = new System.Drawing.Size(53, 16);
            this.lblEqEstado.TabIndex = 5;
            this.lblEqEstado.Text = "Estado:";
            // 
            // cboEqEstado
            // 
            this.cboEqEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEqEstado.Enabled = false;
            this.cboEqEstado.Items.AddRange(new object[] {
            "BUENO",
            "DAÑADO",
            "BAJA"});
            this.cboEqEstado.Location = new System.Drawing.Point(90, 101);
            this.cboEqEstado.Name = "cboEqEstado";
            this.cboEqEstado.Size = new System.Drawing.Size(120, 24);
            this.cboEqEstado.TabIndex = 6;
            // 
            // chkEqFecha
            // 
            this.chkEqFecha.AutoSize = true;
            this.chkEqFecha.Enabled = false;
            this.chkEqFecha.Location = new System.Drawing.Point(5, 136);
            this.chkEqFecha.Name = "chkEqFecha";
            this.chkEqFecha.Size = new System.Drawing.Size(102, 20);
            this.chkEqFecha.TabIndex = 7;
            this.chkEqFecha.Text = "Adquisición:";
            this.chkEqFecha.CheckedChanged += new System.EventHandler(this.chkEqFecha_CheckedChanged);
            // 
            // lblEqFecha
            // 
            this.lblEqFecha.AutoSize = true;
            this.lblEqFecha.Location = new System.Drawing.Point(5, 136);
            this.lblEqFecha.Name = "lblEqFecha";
            this.lblEqFecha.Size = new System.Drawing.Size(0, 16);
            this.lblEqFecha.TabIndex = 8;
            // 
            // dtpEqFecha
            // 
            this.dtpEqFecha.Enabled = false;
            this.dtpEqFecha.Location = new System.Drawing.Point(90, 133);
            this.dtpEqFecha.Name = "dtpEqFecha";
            this.dtpEqFecha.Size = new System.Drawing.Size(140, 22);
            this.dtpEqFecha.TabIndex = 9;
            // 
            // lblEqObs
            // 
            this.lblEqObs.AutoSize = true;
            this.lblEqObs.Location = new System.Drawing.Point(5, 168);
            this.lblEqObs.Name = "lblEqObs";
            this.lblEqObs.Size = new System.Drawing.Size(102, 16);
            this.lblEqObs.TabIndex = 10;
            this.lblEqObs.Text = "Observaciones:";
            // 
            // txtEqObs
            // 
            this.txtEqObs.Location = new System.Drawing.Point(5, 188);
            this.txtEqObs.Multiline = true;
            this.txtEqObs.Name = "txtEqObs";
            this.txtEqObs.ReadOnly = true;
            this.txtEqObs.Size = new System.Drawing.Size(290, 60);
            this.txtEqObs.TabIndex = 11;
            // 
            // btnEqNuevo
            // 
            this.btnEqNuevo.Location = new System.Drawing.Point(5, 260);
            this.btnEqNuevo.Name = "btnEqNuevo";
            this.btnEqNuevo.Size = new System.Drawing.Size(70, 26);
            this.btnEqNuevo.TabIndex = 12;
            this.btnEqNuevo.Text = "Nuevo";
            this.btnEqNuevo.Click += new System.EventHandler(this.btnEqNuevo_Click);
            // 
            // btnEqEditar
            // 
            this.btnEqEditar.Enabled = false;
            this.btnEqEditar.Location = new System.Drawing.Point(82, 260);
            this.btnEqEditar.Name = "btnEqEditar";
            this.btnEqEditar.Size = new System.Drawing.Size(70, 26);
            this.btnEqEditar.TabIndex = 13;
            this.btnEqEditar.Text = "Editar";
            this.btnEqEditar.Click += new System.EventHandler(this.btnEqEditar_Click);
            // 
            // btnEqGuardar
            // 
            this.btnEqGuardar.Enabled = false;
            this.btnEqGuardar.Location = new System.Drawing.Point(5, 293);
            this.btnEqGuardar.Name = "btnEqGuardar";
            this.btnEqGuardar.Size = new System.Drawing.Size(70, 26);
            this.btnEqGuardar.TabIndex = 14;
            this.btnEqGuardar.Text = "Guardar";
            this.btnEqGuardar.Click += new System.EventHandler(this.btnEqGuardar_Click);
            // 
            // btnEqCancelar
            // 
            this.btnEqCancelar.Enabled = false;
            this.btnEqCancelar.Location = new System.Drawing.Point(82, 293);
            this.btnEqCancelar.Name = "btnEqCancelar";
            this.btnEqCancelar.Size = new System.Drawing.Size(70, 26);
            this.btnEqCancelar.TabIndex = 15;
            this.btnEqCancelar.Text = "Cancelar";
            this.btnEqCancelar.Click += new System.EventHandler(this.btnEqCancelar_Click);
            // 
            // btnEqBaja
            // 
            this.btnEqBaja.Enabled = false;
            this.btnEqBaja.Location = new System.Drawing.Point(160, 260);
            this.btnEqBaja.Name = "btnEqBaja";
            this.btnEqBaja.Size = new System.Drawing.Size(70, 26);
            this.btnEqBaja.TabIndex = 16;
            this.btnEqBaja.Text = "Dar Baja";
            this.btnEqBaja.Click += new System.EventHandler(this.btnEqBaja_Click);
            // 
            // pnlEqFiltro
            // 
            this.pnlEqFiltro.Controls.Add(this.lblEqFiltroEstado);
            this.pnlEqFiltro.Controls.Add(this.cboEqFiltroEstado);
            this.pnlEqFiltro.Controls.Add(this.btnEqFiltrar);
            this.pnlEqFiltro.Controls.Add(this.btnEqTodos);
            this.pnlEqFiltro.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEqFiltro.Location = new System.Drawing.Point(3, 3);
            this.pnlEqFiltro.Name = "pnlEqFiltro";
            this.pnlEqFiltro.Size = new System.Drawing.Size(1086, 40);
            this.pnlEqFiltro.TabIndex = 1;
            // 
            // lblEqFiltroEstado
            // 
            this.lblEqFiltroEstado.AutoSize = true;
            this.lblEqFiltroEstado.Location = new System.Drawing.Point(5, 10);
            this.lblEqFiltroEstado.Name = "lblEqFiltroEstado";
            this.lblEqFiltroEstado.Size = new System.Drawing.Size(53, 16);
            this.lblEqFiltroEstado.TabIndex = 0;
            this.lblEqFiltroEstado.Text = "Estado:";
            // 
            // cboEqFiltroEstado
            // 
            this.cboEqFiltroEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEqFiltroEstado.Items.AddRange(new object[] {
            "BUENO",
            "DAÑADO",
            "BAJA"});
            this.cboEqFiltroEstado.Location = new System.Drawing.Point(60, 7);
            this.cboEqFiltroEstado.Name = "cboEqFiltroEstado";
            this.cboEqFiltroEstado.Size = new System.Drawing.Size(120, 24);
            this.cboEqFiltroEstado.TabIndex = 1;
            // 
            // btnEqFiltrar
            // 
            this.btnEqFiltrar.Location = new System.Drawing.Point(190, 6);
            this.btnEqFiltrar.Name = "btnEqFiltrar";
            this.btnEqFiltrar.Size = new System.Drawing.Size(70, 26);
            this.btnEqFiltrar.TabIndex = 2;
            this.btnEqFiltrar.Text = "Filtrar";
            this.btnEqFiltrar.Click += new System.EventHandler(this.btnEqFiltrar_Click);
            // 
            // btnEqTodos
            // 
            this.btnEqTodos.Location = new System.Drawing.Point(268, 6);
            this.btnEqTodos.Name = "btnEqTodos";
            this.btnEqTodos.Size = new System.Drawing.Size(70, 26);
            this.btnEqTodos.TabIndex = 3;
            this.btnEqTodos.Text = "Todos";
            this.btnEqTodos.Click += new System.EventHandler(this.btnEqTodos_Click);
            // 
            // tabMovimientos
            // 
            this.tabMovimientos.Controls.Add(this.pnlMovForm);
            this.tabMovimientos.Location = new System.Drawing.Point(4, 25);
            this.tabMovimientos.Name = "tabMovimientos";
            this.tabMovimientos.Padding = new System.Windows.Forms.Padding(3);
            this.tabMovimientos.Size = new System.Drawing.Size(1092, 621);
            this.tabMovimientos.TabIndex = 2;
            this.tabMovimientos.Text = "Movimientos";
            // 
            // pnlMovForm
            // 
            this.pnlMovForm.AutoScroll = true;
            this.pnlMovForm.Controls.Add(this.lblMovTitulo);
            this.pnlMovForm.Controls.Add(this.lblMovCodigo);
            this.pnlMovForm.Controls.Add(this.txtMovCodigo);
            this.pnlMovForm.Controls.Add(this.btnMovBuscar);
            this.pnlMovForm.Controls.Add(this.lblMovProducto);
            this.pnlMovForm.Controls.Add(this.txtMovProducto);
            this.pnlMovForm.Controls.Add(this.lblMovStock);
            this.pnlMovForm.Controls.Add(this.txtMovStock);
            this.pnlMovForm.Controls.Add(this.lblMovAlerta);
            this.pnlMovForm.Controls.Add(this.picMovAlerta);
            this.pnlMovForm.Controls.Add(this.lblMovTipo);
            this.pnlMovForm.Controls.Add(this.rbMovEntrada);
            this.pnlMovForm.Controls.Add(this.rbMovSalida);
            this.pnlMovForm.Controls.Add(this.lblMovCantidad);
            this.pnlMovForm.Controls.Add(this.numMovCantidad);
            this.pnlMovForm.Controls.Add(this.lblMovMotivo);
            this.pnlMovForm.Controls.Add(this.txtMovMotivo);
            this.pnlMovForm.Controls.Add(this.btnMovRegistrar);
            this.pnlMovForm.Controls.Add(this.btnMovLimpiar);
            this.pnlMovForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMovForm.Location = new System.Drawing.Point(3, 3);
            this.pnlMovForm.Name = "pnlMovForm";
            this.pnlMovForm.Size = new System.Drawing.Size(1086, 615);
            this.pnlMovForm.TabIndex = 0;
            // 
            // lblMovTitulo
            // 
            this.lblMovTitulo.AutoSize = true;
            this.lblMovTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lblMovTitulo.Location = new System.Drawing.Point(10, 10);
            this.lblMovTitulo.Name = "lblMovTitulo";
            this.lblMovTitulo.Size = new System.Drawing.Size(206, 24);
            this.lblMovTitulo.TabIndex = 0;
            this.lblMovTitulo.Text = "Registrar Movimiento";
            // 
            // lblMovCodigo
            // 
            this.lblMovCodigo.AutoSize = true;
            this.lblMovCodigo.Location = new System.Drawing.Point(10, 50);
            this.lblMovCodigo.Name = "lblMovCodigo";
            this.lblMovCodigo.Size = new System.Drawing.Size(54, 16);
            this.lblMovCodigo.TabIndex = 1;
            this.lblMovCodigo.Text = "Código:";
            // 
            // txtMovCodigo
            // 
            this.txtMovCodigo.Location = new System.Drawing.Point(110, 47);
            this.txtMovCodigo.Name = "txtMovCodigo";
            this.txtMovCodigo.Size = new System.Drawing.Size(180, 22);
            this.txtMovCodigo.TabIndex = 2;
            this.txtMovCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMovCodigo_KeyDown);
            // 
            // btnMovBuscar
            // 
            this.btnMovBuscar.Location = new System.Drawing.Point(298, 46);
            this.btnMovBuscar.Name = "btnMovBuscar";
            this.btnMovBuscar.Size = new System.Drawing.Size(70, 26);
            this.btnMovBuscar.TabIndex = 3;
            this.btnMovBuscar.Text = "Buscar";
            this.btnMovBuscar.Click += new System.EventHandler(this.btnMovBuscar_Click);
            // 
            // lblMovProducto
            // 
            this.lblMovProducto.AutoSize = true;
            this.lblMovProducto.Location = new System.Drawing.Point(10, 85);
            this.lblMovProducto.Name = "lblMovProducto";
            this.lblMovProducto.Size = new System.Drawing.Size(64, 16);
            this.lblMovProducto.TabIndex = 4;
            this.lblMovProducto.Text = "Producto:";
            // 
            // txtMovProducto
            // 
            this.txtMovProducto.Location = new System.Drawing.Point(110, 82);
            this.txtMovProducto.Name = "txtMovProducto";
            this.txtMovProducto.ReadOnly = true;
            this.txtMovProducto.Size = new System.Drawing.Size(300, 22);
            this.txtMovProducto.TabIndex = 5;
            // 
            // lblMovStock
            // 
            this.lblMovStock.AutoSize = true;
            this.lblMovStock.Location = new System.Drawing.Point(10, 118);
            this.lblMovStock.Name = "lblMovStock";
            this.lblMovStock.Size = new System.Drawing.Size(83, 16);
            this.lblMovStock.TabIndex = 6;
            this.lblMovStock.Text = "Stock actual:";
            // 
            // txtMovStock
            // 
            this.txtMovStock.Location = new System.Drawing.Point(110, 115);
            this.txtMovStock.Name = "txtMovStock";
            this.txtMovStock.ReadOnly = true;
            this.txtMovStock.Size = new System.Drawing.Size(80, 22);
            this.txtMovStock.TabIndex = 7;
            // 
            // lblMovAlerta
            // 
            this.lblMovAlerta.AutoSize = true;
            this.lblMovAlerta.ForeColor = System.Drawing.Color.Red;
            this.lblMovAlerta.Location = new System.Drawing.Point(200, 118);
            this.lblMovAlerta.Name = "lblMovAlerta";
            this.lblMovAlerta.Size = new System.Drawing.Size(0, 16);
            this.lblMovAlerta.TabIndex = 8;
            this.lblMovAlerta.Visible = false;
            // 
            // picMovAlerta
            // 
            this.picMovAlerta.Location = new System.Drawing.Point(110, 140);
            this.picMovAlerta.Name = "picMovAlerta";
            this.picMovAlerta.Size = new System.Drawing.Size(0, 0);
            this.picMovAlerta.TabIndex = 9;
            this.picMovAlerta.TabStop = false;
            // 
            // lblMovTipo
            // 
            this.lblMovTipo.AutoSize = true;
            this.lblMovTipo.Location = new System.Drawing.Point(10, 150);
            this.lblMovTipo.Name = "lblMovTipo";
            this.lblMovTipo.Size = new System.Drawing.Size(38, 16);
            this.lblMovTipo.TabIndex = 10;
            this.lblMovTipo.Text = "Tipo:";
            // 
            // rbMovEntrada
            // 
            this.rbMovEntrada.AutoSize = true;
            this.rbMovEntrada.Checked = true;
            this.rbMovEntrada.Location = new System.Drawing.Point(110, 148);
            this.rbMovEntrada.Name = "rbMovEntrada";
            this.rbMovEntrada.Size = new System.Drawing.Size(75, 20);
            this.rbMovEntrada.TabIndex = 11;
            this.rbMovEntrada.TabStop = true;
            this.rbMovEntrada.Text = "Entrada";
            // 
            // rbMovSalida
            // 
            this.rbMovSalida.AutoSize = true;
            this.rbMovSalida.Location = new System.Drawing.Point(185, 148);
            this.rbMovSalida.Name = "rbMovSalida";
            this.rbMovSalida.Size = new System.Drawing.Size(67, 20);
            this.rbMovSalida.TabIndex = 12;
            this.rbMovSalida.Text = "Salida";
            // 
            // lblMovCantidad
            // 
            this.lblMovCantidad.AutoSize = true;
            this.lblMovCantidad.Location = new System.Drawing.Point(10, 183);
            this.lblMovCantidad.Name = "lblMovCantidad";
            this.lblMovCantidad.Size = new System.Drawing.Size(64, 16);
            this.lblMovCantidad.TabIndex = 13;
            this.lblMovCantidad.Text = "Cantidad:";
            // 
            // numMovCantidad
            // 
            this.numMovCantidad.Location = new System.Drawing.Point(110, 180);
            this.numMovCantidad.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numMovCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMovCantidad.Name = "numMovCantidad";
            this.numMovCantidad.Size = new System.Drawing.Size(80, 22);
            this.numMovCantidad.TabIndex = 14;
            this.numMovCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblMovMotivo
            // 
            this.lblMovMotivo.AutoSize = true;
            this.lblMovMotivo.Location = new System.Drawing.Point(10, 215);
            this.lblMovMotivo.Name = "lblMovMotivo";
            this.lblMovMotivo.Size = new System.Drawing.Size(50, 16);
            this.lblMovMotivo.TabIndex = 15;
            this.lblMovMotivo.Text = "Motivo:";
            // 
            // txtMovMotivo
            // 
            this.txtMovMotivo.Location = new System.Drawing.Point(110, 212);
            this.txtMovMotivo.Name = "txtMovMotivo";
            this.txtMovMotivo.Size = new System.Drawing.Size(300, 22);
            this.txtMovMotivo.TabIndex = 16;
            // 
            // btnMovRegistrar
            // 
            this.btnMovRegistrar.Location = new System.Drawing.Point(110, 248);
            this.btnMovRegistrar.Name = "btnMovRegistrar";
            this.btnMovRegistrar.Size = new System.Drawing.Size(90, 28);
            this.btnMovRegistrar.TabIndex = 17;
            this.btnMovRegistrar.Text = "Registrar";
            this.btnMovRegistrar.Click += new System.EventHandler(this.btnMovRegistrar_Click);
            // 
            // btnMovLimpiar
            // 
            this.btnMovLimpiar.Location = new System.Drawing.Point(208, 248);
            this.btnMovLimpiar.Name = "btnMovLimpiar";
            this.btnMovLimpiar.Size = new System.Drawing.Size(90, 28);
            this.btnMovLimpiar.TabIndex = 18;
            this.btnMovLimpiar.Text = "Limpiar";
            this.btnMovLimpiar.Click += new System.EventHandler(this.btnMovLimpiar_Click);
            // 
            // tabHistorial
            // 
            this.tabHistorial.Controls.Add(this.dgvHistorial);
            this.tabHistorial.Controls.Add(this.pnlHistFiltro);
            this.tabHistorial.Location = new System.Drawing.Point(4, 25);
            this.tabHistorial.Name = "tabHistorial";
            this.tabHistorial.Padding = new System.Windows.Forms.Padding(3);
            this.tabHistorial.Size = new System.Drawing.Size(1092, 621);
            this.tabHistorial.TabIndex = 3;
            this.tabHistorial.Text = "Historial";
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.AllowUserToAddRows = false;
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistorial.Location = new System.Drawing.Point(3, 48);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.ReadOnly = true;
            this.dgvHistorial.RowHeadersWidth = 51;
            this.dgvHistorial.Size = new System.Drawing.Size(1086, 570);
            this.dgvHistorial.TabIndex = 0;
            // 
            // pnlHistFiltro
            // 
            this.pnlHistFiltro.Controls.Add(this.lblHistDesde);
            this.pnlHistFiltro.Controls.Add(this.dtpHistDesde);
            this.pnlHistFiltro.Controls.Add(this.lblHistHasta);
            this.pnlHistFiltro.Controls.Add(this.dtpHistHasta);
            this.pnlHistFiltro.Controls.Add(this.lblHistProd);
            this.pnlHistFiltro.Controls.Add(this.cboHistProd);
            this.pnlHistFiltro.Controls.Add(this.btnHistBuscar);
            this.pnlHistFiltro.Controls.Add(this.btnHistTodos);
            this.pnlHistFiltro.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHistFiltro.Location = new System.Drawing.Point(3, 3);
            this.pnlHistFiltro.Name = "pnlHistFiltro";
            this.pnlHistFiltro.Size = new System.Drawing.Size(1086, 45);
            this.pnlHistFiltro.TabIndex = 1;
            // 
            // lblHistDesde
            // 
            this.lblHistDesde.AutoSize = true;
            this.lblHistDesde.Location = new System.Drawing.Point(5, 12);
            this.lblHistDesde.Name = "lblHistDesde";
            this.lblHistDesde.Size = new System.Drawing.Size(51, 16);
            this.lblHistDesde.TabIndex = 0;
            this.lblHistDesde.Text = "Desde:";
            // 
            // dtpHistDesde
            // 
            this.dtpHistDesde.Location = new System.Drawing.Point(55, 9);
            this.dtpHistDesde.Name = "dtpHistDesde";
            this.dtpHistDesde.Size = new System.Drawing.Size(120, 22);
            this.dtpHistDesde.TabIndex = 1;
            // 
            // lblHistHasta
            // 
            this.lblHistHasta.AutoSize = true;
            this.lblHistHasta.Location = new System.Drawing.Point(185, 12);
            this.lblHistHasta.Name = "lblHistHasta";
            this.lblHistHasta.Size = new System.Drawing.Size(46, 16);
            this.lblHistHasta.TabIndex = 2;
            this.lblHistHasta.Text = "Hasta:";
            // 
            // dtpHistHasta
            // 
            this.dtpHistHasta.Location = new System.Drawing.Point(230, 9);
            this.dtpHistHasta.Name = "dtpHistHasta";
            this.dtpHistHasta.Size = new System.Drawing.Size(120, 22);
            this.dtpHistHasta.TabIndex = 3;
            // 
            // lblHistProd
            // 
            this.lblHistProd.AutoSize = true;
            this.lblHistProd.Location = new System.Drawing.Point(360, 12);
            this.lblHistProd.Name = "lblHistProd";
            this.lblHistProd.Size = new System.Drawing.Size(64, 16);
            this.lblHistProd.TabIndex = 4;
            this.lblHistProd.Text = "Producto:";
            // 
            // cboHistProd
            // 
            this.cboHistProd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHistProd.Location = new System.Drawing.Point(420, 9);
            this.cboHistProd.Name = "cboHistProd";
            this.cboHistProd.Size = new System.Drawing.Size(160, 24);
            this.cboHistProd.TabIndex = 5;
            // 
            // btnHistBuscar
            // 
            this.btnHistBuscar.Location = new System.Drawing.Point(590, 8);
            this.btnHistBuscar.Name = "btnHistBuscar";
            this.btnHistBuscar.Size = new System.Drawing.Size(70, 26);
            this.btnHistBuscar.TabIndex = 6;
            this.btnHistBuscar.Text = "Buscar";
            this.btnHistBuscar.Click += new System.EventHandler(this.btnHistBuscar_Click);
            // 
            // btnHistTodos
            // 
            this.btnHistTodos.Location = new System.Drawing.Point(668, 8);
            this.btnHistTodos.Name = "btnHistTodos";
            this.btnHistTodos.Size = new System.Drawing.Size(70, 26);
            this.btnHistTodos.TabIndex = 7;
            this.btnHistTodos.Text = "Todos";
            this.btnHistTodos.Click += new System.EventHandler(this.btnHistTodos_Click);
            // 
            // tabDefectos
            // 
            this.tabDefectos.Controls.Add(this.dgvDefectos);
            this.tabDefectos.Controls.Add(this.pnlDefForm);
            this.tabDefectos.Location = new System.Drawing.Point(4, 25);
            this.tabDefectos.Name = "tabDefectos";
            this.tabDefectos.Padding = new System.Windows.Forms.Padding(3);
            this.tabDefectos.Size = new System.Drawing.Size(1092, 621);
            this.tabDefectos.TabIndex = 4;
            this.tabDefectos.Text = "Defectos";
            // 
            // dgvDefectos
            // 
            this.dgvDefectos.AllowUserToAddRows = false;
            this.dgvDefectos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDefectos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDefectos.Location = new System.Drawing.Point(3, 133);
            this.dgvDefectos.Name = "dgvDefectos";
            this.dgvDefectos.ReadOnly = true;
            this.dgvDefectos.RowHeadersWidth = 51;
            this.dgvDefectos.Size = new System.Drawing.Size(1086, 485);
            this.dgvDefectos.TabIndex = 0;
            // 
            // pnlDefForm
            // 
            this.pnlDefForm.Controls.Add(this.lblDefTitulo);
            this.pnlDefForm.Controls.Add(this.lblDefProd);
            this.pnlDefForm.Controls.Add(this.cboDefProd);
            this.pnlDefForm.Controls.Add(this.lblDefDesc);
            this.pnlDefForm.Controls.Add(this.txtDefDesc);
            this.pnlDefForm.Controls.Add(this.lblDefCant);
            this.pnlDefForm.Controls.Add(this.numDefCant);
            this.pnlDefForm.Controls.Add(this.btnDefRegistrar);
            this.pnlDefForm.Controls.Add(this.btnDefLimpiar);
            this.pnlDefForm.Controls.Add(this.lblDefFiltro);
            this.pnlDefForm.Controls.Add(this.cboDefFiltro);
            this.pnlDefForm.Controls.Add(this.btnDefFiltrar);
            this.pnlDefForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDefForm.Location = new System.Drawing.Point(3, 3);
            this.pnlDefForm.Name = "pnlDefForm";
            this.pnlDefForm.Size = new System.Drawing.Size(1086, 130);
            this.pnlDefForm.TabIndex = 1;
            // 
            // lblDefTitulo
            // 
            this.lblDefTitulo.AutoSize = true;
            this.lblDefTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblDefTitulo.Location = new System.Drawing.Point(5, 5);
            this.lblDefTitulo.Name = "lblDefTitulo";
            this.lblDefTitulo.Size = new System.Drawing.Size(159, 20);
            this.lblDefTitulo.TabIndex = 0;
            this.lblDefTitulo.Text = "Registrar Defecto";
            // 
            // lblDefProd
            // 
            this.lblDefProd.AutoSize = true;
            this.lblDefProd.Location = new System.Drawing.Point(5, 35);
            this.lblDefProd.Name = "lblDefProd";
            this.lblDefProd.Size = new System.Drawing.Size(64, 16);
            this.lblDefProd.TabIndex = 1;
            this.lblDefProd.Text = "Producto:";
            // 
            // cboDefProd
            // 
            this.cboDefProd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDefProd.Location = new System.Drawing.Point(90, 32);
            this.cboDefProd.Name = "cboDefProd";
            this.cboDefProd.Size = new System.Drawing.Size(200, 24);
            this.cboDefProd.TabIndex = 2;
            // 
            // lblDefDesc
            // 
            this.lblDefDesc.AutoSize = true;
            this.lblDefDesc.Location = new System.Drawing.Point(5, 65);
            this.lblDefDesc.Name = "lblDefDesc";
            this.lblDefDesc.Size = new System.Drawing.Size(82, 16);
            this.lblDefDesc.TabIndex = 3;
            this.lblDefDesc.Text = "Descripción:";
            // 
            // txtDefDesc
            // 
            this.txtDefDesc.Location = new System.Drawing.Point(90, 62);
            this.txtDefDesc.Name = "txtDefDesc";
            this.txtDefDesc.Size = new System.Drawing.Size(300, 22);
            this.txtDefDesc.TabIndex = 4;
            // 
            // lblDefCant
            // 
            this.lblDefCant.AutoSize = true;
            this.lblDefCant.Location = new System.Drawing.Point(5, 95);
            this.lblDefCant.Name = "lblDefCant";
            this.lblDefCant.Size = new System.Drawing.Size(64, 16);
            this.lblDefCant.TabIndex = 5;
            this.lblDefCant.Text = "Cantidad:";
            // 
            // numDefCant
            // 
            this.numDefCant.Location = new System.Drawing.Point(90, 92);
            this.numDefCant.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numDefCant.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDefCant.Name = "numDefCant";
            this.numDefCant.Size = new System.Drawing.Size(70, 22);
            this.numDefCant.TabIndex = 6;
            this.numDefCant.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnDefRegistrar
            // 
            this.btnDefRegistrar.Location = new System.Drawing.Point(170, 91);
            this.btnDefRegistrar.Name = "btnDefRegistrar";
            this.btnDefRegistrar.Size = new System.Drawing.Size(80, 26);
            this.btnDefRegistrar.TabIndex = 7;
            this.btnDefRegistrar.Text = "Registrar";
            this.btnDefRegistrar.Click += new System.EventHandler(this.btnDefRegistrar_Click);
            // 
            // btnDefLimpiar
            // 
            this.btnDefLimpiar.Location = new System.Drawing.Point(258, 91);
            this.btnDefLimpiar.Name = "btnDefLimpiar";
            this.btnDefLimpiar.Size = new System.Drawing.Size(80, 26);
            this.btnDefLimpiar.TabIndex = 8;
            this.btnDefLimpiar.Text = "Limpiar";
            this.btnDefLimpiar.Click += new System.EventHandler(this.btnDefLimpiar_Click);
            // 
            // lblDefFiltro
            // 
            this.lblDefFiltro.AutoSize = true;
            this.lblDefFiltro.Location = new System.Drawing.Point(350, 35);
            this.lblDefFiltro.Name = "lblDefFiltro";
            this.lblDefFiltro.Size = new System.Drawing.Size(110, 16);
            this.lblDefFiltro.TabIndex = 9;
            this.lblDefFiltro.Text = "Ver por producto:";
            // 
            // cboDefFiltro
            // 
            this.cboDefFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDefFiltro.Location = new System.Drawing.Point(470, 32);
            this.cboDefFiltro.Name = "cboDefFiltro";
            this.cboDefFiltro.Size = new System.Drawing.Size(180, 24);
            this.cboDefFiltro.TabIndex = 10;
            // 
            // btnDefFiltrar
            // 
            this.btnDefFiltrar.Location = new System.Drawing.Point(658, 31);
            this.btnDefFiltrar.Name = "btnDefFiltrar";
            this.btnDefFiltrar.Size = new System.Drawing.Size(70, 26);
            this.btnDefFiltrar.TabIndex = 11;
            this.btnDefFiltrar.Text = "Filtrar";
            this.btnDefFiltrar.Click += new System.EventHandler(this.btnDefFiltrar_Click);
            // 
            // tabAlertas
            // 
            this.tabAlertas.Controls.Add(this.dgvAlertas);
            this.tabAlertas.Controls.Add(this.pnlAlertasBotones);
            this.tabAlertas.Location = new System.Drawing.Point(4, 25);
            this.tabAlertas.Name = "tabAlertas";
            this.tabAlertas.Padding = new System.Windows.Forms.Padding(3);
            this.tabAlertas.Size = new System.Drawing.Size(1092, 621);
            this.tabAlertas.TabIndex = 5;
            this.tabAlertas.Text = "Alertas";
            // 
            // dgvAlertas
            // 
            this.dgvAlertas.AllowUserToAddRows = false;
            this.dgvAlertas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlertas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAlertas.Location = new System.Drawing.Point(3, 43);
            this.dgvAlertas.Name = "dgvAlertas";
            this.dgvAlertas.ReadOnly = true;
            this.dgvAlertas.RowHeadersWidth = 51;
            this.dgvAlertas.Size = new System.Drawing.Size(1086, 575);
            this.dgvAlertas.TabIndex = 0;
            // 
            // pnlAlertasBotones
            // 
            this.pnlAlertasBotones.Controls.Add(this.lblAlertaContador);
            this.pnlAlertasBotones.Controls.Add(this.btnAlertaRefrescar);
            this.pnlAlertasBotones.Controls.Add(this.btnAlertaAtender);
            this.pnlAlertasBotones.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAlertasBotones.Location = new System.Drawing.Point(3, 3);
            this.pnlAlertasBotones.Name = "pnlAlertasBotones";
            this.pnlAlertasBotones.Size = new System.Drawing.Size(1086, 40);
            this.pnlAlertasBotones.TabIndex = 1;
            // 
            // lblAlertaContador
            // 
            this.lblAlertaContador.AutoSize = true;
            this.lblAlertaContador.Location = new System.Drawing.Point(5, 12);
            this.lblAlertaContador.Name = "lblAlertaContador";
            this.lblAlertaContador.Size = new System.Drawing.Size(132, 16);
            this.lblAlertaContador.TabIndex = 0;
            this.lblAlertaContador.Text = "Alertas pendientes: 0";
            // 
            // btnAlertaRefrescar
            // 
            this.btnAlertaRefrescar.Location = new System.Drawing.Point(200, 8);
            this.btnAlertaRefrescar.Name = "btnAlertaRefrescar";
            this.btnAlertaRefrescar.Size = new System.Drawing.Size(80, 26);
            this.btnAlertaRefrescar.TabIndex = 1;
            this.btnAlertaRefrescar.Text = "Refrescar";
            this.btnAlertaRefrescar.Click += new System.EventHandler(this.btnAlertaRefrescar_Click);
            // 
            // btnAlertaAtender
            // 
            this.btnAlertaAtender.Location = new System.Drawing.Point(288, 8);
            this.btnAlertaAtender.Name = "btnAlertaAtender";
            this.btnAlertaAtender.Size = new System.Drawing.Size(80, 26);
            this.btnAlertaAtender.TabIndex = 2;
            this.btnAlertaAtender.Text = "Atendida";
            this.btnAlertaAtender.Click += new System.EventHandler(this.btnAlertaAtender_Click);
            // 
            // FrmInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmInventario";
            this.Text = "Inventario";
            this.Load += new System.EventHandler(this.FrmInventario_Load);
            this.tabControl.ResumeLayout(false);
            this.tabProductos.ResumeLayout(false);
            this.splitProductos.Panel1.ResumeLayout(false);
            this.splitProductos.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitProductos)).EndInit();
            this.splitProductos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.pnlProdForm.ResumeLayout(false);
            this.pnlProdForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCodigoBarras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numProdStockMin)).EndInit();
            this.pnlProdFiltro.ResumeLayout(false);
            this.pnlProdFiltro.PerformLayout();
            this.tabEquipo.ResumeLayout(false);
            this.splitEquipo.Panel1.ResumeLayout(false);
            this.splitEquipo.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitEquipo)).EndInit();
            this.splitEquipo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipo)).EndInit();
            this.pnlEqForm.ResumeLayout(false);
            this.pnlEqForm.PerformLayout();
            this.pnlEqFiltro.ResumeLayout(false);
            this.pnlEqFiltro.PerformLayout();
            this.tabMovimientos.ResumeLayout(false);
            this.pnlMovForm.ResumeLayout(false);
            this.pnlMovForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMovAlerta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMovCantidad)).EndInit();
            this.tabHistorial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.pnlHistFiltro.ResumeLayout(false);
            this.pnlHistFiltro.PerformLayout();
            this.tabDefectos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDefectos)).EndInit();
            this.pnlDefForm.ResumeLayout(false);
            this.pnlDefForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDefCant)).EndInit();
            this.tabAlertas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlertas)).EndInit();
            this.pnlAlertasBotones.ResumeLayout(false);
            this.pnlAlertasBotones.PerformLayout();
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
