namespace CapaPresentacion
{
    partial class FrmOrdenesRestock
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitulo           = new System.Windows.Forms.Label();
            this.lblFiltro           = new System.Windows.Forms.Label();
            this.cboFiltro           = new System.Windows.Forms.ComboBox();
            this.btnRefrescar        = new System.Windows.Forms.Button();
            this.dgvOrdenes          = new System.Windows.Forms.DataGridView();
            this.grpDetalle          = new System.Windows.Forms.GroupBox();
            this.lblDetalleProveedor = new System.Windows.Forms.Label();
            this.btnEnviada          = new System.Windows.Forms.Button();
            this.btnRecibida         = new System.Windows.Forms.Button();
            this.btnCancelarOrden    = new System.Windows.Forms.Button();
            this.btnsalir            = new System.Windows.Forms.Button();
            this.grpDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).BeginInit();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font     = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name     = "lblTitulo";
            this.lblTitulo.Text     = "Órdenes de Restock";

            // lblFiltro
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Location = new System.Drawing.Point(20, 72);
            this.lblFiltro.Name     = "lblFiltro";
            this.lblFiltro.Text     = "Filtrar por estado:";

            // cboFiltro
            this.cboFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFiltro.Items.AddRange(new object[] { "TODAS", "PENDIENTE", "ENVIADA", "RECIBIDA", "CANCELADA" });
            this.cboFiltro.Location      = new System.Drawing.Point(145, 69);
            this.cboFiltro.Name          = "cboFiltro";
            this.cboFiltro.Size          = new System.Drawing.Size(140, 24);
            this.cboFiltro.TabIndex      = 0;
            this.cboFiltro.SelectedIndex = 0;
            this.cboFiltro.SelectedIndexChanged += new System.EventHandler(this.cboFiltro_SelectedIndexChanged);

            // btnRefrescar
            this.btnRefrescar.Location = new System.Drawing.Point(300, 68);
            this.btnRefrescar.Name     = "btnRefrescar";
            this.btnRefrescar.Size     = new System.Drawing.Size(90, 26);
            this.btnRefrescar.TabIndex = 1;
            this.btnRefrescar.Text     = "Refrescar";
            this.btnRefrescar.UseVisualStyleBackColor = true;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);

            // dgvOrdenes
            this.dgvOrdenes.AllowUserToAddRows    = false;
            this.dgvOrdenes.AllowUserToDeleteRows = false;
            this.dgvOrdenes.ReadOnly              = true;
            this.dgvOrdenes.SelectionMode         = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrdenes.MultiSelect           = false;
            this.dgvOrdenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdenes.Location         = new System.Drawing.Point(20, 110);
            this.dgvOrdenes.Name             = "dgvOrdenes";
            this.dgvOrdenes.RowHeadersWidth  = 51;
            this.dgvOrdenes.RowTemplate.Height = 24;
            this.dgvOrdenes.Size             = new System.Drawing.Size(940, 260);
            this.dgvOrdenes.TabIndex         = 2;
            this.dgvOrdenes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrdenes_CellClick);

            // grpDetalle
            this.grpDetalle.Controls.Add(this.lblDetalleProveedor);
            this.grpDetalle.Location = new System.Drawing.Point(20, 385);
            this.grpDetalle.Name     = "grpDetalle";
            this.grpDetalle.Size     = new System.Drawing.Size(940, 55);
            this.grpDetalle.TabIndex = 3;
            this.grpDetalle.Text     = "Datos del Proveedor";

            // lblDetalleProveedor
            this.lblDetalleProveedor.AutoSize = false;
            this.lblDetalleProveedor.Location = new System.Drawing.Point(10, 20);
            this.lblDetalleProveedor.Name     = "lblDetalleProveedor";
            this.lblDetalleProveedor.Size     = new System.Drawing.Size(920, 25);
            this.lblDetalleProveedor.Text     = "Seleccione una orden para ver los datos del proveedor.";

            // btnEnviada
            this.btnEnviada.Enabled  = false;
            this.btnEnviada.Location = new System.Drawing.Point(20, 458);
            this.btnEnviada.Name     = "btnEnviada";
            this.btnEnviada.Size     = new System.Drawing.Size(120, 30);
            this.btnEnviada.TabIndex = 4;
            this.btnEnviada.Text     = "Marcar Enviada";
            this.btnEnviada.UseVisualStyleBackColor = true;
            this.btnEnviada.Click += new System.EventHandler(this.btnEnviada_Click);

            // btnRecibida
            this.btnRecibida.Enabled  = false;
            this.btnRecibida.Location = new System.Drawing.Point(150, 458);
            this.btnRecibida.Name     = "btnRecibida";
            this.btnRecibida.Size     = new System.Drawing.Size(120, 30);
            this.btnRecibida.TabIndex = 5;
            this.btnRecibida.Text     = "Marcar Recibida";
            this.btnRecibida.UseVisualStyleBackColor = true;
            this.btnRecibida.Click += new System.EventHandler(this.btnRecibida_Click);

            // btnCancelarOrden
            this.btnCancelarOrden.Enabled  = false;
            this.btnCancelarOrden.Location = new System.Drawing.Point(280, 458);
            this.btnCancelarOrden.Name     = "btnCancelarOrden";
            this.btnCancelarOrden.Size     = new System.Drawing.Size(110, 30);
            this.btnCancelarOrden.TabIndex = 6;
            this.btnCancelarOrden.Text     = "Cancelar Orden";
            this.btnCancelarOrden.UseVisualStyleBackColor = true;
            this.btnCancelarOrden.Click += new System.EventHandler(this.btnCancelarOrden_Click);

            // btnsalir
            this.btnsalir.Location = new System.Drawing.Point(855, 458);
            this.btnsalir.Name     = "btnsalir";
            this.btnsalir.Size     = new System.Drawing.Size(105, 30);
            this.btnsalir.TabIndex = 7;
            this.btnsalir.Text     = "&Salir";
            this.btnsalir.UseVisualStyleBackColor = true;
            this.btnsalir.Click += new System.EventHandler(this.btnsalir_Click);

            // FrmOrdenesRestock
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(980, 510);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblFiltro);
            this.Controls.Add(this.cboFiltro);
            this.Controls.Add(this.btnRefrescar);
            this.Controls.Add(this.dgvOrdenes);
            this.Controls.Add(this.grpDetalle);
            this.Controls.Add(this.btnEnviada);
            this.Controls.Add(this.btnRecibida);
            this.Controls.Add(this.btnCancelarOrden);
            this.Controls.Add(this.btnsalir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name            = "FrmOrdenesRestock";
            this.Text            = "Órdenes de Restock";
            this.Load           += new System.EventHandler(this.FrmOrdenesRestock_Load);
            this.grpDetalle.ResumeLayout(false);
            this.grpDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label         lblTitulo;
        private System.Windows.Forms.Label         lblFiltro;
        private System.Windows.Forms.ComboBox      cboFiltro;
        private System.Windows.Forms.Button        btnRefrescar;
        private System.Windows.Forms.DataGridView  dgvOrdenes;
        private System.Windows.Forms.GroupBox      grpDetalle;
        private System.Windows.Forms.Label         lblDetalleProveedor;
        private System.Windows.Forms.Button        btnEnviada;
        private System.Windows.Forms.Button        btnRecibida;
        private System.Windows.Forms.Button        btnCancelarOrden;
        private System.Windows.Forms.Button        btnsalir;
    }
}
