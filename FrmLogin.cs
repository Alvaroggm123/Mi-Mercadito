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
