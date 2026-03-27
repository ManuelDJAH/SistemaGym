namespace CapaPresentacion
{
    partial class FrmProveedores
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
            this.tabProveedores = new System.Windows.Forms.TabPage();
            this.tabRestock = new System.Windows.Forms.TabPage();

            // ── TAB PROVEEDORES controls ─────────────────────────────
            this.pnlBusqueda = new System.Windows.Forms.Panel();
            this.rbNombre = new System.Windows.Forms.RadioButton();
            this.rbContacto = new System.Windows.Forms.RadioButton();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnVerTodos = new System.Windows.Forms.Button();
            this.splitProv = new System.Windows.Forms.SplitContainer();
            this.dgvProveedores = new System.Windows.Forms.DataGridView();
            this.pnlFormProv = new System.Windows.Forms.Panel();
            this.lblTituloProv = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblContacto = new System.Windows.Forms.Label();
            this.txtContacto = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.cbCategoria = new System.Windows.Forms.ComboBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();

            // ── TAB RESTOCK controls ─────────────────────────────────
            this.pnlRestockTop = new System.Windows.Forms.Panel();
            this.lblFiltroEstado = new System.Windows.Forms.Label();
            this.cboFiltroEstado = new System.Windows.Forms.ComboBox();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.dgvOrdenes = new System.Windows.Forms.DataGridView();
            this.lblDetalleProveedor = new System.Windows.Forms.Label();
            this.pnlRestockBotones = new System.Windows.Forms.Panel();
            this.btnEnviada = new System.Windows.Forms.Button();
            this.btnRecibida = new System.Windows.Forms.Button();
            this.btnCancelarOrden = new System.Windows.Forms.Button();

            // ── BEGIN INIT ───────────────────────────────────────────
            this.tabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.splitProv).BeginInit();
            this.splitProv.Panel1.SuspendLayout();
            this.splitProv.Panel2.SuspendLayout();
            this.splitProv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvProveedores).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.dgvOrdenes).BeginInit();
            this.SuspendLayout();

            // ── FORM ─────────────────────────────────────────────────
            this.Text = "Proveedores";
            this.Size = new System.Drawing.Size(950, 580);
            this.MinimumSize = new System.Drawing.Size(900, 550);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Load += new System.EventHandler(this.FrmProveedores_Load);

            // ── TAB CONTROL ──────────────────────────────────────────
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.tabControl.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.tabProveedores, this.tabRestock });
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);

            this.tabProveedores.Text = "Proveedores";
            this.tabProveedores.UseVisualStyleBackColor = true;
            this.tabRestock.Text = "Ordenes de Restock";
            this.tabRestock.UseVisualStyleBackColor = true;

            // ════════════════════════════════════════════════════════
            //  TAB PROVEEDORES
            // ════════════════════════════════════════════════════════

            // Panel búsqueda
            this.pnlBusqueda.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBusqueda.Height = 40;

            this.rbNombre.Text = "Nombre";
            this.rbNombre.Location = new System.Drawing.Point(8, 12);
            this.rbNombre.AutoSize = true;
            this.rbNombre.Checked = true;

            this.rbContacto.Text = "Contacto";
            this.rbContacto.Location = new System.Drawing.Point(80, 12);
            this.rbContacto.AutoSize = true;

            this.txtBuscar.Location = new System.Drawing.Point(160, 10);
            this.txtBuscar.Size = new System.Drawing.Size(250, 23);

            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Location = new System.Drawing.Point(418, 9);
            this.btnBuscar.Size = new System.Drawing.Size(70, 25);
            this.btnBuscar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);

            this.btnVerTodos.Text = "Ver todos";
            this.btnVerTodos.Location = new System.Drawing.Point(496, 9);
            this.btnVerTodos.Size = new System.Drawing.Size(75, 25);
            this.btnVerTodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerTodos.Click += new System.EventHandler(this.btnVerTodos_Click);

            this.pnlBusqueda.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.rbNombre, this.rbContacto, this.txtBuscar, this.btnBuscar, this.btnVerTodos });

            // SplitContainer
            this.splitProv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitProv.Panel1MinSize = 10;
            this.splitProv.Panel2MinSize = 10;

            // DGV Proveedores
            this.dgvProveedores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProveedores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProveedores.ReadOnly = true;
            this.dgvProveedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProveedores.AllowUserToAddRows = false;
            this.dgvProveedores.BackgroundColor = System.Drawing.Color.White;
            this.dgvProveedores.RowHeadersVisible = false;
            this.dgvProveedores.SelectionChanged += new System.EventHandler(this.dgvProveedores_SelectionChanged);
            this.splitProv.Panel1.Controls.Add(this.dgvProveedores);

            // Panel form proveedor
            this.pnlFormProv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFormProv.Padding = new System.Windows.Forms.Padding(10);
            this.pnlFormProv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            int py = 8;
            this.lblTituloProv.Text = "Datos del Proveedor";
            this.lblTituloProv.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTituloProv.Location = new System.Drawing.Point(10, py);
            this.lblTituloProv.AutoSize = true;
            py += 30;

            this.lblNombre.Text = "Nombre:"; this.lblNombre.Location = new System.Drawing.Point(10, py); this.lblNombre.AutoSize = true; py += 18;
            this.txtNombre.Location = new System.Drawing.Point(10, py); this.txtNombre.Size = new System.Drawing.Size(260, 23); py += 30;

            this.lblContacto.Text = "Contacto:"; this.lblContacto.Location = new System.Drawing.Point(10, py); this.lblContacto.AutoSize = true; py += 18;
            this.txtContacto.Location = new System.Drawing.Point(10, py); this.txtContacto.Size = new System.Drawing.Size(260, 23); py += 30;

            this.lblTelefono.Text = "Telefono:"; this.lblTelefono.Location = new System.Drawing.Point(10, py); this.lblTelefono.AutoSize = true; py += 18;
            this.txtTelefono.Location = new System.Drawing.Point(10, py); this.txtTelefono.Size = new System.Drawing.Size(180, 23); py += 30;

            this.lblCorreo.Text = "Correo:"; this.lblCorreo.Location = new System.Drawing.Point(10, py); this.lblCorreo.AutoSize = true; py += 18;
            this.txtCorreo.Location = new System.Drawing.Point(10, py); this.txtCorreo.Size = new System.Drawing.Size(260, 23); py += 30;

            this.lblDireccion.Text = "Direccion:"; this.lblDireccion.Location = new System.Drawing.Point(10, py); this.lblDireccion.AutoSize = true; py += 18;
            this.txtDireccion.Location = new System.Drawing.Point(10, py); this.txtDireccion.Size = new System.Drawing.Size(260, 23); py += 30;

            this.lblCategoria.Text = "Categoria:"; this.lblCategoria.Location = new System.Drawing.Point(10, py); this.lblCategoria.AutoSize = true; py += 18;
            this.cbCategoria.Location = new System.Drawing.Point(10, py);
            this.cbCategoria.Size = new System.Drawing.Size(260, 23);
            this.cbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            py += 35;

            this.btnNuevo.Text = "+ Nuevo"; this.btnNuevo.Location = new System.Drawing.Point(10, py);
            this.btnNuevo.Size = new System.Drawing.Size(75, 28); this.btnNuevo.BackColor = System.Drawing.Color.SeaGreen;
            this.btnNuevo.ForeColor = System.Drawing.Color.White; this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);

            this.btnGuardar.Text = "Guardar"; this.btnGuardar.Location = new System.Drawing.Point(92, py);
            this.btnGuardar.Size = new System.Drawing.Size(75, 28); this.btnGuardar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnGuardar.ForeColor = System.Drawing.Color.White; this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Enabled = false; this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            this.btnEditar.Text = "Editar"; this.btnEditar.Location = new System.Drawing.Point(174, py);
            this.btnEditar.Size = new System.Drawing.Size(70, 28); this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Enabled = false; this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            py += 34;

            this.btnEliminar.Text = "Eliminar"; this.btnEliminar.Location = new System.Drawing.Point(10, py);
            this.btnEliminar.Size = new System.Drawing.Size(75, 28); this.btnEliminar.BackColor = System.Drawing.Color.Firebrick;
            this.btnEliminar.ForeColor = System.Drawing.Color.White; this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Enabled = false; this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            this.btnCancelar.Text = "Cancelar"; this.btnCancelar.Location = new System.Drawing.Point(92, py);
            this.btnCancelar.Size = new System.Drawing.Size(75, 28); this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Enabled = false; this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            this.pnlFormProv.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTituloProv, this.lblNombre, this.txtNombre,
                this.lblContacto, this.txtContacto, this.lblTelefono, this.txtTelefono,
                this.lblCorreo, this.txtCorreo, this.lblDireccion, this.txtDireccion,
                this.lblCategoria, this.cbCategoria,
                this.btnNuevo, this.btnGuardar, this.btnEditar,
                this.btnEliminar, this.btnCancelar });
            this.splitProv.Panel2.Controls.Add(this.pnlFormProv);

            this.tabProveedores.Controls.Add(this.splitProv);
            this.tabProveedores.Controls.Add(this.pnlBusqueda);

            // ════════════════════════════════════════════════════════
            //  TAB RESTOCK
            // ════════════════════════════════════════════════════════

            this.pnlRestockTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRestockTop.Height = 40;

            this.lblFiltroEstado.Text = "Filtrar por estado:";
            this.lblFiltroEstado.Location = new System.Drawing.Point(8, 13);
            this.lblFiltroEstado.AutoSize = true;

            this.cboFiltroEstado.Location = new System.Drawing.Point(125, 9);
            this.cboFiltroEstado.Width = 120;
            this.cboFiltroEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFiltroEstado.Items.AddRange(new object[] { "TODAS", "PENDIENTE", "ENVIADA", "RECIBIDA", "CANCELADA" });
            this.cboFiltroEstado.SelectedIndex = 0;
            this.cboFiltroEstado.SelectedIndexChanged += new System.EventHandler(this.cboFiltroEstado_SelectedIndexChanged);

            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.Location = new System.Drawing.Point(255, 9);
            this.btnRefrescar.Size = new System.Drawing.Size(80, 26);
            this.btnRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);

            this.pnlRestockTop.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblFiltroEstado, this.cboFiltroEstado, this.btnRefrescar });

            this.dgvOrdenes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrdenes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrdenes.ReadOnly = true;
            this.dgvOrdenes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrdenes.AllowUserToAddRows = false;
            this.dgvOrdenes.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrdenes.RowHeadersVisible = false;
            this.dgvOrdenes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrdenes_CellClick);

            this.lblDetalleProveedor.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblDetalleProveedor.Height = 24;
            this.lblDetalleProveedor.Text = "Seleccione una orden para ver los datos del proveedor.";
            this.lblDetalleProveedor.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.lblDetalleProveedor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDetalleProveedor.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);

            this.pnlRestockBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlRestockBotones.Height = 42;

            this.btnEnviada.Text = "Marcar Enviada";
            this.btnEnviada.Location = new System.Drawing.Point(8, 8);
            this.btnEnviada.Size = new System.Drawing.Size(120, 28);
            this.btnEnviada.BackColor = System.Drawing.Color.SteelBlue;
            this.btnEnviada.ForeColor = System.Drawing.Color.White;
            this.btnEnviada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviada.Enabled = false;
            this.btnEnviada.Click += new System.EventHandler(this.btnEnviada_Click);

            this.btnRecibida.Text = "Marcar Recibida";
            this.btnRecibida.Location = new System.Drawing.Point(136, 8);
            this.btnRecibida.Size = new System.Drawing.Size(120, 28);
            this.btnRecibida.BackColor = System.Drawing.Color.SeaGreen;
            this.btnRecibida.ForeColor = System.Drawing.Color.White;
            this.btnRecibida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecibida.Enabled = false;
            this.btnRecibida.Click += new System.EventHandler(this.btnRecibida_Click);

            this.btnCancelarOrden.Text = "Cancelar Orden";
            this.btnCancelarOrden.Location = new System.Drawing.Point(264, 8);
            this.btnCancelarOrden.Size = new System.Drawing.Size(110, 28);
            this.btnCancelarOrden.BackColor = System.Drawing.Color.Firebrick;
            this.btnCancelarOrden.ForeColor = System.Drawing.Color.White;
            this.btnCancelarOrden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarOrden.Enabled = false;
            this.btnCancelarOrden.Click += new System.EventHandler(this.btnCancelarOrden_Click);

            this.pnlRestockBotones.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.btnEnviada, this.btnRecibida, this.btnCancelarOrden });

            this.tabRestock.Controls.Add(this.dgvOrdenes);
            this.tabRestock.Controls.Add(this.lblDetalleProveedor);
            this.tabRestock.Controls.Add(this.pnlRestockBotones);
            this.tabRestock.Controls.Add(this.pnlRestockTop);

            this.Controls.Add(this.tabControl);

            // ── END INIT ─────────────────────────────────────────────
            ((System.ComponentModel.ISupportInitialize)this.splitProv).EndInit();
            this.splitProv.Panel1.ResumeLayout(false);
            this.splitProv.Panel2.ResumeLayout(false);
            this.splitProv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.dgvProveedores).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.dgvOrdenes).EndInit();
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        #endregion

        // ── Controles ────────────────────────────────────────────────
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabProveedores, tabRestock;
        private System.Windows.Forms.SplitContainer splitProv;
        // Proveedores
        private System.Windows.Forms.Panel pnlBusqueda, pnlFormProv;
        private System.Windows.Forms.RadioButton rbNombre, rbContacto;
        private System.Windows.Forms.TextBox txtBuscar, txtNombre, txtContacto,
                                                 txtTelefono, txtCorreo, txtDireccion;
        private System.Windows.Forms.ComboBox cbCategoria;
        private System.Windows.Forms.Label lblTituloProv, lblNombre, lblContacto,
                                                 lblTelefono, lblCorreo, lblDireccion, lblCategoria;
        private System.Windows.Forms.Button btnBuscar, btnVerTodos, btnNuevo, btnGuardar,
                                                 btnEditar, btnEliminar, btnCancelar;
        private System.Windows.Forms.DataGridView dgvProveedores;
        // Restock
        private System.Windows.Forms.Panel pnlRestockTop, pnlRestockBotones;
        private System.Windows.Forms.Label lblFiltroEstado, lblDetalleProveedor;
        private System.Windows.Forms.ComboBox cboFiltroEstado;
        private System.Windows.Forms.Button btnRefrescar, btnEnviada, btnRecibida, btnCancelarOrden;
        private System.Windows.Forms.DataGridView dgvOrdenes;
    }
}