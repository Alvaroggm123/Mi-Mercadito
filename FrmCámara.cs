using AForge.Video;// Librería para la cámara.
using AForge.Video.DirectShow;// Librería para la cámara
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
    public partial class FrmCamara : Form
    {
        // ==================== || INICIO Variables || ==================== //

        // Se guardarán las imágenes tomadas por el usuario.
        private string Path = System.IO.Path.GetTempPath();
        private bool Dispositivos;
        // Se utiliza para saber cuál cámara utilizará el dispositivo.
        private FilterInfoCollection MisDispositivos;
        // Obtiene la imagen en tiempo real.
        private VideoCaptureDevice MiCamara;

        // ==================== || FIN Variables || ==================== //

        // ==================== || INICIO Métodos || ==================== //
        public FrmCamara()
        {
            InitializeComponent();
        }

        private void FrmCámara_Load(object sender, EventArgs e)
        {
            // Se llama al mÉtodo para cargar la imagen en el formulario.
            CargaDispositivo();
        }

        public void CargaDispositivo()
        {
            // Realiza la conexión de la cámara en tiempo real con el formulario.
            MisDispositivos = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (MisDispositivos.Count > 0)
            {
                // El arreglo analiza la cantidad de cámaras que tiene el dispositivo.
                Dispositivos = true;
                for (int i = 0; i < MisDispositivos.Count; i++)
                    // Permite agregar los dispositivos y esta en [string] para poder visualizar los nombres.
                    cboxCamara.Items.Add(MisDispositivos[i].Name.ToString());
                // Selecciona el primer dispositivo por defecto.
                cboxCamara.Text = MisDispositivos[0].Name.ToString();
                
            }
            else
                Dispositivos = false;
        }

        private void Capturando(object sender, NewFrameEventArgs eventArgs) 
        {
            // El [Bitmap] sirve para cargar la imagen en base a la cantidad de frames.
            // clona la imagen para que la foto tomada se mande al [picturebox] del Main y no exista conflicto en la lectura de frames.
            // El [.Clone()] crea un nuevo objeto a partir del que existe por el Bitmap Imagen.
            Bitmap Imagen = (Bitmap)eventArgs.Frame.Clone();
            pbox_Camara.Image = Imagen;
        }

        private void CerrarCamara() 
        {
            // Hace que si [MiCamara] no tiene un frame corriendo y esta corriendo se cierre la cámara.
            if (MiCamara !=null && MiCamara.IsRunning)
            {
                MiCamara.SignalToStop();
                MiCamara = null;
            }
        }

        // ==================== || FIN Métodos || ==================== //

        // ==================== || INICIO Eventos || ==================== //

        private void cmdGrabar_Click(object sender, EventArgs e)
        {
            CerrarCamara();
            // Selecciona la cámara que esta en el [combobox] en base a la posición.
            int i = cboxCamara.SelectedIndex;
            // Nos indica el nombre de la posicion.
            string NombreVideo = MisDispositivos[i].MonikerString;
            // Captura la imagen en base al nombre del dispositivo.
            MiCamara = new VideoCaptureDevice(NombreVideo);
            // Agrega el método captura al momento de tomar la foto.
            MiCamara.NewFrame += new NewFrameEventHandler(Capturando);
            // Hace que la cámara inicie.
            MiCamara.Start();
            cmdFoto.Focus();
        }

        private void FrmCamara_FormClosed(object sender, FormClosedEventArgs e)
        {
            CerrarCamara();
        }

        private void cmdCapturarFoto_Click(object sender, EventArgs e)
        {
            if (MiCamara != null && MiCamara.IsRunning)
            {
                string[] not = new string[7];
                not[0] = "";
                this.Close();
            }
            else
            {
                MessageBox.Show("Encienda su cámara", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MiCamara.Stop();
        }
        // Cerrar ventana.
        private void pbxX2_Click(object sender, EventArgs e)
        {
            pbox_Camara.Image = Mi_mercadito.Properties.Resources.logomiMercadito;
            Close();
        }
        private void pbxX_MouseHover(object sender, EventArgs e)
        {
            pbxX2.BackColor = Color.White;
            pbxX2.Visible = true;
            pbxX.Visible = false;
        }

        // Efectos de boton X.
        private void pbxX_MouseLeave(object sender, EventArgs e)
        {
            pbxX.BackColor = Color.PaleTurquoise;
        }
        private void pbxX2_MouseLeave(object sender, EventArgs e)
        {
            pbxX2.Visible = false;
            pbxX.Visible = true;
        }
        // Minimizar ventana.
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
        // Efectos de botón min.
        private void pbxmin_MouseHover(object sender, EventArgs e)
        {
            pbxmin2.BackColor = Color.White;
            pbxmin.Visible = false;
            pbxmin2.Visible = true;
        }

        private void pbxmin_MouseLeave(object sender, EventArgs e)
        {
            pbxmin.BackColor = Color.PaleTurquoise;
        }

        private void pbxmin2_MouseLeave(object sender, EventArgs e)
        {
            pbxmin.Visible = true;
            pbxmin2.Visible = false;
        }

        // ==================== || FIN Eventos || ==================== //


    }
}
