using System;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmListadoProveedor : Form
    {
        public bool Insert = false;
        public bool Edit   = false;

        public FrmListadoProveedor()
        {
            InitializeComponent();
        }

        private void FrmListadoProveedor_Load(object sender, EventArgs e)
        {
            this.Top  = 0;
            this.Left = 0;
            Mostrar();
        }

        // ── MOSTRAR / BUSCAR ─────────────────────────────────────────
        public void Mostrar()
        {
            this.dlistado.DataSource = CNProveedor.Listar();
        }

        public void BuscarNombre()
        {
            this.dlistado.DataSource = CNProveedor.BuscarNombre(txtbuscar.Text);
        }

        public void BuscarRfc()
        {
            this.dlistado.DataSource = CNProveedor.BuscarRfc(txtbuscar.Text);
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            if (rbtnnombre.Checked)
            {
                BuscarNombre();
            }
            else if (rdbtndni.Checked)
            {
                BuscarRfc();
            }
            else
            {
                MessageBox.Show("Seleccione un criterio de búsqueda.",
                    "SistemaGym", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── NUEVO ────────────────────────────────────────────────────
        private void btnnuevo_Click(object sender, EventArgs e)
        {
            FrmRegistrarProveedor form = new FrmRegistrarProveedor();
            form.Insert = true;
            form.Show();
            form.FormClosed += (s, ev) => Mostrar(); // refresca al cerrar
        }

        // ── EDITAR ───────────────────────────────────────────────────
        private void btneditar_Click(object sender, EventArgs e)
        {
            if (dlistado.CurrentRow == null) return;

            FrmRegistrarProveedor form = new FrmRegistrarProveedor();
            form.Edit = true;

            form.txtidproveedor.Text = dlistado.CurrentRow.Cells["idproveedor"].Value.ToString();
            form.txtnombre.Text      = dlistado.CurrentRow.Cells["nombre"].Value.ToString();
            form.txtcontacto.Text    = dlistado.CurrentRow.Cells["contacto"].Value?.ToString() ?? "";
            form.txtrfc.Text         = dlistado.CurrentRow.Cells["rfc"].Value?.ToString() ?? "";
            form.txttelefono.Text    = dlistado.CurrentRow.Cells["telefono"].Value?.ToString() ?? "";
            form.txtcorreo.Text      = dlistado.CurrentRow.Cells["correo"].Value?.ToString() ?? "";
            form.txtdireccion.Text   = dlistado.CurrentRow.Cells["direccion"].Value?.ToString() ?? "";

            string estado = dlistado.CurrentRow.Cells["estado"].Value?.ToString();
            if (estado == "ACTIVO")
                form.rbtnactivo.Checked = true;
            else
                form.rbtninactivo.Checked = true;

            form.Show();
            form.FormClosed += (s, ev) => Mostrar();
            this.Hide();
        }

        // ── ELIMINAR ─────────────────────────────────────────────────
        private void btneliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion = MessageBox.Show(
                    "¿Realmente desea eliminar el(los) registro(s)?",
                    "SistemaGym",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question);

                if (dlistado.SelectedRows.Count > 0 && opcion == DialogResult.OK)
                {
                    int idproveedor = Convert.ToInt32(
                        dlistado.CurrentRow.Cells["idproveedor"].Value);

                    CNProveedor.Eliminar(idproveedor);

                    MessageBox.Show("Registro eliminado.",
                        "SistemaGym", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }

        // ── SALIR ────────────────────────────────────────────────────
        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
