using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            RegUsuarios frm = new RegUsuarios();
            frm.Show();
        }

        private void btnAsistencia_Click(object sender, EventArgs e)
        {
            RegAsistGym frm = new RegAsistGym();
            frm.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            if (Sesion.Rol != "ADMIN")
            {
                btnBitacora.Visible = false;
            }
        }

        private void btnBitacora_Click(object sender, EventArgs e)
        {
            FrmBitacora frm = new FrmBitacora();
            frm.ShowDialog();
        }
    }
}