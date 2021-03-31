using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Mi_mercadito
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void CmdAccept_Click(object sender, EventArgs e)
        {
            // Arreglo para datos del usuario
            string[] Consulta = new string[7];
            Usuarios Usuario = new Usuarios();
            System.Drawing.Image z;
            z = pbxLogo.Image;
            // Validamos que existe el usuario
            if (!Usuario.Validar(txtUsername.Text) && !Usuario.Login(txtUsername.Text, txtPassword.Text))
            {
                // Llamada al método de ConsultaT
                Usuarios Consultas = new Usuarios();
                Consulta = Consultas.ConsultaT(txtUsername.Text);
                this.Hide();
                FrmMain Main = new FrmMain(z, Consulta);
                if (Main.ShowDialog() != DialogResult.OK)
                    //while(DialogResult.Ignore)
                    this.Show();
                txtPassword.Clear();
            }
        }

        private void CmdRegister_Click(object sender, EventArgs e)
        {
            // Creamos objeto de formulario de registro.
            FrmRegistro FormRegistro = new FrmRegistro();

            // Desplegamos el formuario de registro.
            FormRegistro.Show();
        }
    }
}
