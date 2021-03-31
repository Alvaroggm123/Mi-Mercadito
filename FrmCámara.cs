using AForge.Video;//librería para la cámara
using AForge.Video.DirectShow;//librería para la cámara
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
    public partial class FrmCámara : Form
    {
        //se guardaran las imagenes tomadas por el usuario
        private string Path = System.IO.Path.GetTempPath();
        private bool Dispositivos;
        //se utiliza para saber cual cámara utilizara el dispositivo
        private FilterInfoCollection MisDispositivos;
        //obtiene la imagen en tiempo real
        private VideoCaptureDevice MiCamara;

        public FrmCámara()
        {
            InitializeComponent();
        }

        private void FrmCámara_Load(object sender, EventArgs e)
        {
            //se llama al metodo para cargar la imagen en el formulario
            CargaDispositivo();
        }

        public void CargaDispositivo()
        {
            //realiza la conexión de la cámara en tiempo real con el formulario
            MisDispositivos = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (MisDispositivos.Count > 0)
            {
                //el arreglo analiza la cantidad de cámaras que tiene el dispositivo
                Dispositivos = true;
                for (int i = 0; i < MisDispositivos.Count; i++)
                    ///permite agregar los dispositivos y esta en string para poder visualizar los nombre
                    cbox_Camara.Items.Add(MisDispositivos[i].Name.ToString());
                //selecciona el primer dispositivo por defecto
                cbox_Camara.Text = MisDispositivos[0].Name.ToString();
                
            }
            else
                Dispositivos = false;
        }

        private void Capturando(object sender, NewFrameEventArgs eventArgs) 
        {
            //el Bitmap sirve para cargar la imagen en base a la cantidad de frames
            //clona la imagen para que la foto tomada se mande al picturebox del Main y no exista conflicto en la lectura de frames
            //el .Clone() crea un nuevo objeto a partir del que existe por el Bitmap Imagen
            Bitmap Imagen = (Bitmap)eventArgs.Frame.Clone();
            pbox_Camara.Image = Imagen;
        }

        private void CerrarCamara() 
        {
            ///hace que si MiCamara no tiene un frame corriendo y esta corriendo se cierre la cámara
            if (MiCamara !=null && MiCamara.IsRunning)
            {
                MiCamara.SignalToStop();
                MiCamara = null;
            }
        }

        private void btn_Grabar_Click(object sender, EventArgs e)
        {
            CerrarCamara();
            //selecciona la camara que esta en el combobox en base a la posición
            int i = cbox_Camara.SelectedIndex;
            //nos indica el nombre de la posiicon
            string NombreVideo = MisDispositivos[i].MonikerString;
            //captura la imagen en base al nombre del dispositivo
            MiCamara = new VideoCaptureDevice(NombreVideo);
            //agrega el metodo captura al momento de tomar la foto
            MiCamara.NewFrame += new NewFrameEventHandler(Capturando);
            //hace que la cámara inicie
            MiCamara.Start();
            cmdFoto.Focus();
        }

        private void FrmCámara_FormClosed(object sender, FormClosedEventArgs e)
        {
            CerrarCamara();
        }

        private void btn_CapturarFoto_Click(object sender, EventArgs e) 
        {
            if (MiCamara !=null && MiCamara.IsRunning)
            {
                string[] not = new string[7];
                not[0] = "";
            }
            else
            {
                MessageBox.Show("Encienda su cámara", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MiCamara.Stop();
        }
    }
}
