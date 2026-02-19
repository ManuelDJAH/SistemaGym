using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            UsuariosBL bl = new UsuariosBL();

            string mensaje = bl.RegistrarUsuario(
                txtNombre.Text,
                int.Parse(txtEdad.Text),
                txtCorreo.Text,
                txtTelefono.Text,
                DateTime.Now,
                Convert.ToInt32(cbMembresias.SelectedValue)
            );

            MessageBox.Show(mensaje);
            Limpiar();
            CargarUsuarios();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idUsuario == 0)
            {
                MessageBox.Show("Seleccione un usuario para editar");
                return;
            }

            UsuariosBL bl = new UsuariosBL();

            string mensaje = bl.ActualizarUsuario(
                idUsuario,
                txtNombre.Text,
                int.Parse(txtEdad.Text),
                txtCorreo.Text,
                txtTelefono.Text,
                Convert.ToInt32(cbMembresias.SelectedValue)
            );

            MessageBox.Show(mensaje);
            Limpiar();
            CargarUsuarios();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idUsuario == 0)
            {
                MessageBox.Show("Seleccione un usuario para eliminar");
                return;
            }

            DialogResult r = MessageBox.Show(
                "¿Está seguro de eliminar este usuario?",
                "SistemaGym",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (r == DialogResult.Yes)
            {
                UsuariosBL bl = new UsuariosBL();
                MessageBox.Show(bl.EliminarUsuario(idUsuario));
                Limpiar();
                CargarUsuarios();
            }
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvUsuarios.Rows[e.RowIndex];

                idUsuario = Convert.ToInt32(fila.Cells["id_usuario"].Value);
                txtNombre.Text = fila.Cells["nombre"].Value.ToString();
                txtEdad.Text = fila.Cells["edad"].Value.ToString();
                txtCorreo.Text = fila.Cells["correo"].Value.ToString();
                txtTelefono.Text = fila.Cells["telefono"].Value.ToString();
                cbMembresias.SelectedValue = fila.Cells["id_membresia"].Value;
            }
        }

        private void CargarUsuarios()
        {
            UsuariosBL bl = new UsuariosBL();
            dgvUsuarios.DataSource = bl.ListarUsuarios();
        }

        private void CargarMembresias()
        {
            MembresiaBL bl = new MembresiaBL();
            cbMembresias.DataSource = bl.ListarMembresias();
            cbMembresias.DisplayMember = "descripcion";
            cbMembresias.ValueMember = "id_membresia";
        }

        private void Limpiar()
        {
            idUsuario = 0;
            txtNombre.Clear();
            txtEdad.Clear();
            txtCorreo.Clear();
            txtTelefono.Clear();
            cbMembresias.SelectedIndex = -1;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}