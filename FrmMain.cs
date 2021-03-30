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
        public FrmMain() 
        {
            InitializeComponent();
        }

        public FrmMain(System.Drawing.Image i)
        {
            InitializeComponent();
            pbox_Camara.Image = i;
        }

        private void menToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void btn_Foto_Click(object sender, EventArgs e)
        {
            //hace que al dar click en el boton tomar foto se habra el formulario de la camara
            FrmCámara formulario = new FrmCámara();
            formulario.Show();
            this.Hide();
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
