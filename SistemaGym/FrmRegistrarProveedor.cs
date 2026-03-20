using System;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmRegistrarProveedor : Form
    {
        public bool Insert = false;
        public bool Edit   = false;

        public FrmRegistrarProveedor()
        {
            InitializeComponent();
        }

        private void FrmRegistrarProveedor_Load(object sender, EventArgs e)
        {
            CargarCategorias();
        }

        private void CargarCategorias()
        {
            cbcategoria.DataSource    = CNProveedor.ListarCategorias();
            cbcategoria.DisplayMember = "nombre";
            cbcategoria.ValueMember   = "idcategoria";
        }

        // ── GUARDAR (Insert o Edit) ──────────────────────────────────
        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validación básica
                if (string.IsNullOrWhiteSpace(txtnombre.Text))
                {
                    MessageBox.Show("El nombre es obligatorio.",
                        "SistemaGym", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string estado = rbtnactivo.Checked ? "ACTIVO" : "INACTIVO";
                int    idCat  = Convert.ToInt32(cbcategoria.SelectedValue);
                string msg;

                if (Insert)
                {
                    msg = CNProveedor.Insertar(
                        txtnombre.Text.Trim(),
                        txtcontacto.Text.Trim(),
                        txtrfc.Text.Trim(),
                        txttelefono.Text.Trim(),
                        txtcorreo.Text.Trim(),
                        txtdireccion.Text.Trim(),
                        estado,
                        idCat
                    );
                }
                else // Edit
                {
                    msg = CNProveedor.Actualizar(
                        Convert.ToInt32(txtidproveedor.Text),
                        txtnombre.Text.Trim(),
                        txtcontacto.Text.Trim(),
                        txtrfc.Text.Trim(),
                        txttelefono.Text.Trim(),
                        txtcorreo.Text.Trim(),
                        txtdireccion.Text.Trim(),
                        estado,
                        idCat
                    );
                }

                MessageBox.Show(msg, "SistemaGym",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SistemaGym",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── CANCELAR ─────────────────────────────────────────────────
        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
