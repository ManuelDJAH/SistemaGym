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
    using System;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    public partial class FrmLogin : Form
    {

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UsuariosBL bl = new UsuariosBL();
            string rol = bl.Login(txtUsuario.Text, txtClave.Text);

            if (rol != null)
            {
                Sesion.Usuario = txtUsuario.Text;
                Sesion.Rol = rol;

                MessageBox.Show("Bienvenido " + Sesion.Usuario);

                FrmMenuPrincipal menu = new FrmMenuPrincipal();
                this.Hide();

                menu.ShowDialog(); // Bloquea hasta que se cierre
                this.Close();      // Cierra completamente el login
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
        }

    }
}


