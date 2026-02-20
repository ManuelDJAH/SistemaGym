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
            UsuariosBL usuariosBL = new UsuariosBL();
            string rol = usuariosBL.Login(txtUsuario.Text, txtClave.Text);

            if (rol != null)
            {
                // Guardar datos de sesión
                Sesion.Usuario = txtUsuario.Text;
                Sesion.Rol = rol;

                // Registrar entrada en bitácora
                BitacoraBL bitacoraBL = new BitacoraBL();
                Sesion.IdBitacoraActual = bitacoraBL.RegistrarEntrada(Sesion.Usuario);

                MessageBox.Show("Bienvenido " + Sesion.Usuario);

                FrmMenuPrincipal menu = new FrmMenuPrincipal();

                this.Hide();
                menu.ShowDialog();   // Espera a que el menú se cierre
                this.Close();        // Cierra el login completamente
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void FrmLogin_Load(object sender, EventArgs e)
        {
        }

    }
}


