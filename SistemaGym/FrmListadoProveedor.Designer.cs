namespace CapaPresentacion
{
    partial class FrmListadoProveedor
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
            this.label1    = new System.Windows.Forms.Label();
            this.panel1    = new System.Windows.Forms.Panel();
            this.btnsalir  = new System.Windows.Forms.Button();
            this.btnbuscar = new System.Windows.Forms.Button();
            this.txtbuscar = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbtndni  = new System.Windows.Forms.RadioButton();   // RFC
            this.rbtnnombre= new System.Windows.Forms.RadioButton();
            this.dlistado  = new System.Windows.Forms.DataGridView();
            this.btnnuevo  = new System.Windows.Forms.Button();
            this.btneditar = new System.Windows.Forms.Button();
            this.btneliminar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dlistado)).BeginInit();
            this.SuspendLayout();

            // label1
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F,
                System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 36);
            this.label1.Name     = "label1";
            this.label1.Size     = new System.Drawing.Size(143, 29);
            this.label1.TabIndex = 0;
            this.label1.Text     = "Proveedores";

            // panel1
            this.panel1.Controls.Add(this.btnsalir);
            this.panel1.Controls.Add(this.btnbuscar);
            this.panel1.Controls.Add(this.txtbuscar);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(33, 90);
            this.panel1.Name     = "panel1";
            this.panel1.Size     = new System.Drawing.Size(728, 94);
            this.panel1.TabIndex = 1;

            // btnsalir
            this.btnsalir.Location = new System.Drawing.Point(648, 38);
            this.btnsalir.Name     = "btnsalir";
            this.btnsalir.Size     = new System.Drawing.Size(75, 23);
            this.btnsalir.TabIndex = 5;
            this.btnsalir.Text     = "&Salir";
            this.btnsalir.UseVisualStyleBackColor = true;
            this.btnsalir.Click += new System.EventHandler(this.btnsalir_Click);

            // btnbuscar
            this.btnbuscar.Location = new System.Drawing.Point(566, 38);
            this.btnbuscar.Name     = "btnbuscar";
            this.btnbuscar.Size     = new System.Drawing.Size(75, 23);
            this.btnbuscar.TabIndex = 4;
            this.btnbuscar.Text     = "&Buscar";
            this.btnbuscar.UseVisualStyleBackColor = true;
            this.btnbuscar.Click += new System.EventHandler(this.btnbuscar_Click);

            // txtbuscar
            this.txtbuscar.Location = new System.Drawing.Point(199, 39);
            this.txtbuscar.Name     = "txtbuscar";
            this.txtbuscar.Size     = new System.Drawing.Size(360, 22);
            this.txtbuscar.TabIndex = 3;

            // groupBox1
            this.groupBox1.Controls.Add(this.rdbtndni);
            this.groupBox1.Controls.Add(this.rbtnnombre);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name     = "groupBox1";
            this.groupBox1.Size     = new System.Drawing.Size(178, 82);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop  = false;
            this.groupBox1.Text     = "Criterio de Búsqueda";

            // rdbtndni  →  RFC
            this.rdbtndni.AutoSize  = true;
            this.rdbtndni.Location  = new System.Drawing.Point(100, 36);
            this.rdbtndni.Name      = "rdbtndni";
            this.rdbtndni.Size      = new System.Drawing.Size(51, 20);
            this.rdbtndni.TabIndex  = 1;
            this.rdbtndni.TabStop   = true;
            this.rdbtndni.Text      = "RFC";
            this.rdbtndni.UseVisualStyleBackColor = true;

            // rbtnnombre
            this.rbtnnombre.AutoSize  = true;
            this.rbtnnombre.Location  = new System.Drawing.Point(18, 36);
            this.rbtnnombre.Name      = "rbtnnombre";
            this.rbtnnombre.Size      = new System.Drawing.Size(77, 20);
            this.rbtnnombre.TabIndex  = 0;
            this.rbtnnombre.TabStop   = true;
            this.rbtnnombre.Text      = "Nombre";
            this.rbtnnombre.UseVisualStyleBackColor = true;

            // dlistado
            this.dlistado.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dlistado.Location        = new System.Drawing.Point(33, 205);
            this.dlistado.Name            = "dlistado";
            this.dlistado.RowHeadersWidth = 51;
            this.dlistado.RowTemplate.Height = 24;
            this.dlistado.Size            = new System.Drawing.Size(728, 202);
            this.dlistado.TabIndex        = 2;

            // btnnuevo
            this.btnnuevo.Location = new System.Drawing.Point(545, 418);
            this.btnnuevo.Name     = "btnnuevo";
            this.btnnuevo.Size     = new System.Drawing.Size(75, 23);
            this.btnnuevo.TabIndex = 3;
            this.btnnuevo.Text     = "&Nuevo";
            this.btnnuevo.UseVisualStyleBackColor = true;
            this.btnnuevo.Click += new System.EventHandler(this.btnnuevo_Click);

            // btneditar
            this.btneditar.Location = new System.Drawing.Point(627, 418);
            this.btneditar.Name     = "btneditar";
            this.btneditar.Size     = new System.Drawing.Size(75, 23);
            this.btneditar.TabIndex = 4;
            this.btneditar.Text     = "&Editar";
            this.btneditar.UseVisualStyleBackColor = true;
            this.btneditar.Click += new System.EventHandler(this.btneditar_Click);

            // btneliminar
            this.btneliminar.Location = new System.Drawing.Point(709, 418);
            this.btneliminar.Name     = "btneliminar";
            this.btneliminar.Size     = new System.Drawing.Size(75, 23);
            this.btneliminar.TabIndex = 5;
            this.btneliminar.Text     = "&Eliminar";
            this.btneliminar.UseVisualStyleBackColor = true;
            this.btneliminar.Click += new System.EventHandler(this.btneliminar_Click);

            // FrmListadoProveedor
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btneliminar);
            this.Controls.Add(this.btneditar);
            this.Controls.Add(this.btnnuevo);
            this.Controls.Add(this.dlistado);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmListadoProveedor";
            this.Text = "FrmListadoProveedor";
            this.Load += new System.EventHandler(this.FrmListadoProveedor_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dlistado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnsalir;
        private System.Windows.Forms.Button btnbuscar;
        private System.Windows.Forms.TextBox txtbuscar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbtndni;
        private System.Windows.Forms.RadioButton rbtnnombre;
        private System.Windows.Forms.DataGridView dlistado;
        private System.Windows.Forms.Button btnnuevo;
        private System.Windows.Forms.Button btneditar;
        private System.Windows.Forms.Button btneliminar;
    }
}
