using System;
using System.Drawing;
using System.Windows.Forms;
using ClaseNegocio;
using CapaDatos;

namespace CapaPresentacion
{
    public partial class FrmProveedores : Form
    {
        // ── Estado ───────────────────────────────────────────────────
        private int _idProveedorSeleccionado = 0;
        private bool _modoEdicion = false;
        private readonly RestockBL _restockBL = new RestockBL();
        private int _idOrdenSeleccionada = 0;

        public FrmProveedores()
        {
            InitializeComponent();
        }

        private void FrmProveedores_Load(object sender, EventArgs e)
        {
            CargarCategorias();
            CargarProveedores();
        }

        // ════════════════════════════════════════════════════════════
        //  TAB 1 — PROVEEDORES
        // ════════════════════════════════════════════════════════════

        private void CargarCategorias()
        {
            cbCategoria.DataSource = CNProveedor.ListarCategorias();
            cbCategoria.DisplayMember = "nombre";
            cbCategoria.ValueMember = "id_categoria";
        }

        private void CargarProveedores()
        {
            dgvProveedores.DataSource = null;
            dgvProveedores.DataSource = CNProveedor.Listar();

            foreach (DataGridViewColumn col in dgvProveedores.Columns)
                col.Visible = false;

            MostrarCol(dgvProveedores, "id_proveedor", "ID", 40);
            MostrarCol(dgvProveedores, "nombre", "Nombre", 180);
            MostrarCol(dgvProveedores, "contacto", "Contacto", 130);
            MostrarCol(dgvProveedores, "telefono", "Teléfono", 110);
            MostrarCol(dgvProveedores, "correo", "Correo", 170);
            MostrarCol(dgvProveedores, "direccion", "Dirección", 160);
            MostrarCol(dgvProveedores, "categoria", "Categoría", 120);

            ModoLecturaProveedor();
        }

        private void dgvProveedores_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProveedores.CurrentRow == null) return;
            var row = dgvProveedores.CurrentRow;

            _idProveedorSeleccionado = Convert.ToInt32(row.Cells["id_proveedor"].Value);
            txtNombre.Text = row.Cells["nombre"].Value?.ToString() ?? "";
            txtContacto.Text = row.Cells["contacto"].Value?.ToString() ?? "";
            txtTelefono.Text = row.Cells["telefono"].Value?.ToString() ?? "";
            txtCorreo.Text = row.Cells["correo"].Value?.ToString() ?? "";
            txtDireccion.Text = row.Cells["direccion"].Value?.ToString() ?? "";

            // Seleccionar categoría en el combo
            if (row.Cells["id_categoria"].Value != null)
                cbCategoria.SelectedValue = row.Cells["id_categoria"].Value;

            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            ModoLecturaProveedor();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            _idProveedorSeleccionado = 0;
            _modoEdicion = false;
            LimpiarFormProveedor();
            ModoCapturaProveedor();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (_idProveedorSeleccionado == 0) return;
            _modoEdicion = true;
            ModoCapturaProveedor();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int idCat = cbCategoria.SelectedValue != null
                ? Convert.ToInt32(cbCategoria.SelectedValue) : 0;

            string msg;
            if (_modoEdicion)
            {
                msg = CNProveedor.Actualizar(
                    _idProveedorSeleccionado,
                    txtNombre.Text.Trim(),
                    txtContacto.Text.Trim(),
                    txtTelefono.Text.Trim(),
                    txtCorreo.Text.Trim(),
                    txtDireccion.Text.Trim(),
                    idCat);
            }
            else
            {
                msg = CNProveedor.Insertar(
                    txtNombre.Text.Trim(),
                    txtContacto.Text.Trim(),
                    txtTelefono.Text.Trim(),
                    txtCorreo.Text.Trim(),
                    txtDireccion.Text.Trim(),
                    idCat);
            }

            MessageBox.Show(msg, "SistemaGym", MessageBoxButtons.OK,
                msg.Contains("correctamente") ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            if (msg.Contains("correctamente"))
            {
                CargarProveedores();
                LimpiarFormProveedor();
                ModoLecturaProveedor();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_idProveedorSeleccionado == 0) return;

            var confirm = MessageBox.Show(
                "¿Eliminar este proveedor?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            string msg = CNProveedor.Eliminar(_idProveedorSeleccionado);
            MessageBox.Show(msg, "SistemaGym", MessageBoxButtons.OK,
                msg.Contains("correctamente") ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            if (msg.Contains("correctamente")) CargarProveedores();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormProveedor();
            ModoLecturaProveedor();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string texto = txtBuscar.Text.Trim();
            if (string.IsNullOrEmpty(texto)) { CargarProveedores(); return; }

            dgvProveedores.DataSource = rbNombre.Checked
                ? CNProveedor.BuscarNombre(texto)
                : CNProveedor.BuscarContacto(texto);
        }

        private void btnVerTodos_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            CargarProveedores();
        }

        // Helpers proveedores
        private void ModoCapturaProveedor()
        {
            txtNombre.ReadOnly = false;
            txtContacto.ReadOnly = false;
            txtTelefono.ReadOnly = false;
            txtCorreo.ReadOnly = false;
            txtDireccion.ReadOnly = false;
            cbCategoria.Enabled = true;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void ModoLecturaProveedor()
        {
            txtNombre.ReadOnly = true;
            txtContacto.ReadOnly = true;
            txtTelefono.ReadOnly = true;
            txtCorreo.ReadOnly = true;
            txtDireccion.ReadOnly = true;
            cbCategoria.Enabled = false;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnNuevo.Enabled = true;
        }

        private void LimpiarFormProveedor()
        {
            _idProveedorSeleccionado = 0;
            txtNombre.Clear();
            txtContacto.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtDireccion.Clear();
            if (cbCategoria.Items.Count > 0) cbCategoria.SelectedIndex = 0;
        }

        // ════════════════════════════════════════════════════════════
        //  TAB 2 — ÓRDENES DE RESTOCK
        // ════════════════════════════════════════════════════════════

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 1)
                CargarOrdenes();
        }

        private void CargarOrdenes(string filtro = null)
        {
            var lista = _restockBL.ListarOrdenes(filtro);
            dgvOrdenes.DataSource = null;
            dgvOrdenes.DataSource = lista;

            foreach (DataGridViewColumn col in dgvOrdenes.Columns)
                col.Visible = false;

            MostrarCol(dgvOrdenes, "IdOrden", "# Orden", 50);
            MostrarCol(dgvOrdenes, "FechaGenerada", "Fecha", 120);
            MostrarCol(dgvOrdenes, "Producto", "Producto", 180);
            MostrarCol(dgvOrdenes, "StockActual", "Stock", 70);
            MostrarCol(dgvOrdenes, "StockMinimo", "Minimo", 60);
            MostrarCol(dgvOrdenes, "CantidadSolicit", "A Pedir", 70);
            MostrarCol(dgvOrdenes, "Proveedor", "Proveedor", 150);
            MostrarCol(dgvOrdenes, "TelProveedor", "Telefono", 110);
            MostrarCol(dgvOrdenes, "Estado", "Estado", 90);

            foreach (DataGridViewRow row in dgvOrdenes.Rows)
            {
                string estado = row.Cells["Estado"].Value?.ToString();
                switch (estado)
                {
                    case "PENDIENTE": row.DefaultCellStyle.BackColor = Color.FromArgb(255, 245, 190); break;
                    case "ENVIADA": row.DefaultCellStyle.BackColor = Color.FromArgb(190, 220, 255); break;
                    case "RECIBIDA": row.DefaultCellStyle.BackColor = Color.FromArgb(200, 255, 200); break;
                    case "CANCELADA": row.DefaultCellStyle.BackColor = Color.FromArgb(220, 220, 220); break;
                }
            }

            ActualizarBotonesRestock();
        }

        private void dgvOrdenes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvOrdenes.Rows[e.RowIndex].DataBoundItem is OrdenRestock o)
            {
                _idOrdenSeleccionada = o.IdOrden;
                lblDetalleProveedor.Text =
                    $"Proveedor: {o.Proveedor}     " +
                    $"Contacto: {o.ContactoProveedor}     " +
                    $"Tel: {o.TelProveedor}     " +
                    $"Correo: {o.CorreoProveedor}";
                ActualizarBotonesRestock();
            }
        }

        private void cboFiltroEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sel = cboFiltroEstado.SelectedItem?.ToString();
            CargarOrdenes(sel == "TODAS" ? null : sel);
        }

        private void btnRefrescar_Click(object sender, EventArgs e) => CargarOrdenes();

        private void btnEnviada_Click(object sender, EventArgs e)
        {
            if (_idOrdenSeleccionada == 0) return;
            var orden = dgvOrdenes.CurrentRow?.DataBoundItem as OrdenRestock;
            if (orden == null) return;

            Form dlg = new Form
            {
                Text = "Confirmar Envio",
                Size = new Size(380, 230),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label lblProd = new Label { Text = $"Producto:  {orden.Producto}", Location = new Point(12, 15), AutoSize = true };
            Label lblProv = new Label { Text = $"Proveedor: {orden.Proveedor}", Location = new Point(12, 38), AutoSize = true };
            Label lblTel = new Label { Text = $"Telefono:  {orden.TelProveedor}", Location = new Point(12, 61), AutoSize = true };
            Label lblStock = new Label { Text = $"Stock actual: {orden.StockActual} (minimo: {orden.StockMinimo})", Location = new Point(12, 84), AutoSize = true };
            Label lblCant = new Label { Text = "Cantidad a pedir:", Location = new Point(12, 115), AutoSize = true };
            NumericUpDown num = new NumericUpDown { Location = new Point(145, 112), Width = 80, Minimum = 1, Maximum = 9999, Value = orden.CantidadSolicit };
            Button btnOk = new Button { Text = "Confirmar Envio", DialogResult = DialogResult.OK, Location = new Point(12, 155), Width = 130 };
            Button btnNo = new Button { Text = "Cancelar", DialogResult = DialogResult.Cancel, Location = new Point(152, 155), Width = 80 };

            dlg.Controls.AddRange(new Control[] { lblProd, lblProv, lblTel, lblStock, lblCant, num, btnOk, btnNo });
            dlg.AcceptButton = btnOk;
            dlg.CancelButton = btnNo;

            if (dlg.ShowDialog() != DialogResult.OK) return;

            int nuevaCantidad = (int)num.Value;
            if (nuevaCantidad != orden.CantidadSolicit)
                _restockBL.ActualizarCantidad(_idOrdenSeleccionada, nuevaCantidad);

            var (ok, msg) = _restockBL.MarcarEnviada(_idOrdenSeleccionada);
            MessageBox.Show(msg, "SistemaGym", MessageBoxButtons.OK,
                ok ? MessageBoxIcon.Information : MessageBoxIcon.Error);
            if (ok) CargarOrdenes();
        }

        private void btnRecibida_Click(object sender, EventArgs e)
        {
            if (_idOrdenSeleccionada == 0) return;
            var (ok, msg) = _restockBL.MarcarRecibida(_idOrdenSeleccionada);
            MessageBox.Show(msg, "SistemaGym", MessageBoxButtons.OK,
                ok ? MessageBoxIcon.Information : MessageBoxIcon.Error);
            if (ok) CargarOrdenes();
        }

        private void btnCancelarOrden_Click(object sender, EventArgs e)
        {
            if (_idOrdenSeleccionada == 0) return;

            Form dlg = new Form
            {
                Text = "Cancelar orden",
                Size = new Size(380, 160),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label lbl = new Label { Text = "Motivo de cancelacion:", Location = new Point(12, 15), AutoSize = true };
            TextBox txt = new TextBox { Location = new Point(12, 35), Width = 340 };
            Button btnOk = new Button { Text = "Aceptar", DialogResult = DialogResult.OK, Location = new Point(190, 75), Width = 80 };
            Button btnNo = new Button { Text = "Cancelar", DialogResult = DialogResult.Cancel, Location = new Point(280, 75), Width = 80 };

            dlg.Controls.AddRange(new Control[] { lbl, txt, btnOk, btnNo });
            dlg.AcceptButton = btnOk;
            dlg.CancelButton = btnNo;

            if (dlg.ShowDialog() != DialogResult.OK) return;

            var (ok, msg) = _restockBL.CancelarOrden(_idOrdenSeleccionada, txt.Text.Trim());
            MessageBox.Show(msg, "SistemaGym", MessageBoxButtons.OK,
                ok ? MessageBoxIcon.Information : MessageBoxIcon.Error);
            if (ok) CargarOrdenes();
        }

        private void ActualizarBotonesRestock()
        {
            if (dgvOrdenes.CurrentRow?.DataBoundItem is OrdenRestock o)
            {
                btnEnviada.Enabled = o.Estado == "PENDIENTE";
                btnRecibida.Enabled = o.Estado == "ENVIADA";
                btnCancelarOrden.Enabled = o.Estado == "PENDIENTE" || o.Estado == "ENVIADA";
            }
            else
            {
                btnEnviada.Enabled = btnRecibida.Enabled = btnCancelarOrden.Enabled = false;
            }
        }

        // ════════════════════════════════════════════════════════════
        //  UTILITY
        // ════════════════════════════════════════════════════════════
        private static void MostrarCol(DataGridView dgv, string name, string header, int fillWeight)
        {
            if (dgv.Columns[name] == null) return;
            dgv.Columns[name].Visible = true;
            dgv.Columns[name].HeaderText = header;
            dgv.Columns[name].FillWeight = fillWeight;
        }
    }
}
