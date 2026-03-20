namespace CapaPresentacion
{
    partial class FrmRegistrarProveedor
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
            this.lbltitulo = new System.Windows.Forms.Label();
            this.lblidproveedor = new System.Windows.Forms.Label();
            this.txtidproveedor = new System.Windows.Forms.TextBox();
            this.lblnombre = new System.Windows.Forms.Label();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.lblcontacto = new System.Windows.Forms.Label();
            this.txtcontacto = new System.Windows.Forms.TextBox();
            this.lblrfc = new System.Windows.Forms.Label();
            this.txtrfc = new System.Windows.Forms.TextBox();
            this.lbltelefono = new System.Windows.Forms.Label();
            this.txttelefono = new System.Windows.Forms.TextBox();
            this.lblcorreo = new System.Windows.Forms.Label();
            this.txtcorreo = new System.Windows.Forms.TextBox();
            this.lbldireccion = new System.Windows.Forms.Label();
            this.txtdireccion = new System.Windows.Forms.TextBox();
            this.lblcategoria = new System.Windows.Forms.Label();
            this.cbcategoria = new System.Windows.Forms.ComboBox();
            this.lblestado = new System.Windows.Forms.Label();
            this.gbestado = new System.Windows.Forms.GroupBox();
            this.rbtninactivo = new System.Windows.Forms.RadioButton();
            this.rbtnactivo = new System.Windows.Forms.RadioButton();
            this.btnguardar = new System.Windows.Forms.Button();
            this.btncancelar = new System.Windows.Forms.Button();
            this.gbestado.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbltitulo
            // 
            this.lbltitulo.AutoSize = true;
            this.lbltitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitulo.Location = new System.Drawing.Point(30, 20);
            this.lbltitulo.Name = "lbltitulo";
            this.lbltitulo.Size = new System.Drawing.Size(249, 29);
            this.lbltitulo.TabIndex = 0;
            this.lbltitulo.Text = "Registrar Proveedor";
            // 
            // lblidproveedor
            // 
            this.lblidproveedor.AutoSize = true;
            this.lblidproveedor.Location = new System.Drawing.Point(30, 75);
            this.lblidproveedor.Name = "lblidproveedor";
            this.lblidproveedor.Size = new System.Drawing.Size(90, 16);
            this.lblidproveedor.TabIndex = 1;
            this.lblidproveedor.Text = "ID Proveedor:";
            // 
            // txtidproveedor
            // 
            this.txtidproveedor.Location = new System.Drawing.Point(150, 72);
            this.txtidproveedor.Name = "txtidproveedor";
            this.txtidproveedor.ReadOnly = true;
            this.txtidproveedor.Size = new System.Drawing.Size(100, 22);
            this.txtidproveedor.TabIndex = 2;
            // 
            // lblnombre
            // 
            this.lblnombre.AutoSize = true;
            this.lblnombre.Location = new System.Drawing.Point(30, 110);
            this.lblnombre.Name = "lblnombre";
            this.lblnombre.Size = new System.Drawing.Size(59, 16);
            this.lblnombre.TabIndex = 3;
            this.lblnombre.Text = "Nombre:";
            // 
            // txtnombre
            // 
            this.txtnombre.Location = new System.Drawing.Point(150, 107);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(280, 22);
            this.txtnombre.TabIndex = 4;
            // 
            // lblcontacto
            // 
            this.lblcontacto.AutoSize = true;
            this.lblcontacto.Location = new System.Drawing.Point(30, 145);
            this.lblcontacto.Name = "lblcontacto";
            this.lblcontacto.Size = new System.Drawing.Size(63, 16);
            this.lblcontacto.TabIndex = 5;
            this.lblcontacto.Text = "Contacto:";
            // 
            // txtcontacto
            // 
            this.txtcontacto.Location = new System.Drawing.Point(150, 142);
            this.txtcontacto.Name = "txtcontacto";
            this.txtcontacto.Size = new System.Drawing.Size(280, 22);
            this.txtcontacto.TabIndex = 6;
            // 
            // lblrfc
            // 
            this.lblrfc.AutoSize = true;
            this.lblrfc.Location = new System.Drawing.Point(30, 180);
            this.lblrfc.Name = "lblrfc";
            this.lblrfc.Size = new System.Drawing.Size(37, 16);
            this.lblrfc.TabIndex = 7;
            this.lblrfc.Text = "RFC:";
            // 
            // txtrfc
            // 
            this.txtrfc.Location = new System.Drawing.Point(150, 177);
            this.txtrfc.Name = "txtrfc";
            this.txtrfc.Size = new System.Drawing.Size(180, 22);
            this.txtrfc.TabIndex = 8;
            // 
            // lbltelefono
            // 
            this.lbltelefono.AutoSize = true;
            this.lbltelefono.Location = new System.Drawing.Point(30, 215);
            this.lbltelefono.Name = "lbltelefono";
            this.lbltelefono.Size = new System.Drawing.Size(64, 16);
            this.lbltelefono.TabIndex = 9;
            this.lbltelefono.Text = "Teléfono:";
            // 
            // txttelefono
            // 
            this.txttelefono.Location = new System.Drawing.Point(150, 212);
            this.txttelefono.Name = "txttelefono";
            this.txttelefono.Size = new System.Drawing.Size(180, 22);
            this.txttelefono.TabIndex = 10;
            // 
            // lblcorreo
            // 
            this.lblcorreo.AutoSize = true;
            this.lblcorreo.Location = new System.Drawing.Point(30, 250);
            this.lblcorreo.Name = "lblcorreo";
            this.lblcorreo.Size = new System.Drawing.Size(51, 16);
            this.lblcorreo.TabIndex = 11;
            this.lblcorreo.Text = "Correo:";
            // 
            // txtcorreo
            // 
            this.txtcorreo.Location = new System.Drawing.Point(150, 247);
            this.txtcorreo.Name = "txtcorreo";
            this.txtcorreo.Size = new System.Drawing.Size(280, 22);
            this.txtcorreo.TabIndex = 12;
            // 
            // lbldireccion
            // 
            this.lbldireccion.AutoSize = true;
            this.lbldireccion.Location = new System.Drawing.Point(30, 285);
            this.lbldireccion.Name = "lbldireccion";
            this.lbldireccion.Size = new System.Drawing.Size(67, 16);
            this.lbldireccion.TabIndex = 13;
            this.lbldireccion.Text = "Dirección:";
            // 
            // txtdireccion
            // 
            this.txtdireccion.Location = new System.Drawing.Point(150, 282);
            this.txtdireccion.Name = "txtdireccion";
            this.txtdireccion.Size = new System.Drawing.Size(280, 22);
            this.txtdireccion.TabIndex = 14;
            // 
            // lblcategoria
            // 
            this.lblcategoria.AutoSize = true;
            this.lblcategoria.Location = new System.Drawing.Point(30, 320);
            this.lblcategoria.Name = "lblcategoria";
            this.lblcategoria.Size = new System.Drawing.Size(69, 16);
            this.lblcategoria.TabIndex = 15;
            this.lblcategoria.Text = "Categoría:";
            // 
            // cbcategoria
            // 
            this.cbcategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbcategoria.Location = new System.Drawing.Point(150, 317);
            this.cbcategoria.Name = "cbcategoria";
            this.cbcategoria.Size = new System.Drawing.Size(200, 24);
            this.cbcategoria.TabIndex = 16;
            // 
            // lblestado
            // 
            this.lblestado.Location = new System.Drawing.Point(0, 0);
            this.lblestado.Name = "lblestado";
            this.lblestado.Size = new System.Drawing.Size(100, 23);
            this.lblestado.TabIndex = 0;
            // 
            // gbestado
            // 
            this.gbestado.Controls.Add(this.rbtninactivo);
            this.gbestado.Controls.Add(this.rbtnactivo);
            this.gbestado.Location = new System.Drawing.Point(30, 355);
            this.gbestado.Name = "gbestado";
            this.gbestado.Size = new System.Drawing.Size(200, 55);
            this.gbestado.TabIndex = 17;
            this.gbestado.TabStop = false;
            this.gbestado.Text = "Estado";
            // 
            // rbtninactivo
            // 
            this.rbtninactivo.AutoSize = true;
            this.rbtninactivo.Location = new System.Drawing.Point(100, 25);
            this.rbtninactivo.Name = "rbtninactivo";
            this.rbtninactivo.Size = new System.Drawing.Size(74, 20);
            this.rbtninactivo.TabIndex = 0;
            this.rbtninactivo.Text = "Inactivo";
            // 
            // rbtnactivo
            // 
            this.rbtnactivo.AutoSize = true;
            this.rbtnactivo.Checked = true;
            this.rbtnactivo.Location = new System.Drawing.Point(15, 25);
            this.rbtnactivo.Name = "rbtnactivo";
            this.rbtnactivo.Size = new System.Drawing.Size(65, 20);
            this.rbtnactivo.TabIndex = 1;
            this.rbtnactivo.TabStop = true;
            this.rbtnactivo.Text = "Activo";
            // 
            // btnguardar
            // 
            this.btnguardar.Location = new System.Drawing.Point(270, 365);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(80, 30);
            this.btnguardar.TabIndex = 18;
            this.btnguardar.Text = "&Guardar";
            this.btnguardar.UseVisualStyleBackColor = true;
            this.btnguardar.Click += new System.EventHandler(this.btnguardar_Click);
            // 
            // btncancelar
            // 
            this.btncancelar.Location = new System.Drawing.Point(360, 365);
            this.btncancelar.Name = "btncancelar";
            this.btncancelar.Size = new System.Drawing.Size(80, 30);
            this.btncancelar.TabIndex = 19;
            this.btncancelar.Text = "&Cancelar";
            this.btncancelar.UseVisualStyleBackColor = true;
            this.btncancelar.Click += new System.EventHandler(this.btncancelar_Click);
            // 
            // FrmRegistrarProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 420);
            this.Controls.Add(this.lbltitulo);
            this.Controls.Add(this.lblidproveedor);
            this.Controls.Add(this.txtidproveedor);
            this.Controls.Add(this.lblnombre);
            this.Controls.Add(this.txtnombre);
            this.Controls.Add(this.lblcontacto);
            this.Controls.Add(this.txtcontacto);
            this.Controls.Add(this.lblrfc);
            this.Controls.Add(this.txtrfc);
            this.Controls.Add(this.lbltelefono);
            this.Controls.Add(this.txttelefono);
            this.Controls.Add(this.lblcorreo);
            this.Controls.Add(this.txtcorreo);
            this.Controls.Add(this.lbldireccion);
            this.Controls.Add(this.txtdireccion);
            this.Controls.Add(this.lblcategoria);
            this.Controls.Add(this.cbcategoria);
            this.Controls.Add(this.gbestado);
            this.Controls.Add(this.btnguardar);
            this.Controls.Add(this.btncancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmRegistrarProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Proveedor";
            this.Load += new System.EventHandler(this.FrmRegistrarProveedor_Load);
            this.gbestado.ResumeLayout(false);
            this.gbestado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label      lbltitulo;
        private System.Windows.Forms.Label      lblidproveedor;
        public  System.Windows.Forms.TextBox    txtidproveedor;
        private System.Windows.Forms.Label      lblnombre;
        public  System.Windows.Forms.TextBox    txtnombre;
        private System.Windows.Forms.Label      lblcontacto;
        public  System.Windows.Forms.TextBox    txtcontacto;
        private System.Windows.Forms.Label      lblrfc;
        public  System.Windows.Forms.TextBox    txtrfc;
        private System.Windows.Forms.Label      lbltelefono;
        public  System.Windows.Forms.TextBox    txttelefono;
        private System.Windows.Forms.Label      lblcorreo;
        public  System.Windows.Forms.TextBox    txtcorreo;
        private System.Windows.Forms.Label      lbldireccion;
        public  System.Windows.Forms.TextBox    txtdireccion;
        private System.Windows.Forms.Label      lblcategoria;
        public  System.Windows.Forms.ComboBox   cbcategoria;
        private System.Windows.Forms.Label      lblestado;
        private System.Windows.Forms.GroupBox   gbestado;
        public  System.Windows.Forms.RadioButton rbtnactivo;
        public  System.Windows.Forms.RadioButton rbtninactivo;
        private System.Windows.Forms.Button     btnguardar;
        private System.Windows.Forms.Button     btncancelar;
    }
}
