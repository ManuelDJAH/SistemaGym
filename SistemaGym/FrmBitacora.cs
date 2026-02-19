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
    public partial class FrmBitacora : Form
    {
        public FrmBitacora()
        {
            InitializeComponent();
        }

        private void FrmBitacora_Load(object sender, EventArgs e)
        {
            UsuariosBL bl = new UsuariosBL();
            dgvBitacora.DataSource = bl.MostrarBitacora();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
