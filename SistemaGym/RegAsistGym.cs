using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class RegAsistGym : Form
    {
        AsistenciaBL bl = new AsistenciaBL();

        public RegAsistGym()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            int idUsuario = int.Parse(txtIdUsuario.Text);

            AsistenciaBL asistenciaBL = new AsistenciaBL();
            string resultado = asistenciaBL.RegistrarAsistencia(idUsuario);

            MessageBox.Show(resultado);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

