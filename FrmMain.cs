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
        // ==================== || INICIO Variables || ==================== //
             
        // ==================== || FIN Variables || ==================== //

        // ==================== || INICIO Métodos || ==================== //

        // Creación de método para movimiento de ventana.
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        string[] DatosUsr;
        public FrmMain(System.Drawing.Image i, string[] Consulta)
        {
            DatosUsr = Consulta;
            InitializeComponent();
            // Se asigna el valor de la imagen de la foto a el picturebox de FrmMain.
            pboxCamara.Image = i;
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
        
        public void Autocompletar()
        {
           
            // Método autocompletar txtNombreProduc.
            string Consulta = (@"SELECT * FROM Producto ;"); // Se consulta la BD en la tabla Producto.
            using (SqlConnection Conn = ConnectionDB.StartConn())
            {
                DataTable Datos = new DataTable(); // Se obtienen los datos de la tabla.
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection(); // Se crea  el objeto [Lista] en base a la clase que general el autocompletar.
                SqlDataAdapter adaptador = new SqlDataAdapter(Consulta, Conn);
                adaptador.Fill(Datos); // Rellena los datos en base a los que se encuentran en la tabla Producto de la BD.
                // Ciclo for donde va leyendo fila por fila los datos que se relacionan con la tabla Producto.
                for (int i = 0; i < Datos.Rows.Count; i++)
                {
                    lista.Add(Datos.Rows[i]["prodName"].ToString()); // Se añaden los datos de la columna [prodName] y los pasa a tipo string.
                }
                txtNombreProduc.AutoCompleteCustomSource = lista; // Se autocompleta el textbox aplicando la propiedad [autocomplete] realizando la lectura de la lista.
            }
        }
        public void AutoCompletarMarca() 
        {
            // Método autocompletar txtProdMarc
            string Consulta = (@"SELECT * FROM Marca ;");
            using (SqlConnection Conn = ConnectionDB.StartConn())
            {
                DataTable Datos = new DataTable();
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                SqlDataAdapter adaptador = new SqlDataAdapter(Consulta, Conn);
                adaptador.Fill(Datos);

                for (int i = 0; i < Datos.Rows.Count; i++)
                {
                    lista.Add(Datos.Rows[i]["marcName"].ToString());
                }
                txtProdMarc.AutoCompleteCustomSource = lista;
            }
        }

        public void AutoCompletarDpto() 
        {
            // Método autocompletar txtProdDpto.
            string Consulta = (@"SELECT * FROM Departamento ;");
            using (SqlConnection Conn = ConnectionDB.StartConn())
            {
                DataTable Datos = new DataTable();
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                SqlDataAdapter adaptador = new SqlDataAdapter(Consulta, Conn);
                adaptador.Fill(Datos);

                for (int i = 0; i < Datos.Rows.Count; i++)
                {
                    lista.Add(Datos.Rows[i]["dptoName"].ToString());
                }
                txtProdDpto.AutoCompleteCustomSource = lista;
            }
        }
        
        public bool Bloqueo(string txtblockmarc)
        {
            // Función Bloqueo() que me indica cuando puedo modificar ciertos textbox dependiendo
            // de los datos introducidos por el usuario en el txtNombreProduc.
            string Consulta = @"SELECT * FROM Producto WHERE prodName = @prodName;";
            using (SqlConnection Conn = ConnectionDB.StartConn())
            {
                SqlCommand cmd = new SqlCommand(Consulta, Conn);
                cmd.Parameters.AddWithValue("@prodName", txtblockmarc);
                int Count = Convert.ToInt32(cmd.ExecuteScalar());
                return Count == 0;
            }
        }

        public string RellenarLista(string listadatos)
        {
            string Salida = "";
            string Consulta = @"SELECT DISTINCT prodName AS 'Producto' FROM MisProductos,Producto, MiCarrito WHERE mprodCar = '" + listadatos + "' AND mprodProd = prodId;";
            using (SqlConnection Conn = ConnectionDB.StartConn())
            {
                SqlCommand cmd = new SqlCommand(Consulta, Conn);
                //cmd.Parameters.AddWithValue("@mprodCar", listadatos);
                //* Lectura de datos.
                SqlDataReader Leer = cmd.ExecuteReader();
                while (Leer.Read())
                {
                    Salida = Leer["Producto"].ToString();
                    lboxListaMercado.Items.Add(Salida);
                }
                return "";

            }
        }

        // ==================== || FIN Métodos || ==================== //

        // ==================== || INICIO Eventos || ==================== //

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Sucursal sucursal = new Sucursal();
            sucursal.ConsultaSuc(cboxSucursal);
            Autocompletar();
            AutoCompletarMarca();
            AutoCompletarDpto();
            // Condicional donde si el picturebox no cuenta con una imagen dentro, mandará a enviar el logo de Mi mercadito.
            if (pboxCamara.Image == null)
            {
                pboxCamara.Image = Mi_mercadito.Properties.Resources.logomiMercadito;
            }
            string IdCarrito = "", NameList, Datos = "";

            Carrito Carro = new Carrito();
            if (!Carro.ValidarList(DatosUsr[0]))
            {
                IdCarrito = Carro.ConsultIdLista(DatosUsr[0]);
                NameList = Carro.ConsultNameList(IdCarrito);
                lblnomList.Text = NameList;
                Datos = RellenarLista(IdCarrito);
                lboxListaMercado.Items.Add(Datos.ToString());
            }
        }

        private void cmdFoto_Click(object sender, EventArgs e)
        {
            // Hace que al dar click en el botón tomar foto se habra el formulario de la cámara.
            FrmCamara Camara = new FrmCamara();
            Image Logo = Camara.pbox_Camara.Image;
            this.Enabled = false;
            if (Camara.ShowDialog() == DialogResult.OK)
                this.Show();
            this.Enabled = true; ;
            // Reasignamos en caso de que corresponda un cambio.
            if (Logo != pboxCamara.Image)
            {
                pboxCamara.Image = Camara.pbox_Camara.Image;
                Camara.pbox_Camara.Image = Logo;
            }
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            string IdMarca="", IdDepartamento="", IdSuc="";
            Marca Marc = new Marca();
            if (!Marc.ValidarMarc(txtProdMarc.Text))
            {
                IdMarca = Marc.ConsultId(txtProdMarc.Text);
            }
            else
            {
                Marc.InsertarMarc(txtProdMarc.Text, pboxCamara);
                IdMarca = Marc.ConsultId(txtProdMarc.Text);
            }

            Departamento Departamento = new Departamento();
            if (!Departamento.ValidarDepart(txtProdDpto.Text))
            {
                IdDepartamento = Departamento.ConsultId(txtProdDpto.Text);
            }
            else
            {
                MessageBox.Show("Ingrese un departamento válido", "Error departamento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            Sucursal Sucursal = new Sucursal();
            IdSuc = Sucursal.ConsultId(cboxSucursal.Text, txtPais.Text, txtCiudad.Text, txtDireccion.Text);

            Producto Productos = new Producto();
            if (Productos.InsertProductos(txtNombreProduc.Text, txtProdPrecio.Text, txtProdContNet.Text, txtProdDesc.Text, pboxCamara, IdMarca, IdDepartamento, IdSuc) > 0)
            {
                MessageBox.Show("Se ha guardado el producto de manera correcta.", "Producto guardado", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("No se ha guardado el producto de manera correcta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cboxSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] arreglo = new string[3]; // Se crea un arreglo que almacena 4 datos.
            Sucursal datos = new Sucursal(); // Se crea el objeto [datos] en base a la clase Sucursal.
            arreglo = datos.Datos(cboxSucursal.Text); // Se llama al método de la clase Sucursal, que tiene como parámetro el cboxSucursal.
            txtProdSuc.Text = cboxSucursal.Text; // Iguala los datos que se implemnten en las sucursales tanto en el textbox como el combobox.
            txtPais.Text = arreglo[1];
            txtCiudad.Text = arreglo[2];
            txtDireccion.Text = arreglo[3];
        }

        private void pnlLogin_MouseDown(object sender, MouseEventArgs e)
        {
            // Movimiento de pantalla.
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pbxX2_Click(object sender, EventArgs e)
        {
            // Cerrar ventana y programa.
            // MessageBox implementación de código.
            string Msg = "¿Desea salir?", Title = "Cancelar";
            if (MessageBox.Show(Msg, Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
                Application.Exit();
            }
        }

        private void pbxX_MouseHover(object sender, EventArgs e)
        {
            // Efectos del botón X.
            pbxX2.BackColor = Color.White;
            pbxX2.Visible = true;
        }

        private void pbxX_MouseLeave(object sender, EventArgs e)
        {
            // Efectos del botón X.
            pbxX.BackColor = Color.PaleTurquoise;
        }
        private void pbxX2_MouseLeave(object sender, EventArgs e)
        {
            // Efectos del botón X.
            pbxX2.Visible = false;
        }
        private void pbxmin2_Click(object sender, EventArgs e)
        {
            // Minimizar ventana.
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Minimized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void pbxmin_MouseHover(object sender, EventArgs e)
        {
            // Efectos del botón min
            pbxmin2.BackColor = Color.White;
            pbxmin2.Visible = true;
        }

        private void pbxmin_MouseLeave(object sender, EventArgs e)
        {
            // Efectos del botón min.
            pbxmin.BackColor = Color.PaleTurquoise;
        }

        private void pbxmin2_MouseLeave(object sender, EventArgs e)
        {
            pbxmin2.Visible = false;
        }

        
        private void iniciarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Cerrar ventana.
            string Msg = "¿Desea cerrar sesión?", Title = "Cancelar";
            if (MessageBox.Show(Msg, Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void cmdCargarImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog cargarImg = new OpenFileDialog();
            cargarImg.Filter = "Todas las imágenes soportadas|*.Jpeg;*.JPG;*.png;*.bmp;*.ico";
            cargarImg.InitialDirectory = System.IO.Path.GetTempPath();
            if (cargarImg.ShowDialog() == DialogResult.OK) pboxCamara.Load(cargarImg.FileName);
        }

        private void txtNombreProduc_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Tab)
            {
                //string[] arreglo = new string[7];
                //Producto datos = new Producto();
                //arreglo = datos.RellenarProduc(txtNombreProduc.Text);
                //txtProdPrecio.Text = arreglo[1];
                //txtProdContNet.Text = arreglo[2];
                //txtProdDesc.Text = arreglo[3];
                //txtProdMarc.Text = arreglo[4];
                //txtProdDpto.Text = arreglo[5];
                //txtProdSuc.Text = arreglo[6];
                //// Muestra la imágen del producto que esta almacenada en la base de datos
                //datos.Imagen(ref pbox_Camara, txtNombreProduc.Text);
                //// Hace que al presionar el TAB se modifique el combobox de la sucursal en base al del producto.
                //cboxSucursal.Text = txtProdSuc.Text;

                //if (txtNombreProduc.Text == "" || txtNombreProduc.Text == null)
                {
                    // MessageBox que obliga al usuario registrar un producto al usuario para que no rompa el programa al querer usar el TAB
                    //MessageBox.Show("Ingrese primero un producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //return;
                }
                //else
                {
                    //txtProdPrecio.Focus();
                }
            }
        }

        private void cmdCar_Click(object sender, EventArgs e)
        {
            // Variables para guardar ids
            string IdCarrito="", IdProducto="", IdSuc="",IdMarca="",IdDepartamento="" ;

            //  Validación de Carro, existencia de usuario, obtención de IdCarrito, IdSuc, IdMarca,
            //  IdDepartamento y IdProducto, y inserción de datos en tabla MisProductos
            Carrito Carro = new Carrito();
            if (!Carro.ValidarList(DatosUsr[0]))
            {
                IdCarrito = Carro.ConsultIdLista(DatosUsr[0]);
            }

            Sucursal Sucursal = new Sucursal();
            IdSuc = Sucursal.ConsultId(cboxSucursal.Text, txtPais.Text, txtCiudad.Text, txtDireccion.Text);
            
            Marca Marc = new Marca();
            if (!Marc.ValidarMarc(txtProdMarc.Text))
            {
                IdMarca = Marc.ConsultId(txtProdMarc.Text);
                lboxListaMercado.Items.ToString();
            }
            else
            {
                MessageBox.Show("No ha registrado la marca.", "Error Marca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            Departamento Departamento = new Departamento();
            if (!Departamento.ValidarDepart(txtProdDpto.Text))
            {
                IdDepartamento = Departamento.ConsultId(txtProdDpto.Text);
            }
            else
            {
                MessageBox.Show("Ingrese un departamento válido", "Error departamento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            Producto Prod = new Producto();
            IdProducto = Prod.ConsultIdProducto(txtNombreProduc.Text, txtProdPrecio.Text, txtProdContNet.Text, txtProdDesc.Text, IdMarca, IdDepartamento, IdSuc);

            MisProductos MiProd = new MisProductos();
            MiProd.InsertarMisProductos(IdCarrito, IdProducto);

            if (!Bloqueo(txtNombreProduc.Text))
            {
                int id = 1;
                string listaprod = Convert.ToString(id);
                // Condicional que indica que si el método [Bloqueo] es igual tanto el parámetro [txtNombreProduc.Text] al ["prodName"].
                if (lboxListaMercado.Items.ToString() != txtNombreProduc.Text.ToString())
                {
                    lboxListaMercado.Items.Add(txtNombreProduc.Text.ToString()); // Se almacena el valor del [txtNombreProduc.Text] al [lboxListaMercado]. 

                }
                else if (lboxListaMercado.Items.ToString() == txtNombreProduc.Text.ToString())
                {
                    //int i = 0;
                    //foreach (var item in i.ToString())
                    //{
                    //    lboxListaMercado.Items.Add(txtNombreProduc.Text.ToString());
                    //}
                }
            }
            else
                MessageBox.Show("Ingrese un Producto", "Error Producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            MessageBox.Show("Producto agregado al carrito correctamente", "Producto agregado", MessageBoxButtons.OK);
        }

        private void txtNombreProduc_Leave(object sender, EventArgs e)
        {
            try
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
                datos.Imagen(ref pboxCamara, txtNombreProduc.Text); // Muestra la imagen del producto que esta almacenada en la base de datos.
                cboxSucursal.Text = txtProdSuc.Text; // Hace que al presionar [TAB] se modifique el combobox de la sucursal en base a la del producto.
            }
            catch (Exception)
            {
                //MessageBox.Show("Ingrese primero un producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return;
            }
        }

        private void txtNombreProduc_TextChanged(object sender, EventArgs e)
        {
            if (!Bloqueo(txtNombreProduc.Text))
            {
                txtProdMarc.ReadOnly = true;
                txtProdDpto.ReadOnly = true;
                txtProdDesc.ReadOnly = true;
            }
            else
            {
                txtProdMarc.ReadOnly = false;
                txtProdDpto.ReadOnly = false;
                txtProdDesc.ReadOnly = false;
                pboxCamara.Image = Mi_mercadito.Properties.Resources.logomiMercadito;
            }
        }

        private void cmdSlide_Click(object sender, EventArgs e)
        {
            // Ocultar la lista.
            lboxListaMercado.Visible = false;
            cmdSlide.Visible = false;

            // Mover la foto.
            pboxCamara.Size = new Size(359, 329);
            pboxCamara.Location = new Point(28,95);
        }

        private void cmdSlide2_Click(object sender, EventArgs e)
        {
            // Mostrar la lista.
            lboxListaMercado.Visible = true;
            cmdSlide.Visible = true;

            // Mover la foto.
            pboxCamara.Size = new Size(231, 329);
            pboxCamara.Location = new Point(158, 96);
        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }
        // ==================== || FIN Eventos || ==================== //
    }
}
