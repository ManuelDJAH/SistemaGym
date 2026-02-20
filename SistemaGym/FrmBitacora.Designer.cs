namespace CapaPresentacion
{
    partial class FrmBitacora
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvCambiosRecientes = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvIniciosSesion = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCambiosRecientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIniciosSesion)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCambiosRecientes
            // 
            this.dgvCambiosRecientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCambiosRecientes.Location = new System.Drawing.Point(18, 46);
            this.dgvCambiosRecientes.Margin = new System.Windows.Forms.Padding(2);
            this.dgvCambiosRecientes.Name = "dgvCambiosRecientes";
            this.dgvCambiosRecientes.RowHeadersWidth = 51;
            this.dgvCambiosRecientes.RowTemplate.Height = 24;
            this.dgvCambiosRecientes.Size = new System.Drawing.Size(584, 141);
            this.dgvCambiosRecientes.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bebas Neue", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(230, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cambios Recientes";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(545, 340);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(56, 19);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.Text = "&Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bebas Neue", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(238, 191);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Inicios de sesion";
            // 
            // dgvIniciosSesion
            // 
            this.dgvIniciosSesion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIniciosSesion.Location = new System.Drawing.Point(18, 218);
            this.dgvIniciosSesion.Margin = new System.Windows.Forms.Padding(2);
            this.dgvIniciosSesion.Name = "dgvIniciosSesion";
            this.dgvIniciosSesion.RowHeadersWidth = 51;
            this.dgvIniciosSesion.RowTemplate.Height = 24;
            this.dgvIniciosSesion.Size = new System.Drawing.Size(584, 118);
            this.dgvIniciosSesion.TabIndex = 4;
            // 
            // FrmBitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 368);
            this.Controls.Add(this.dgvIniciosSesion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvCambiosRecientes);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmBitacora";
            this.Text = "FrmBitacora";
            this.Load += new System.EventHandler(this.FrmBitacora_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCambiosRecientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIniciosSesion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCambiosRecientes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvIniciosSesion;
    }
}