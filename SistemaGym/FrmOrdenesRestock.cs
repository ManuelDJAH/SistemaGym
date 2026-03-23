using System;
using System.Drawing;
using System.Windows.Forms;
using ClaseNegocio;
using CapaDatos;

namespace CapaPresentacion
{
    public partial class FrmOrdenesRestock : Form
    {
        private readonly RestockBL _bl = new RestockBL();
        private int _idOrdenSeleccionada = 0;

        public FrmOrdenesRestock()
        {
            InitializeComponent();
        }

        private void FrmOrdenesRestock_Load(object sender, EventArgs e)
        {
            this.Top  = 0;
            this.Left = 0;
            CargarOrdenes();
        }

        // ── CARGAR GRILLA ────────────────────────────────────────────
        private void CargarOrdenes(string filtro = null)
        {
            var lista = _bl.ListarOrdenes(filtro);
            dgvOrdenes.DataSource = null;
            dgvOrdenes.DataSource = lista;

            foreach (DataGridViewColumn col in dgvOrdenes.Columns)
                col.Visible = false;

            MostrarCol("IdOrden",         "# Orden",    50);
            MostrarCol("FechaGenerada",   "Fecha",      120);
            MostrarCol("Producto",        "Producto",   180);
            MostrarCol("StockActual",     "Stock Act.", 80);
            MostrarCol("StockMinimo",     "Mínimo",     65);
            MostrarCol("CantidadSolicit", "A Pedir",    65);
            MostrarCol("Proveedor",       "Proveedor",  160);
            MostrarCol("TelProveedor",    "Teléfono",   110);
            MostrarCol("Estado",          "Estado",     90);

            foreach (DataGridViewRow row in dgvOrdenes.Rows)
            {
                string estado = row.Cells["Estado"].Value?.ToString();
                switch (estado)
                {
                    case "PENDIENTE":  row.DefaultCellStyle.BackColor = Color.FromArgb(255, 245, 190); break;
                    case "ENVIADA":    row.DefaultCellStyle.BackColor = Color.FromArgb(190, 220, 255); break;
                    case "RECIBIDA":   row.DefaultCellStyle.BackColor = Color.FromArgb(200, 255, 200); break;
                    case "CANCELADA":  row.DefaultCellStyle.BackColor = Color.FromArgb(220, 220, 220); break;
                }
            }

            ActualizarBotones();
        }

        // ── SELECCIÓN EN GRILLA ──────────────────────────────────────
        private void dgvOrdenes_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvOrdenes.Rows[e.RowIndex].DataBoundItem is OrdenRestock o)
            {
                _idOrdenSeleccionada = o.IdOrden;
                lblDetalleProveedor.Text =
                    $"Proveedor: {o.Proveedor}     " +
                    $"Contacto: {o.ContactoProveedor}     " +
                    $"Teléfono: {o.TelProveedor}     " +
                    $"Correo: {o.CorreoProveedor}";
                ActualizarBotones();
            }
        }

        // ── FILTRO ───────────────────────────────────────────────────
        private void cboFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sel = cboFiltro.SelectedItem?.ToString();
            CargarOrdenes(sel == "TODAS" ? null : sel);
        }

        // ── BOTONES ──────────────────────────────────────────────────
        private void btnEnviada_Click(object sender, EventArgs e)
        {
            if (_idOrdenSeleccionada == 0) return;

            // Obtener la orden seleccionada para mostrar cantidad actual
            var orden = dgvOrdenes.CurrentRow?.DataBoundItem as OrdenRestock;
            if (orden == null) return;

            // ── Diálogo para confirmar/editar cantidad ───────────────
            Form dlg = new Form
            {
                Text            = "Confirmar Orden de Restock",
                Size            = new Size(380, 230),
                StartPosition   = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox     = false,
                MinimizeBox     = false
            };

            Label lblProd    = new Label  { Text = $"Producto:  {orden.Producto}",         Location = new Point(12, 15),  AutoSize = true };
            Label lblProv    = new Label  { Text = $"Proveedor: {orden.Proveedor}",         Location = new Point(12, 38),  AutoSize = true };
            Label lblTel     = new Label  { Text = $"Teléfono:  {orden.TelProveedor}",      Location = new Point(12, 61),  AutoSize = true };
            Label lblStock   = new Label  { Text = $"Stock actual: {orden.StockActual}  (mínimo: {orden.StockMinimo})", Location = new Point(12, 84), AutoSize = true };
            Label lblCant    = new Label  { Text = "Cantidad a pedir:",                     Location = new Point(12, 115), AutoSize = true };
            NumericUpDown num = new NumericUpDown
            {
                Location = new Point(145, 112),
                Width    = 80,
                Minimum  = 1,
                Maximum  = 9999,
                Value    = orden.CantidadSolicit
            };
            Button btnOk     = new Button { Text = "✅ Confirmar Envío", DialogResult = DialogResult.OK,     Location = new Point(12,  155), Width = 140 };
            Button btnCancel = new Button { Text = "Cancelar",           DialogResult = DialogResult.Cancel, Location = new Point(162, 155), Width = 80  };

            dlg.Controls.AddRange(new Control[] { lblProd, lblProv, lblTel, lblStock, lblCant, num, btnOk, btnCancel });
            dlg.AcceptButton = btnOk;
            dlg.CancelButton = btnCancel;

            if (dlg.ShowDialog() != DialogResult.OK) return;

            // Actualizar cantidad si cambió
            int nuevaCantidad = (int)num.Value;
            if (nuevaCantidad != orden.CantidadSolicit)
                _bl.ActualizarCantidad(_idOrdenSeleccionada, nuevaCantidad);

            var (ok, msg) = _bl.MarcarEnviada(_idOrdenSeleccionada);
            MessageBox.Show(msg, "SistemaGym", MessageBoxButtons.OK,
                ok ? MessageBoxIcon.Information : MessageBoxIcon.Error);
            if (ok) CargarOrdenes();
        }

        private void btnRecibida_Click(object sender, EventArgs e)
        {
            if (_idOrdenSeleccionada == 0) return;
            var (ok, msg) = _bl.MarcarRecibida(_idOrdenSeleccionada);
            MessageBox.Show(msg, "SistemaGym", MessageBoxButtons.OK,
                ok ? MessageBoxIcon.Information : MessageBoxIcon.Error);
            if (ok) CargarOrdenes();
        }

        private void btnCancelarOrden_Click(object sender, EventArgs e)
        {
            if (_idOrdenSeleccionada == 0) return;

            Form dlg = new Form
            {
                Text            = "Cancelar orden",
                Size            = new Size(380, 160),
                StartPosition   = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox     = false,
                MinimizeBox     = false
            };

            Label   lbl       = new Label   { Text = "Motivo de cancelación:", Location = new Point(12, 15), AutoSize = true };
            TextBox txt       = new TextBox { Location = new Point(12, 35), Width = 340 };
            Button  btnOk     = new Button  { Text = "Aceptar",  DialogResult = DialogResult.OK,     Location = new Point(190, 75), Width = 80 };
            Button  btnCancel = new Button  { Text = "Cancelar", DialogResult = DialogResult.Cancel, Location = new Point(280, 75), Width = 80 };

            dlg.Controls.AddRange(new Control[] { lbl, txt, btnOk, btnCancel });
            dlg.AcceptButton = btnOk;
            dlg.CancelButton = btnCancel;

            if (dlg.ShowDialog() != DialogResult.OK) return;

            var (ok, msg) = _bl.CancelarOrden(_idOrdenSeleccionada, txt.Text.Trim());
            MessageBox.Show(msg, "SistemaGym", MessageBoxButtons.OK,
                ok ? MessageBoxIcon.Information : MessageBoxIcon.Error);
            if (ok) CargarOrdenes();
        }

        private void btnRefrescar_Click(object sender, EventArgs e) => CargarOrdenes();

        private void btnsalir_Click(object sender, EventArgs e) => this.Close();

        // ── HELPERS ──────────────────────────────────────────────────
        private void MostrarCol(string name, string header, int width)
        {
            if (dgvOrdenes.Columns[name] == null) return;
            dgvOrdenes.Columns[name].Visible    = true;
            dgvOrdenes.Columns[name].HeaderText = header;
            dgvOrdenes.Columns[name].Width      = width;
        }

        private void ActualizarBotones()
        {
            if (dgvOrdenes.CurrentRow?.DataBoundItem is OrdenRestock o)
            {
                btnEnviada.Enabled       = o.Estado == "PENDIENTE";
                btnRecibida.Enabled      = o.Estado == "ENVIADA";
                btnCancelarOrden.Enabled = o.Estado == "PENDIENTE" || o.Estado == "ENVIADA";
            }
            else
            {
                btnEnviada.Enabled = btnRecibida.Enabled = btnCancelarOrden.Enabled = false;
            }
        }
    }
}
