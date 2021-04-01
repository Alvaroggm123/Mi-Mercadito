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
using System.Data.SqlClient;

namespace Mi_mercadito
{
    public partial class FrmMain : Form
    {
        public FrmMain(System.Drawing.Image i, string[] Consulta)
        {
            InitializeComponent();
            // Se asigna el valor de la imagen de la foto a el picturebox de FrmMain.
            pbox_Camara.Image = i;
            // Mensaje de saludo.
            switch (Consulta[4])
            {
                case "M":
                    lblName.Text = "Bienvenido " + Consulta[1];
                    break;
                case "F":
                    lblName.Text = "Bienvenida " + Consulta[1];
                    break;
                default:
                    lblName.Text = "Hola " + Consulta[1];
                    break;
            }
        }


        private void btn_Foto_Click(object sender, EventArgs e)
        {
            // Hace que al dar click en el boton tomar foto se habra el formulario de la camara.
            FrmCámara Camara = new FrmCámara();
            Image Logo = Camara.pbox_Camara.Image;
            this.Hide();
            if (Camara.ShowDialog()==DialogResult.OK)
                this.Show();
            // Re asignamos en caso de que corresponda un cambio
            if (Logo != pbox_Camara.Image)
            {
                pbox_Camara.Image = Camara.pbox_Camara.Image;
                Camara.pbox_Camara.Image = Logo;
            }
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

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            string Msg = "¿Desea salir?", Title = "Salir de mi lista";
            if (MessageBox.Show(Msg, Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
            else
                this.Show();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Sucursal sucursal = new Sucursal();
            sucursal.ConsultaSuc(cboxSucursal);
        }

        private void cboxSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] arreglo = new string[3];
            Sucursal datos = new Sucursal();
            arreglo = datos.Datos(cboxSucursal.Text);
            txtPaís.Text = arreglo[1];
            txtCiudad.Text = arreglo[2];
            txtDir.Text = arreglo[3];
        }

    }
}
