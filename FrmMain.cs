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
        Image I;

        public FrmMain(System.Drawing.Image i)
        {
            I = i;
            InitializeComponent();
            //pictureBox1.Image = i;
            
        }

        private void menToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        //public static Image Logo = null;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Logo = pbox_imgProductoMain.Image;
            /*FrmCámara f2 = new FrmCámara();
            DialogResult res = f2.ShowDialog();
            if (res == DialogResult.OK)
            {
                pbox_imgProductoMain.Image = f2.Micamara2.Image;
            }*/

            //pbox_imgProductoMain.Image = Image.FromFile(@"C:\Users\chris\source\repos\Mi-mercadito");
            /*pbox_imgProductoMain.Image = FrmCámara.Logo;
            this.Show();*/
        }

        private void btn_Foto_Click(object sender, EventArgs e)
        {
            FrmCámara formulario = new FrmCámara();
            formulario.Show();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = I;
        }
    }
}
