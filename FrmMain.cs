using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mi_mercadito
{
    public partial class FrmMain : Form
    {
        public FrmMain(System.Drawing.Image i, string[] consulta)
        {
            InitializeComponent();
            // Se asigna el valor de la imagen de la foto a el picturebox de FrmMain.
            pbox_Camara.Image = i;
            // Mensaje de saludo.
            switch (consulta[4])
            {
                case "M":
                    lblName.Text = "Bienvenido " + consulta[1];
                    break;
                case "F":
                    lblName.Text = "Bienvenida " + consulta[1];
                    break;
                default:
                    lblName.Text = "";
                    break;
            }
        }


        private void btn_Foto_Click(object sender, EventArgs e)
        {
            // Hace que al dar click en el boton tomar foto se habra el formulario de la camara.
            FrmCámara formulario = new FrmCámara();
            formulario.Show();
            this.Hide();
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            Usuarios Usuario = new Usuarios();
            if (Usuario.InsertarCarrito(pbox_Camara) > 0)
            {
                MessageBox.Show("Se ha guardado la imagen de manera correcta.", "Imagen guardada");

            }
            else
            {
                MessageBox.Show("No se ha ingresado la imagen de manera correcta.", "Error");
            }
        }
    }
}
