using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ClaseNegocio;

namespace CapaPresentacion
{
    public partial class RegUsuarios : Form
    {
        int idUsuario = 0;

        public RegUsuarios()
        {
            InitializeComponent();
        }

        private void RegUsuarios_Load(object sender, EventArgs e)
        {
            CargarMembresias();
            CargarUsuarios();
            ConfigurarGrid();
        }

        // ── CONFIGURAR GRID ──────────────────────────────────────────
        private void ConfigurarGrid()
        {
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.RowHeadersVisible = false;

            // Columnas visibles y encabezados
            string[] ocultas = { "id_membresia", "duracion_meses" };
            foreach (string col in ocultas)
                if (dgvUsuarios.Columns[col] != null)
                    dgvUsuarios.Columns[col].Visible = false;

            RenombrarCol("id_usuario", "ID");
            RenombrarCol("nombre", "Nombre");
            RenombrarCol("edad", "Edad");
            RenombrarCol("correo", "Correo");
            RenombrarCol("telefono", "Teléfono");
            RenombrarCol("nombre_membresia", "Membresía");
            RenombrarCol("fecha_registro", "Registro");
            RenombrarCol("fecha_vencimiento", "Vencimiento");
            RenombrarCol("estado_membresia", "Estado");

            // Ancho fijo para columnas cortas
            SetColWidth("ID", 50);
            SetColWidth("Edad", 50);
            SetColWidth("Membresía", 90);
            SetColWidth("Registro", 90);
            SetColWidth("Vencimiento", 90);
            SetColWidth("Estado", 80);
        }

        private void RenombrarCol(string name, string header)
        {
            if (dgvUsuarios.Columns[name] != null)
                dgvUsuarios.Columns[name].HeaderText = header;
        }

        private void SetColWidth(string header, int width)
        {
            foreach (DataGridViewColumn col in dgvUsuarios.Columns)
                if (col.HeaderText == header)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    col.Width = width;
                }
        }

        // ── CARGAR DATOS ─────────────────────────────────────────────
        private void CargarUsuarios()
        {
            UsuariosBL bl = new UsuariosBL();
            dgvUsuarios.DataSource = bl.ListarUsuarios();
            ColorearFilas();
        }

        private void CargarMembresias()
        {
            UsuariosBL bl = new UsuariosBL();
            cbMembresias.DataSource = bl.ListarMembresias();
            cbMembresias.DisplayMember = "nombre_membresia";
            cbMembresias.ValueMember = "id_membresia";
            cbMembresias.SelectedIndex = -1;
        }

        // ── COLOREAR FILAS POR ESTADO ────────────────────────────────
        private void ColorearFilas()
        {
            foreach (DataGridViewRow fila in dgvUsuarios.Rows)
            {
                if (fila.IsNewRow) continue;
                string estado = fila.Cells["estado_membresia"]?.Value?.ToString() ?? "";
                if (estado == "VENCIDA")
                {
                    fila.DefaultCellStyle.BackColor = Color.FromArgb(255, 220, 220); // rojo suave
                    fila.DefaultCellStyle.ForeColor = Color.FromArgb(180, 0, 0);
                }
                else
                {
                    fila.DefaultCellStyle.BackColor = Color.White;
                    fila.DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }

        // ── SELECCIONAR FILA ─────────────────────────────────────────
        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dgvUsuarios.Rows[e.RowIndex];

            idUsuario = Convert.ToInt32(fila.Cells["id_usuario"].Value);
            txtNombre.Text = fila.Cells["nombre"].Value?.ToString() ?? "";
            txtEdad.Text = fila.Cells["edad"].Value?.ToString() ?? "";
            txtCorreo.Text = fila.Cells["correo"].Value?.ToString() ?? "";
            txtTelefono.Text = fila.Cells["telefono"].Value?.ToString() ?? "";
            cbMembresias.SelectedValue = fila.Cells["id_membresia"].Value;

            // Activar botones de acción
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            btnRenovar.Enabled = true;
        }

        // ── REGISTRAR ────────────────────────────────────────────────
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            UsuariosBL bl = new UsuariosBL();
            string mensaje = bl.RegistrarUsuario(
                txtNombre.Text.Trim(),
                int.Parse(txtEdad.Text),
                txtCorreo.Text.Trim(),
                txtTelefono.Text.Trim(),
                DateTime.Today,
                Convert.ToInt32(cbMembresias.SelectedValue)
            );

            MessageBox.Show(mensaje, "SistemaGym",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            Limpiar();
            CargarUsuarios();
        }

        // ── EDITAR ───────────────────────────────────────────────────
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idUsuario == 0) { MessageBox.Show("Seleccione un usuario."); return; }
            if (!ValidarCampos()) return;

            UsuariosBL bl = new UsuariosBL();
            string mensaje = bl.ActualizarUsuario(
                idUsuario,
                txtNombre.Text.Trim(),
                int.Parse(txtEdad.Text),
                txtCorreo.Text.Trim(),
                txtTelefono.Text.Trim(),
                Convert.ToInt32(cbMembresias.SelectedValue)
            );

            MessageBox.Show(mensaje, "SistemaGym",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            Limpiar();
            CargarUsuarios();
        }

        // ── RENOVAR ──────────────────────────────────────────────────
        private void btnRenovar_Click(object sender, EventArgs e)
        {
            if (idUsuario == 0) { MessageBox.Show("Seleccione un usuario."); return; }

            string nombre = txtNombre.Text;
            int idMem = Convert.ToInt32(cbMembresias.SelectedValue);

            DialogResult r = MessageBox.Show(
                $"¿Renovar membresía de \"{nombre}\" desde hoy?",
                "Renovar Membresía",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (r == DialogResult.Yes)
            {
                UsuariosBL bl = new UsuariosBL();
                string msg = bl.RenovarMembresia(idUsuario, idMem);
                MessageBox.Show(msg, "SistemaGym",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
                CargarUsuarios();
            }
        }

        // ── ELIMINAR ─────────────────────────────────────────────────
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idUsuario == 0) { MessageBox.Show("Seleccione un usuario."); return; }

            DialogResult r = MessageBox.Show(
                "¿Está seguro de eliminar este usuario?",
                "SistemaGym",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (r == DialogResult.Yes)
            {
                UsuariosBL bl = new UsuariosBL();
                MessageBox.Show(bl.EliminarUsuario(idUsuario), "SistemaGym",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
                CargarUsuarios();
            }
        }

        // ── LIMPIAR ──────────────────────────────────────────────────
        private void Limpiar()
        {
            idUsuario = 0;
            txtNombre.Clear();
            txtEdad.Clear();
            txtCorreo.Clear();
            txtTelefono.Clear();
            cbMembresias.SelectedIndex = -1;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnRenovar.Enabled = false;
        }

        // ── VALIDAR CAMPOS ───────────────────────────────────────────
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            { MessageBox.Show("El nombre es obligatorio."); return false; }

            if (!int.TryParse(txtEdad.Text, out int edad) || edad <= 0 || edad > 120)
            { MessageBox.Show("Ingresa una edad válida (1-120)."); return false; }

            if (cbMembresias.SelectedValue == null)
            { MessageBox.Show("Selecciona una membresía."); return false; }

            return true;
        }

        private void btnCerrar_Click(object sender, EventArgs e) => this.Close();
    }
}