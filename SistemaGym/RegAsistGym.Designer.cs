namespace CapaPresentacion
{
    partial class RegAsistGym
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtIdUsuario = new System.Windows.Forms.TextBox();
            this.btnRegistrarAsistencia = new System.Windows.Forms.Button();
            this.txtRegistrarAsistenciaGym = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtIdUsuario
            // 
            this.txtIdUsuario.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.txtIdUsuario.Location = new System.Drawing.Point(330, 226);
            this.txtIdUsuario.Name = "txtIdUsuario";
            this.txtIdUsuario.Size = new System.Drawing.Size(184, 20);
            this.txtIdUsuario.TabIndex = 0;
            this.txtIdUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnRegistrarAsistencia
            // 
            this.btnRegistrarAsistencia.Location = new System.Drawing.Point(364, 254);
            this.btnRegistrarAsistencia.Name = "btnRegistrarAsistencia";
            this.btnRegistrarAsistencia.Size = new System.Drawing.Size(118, 26);
            this.btnRegistrarAsistencia.TabIndex = 1;
            this.btnRegistrarAsistencia.Text = "&Registrar asistencia";
            this.btnRegistrarAsistencia.UseVisualStyleBackColor = true;
            this.btnRegistrarAsistencia.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // txtRegistrarAsistenciaGym
            // 
            this.txtRegistrarAsistenciaGym.AutoSize = true;
            this.txtRegistrarAsistenciaGym.Font = new System.Drawing.Font("Bebas Neue", 23.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegistrarAsistenciaGym.Location = new System.Drawing.Point(272, 165);
            this.txtRegistrarAsistenciaGym.Name = "txtRegistrarAsistenciaGym";
            this.txtRegistrarAsistenciaGym.Size = new System.Drawing.Size(302, 40);
            this.txtRegistrarAsistenciaGym.TabIndex = 2;
            this.txtRegistrarAsistenciaGym.Text = "Registrar Asistencia Gym";
            this.txtRegistrarAsistenciaGym.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(364, 367);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(118, 26);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.Text = "&Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // RegAsistGym
            // 
            this.ClientSize = new System.Drawing.Size(850, 500);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.txtRegistrarAsistenciaGym);
            this.Controls.Add(this.btnRegistrarAsistencia);
            this.Controls.Add(this.txtIdUsuario);
            this.Name = "RegAsistGym";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Asistencia Gym";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIdUsuario;
        private System.Windows.Forms.Button btnRegistrarAsistencia;
        private System.Windows.Forms.Label txtRegistrarAsistenciaGym;
        private System.Windows.Forms.Button btnCerrar;
    }
}

