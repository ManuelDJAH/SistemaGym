using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using ClaseNegocio;

namespace CapaPresentacion
{
    /// <summary>
    /// Panel de administración — solo accesible con rol ADMIN.
    /// Tabs: Bitácora (cambios + sesiones) | Respaldo BD
    /// </summary>
    public partial class FrmAdmin : Form
    {
        private readonly RespaldoBL _respaldoBL = new RespaldoBL();

        public FrmAdmin()
        {
            InitializeComponent();
        }

        private void FrmAdmin_Load(object sender, EventArgs e)
        {
            // Cargar bitácora al abrir (reutiliza la lógica existente de FrmBitacora)
            CargarBitacora();
        }

        // ════════════════════════════════════════════════════════════
        //  TAB BITÁCORA  (misma lógica que FrmBitacora)
        // ════════════════════════════════════════════════════════════
        private void CargarBitacora()
        {
            try
            {
                BitacoraBL bl = new BitacoraBL();
                var dt = bl.MostrarBitacora();
                dgvCambios.DataSource = dt;
                dgvSesiones.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar bitácora: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefrescarBitacora_Click(object sender, EventArgs e)
        {
            CargarBitacora();
        }

        // ════════════════════════════════════════════════════════════
        //  TAB RESPALDO
        // ════════════════════════════════════════════════════════════
        private void btnSeleccionarCarpeta_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                dlg.Description = "Selecciona la carpeta donde se guardará el respaldo";
                dlg.ShowNewFolderButton = true;

                if (dlg.ShowDialog() == DialogResult.OK)
                    txtRutaRespaldo.Text = dlg.SelectedPath;
            }
        }

        private void btnGenerarRespaldo_Click(object sender, EventArgs e)
        {
            string carpeta = txtRutaRespaldo.Text.Trim();

            if (string.IsNullOrEmpty(carpeta))
            {
                MessageBox.Show("Selecciona una carpeta destino primero.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"Se generará un respaldo completo de GymDB en:\n\n{carpeta}\n\n¿Continuar?",
                "Confirmar respaldo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            // Deshabilitar botón y mostrar progreso
            btnGenerarRespaldo.Enabled = false;
            lblEstadoRespaldo.Text = "Generando respaldo... por favor espera.";
            lblEstadoRespaldo.ForeColor = System.Drawing.Color.DarkOrange;
            Application.DoEvents();

            var (ok, mensaje, rutaFinal) = _respaldoBL.GenerarRespaldo(carpeta);

            btnGenerarRespaldo.Enabled = true;

            if (ok)
            {
                lblEstadoRespaldo.Text = $"Respaldo completado: {Path.GetFileName(rutaFinal)}";
                lblEstadoRespaldo.ForeColor = System.Drawing.Color.SeaGreen;

                var verArchivo = MessageBox.Show(
                    $"Respaldo generado exitosamente.\n\nArchivo: {rutaFinal}\n\n¿Abrir carpeta destino?",
                    "Exito",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

                if (verArchivo == DialogResult.Yes)
                    Process.Start("explorer.exe", carpeta);
            }
            else
            {
                lblEstadoRespaldo.Text = "Error al generar respaldo.";
                lblEstadoRespaldo.ForeColor = System.Drawing.Color.Firebrick;

                MessageBox.Show(mensaje, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e) => this.Close();
    }
}