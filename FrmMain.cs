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

        public FrmMain()
        {
        }

        private bool ErrorMessage(string Grupo, string Mensaje, Control Enfoque)
        {
            string Titulo = "Error en " + Grupo;
            MessageBox.Show(Mensaje, Titulo);
            Enfoque.Focus();
            return false;
        }

        public void AutocompletarTxt(string Consulta, TextBox Elemento)
        {
            // Método autocompletar txtProdMarc
            string Command = (@"SELECT * FROM " + Consulta + " ;");
            using (SqlConnection Conn = ConnectionDB.StartConn())
            {
                DataTable Datos = new DataTable();
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                SqlDataAdapter Adapter = new SqlDataAdapter(Command, Conn);
                Adapter.Fill(Datos);

                for (int i = 0; i < Datos.Rows.Count; i++)
                {
                    lista.Add(Datos.Rows[i][1].ToString());
                }
                if (Elemento is TextBox)
                    Elemento.AutoCompleteCustomSource = lista;
            }
        }
        public void AutocompletarTxt(string Consulta, TextBox Elemento, int Columna)
        {
            // Método autocompletar txtProdMarc
            string Command = (@"SELECT * FROM " + Consulta + " ;");
            using (SqlConnection Conn = ConnectionDB.StartConn())
            {
                DataTable Datos = new DataTable();
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                SqlDataAdapter Adapter = new SqlDataAdapter(Command, Conn);
                Adapter.Fill(Datos);

                for (int i = 0; i < Datos.Rows.Count; i++)
                {
                    lista.Add(Datos.Rows[i][Columna].ToString());
                }
                if (Elemento is TextBox)
                    Elemento.AutoCompleteCustomSource = lista;
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
            double total = 0;
            string Salida = "", Salida2 = "", Salida3 = "", auxPrice = "", auxCantidad = "";
            string Consulta = @"SELECT DISTINCT prodName AS 'Producto', prodPrice AS 'prodPrice', mprodCantidad AS 'mprodCantidad' FROM MisProductos,Producto, MiCarrito WHERE mprodCar = '" + listadatos + "' AND mprodProd = prodId;";
            using (SqlConnection Conn = ConnectionDB.StartConn())
            {
                SqlCommand cmd = new SqlCommand(Consulta, Conn);
                //* Lectura de datos.
                SqlDataReader Leer = cmd.ExecuteReader();
                while (Leer.Read())
                {
                    Salida = Leer["Producto"].ToString();
                    ListViewItem Producto = new ListViewItem(Convert.ToString(Salida));
                    Salida2 = Leer["mprodCantidad"].ToString();
                    Producto.SubItems.Add(Salida2);
                    // Guardado de cantidad y precio + multiplicación 
                    auxCantidad = Leer["mprodCantidad"].ToString();
                    auxPrice = Leer["prodPrice"].ToString();
                    total = Convert.ToInt32(auxCantidad) * Convert.ToDouble(auxPrice);
                    Salida3 = total.ToString();
                    Producto.SubItems.Add(Salida3);
                    lviewProducto.Items.Add(Producto);
                }
                return "";
            }
        }
        void RellenaSucursal(string SucursalAutocompletar)
        {
            string[] arreglo = new string[3]; // Se crea un arreglo que almacena 4 datos.
            Sucursal datos = new Sucursal(); // Se crea el objeto [datos] en base a la clase Sucursal.
            arreglo = datos.Datos(SucursalAutocompletar); // Se llama al método de la clase Sucursal, que tiene como parámetro el cboxSucursal.
            cboxSucursal.Text = arreglo[0];
            txtPais.Text = arreglo[1];
            txtCiudad.Text = arreglo[2];
            txtDireccion.Text = arreglo[3];
        }
        void AutocompletarFormulario(string Producto)
        {
            // Método que autocompleta los campos del Frm Main
            Producto datos = new Producto();
            string[] arreglo = datos.RellenarProduc(Producto);
            txtNombreProduc.Text = arreglo[0];
            txtProdPrecio.Text = arreglo[1];
            txtProdContNet.Text = arreglo[2];
            txtProdDesc.Text = arreglo[3];
            txtProdMarc.Text = arreglo[4];
            cboxProdDpto.Text = arreglo[5];
            datos.ImagenDpto(ref pboxDpto, cboxProdDpto.Text);
            cboxSucursal.Text = arreglo[6];
            datos.Imagen(ref pboxCamara, txtNombreProduc.Text); // Muestra la imagen del producto que esta almacenada en la base de datos.
            RellenaSucursal(cboxSucursal.Text);
        }

        public string SumaPrecio()
        {
            // Función SumaPrecio que realiza un ciclo for con el cual lee los elementos del [lviewProducto] en base a la columna Precio.
            string SumPrecio = "";
            double Suma = 0;
            for (int i = 0; i < lviewProducto.Items.Count; i++)
            {
                if (lviewProducto.Items[i].SubItems[0].Text != "")
                {
                    Suma += double.Parse(lviewProducto.Items[i].SubItems[2].Text); // Realiza la suma de los datos de la columan Precio.
                }
            }
            return SumPrecio = Suma.ToString(); // Retorna el valor de la suma total.
        }
        // ==================== || FIN Métodos || ==================== //

        // ==================== || INICIO Eventos || ==================== //

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Sucursal sucursal = new Sucursal();
            sucursal.ConsultaSuc(cboxSucursal);
            Departamento dpto = new Departamento();
            AutocompletarTxt("Marca", txtProdMarc);
            AutocompletarTxt("Producto", txtNombreProduc);
            dpto.ConsultaDpto(cboxProdDpto);
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
                txtnomList.Text = NameList;
                Datos = RellenarLista(IdCarrito);
                lviewProducto.Items.Add(Datos.ToString());
            }
            txtTotalCompra.Text = string.Concat(txtTotalCompra.Text, " " + SumaPrecio()); // Se manda llamar a la función [SumaPrecio].
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
            // Variables para guardar Ids
            string IdMarca = "", IdDepartamento = "", IdSuc = "";
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
            if (!Departamento.ValidarDepart(cboxProdDpto.Text))
            {
                IdDepartamento = Departamento.ConsultId(cboxProdDpto.Text);
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
            RellenaSucursal(cboxSucursal.Text);
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
            pbxX.BackColor = Color.SteelBlue;
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
            pbxmin.BackColor = Color.SteelBlue;
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

        private void cmdCar_Click(object sender, EventArgs e)
        {
            if (txtNombreProduc.Text == "" || txtProdPrecio.Text == "" || txtProdContNet.Text == "" || txtProdMarc.Text == "" || cboxProdDpto.Text == "")
                ErrorMessage("Datos del producto", "Debe llenar todos los datos del producto.", txtNombreProduc);
            else
            {
                // Variables para guardar ids
                string IdCarrito = "", IdProducto = "", IdSuc = "", IdMarca = "", IdDepartamento = "";

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
                }
                else
                {
                    MessageBox.Show("No ha registrado la marca.", "Error Marca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                Departamento Departamento = new Departamento();
                if (!Departamento.ValidarDepart(cboxProdDpto.Text))
                {
                    IdDepartamento = Departamento.ConsultId(cboxProdDpto.Text);
                }
                else
                {
                    MessageBox.Show("Ingrese un departamento válido", "Error departamento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                Producto Prod = new Producto();
                IdProducto = Prod.ConsultIdProducto(txtNombreProduc.Text, txtProdPrecio.Text, txtProdContNet.Text, txtProdDesc.Text, IdMarca, IdDepartamento, IdSuc);

                MisProductos MiProd = new MisProductos();
                if (!MiProd.ValidarContador(IdCarrito, IdProducto))
                {
                    string[] DatosMisProd = new string[4];
                    DatosMisProd = MiProd.ConsultaDatosMiProd(IdCarrito, IdProducto);
                    int r = 0;
                    r = Convert.ToInt32(DatosMisProd[2]) + 1;
                    MiProd.ActualizarCantidad(IdCarrito, IdProducto, r);
                }
                else
                {

                    MiProd.InsertarMisProductos(IdCarrito, IdProducto);
                }
                string Datos = "";
                lviewProducto.Items.Clear();
                Datos = RellenarLista(IdCarrito);
                lviewProducto.Items.Add(Datos.ToString());
                txtTotalCompra.Text = "Total: $";
                txtTotalCompra.Text = string.Concat(txtTotalCompra.Text, " " + SumaPrecio());
            }
        }

        private void txtNombreProduc_Leave(object sender, EventArgs e)
        {
            Producto Prod = new Producto();
            try
            {
                if (!Prod.Validar(txtNombreProduc.Text))
                    AutocompletarFormulario(txtNombreProduc.Text); // Se manda llamar al Método que se rellena desde el [txtNombreProduc]. 
            }
            catch (Exception)
            {
                //MessageBox.Show("Ingrese primero un producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return;
            }
        }

        private void txtNombreProduc_TextChanged(object sender, EventArgs e)
        {
            if (!Bloqueo(txtNombreProduc.Text) || txtNombreProduc.Text == "")
            {
                txtProdMarc.ReadOnly = true;
                cboxProdDpto.Enabled = false;
                txtProdDesc.ReadOnly = true;
            }
            else
            {
                txtProdMarc.ReadOnly = false;
                cboxProdDpto.Enabled = true;
                txtProdDesc.ReadOnly = false;
                pboxCamara.Image = Mi_mercadito.Properties.Resources.logomiMercadito;
            }
        }

        private void cmdSlide_Click(object sender, EventArgs e)
        {
            // Ocultar la lista.
            lviewProducto.Visible = false;
            cmdSlide.Visible = false;
            txtTotalCompra.Visible = false;
            cmdEliminar.Visible = false;
            txtnomList.Visible = false;

            // Mover la foto.
            pboxCamara.Size = new Size(pboxCamara.Width + 195, pboxCamara.Height);
            pboxCamara.Location = new Point(pboxCamara.Location.X - 195, pboxCamara.Location.Y);

            // Mover el botón.
            cmdCargarImg.Size = new Size(cmdCargarImg.Width + 195, cmdCargarImg.Height);
            cmdCargarImg.Location = new Point(cmdCargarImg.Location.X - 195, cmdCargarImg.Location.Y);

            // Mover el lblDescription
            lblProdDesc.Location = new Point(lblProdDesc.Location.X - 85, lblProdDesc.Location.Y);

            // Mover el txtProdDesc
            txtProdDesc.Size = new Size(txtProdDesc.Width + 85, txtProdDesc.Height);
            txtProdDesc.Location = new Point(txtProdDesc.Location.X - 85, txtProdDesc.Location.Y);

            // Mover el txtTotalCompra.
            txtTotalCompra.Size = new Size(txtTotalCompra.Width + 85, txtTotalCompra.Height);
            txtTotalCompra.Location = new Point(txtTotalCompra.Location.X - 85, txtTotalCompra.Location.Y);
        }

        private void cmdSlide2_Click(object sender, EventArgs e)
        {
            // Mostrar la lista.
            lviewProducto.Visible = true;
            cmdSlide.Visible = true;
            txtTotalCompra.Visible = true;
            cmdEliminar.Visible = true;
            txtnomList.Visible = true;

            // Mover la foto.
            pboxCamara.Size = new Size(pboxCamara.Width - 195, pboxCamara.Height);
            pboxCamara.Location = new Point(pboxCamara.Location.X + 195, pboxCamara.Location.Y);

            // Mover el botón.
            cmdCargarImg.Size = new Size(cmdCargarImg.Width - 195, cmdCargarImg.Height);
            cmdCargarImg.Location = new Point(cmdCargarImg.Location.X + 195, cmdCargarImg.Location.Y);

            // Mover el lblDescription
            lblProdDesc.Location = new Point(lblProdDesc.Location.X + 85, lblProdDesc.Location.Y);

            // Mover el txtProdDesc
            txtProdDesc.Size = new Size(txtProdDesc.Width - 85, txtProdDesc.Height);
            txtProdDesc.Location = new Point(txtProdDesc.Location.X + 85, txtProdDesc.Location.Y);

            // Mover el txtTotalCompra
            txtTotalCompra.Size = new Size(txtTotalCompra.Width - 85, txtTotalCompra.Height);
            txtTotalCompra.Location = new Point(txtTotalCompra.Location.X + 85, txtTotalCompra.Location.Y);
        }
        private void lviewProducto_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Producto datos = new Producto();
            for (int i = 0; i < lviewProducto.Items.Count; i++)
            {
                if (lviewProducto.Items[i].Selected)
                {
                    AutocompletarFormulario(lviewProducto.Items[i].SubItems[0].Text); // Se manda llamar al Método que se rellena desde el [lviewProducto].
                }
            }
        }

        // Cambio del nombre de la lista
        private void txtnomList_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                Carrito Carro = new Carrito();
                Carro.ActualizarLista(DatosUsr[0], txtnomList.Text);
            }
            catch (Exception)
            {

            }
        }

        private void cmdEliminar_Click(object sender, EventArgs e)
        {
            // Condición de selecciones de campos autorrellenados para las eliminaciones
            foreach (ListViewItem Lprod in lviewProducto.SelectedItems)
            {
                Lprod.Selected = true;

                if (txtNombreProduc.Text == "" || txtProdPrecio.Text == "" || txtProdContNet.Text == "" || txtProdMarc.Text == "" || cboxProdDpto.Text == "" || Lprod.Selected == false)
                    ErrorMessage("producto no seleccionado", "Debe seleccionar un producto de la lista.", txtNombreProduc);
                else
                {
                    // Variables para guardar ids
                    string IdCarrito = "", IdProducto = "", IdSuc = "", IdMarca = "", IdDepartamento = "";

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
                    }
                    else
                    {
                        MessageBox.Show("No ha registrado la marca.", "Error Marca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    Departamento Departamento = new Departamento();
                    if (!Departamento.ValidarDepart(cboxProdDpto.Text))
                    {
                        IdDepartamento = Departamento.ConsultId(cboxProdDpto.Text);
                    }
                    else
                    {
                        MessageBox.Show("Ingrese un departamento válido", "Error departamento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    Producto Prod = new Producto();
                    IdProducto = Prod.ConsultIdProducto(txtNombreProduc.Text, txtProdPrecio.Text, txtProdContNet.Text, txtProdDesc.Text, IdMarca, IdDepartamento, IdSuc);

                    MisProductos MiProd = new MisProductos();
                    
                    if (!MiProd.ValidarContador(IdCarrito, IdProducto))  // Validación de contador de productos
                    {
                        string[] DatosMisProd = new string[4];  // Datos del Mis productos
                        DatosMisProd = MiProd.ConsultaDatosMiProd(IdCarrito, IdProducto);
                        int r = 0;
                        if (Convert.ToInt32(DatosMisProd[2]) > 1)
                        {
                            r = Convert.ToInt32(DatosMisProd[2]) - 1; // Contador de resta
                            MiProd.ActualizarCantidad(IdCarrito, IdProducto, r);
                        }
                        else if (Convert.ToInt32(DatosMisProd[2]) == 1) // Condición de eliminación
                        {
                            MiProd.EliminarProdMiList(IdCarrito, IdProducto);  // Eliminación del productos
                            /* |==| Limpieza de textbox |==| */
                            txtNombreProduc.Clear();
                            txtProdPrecio.Clear();
                            txtProdContNet.Clear();
                            txtProdMarc.Clear();    txtProdMarc.Enabled = true;
                            cboxProdDpto.ResetText();
                            txtProdDesc.Clear();
                            cboxProdDpto.ResetText();
                            Prod.ImagenDpto(ref pboxDpto, "Otros");
                        }
                    }
                    else
                    {}
                    // Limpieza y actualización de la base de datos y sus resultados
                    string Datos = "";
                    lviewProducto.Items.Clear();
                    Datos = RellenarLista(IdCarrito);
                    lviewProducto.Items.Add(Datos.ToString());
                    txtTotalCompra.Text = "Total: $";
                    txtTotalCompra.Text = string.Concat(txtTotalCompra.Text, " " + SumaPrecio());
                }
            }
        }

        private void cboxProdDpto_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Evento que al seleccionar una opción del [cboxProdDpto] del [Departamento] cambie la imágen del [pboxDpto].
            Producto datos = new Producto();
            datos.ImagenDpto(ref pboxDpto, cboxProdDpto.Text);
        }
        // ==================== || FIN Eventos || ==================== //
    }
}
