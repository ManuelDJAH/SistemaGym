namespace CapaPresentacion
{
    partial class FrmAdmin
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
            this.tabCambios = new System.Windows.Forms.TabPage();
            this.tabSesiones = new System.Windows.Forms.TabPage();
            this.tabRespaldo = new System.Windows.Forms.TabPage();
            this.dgvCambios = new System.Windows.Forms.DataGridView();
            this.dgvSesiones = new System.Windows.Forms.DataGridView();
            this.btnRefrescarBitacora = new System.Windows.Forms.Button();
            // Respaldo
            this.pnlRespaldo = new System.Windows.Forms.Panel();
            this.lblTituloRespaldo = new System.Windows.Forms.Label();
            this.lblInfoRespaldo = new System.Windows.Forms.Label();
            this.lblRutaLabel = new System.Windows.Forms.Label();
            this.txtRutaRespaldo = new System.Windows.Forms.TextBox();
            this.btnSeleccionarCarpeta = new System.Windows.Forms.Button();
            this.btnGenerarRespaldo = new System.Windows.Forms.Button();
            this.lblEstadoRespaldo = new System.Windows.Forms.Label();
            // Botón cerrar
            this.btnCerrar = new System.Windows.Forms.Button();

            this.tabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvCambios).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.dgvSesiones).BeginInit();
            this.SuspendLayout();

            // ── FORM ─────────────────────────────────────────────────
            this.Text = "Panel de Administracion";
            this.Size = new System.Drawing.Size(860, 520);
            this.MinimumSize = new System.Drawing.Size(800, 480);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Load += new System.EventHandler(this.FrmAdmin_Load);

            // ── TAB CONTROL ──────────────────────────────────────────
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.tabControl.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.tabCambios, this.tabSesiones, this.tabRespaldo });

            this.tabCambios.Text = "Cambios Recientes";
            this.tabCambios.UseVisualStyleBackColor = true;
            this.tabSesiones.Text = "Inicios de Sesion";
            this.tabSesiones.UseVisualStyleBackColor = true;
            this.tabRespaldo.Text = "Respaldo BD";
            this.tabRespaldo.UseVisualStyleBackColor = true;

            // ── DGV CAMBIOS ──────────────────────────────────────────
            this.btnRefrescarBitacora.Text = "Refrescar";
            this.btnRefrescarBitacora.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnRefrescarBitacora.Height = 30;
            this.btnRefrescarBitacora.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefrescarBitacora.Click += new System.EventHandler(this.btnRefrescarBitacora_Click);

            this.dgvCambios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCambios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCambios.ReadOnly = true;
            this.dgvCambios.AllowUserToAddRows = false;
            this.dgvCambios.BackgroundColor = System.Drawing.Color.White;
            this.dgvCambios.RowHeadersVisible = false;
            this.dgvCambios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.tabCambios.Controls.Add(this.dgvCambios);
            this.tabCambios.Controls.Add(this.btnRefrescarBitacora);

            // ── DGV SESIONES ─────────────────────────────────────────
            this.dgvSesiones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSesiones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSesiones.ReadOnly = true;
            this.dgvSesiones.AllowUserToAddRows = false;
            this.dgvSesiones.BackgroundColor = System.Drawing.Color.White;
            this.dgvSesiones.RowHeadersVisible = false;
            this.dgvSesiones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.tabSesiones.Controls.Add(this.dgvSesiones);

            // ── TAB RESPALDO ─────────────────────────────────────────
            this.pnlRespaldo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRespaldo.Padding = new System.Windows.Forms.Padding(30, 20, 30, 20);

            int ry = 20;

            this.lblTituloRespaldo.Text = "Respaldo de Base de Datos";
            this.lblTituloRespaldo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTituloRespaldo.Location = new System.Drawing.Point(30, ry);
            this.lblTituloRespaldo.AutoSize = true;
            ry += 40;

            this.lblInfoRespaldo.Text =
                "Genera un respaldo completo de GymDB en formato .bak compatible con SQL Server.\r\n" +
                "Se recomienda realizar respaldos periodicamente para evitar perdida de datos.";
            this.lblInfoRespaldo.Location = new System.Drawing.Point(30, ry);
            this.lblInfoRespaldo.Size = new System.Drawing.Size(700, 40);
            this.lblInfoRespaldo.ForeColor = System.Drawing.Color.DimGray;
            ry += 60;

            this.lblRutaLabel.Text = "Carpeta destino:";
            this.lblRutaLabel.Location = new System.Drawing.Point(30, ry);
            this.lblRutaLabel.AutoSize = true;
            ry += 22;

            this.txtRutaRespaldo.Location = new System.Drawing.Point(30, ry);
            this.txtRutaRespaldo.Size = new System.Drawing.Size(520, 23);
            this.txtRutaRespaldo.ReadOnly = true;
            this.txtRutaRespaldo.BackColor = System.Drawing.Color.WhiteSmoke;

            this.btnSeleccionarCarpeta.Text = "Seleccionar...";
            this.btnSeleccionarCarpeta.Location = new System.Drawing.Point(558, ry - 1);
            this.btnSeleccionarCarpeta.Size = new System.Drawing.Size(110, 26);
            this.btnSeleccionarCarpeta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionarCarpeta.Click += new System.EventHandler(this.btnSeleccionarCarpeta_Click);
            ry += 50;

            this.btnGenerarRespaldo.Text = "Generar Respaldo .bak";
            this.btnGenerarRespaldo.Location = new System.Drawing.Point(30, ry);
            this.btnGenerarRespaldo.Size = new System.Drawing.Size(200, 38);
            this.btnGenerarRespaldo.BackColor = System.Drawing.Color.SteelBlue;
            this.btnGenerarRespaldo.ForeColor = System.Drawing.Color.White;
            this.btnGenerarRespaldo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarRespaldo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGenerarRespaldo.Click += new System.EventHandler(this.btnGenerarRespaldo_Click);
            ry += 55;

            this.lblEstadoRespaldo.Text = "";
            this.lblEstadoRespaldo.Location = new System.Drawing.Point(30, ry);
            this.lblEstadoRespaldo.Size = new System.Drawing.Size(640, 22);
            this.lblEstadoRespaldo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            this.pnlRespaldo.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTituloRespaldo, this.lblInfoRespaldo,
                this.lblRutaLabel, this.txtRutaRespaldo, this.btnSeleccionarCarpeta,
                this.btnGenerarRespaldo, this.lblEstadoRespaldo });

            this.tabRespaldo.Controls.Add(this.pnlRespaldo);

            // ── BOTÓN CERRAR ─────────────────────────────────────────
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCerrar.Height = 32;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnCerrar);

            ((System.ComponentModel.ISupportInitialize)this.dgvCambios).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.dgvSesiones).EndInit();
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabCambios, tabSesiones, tabRespaldo;
        private System.Windows.Forms.DataGridView dgvCambios, dgvSesiones;
        private System.Windows.Forms.Button btnRefrescarBitacora;
        private System.Windows.Forms.Panel pnlRespaldo;
        private System.Windows.Forms.Label lblTituloRespaldo, lblInfoRespaldo,
                                                   lblRutaLabel, lblEstadoRespaldo;
        private System.Windows.Forms.TextBox txtRutaRespaldo;
        private System.Windows.Forms.Button btnSeleccionarCarpeta, btnGenerarRespaldo, btnCerrar;
    }
}