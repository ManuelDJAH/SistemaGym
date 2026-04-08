using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using ClaseNegocio;

namespace CapaPresentacion
{
    public partial class FrmAdmin : Form
    {
        private readonly RespaldoBL _respaldoBL = new RespaldoBL();

        // ── A) CAMPOS PRIVADOS USUARIOS ──
        private readonly ClaseNegocio.UsuarioSistemaBL _usBL = new ClaseNegocio.UsuarioSistemaBL();
        private int _usIDSeleccionado = 0;
        private bool _usModoEdicion = false;

        public FrmAdmin()
        {
            InitializeComponent();
            // Suscribir el evento de cambio de pestaña si no está en el Designer
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
        }

        private void FrmAdmin_Load(object sender, EventArgs e)
        {
            CargarBitacora();
        }

        // ── B) EVENTO SELECCIÓN DE TAB ──
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl.SelectedIndex)
            {
                case 0: // Cambios Recientes
                case 1: // Inicios de Sesión
                    CargarBitacora();
                    break;
                case 3: // Usuarios Sistema (4ta pestaña)
                    CargarUsuariosSistema();
                    break;
            }
        }

        // ════════════════════════════════════════════════════════════
        //  TAB BITÁCORA
        // ════════════════════════════════════════════════════════════
        private void CargarBitacora()
        {
            try
            {
                BitacoraBL bl = new BitacoraBL();
                dgvCambios.DataSource = bl.ObtenerCambios();
                dgvSesiones.DataSource = bl.ObtenerSesiones();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar bitacora: " + ex.Message,
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
                dlg.Description = "Selecciona la carpeta donde se guardara el respaldo";
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
                $"Se generara un respaldo completo de GymDB en:\n\n{carpeta}\n\n¿Continuar?",
                "Confirmar respaldo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

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
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e) => this.Close();

        // ════════════════════════════════════════════════════════════
        //  C) MÉTODOS USUARIOS DEL SISTEMA
        // ════════════════════════════════════════════════════════════

        private void CargarUsuariosSistema()
        {
            dgvUsuariosSistema.DataSource = null;
            dgvUsuariosSistema.DataSource = _usBL.Listar();

            foreach (DataGridViewColumn col in dgvUsuariosSistema.Columns)
                col.Visible = false;

            void Mostrar(string name, string header, int w)
            {
                if (dgvUsuariosSistema.Columns[name] == null) return;
                dgvUsuariosSistema.Columns[name].Visible = true;
                dgvUsuariosSistema.Columns[name].HeaderText = header;
                dgvUsuariosSistema.Columns[name].FillWeight = w;
            }

            Mostrar("id_usuario", "ID", 30);
            Mostrar("usuario", "Usuario", 120);
            Mostrar("nombre", "Nombre", 200);
            Mostrar("rol", "Rol", 80);

            USModoLectura();
        }

        private void dgvUsuariosSistema_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsuariosSistema.CurrentRow == null) return;
            var row = dgvUsuariosSistema.CurrentRow;

            _usIDSeleccionado = Convert.ToInt32(row.Cells["id_usuario"].Value);
            txtUSNombre.Text = row.Cells["nombre"].Value?.ToString() ?? "";
            txtUSUsuario.Text = row.Cells["usuario"].Value?.ToString() ?? "";
            txtUSClave.Clear();
            cboUSRol.Text = row.Cells["rol"].Value?.ToString() ?? "USUARIO";

            btnUSEditar.Enabled = true;
            btnUSEliminar.Enabled = true;
            USModoLectura();
        }

        private void btnUSNuevo_Click(object sender, EventArgs e)
        {
            _usIDSeleccionado = 0;
            _usModoEdicion = false;
            LimpiarFormUS();
            USModoCaptura();
            txtUSUsuario.ReadOnly = false;
        }

        private void btnUSEditar_Click(object sender, EventArgs e)
        {
            if (_usIDSeleccionado == 0) return;
            _usModoEdicion = true;
            USModoCaptura();
            txtUSUsuario.ReadOnly = true;
        }

        private void btnUSGuardar_Click(object sender, EventArgs e)
        {
            bool ok; string msg;

            if (_usModoEdicion)
            {
                string nuevaClave = string.IsNullOrWhiteSpace(txtUSClave.Text) ? null : txtUSClave.Text;
                (ok, msg) = _usBL.Actualizar(_usIDSeleccionado, txtUSNombre.Text, cboUSRol.Text, nuevaClave);
            }
            else
            {
                (ok, msg) = _usBL.Crear(txtUSUsuario.Text, txtUSClave.Text, txtUSNombre.Text, cboUSRol.Text);
            }

            MessageBox.Show(msg, ok ? "Exito" : "Error", MessageBoxButtons.OK,
                ok ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            if (ok) { CargarUsuariosSistema(); LimpiarFormUS(); }
        }

        private void btnUSEliminar_Click(object sender, EventArgs e)
        {
            if (_usIDSeleccionado == 0) return;

            var confirm = MessageBox.Show("Eliminar este usuario del sistema?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            var (ok, msg) = _usBL.Eliminar(_usIDSeleccionado);
            MessageBox.Show(msg, ok ? "Exito" : "Error", MessageBoxButtons.OK,
                ok ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            if (ok) CargarUsuariosSistema();
        }

        private void btnUSCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormUS();
            USModoLectura();
        }

        private void USModoCaptura()
        {
            txtUSNombre.ReadOnly = false;
            txtUSClave.ReadOnly = false;
            cboUSRol.Enabled = true;
            btnUSGuardar.Enabled = true;
            btnUSCancelar.Enabled = true;
            btnUSNuevo.Enabled = false;
            btnUSEditar.Enabled = false;
            btnUSEliminar.Enabled = false;
        }

        private void USModoLectura()
        {
            txtUSNombre.ReadOnly = true;
            txtUSUsuario.ReadOnly = true;
            txtUSClave.ReadOnly = true;
            cboUSRol.Enabled = false;
            btnUSGuardar.Enabled = false;
            btnUSCancelar.Enabled = false;
            btnUSNuevo.Enabled = true;
        }

        private void LimpiarFormUS()
        {
            _usIDSeleccionado = 0;
            txtUSNombre.Clear();
            txtUSUsuario.Clear();
            txtUSClave.Clear();
            cboUSRol.SelectedIndex = 1;
        }
    }
}