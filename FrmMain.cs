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
using System.IO;
// Librerías a utilizar
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

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
        // Creación de método para movimiento de ventana
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void btn_Foto_Click(object sender, EventArgs e)
        {
            // Hace que al dar click en el boton tomar foto se habra el formulario de la camara.
            FrmCámara Camara = new FrmCámara();
            Image Logo = Camara.pbox_Camara.Image;
            this.Enabled = false;
            if (Camara.ShowDialog()==DialogResult.OK)
                this.Show();
            this.Enabled = true; ;
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
            Autocompletar();
            
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

        public void Autocompletar()
        {
            string Consulta = (@"SELECT * FROM Producto ;");
            using (SqlConnection Conn = ConnectionDB.StartConn())
            {
                DataTable Datos = new DataTable();
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                SqlDataAdapter adaptador = new SqlDataAdapter(Consulta, Conn);
                adaptador.Fill(Datos);

                for (int i = 0; i < Datos.Rows.Count; i++)
                {
                    lista.Add(Datos.Rows[i]["prodName"].ToString());
                }
                txtNombreProduc.AutoCompleteCustomSource = lista;
                Producto datos = new Producto();
                //AutocompletarResto(datos);
            }
        }

        private void AutocompletarResto(Producto datos)
        {
            //string [] arreglo = datos.RellenarProduc(txtNombreProduc.Text);
            
            ////string[] arreglo = new string[7];
            ////Producto datos = new Producto();
            ////arreglo = datos.RellenarProduc(txtNombreProduc.Text);
            //txtProdPrecio.Text = arreglo[1];
            //txtProdContNet.Text = arreglo[2];
            //txtProdDesc.Text = arreglo[3];
            //txtProdMarc.Text = arreglo[4];
            //txtProdDpto.Text = arreglo[5];
            //txtProdSuc.Text = arreglo[6];

            ////datos.Imagen(ref pbox_Camara, txtNombreProduc.Text);
        }

        private void txtNombreProduc_Leave(object sender, EventArgs e)
        {
            string[] arreglo = new string[7];
            Producto datos = new Producto();
            arreglo = datos.RellenarProduc(txtNombreProduc.Text);
            txtProdPrecio.Text = arreglo[1];
            txtProdContNet.Text = arreglo[2];
            txtProdDesc.Text = arreglo[3];
            txtProdMarc.Text = arreglo[4];
            txtProdDpto.Text = arreglo[5];
            txtProdSuc.Text = arreglo[6];

            //datos.Imagen(ref pbox_Camara, txtNombreProduc.Text);

        }

        // Movimiento de pantalla
        private void pnlLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        // Cerrar ventana y programa
        private void pbxX2_Click(object sender, EventArgs e)
        {
            // MessageBox implementación de código 
            string Msg = "¿Desea salir?", Title = "Cancelar";
            if (MessageBox.Show(Msg, Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
                Application.Exit();
            }
              
        }
        // Efectos del boton X
        private void pbxX_MouseHover(object sender, EventArgs e)
        {
            pbxX2.BackColor = Color.White;
            pbxX2.Visible = true;
         
        }

        private void pbxX_MouseLeave(object sender, EventArgs e)
        {
            pbxX.BackColor = Color.PaleTurquoise;
        }
        private void pbxX2_MouseLeave(object sender, EventArgs e)
        {
            pbxX2.Visible = false;
  
        }

        // Minimizar ventana
        private void pbxmin2_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Minimized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }
        // Efectos del boton min
        private void pbxmin_MouseHover(object sender, EventArgs e)
        {
            pbxmin2.BackColor = Color.White;        
            pbxmin2.Visible = true;
        }

        private void pbxmin_MouseLeave(object sender, EventArgs e)
        {
            pbxmin.BackColor = Color.PaleTurquoise;
        }

        private void pbxmin2_MouseLeave(object sender, EventArgs e)
        {
            pbxmin2.Visible = false;
        }

        // Cerrar ventana
        private void iniciarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Msg = "¿Desea cerrar sesión?", Title = "Cancelar";
            if (MessageBox.Show(Msg, Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        } 
    }
}
