using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Librerías a utilizar
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Mi_mercadito
{
    public partial class FrmLogin : Form
    {
        // === | INICIO Métodos | === //
        public static string ReemplazarAcentos(string txtCajaTexto)
        {
            Regex ReemplazarA = new Regex("[á|à|ä|â]", RegexOptions.Compiled);
            Regex ReemplazarE = new Regex("[é|è|ë|ê]", RegexOptions.Compiled);
            Regex ReemplazarI = new Regex("[í|ì|ï|î]", RegexOptions.Compiled);
            Regex ReemplazarO = new Regex("[ó|ò|ö|ô]", RegexOptions.Compiled);
            Regex ReemplazarU = new Regex("[ú|ù|ü|û]", RegexOptions.Compiled);
            txtCajaTexto = ReemplazarA.Replace(txtCajaTexto, "a");
            txtCajaTexto = ReemplazarE.Replace(txtCajaTexto, "e");
            txtCajaTexto = ReemplazarI.Replace(txtCajaTexto, "i");
            txtCajaTexto = ReemplazarO.Replace(txtCajaTexto, "o");
            txtCajaTexto = ReemplazarU.Replace(txtCajaTexto, "u");
            return txtCajaTexto;
        }
        private void ValidarUsername(TextBox txtUsername)
        {
            // Validamos que se usen signos válidos para un usuario.
            foreach (int Caracter in Encoding.ASCII.GetBytes(txtUsername.Text))
                /*  //-Guión bajo-//    //-----Letras Mayúsculas-----//    //-----Letras Minúsculas-----//     //-----------Números-----------//  */
                if (Caracter != 95 && (Caracter < 65 || Caracter > 90) && (Caracter < 97 || Caracter > 122) && (Caracter < 48 || Caracter > 57))
                {
                    try
                    {
                        int AuxUbi = Convert.ToByte(txtUsername.Text.IndexOf(Convert.ToChar(Caracter)));
                        MessageBox.Show("Solo se pueden ingresar valores válidos: \n[(Letras), (números), (_)]", "Error de sintáxis de usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtUsername.Text = txtUsername.Text.Remove(AuxUbi, 1);
                        txtUsername.SelectionStart = AuxUbi;
                    }
                    catch
                    {
                        txtUsername.Text = ReemplazarAcentos(txtUsername.Text);
                        txtUsername.SelectionStart = txtUsername.TextLength;
                    }
                }
        }
        // === | FIN Métodos | === //
        public FrmLogin()
        {
            InitializeComponent();
        }

        // === | INICIO Eventos | === //
        private void CmdAccept_Click(object sender, EventArgs e)
        {
            // Arreglo para datos del usuario.
            string[] Consulta = new string[7];
            Usuarios Usuario = new Usuarios();
            System.Drawing.Image z;
            z = pbxLogo.Image;
            // Validamos que existe el usuario.
            if (!Usuario.Validar(txtUsername.Text))
                if (!Usuario.Login(txtUsername.Text, txtPassword.Text))
                {
                    // Llamada al método de ConsultaT.
                    Usuarios Consultas = new Usuarios();
                    Consulta = Consultas.ConsultaT(txtUsername.Text);
                    this.Hide();
                    FrmMain Main = new FrmMain(z, Consulta);
                    if (Main.ShowDialog() != DialogResult.OK)
                        //while(DialogResult.Ignore)
                        this.Show();
                    txtPassword.Clear();
                }
                else
                {
                    //Un saludito
                }
            else
            {
                // Limpiamos la contraseña y mostramos lblUsuarioRip
                lblUsuarioRip.Visible = true;
                txtPassword.ResetText();
                txtUsername.Focus();
                txtUsername.SelectAll();
            }
        }

        private void CmdRegister_Click(object sender, EventArgs e)
        {
            // Creamos objeto de formulario de registro.
            FrmRegistro FormRegistro = new FrmRegistro();

            // Desplegamos el formulario de registro.
            FormRegistro.Show();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            // Apagamos el lblUsuarioRip
            lblUsuarioRip.Visible = false;

            // Validación [LOGIN] - Username
            ValidarUsername(txtUsername);
        }

        // === | FIN Eventos | === //
    }
}
