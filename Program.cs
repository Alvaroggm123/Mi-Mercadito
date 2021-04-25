using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Data;

namespace Mi_mercadito
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmLogin());
        }
    }
    // Clase que permitirá obtener los valores del usuario a registrar.
    public class Usuarios
    {
        public string Username { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public DateTime Birth { get; set; }
        public char Sex { get; set; }
        public string Paswrd { get; set; }
        public string Email { get; set; }
        // Constructor genérico.
        public Usuarios() { }

        // Constructor sobrecargado.
        public Usuarios(string Username, string Fname, string Lname, DateTime Birth, char Sex, string Email, string Paswrd)
        {
            this.Username = Username;
            this.Fname = Fname;
            this.Lname = Lname;
            this.Birth = Birth;
            this.Sex = Sex;
            this.Email = Email;
            this.Paswrd = Paswrd;
        }
        public int Insertar(Usuarios UsuarioReg)
        {
            using (SqlConnection Conn = ConnectionDB.StartConn())
            {
                // Variable para formato de la base de datos año, mes y día.
                string Format = "yyyy-MM-dd";

                SqlCommand Comando = new SqlCommand(
                    string.Format("INSERT INTO Users (usrUsrname, usrFname, usrLname, usrBirth, usrSex, usrEmail, usrPswrd, usrRegDate) " +
                    "VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')",
                    UsuarioReg.Username,
                    UsuarioReg.Fname,
                    UsuarioReg.Lname,
                    //* Fecha de nacimiento a string con formato de base de datos.
                    UsuarioReg.Birth.ToString(Format),
                    UsuarioReg.Sex,
                    UsuarioReg.Email,
                    UsuarioReg.Paswrd,
                    //* Fecha de día de registro a string con formato de la base de datos.
                    DateTime.Today.ToString(Format)), Conn);
                return Comando.ExecuteNonQuery();
            }
        }
        public int InsertList(string usrRegDate, string usrUsrname)
        {
            using (SqlConnection Conn = ConnectionDB.StartConn())
            {
                SqlCommand Comando = new SqlCommand("INSERT INTO MiCarrito VALUES (@mcarName,@mcarDate,@mcarUsr)", Conn);
                Comando.Parameters.Add("@mcarName", SqlDbType.NVarChar);
                Comando.Parameters.Add("@mcarDate", SqlDbType.DateTime);
                Comando.Parameters.Add("@mcarUsr", SqlDbType.NVarChar);

                Comando.Parameters["@mcarName"].Value = "Mi lista";
                Comando.Parameters["@mcarDate"].Value = usrRegDate;
                Comando.Parameters["@mcarUsr"].Value = usrUsrname;

                return Comando.ExecuteNonQuery();
            }
        }

        public bool Validar(string Username)
        {
            string Consulta = @"SELECT COUNT(*) FROM Users WHERE usrUsrname = @usrUsrname ; ";
            using (SqlConnection Conn = ConnectionDB.StartConn())
            {
                SqlCommand cmd = new SqlCommand(Consulta, Conn);
                cmd.Parameters.AddWithValue("@usrUsrname ", Username);
                int Count = Convert.ToInt32(cmd.ExecuteScalar());
                return Count == 0;
            }
        }
        // Consulta de datos de usuario. 
        public string[] ConsultaT(string Username)
        {
            string[] Salida = new string[7];
            string Consulta = @"SELECT usrUsrname, usrFname, usrLname, usrEmail, usrSex, usrBirth,usrRegDate FROM Users WHERE usrUsrname = @usrUsrname;";
            using (SqlConnection Conn = ConnectionDB.StartConn())
            {
                SqlCommand cmd = new SqlCommand(Consulta, Conn);
                cmd.Parameters.AddWithValue("@usrUsrname ", Username);
                //* Lectura de datos.
                SqlDataReader Leer = cmd.ExecuteReader();
                if (Leer.Read())
                {
                    Salida[0] = Leer["usrUsrname"].ToString();
                    Salida[1] = Leer["usrFname"].ToString();
                    Salida[2] = Leer["usrLname"].ToString();
                    Salida[3] = Leer["usrEmail"].ToString();
                    Salida[4] = Leer["usrSex"].ToString();
                    Salida[5] = Leer["usrBirth"].ToString();
                    Salida[6] = Leer["usrRegDate"].ToString();

                }
                return Salida;
            }

        }

        public int InsertarCarrito(PictureBox pb)
        {
            using (SqlConnection Conn = ConnectionDB.StartConn())
            {
                SqlCommand Comando = new SqlCommand("INSERT INTO Imagen VALUES (@img)", Conn);
                Comando.Parameters.Add("@img", SqlDbType.Image);

                MemoryStream ms = new MemoryStream();
                pb.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                Comando.Parameters["@img"].Value = ms.GetBuffer();

                return Comando.ExecuteNonQuery();
            }
        }
        public bool Login(string Username, string Password)
        {
            string Consulta = @"SELECT COUNT(*) FROM Users WHERE usrUsrname = @usrUsrname AND usrPswrd = @usrPswrd; ";
            using (SqlConnection Conn = ConnectionDB.StartConn())
            {
                SqlCommand cmd = new SqlCommand(Consulta, Conn);
                cmd.Parameters.AddWithValue("@usrUsrname ", Username);
                cmd.Parameters.AddWithValue("@usrPswrd ", Password);
                int Count = Convert.ToInt32(cmd.ExecuteScalar());
                return Count == 0;
            }
        }
    }
    // Creamos clase que permite la conexión con la base de datos.
    public class ConnectionDB
    {
        public static SqlConnection StartConn()
        {
            // Configuración de los parámetros para conectar con la base de datos.
            string[] Config = { "Data Source = mercadito.axolotlteam.com;",
            /*                 */"Initial Catalog=Mercadito;",
            /*                 */"User Id=Mercader;",
            /*                 */"Password=Mercadito3312"};
            string Connection = Config[0] + Config[1] + Config[2] + Config[3];
            SqlConnection Conn = new SqlConnection(Connection);
            Conn.Open();
            return Conn;
        }
    }

    public class Sucursal //creacion de clase sucursal
    {
        public int ConsultaSuc(ComboBox cboxTienda) //creacion de método ConsultaSuc
        {
            cboxTienda.Items.Clear();  // limpia los items que se encuentran en el Combobox
            int a = 0; //variable auxiliar "a"
            string Consulta = (@"SELECT * FROM Sucursal;"); // consulta los elementos de la tabla de la BD de la Sucursal
            using (SqlConnection Conn = ConnectionDB.StartConn()) 
            {
                SqlCommand cm = new SqlCommand(Consulta,Conn);
                SqlDataReader dr = cm.ExecuteReader(); // lee los elementos de la tabla de la BD de Sucursal
                while (dr.Read())
                {
                    a = cboxTienda.Items.Add(dr.GetString(1)); // añade los items de la BD Sucursal en el cboxTienda
                }                
            }
            return a; // retorna el valor seleccionado por el usuario en el cboxTienda
        }

        public string[] Datos(string cboxSucursal ) //creacion de un metodo en base a un arreglo con el parámetro cboxSucursal
        {
            string[] Salida = new string[4]; // el arreglo Salida es de 4 datos de lectura ya que también lee la posición del IDSuc de la BD
            string Consulta = (@"SELECT * FROM Sucursal WHERE sucName = @sucName;");
            using (SqlConnection Conn = ConnectionDB.StartConn()) 
            {
                SqlCommand cm = new SqlCommand(Consulta,Conn);
                cm.Parameters.AddWithValue("@sucName ", cboxSucursal);
                SqlDataReader Leer = cm.ExecuteReader();
                if (Leer.Read())
                {
                    //se realiza la lectura de la columna de la tabla e identifica que la posición del cboxSucursal coincida con la de los 
                    //datos de la tabla
                    Salida[0] = Leer["sucName"].ToString();                    
                    Salida[1] = Leer["sucPais"].ToString();
                    Salida[2] = Leer["sucCity"].ToString();
                    Salida[3] = Leer["sucDirec"].ToString();
                }                
            }
            return Salida;
        }
        // Consulta del Id de la Sucursal
        public string ConsultId(string sucName, string sucPais, string sucCity, string sucDirec)
        {
            string Salida = "";
            string Consulta = @"SELECT * FROM Sucursal WHERE sucName = @sucName AND sucPais = @sucPais AND sucCity = @sucCity AND sucDirec = @sucDirec;";
            using (SqlConnection Conn = ConnectionDB.StartConn())
            {
                SqlCommand cmd = new SqlCommand(Consulta, Conn);
                cmd.Parameters.AddWithValue("@sucName", sucName);
                cmd.Parameters.AddWithValue("@sucPais", sucPais);
                cmd.Parameters.AddWithValue("@sucCity", sucCity);
                cmd.Parameters.AddWithValue("@sucDirec", sucDirec);
                //* Lectura de datos.
                SqlDataReader Leer = cmd.ExecuteReader();
                if (Leer.Read())
                {
                    Salida = Leer["sucId"].ToString();
                }
                return Salida;
            }
        }
    }

    class Producto 
    {
        public string [] RellenarProduc(string nombreProduc)
        {
            string[] datoProduc = new string[7];
            string Consulta = (@"SELECT prodName, prodPrice, prodContNet, prodDesc, marcName, dptoName, sucName FROM  Producto, Marca, Departamento, Sucursal" +
            " WHERE prodName = @prodName AND prodMarc= marcId AND prodSuc=sucId AND prodDpto=dptoId ;");
            using (SqlConnection Conn = ConnectionDB.StartConn())
            {
                SqlCommand cm = new SqlCommand(Consulta, Conn);
                cm.Parameters.AddWithValue("@prodName",nombreProduc);
                SqlDataReader Leer = cm.ExecuteReader();
                if (Leer.Read())
                {
                    datoProduc[0] = Leer["prodName"].ToString();
                    datoProduc[1] = Leer["prodPrice"].ToString();
                    datoProduc[2] = Leer["prodContNet"].ToString();
                    datoProduc[3] = Leer["prodDesc"].ToString();
                    datoProduc[4] = Leer["marcName"].ToString();
                    datoProduc[5] = Leer["dptoName"].ToString();
                    datoProduc[6] = Leer["sucName"].ToString();
                }
                return datoProduc;
            }
        }
        // Inserción de imagen
        public void Imagen(ref PictureBox pbImagen, string nombreProducto)
        {
            string Consulta = @"SELECT prodPic FROM Producto WHERE prodName=@prodPic";
            using (SqlConnection Conn = ConnectionDB.StartConn())
            {
                SqlCommand cm = new SqlCommand(Consulta, Conn);
                cm.Parameters.AddWithValue("@prodPic", nombreProducto);

                SqlDataAdapter dp = new SqlDataAdapter(cm);
                DataSet ds = new DataSet();
                dp.Fill(ds, "Producto");

                byte[] Datos = new byte[0];
                DataRow dr = ds.Tables["Producto"].Rows[0];
                Datos = (byte[])dr["prodPic"];
                MemoryStream ms = new MemoryStream(Datos);
                pbImagen.Image = System.Drawing.Bitmap.FromStream(ms);
            }
        }

        // Inserción de nuevos productos
        public int InsertProductos(string prodName, string prodPrice, string prodContNet, string prodDesc, PictureBox pb, string prodMarc, string prodDpto, string prodSuc)
        {
            using (SqlConnection Conn = ConnectionDB.StartConn())
            {
                SqlCommand Comando = new SqlCommand("INSERT INTO Producto VALUES (@prodName,@prodPrice,@prodContNet,@prodDesc,@prodPic,@prodMarc,@prodDpto,@prodSuc)", Conn);
                Comando.Parameters.Add("@prodName", SqlDbType.NVarChar);
                Comando.Parameters.Add("@prodPrice", SqlDbType.Decimal);
                Comando.Parameters.Add("@prodContNet", SqlDbType.Decimal);
                Comando.Parameters.Add("@prodDesc", SqlDbType.NVarChar);
                Comando.Parameters.Add("@prodPic", SqlDbType.Image);
                Comando.Parameters.Add("@prodMarc", SqlDbType.Int);
                Comando.Parameters.Add("@prodDpto", SqlDbType.Int);
                Comando.Parameters.Add("@prodSuc", SqlDbType.Int);


                Comando.Parameters["@prodName"].Value = prodName;
                Comando.Parameters["@prodPrice"].Value = prodPrice;
                Comando.Parameters["@prodContNet"].Value = prodContNet;
                Comando.Parameters["@prodDesc"].Value = prodDesc;

                MemoryStream ms = new MemoryStream();
                pb.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                Comando.Parameters["@prodPic"].Value = ms.GetBuffer();

                Comando.Parameters["@prodMarc"].Value = prodMarc;
                Comando.Parameters["@prodDpto"].Value = prodDpto;
                Comando.Parameters["@prodSuc"].Value = prodSuc;
                return Comando.ExecuteNonQuery();
            }
        }
        // Consulta del Id de la tabla Producto
        public string ConsultIdProducto(string ProdName, string prodPrice, string prodContNet, string Desc, string MarcId, string DepartamentoId, string SucId)
        {
            string Salida = "";
            string Consulta = @"SELECT prodId FROM Producto WHERE prodName=@prodName AND prodPrice=@prodPrice AND prodContNet=@prodContNet AND prodDesc=@prodDesc AND prodMarc=@prodMarc AND prodDpto=@prodDpto AND prodSuc=@prodSuc;";
            using (SqlConnection Conn = ConnectionDB.StartConn())
            {
                SqlCommand cmd = new SqlCommand(Consulta, Conn);
                cmd.Parameters.AddWithValue("@prodName", ProdName);
                cmd.Parameters.AddWithValue("@prodPrice", prodPrice); 
                cmd.Parameters.AddWithValue("@prodContNet", prodContNet); 
                cmd.Parameters.AddWithValue("@prodDesc", Desc);
                cmd.Parameters.AddWithValue("@prodMarc", MarcId);
                cmd.Parameters.AddWithValue("@prodDpto", DepartamentoId);
                cmd.Parameters.AddWithValue("@prodSuc", SucId);

                //* Lectura de datos.
                SqlDataReader Leer = cmd.ExecuteReader();
                if (Leer.Read())
                {
                    Salida = Leer["prodId"].ToString();
                }
                return Salida;
            }
        }
    }
    class Marca
    {
        // Validar existencia de la Marca
        public bool ValidarMarc(string Marca)
        {
            string Consulta = @"SELECT COUNT(*) FROM Marca WHERE marcName = @marcName ; ";
            using (SqlConnection Conn = ConnectionDB.StartConn())
            {
                SqlCommand cmd = new SqlCommand(Consulta, Conn);
                cmd.Parameters.AddWithValue("@marcName", Marca);
                int Count = Convert.ToInt32(cmd.ExecuteScalar());
                return Count == 0;
            }
        }
        // Consulta del Id de la Marca
        public string ConsultId(string MarcName)
        {
            string Salida="";
            string Consulta = @"SELECT marcId FROM Marca WHERE marcName = @marcName;";
            using (SqlConnection Conn = ConnectionDB.StartConn())
            {
                SqlCommand cmd = new SqlCommand(Consulta, Conn);
                cmd.Parameters.AddWithValue("@marcName", MarcName);
                //* Lectura de datos.
                SqlDataReader Leer = cmd.ExecuteReader();
                if (Leer.Read())
                {
                    Salida = Leer["marcId"].ToString();              
                }
                return Salida;
            }
        }

        // Insertar Marca
        public int InsertarMarc(string MarcaName, PictureBox Imagen)
        {
            using (SqlConnection Conn = ConnectionDB.StartConn())
            {
                SqlCommand Comando = new SqlCommand("INSERT INTO Marca VALUES (@marcName,@marcPic)", Conn);
                Comando.Parameters.Add("@marcName", SqlDbType.NVarChar);
                Comando.Parameters.Add("@marcPic", SqlDbType.Image);

                Comando.Parameters["@marcName"].Value = MarcaName;

                MemoryStream ms = new MemoryStream();
                Imagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                Comando.Parameters["@marcPic"].Value = ms.GetBuffer();

                return Comando.ExecuteNonQuery();
            }
        }
    }

   class Departamento
    {
        // Validar existencia de departamento
        public bool ValidarDepart(string Depart)
        {
            string Consulta = @"SELECT COUNT(*) FROM Departamento WHERE dptoName = @dptoName ; ";
            using (SqlConnection Conn = ConnectionDB.StartConn())
            {
                SqlCommand cmd = new SqlCommand(Consulta, Conn);
                cmd.Parameters.AddWithValue("@dptoName", Depart);
                int Count = Convert.ToInt32(cmd.ExecuteScalar());
                return Count == 0;
            }
        }
        // Consulta del Id del Departamento
        public string ConsultId(string dptoName)
        {
            string Salida = "";
            string Consulta = @"SELECT dptoId FROM Departamento WHERE dptoName = @dptoName;";
            using (SqlConnection Conn = ConnectionDB.StartConn())
            {
                SqlCommand cmd = new SqlCommand(Consulta, Conn);
                cmd.Parameters.AddWithValue("@dptoName", dptoName);
                //* Lectura de datos.
                SqlDataReader Leer = cmd.ExecuteReader();
                if (Leer.Read())
                {
                    Salida = Leer["dptoId"].ToString();
                }
                return Salida;
            }
        }

    }
    // Clase para carrito
    class Carrito
    {
        // Válidación de los datos de la lista
        public bool ValidarList(string Username)
        {
            string Consulta = @"SELECT COUNT(*) FROM MiCarrito WHERE mcarUsr = @mcarUsr ; ";
            using (SqlConnection Conn = ConnectionDB.StartConn())
            {
                SqlCommand cmd = new SqlCommand(Consulta, Conn);
                cmd.Parameters.AddWithValue("@mcarUsr", Username);
                int Count = Convert.ToInt32(cmd.ExecuteScalar());
                return Count == 0;
            }
        }
        // Consulta del Id de la lista
        public string ConsultIdLista(string LName)
        {
            string Salida = "";
            string Consulta = @"SELECT mcarId FROM MiCarrito WHERE mcarUsr = @mcarUsr;";
            using (SqlConnection Conn = ConnectionDB.StartConn())
            {
                SqlCommand cmd = new SqlCommand(Consulta, Conn);
                cmd.Parameters.AddWithValue("@mcarUsr", LName);
                //* Lectura de datos.
                SqlDataReader Leer = cmd.ExecuteReader();
                if (Leer.Read())
                {
                    Salida = Leer["mcarId"].ToString();
                }
                return Salida;
            }
        }
        public string ConsultNameList(string IdL)
        {
            string Salida = "";
            string Consulta = @"SELECT mcarName FROM MiCarrito WHERE mcarId = @mcarId;";
            using (SqlConnection Conn = ConnectionDB.StartConn())
            {
                SqlCommand cmd = new SqlCommand(Consulta, Conn);
                cmd.Parameters.AddWithValue("@mcarId", IdL);
                //* Lectura de datos.
                SqlDataReader Leer = cmd.ExecuteReader();
                if (Leer.Read())
                {
                    Salida = Leer["mcarName"].ToString();
                }
                return Salida;
            }
        }

    }
    // Clase parar MisProductos de la lista
    class MisProductos
    {
        // Inserción de datos de la tabla MisProductos
        public int InsertarMisProductos(string IdCarro, string IdProd)
        {
            using (SqlConnection Conn = ConnectionDB.StartConn())
            {
                SqlCommand Comando = new SqlCommand("INSERT INTO MisProductos VALUES (@mprodCar,@mprodProd, @mprodCantidad)", Conn);
                Comando.Parameters.Add("@mprodCar", SqlDbType.NVarChar);
                Comando.Parameters.Add("@mprodProd", SqlDbType.NVarChar);
                Comando.Parameters.Add("@mprodCantidad", SqlDbType.Int);

                Comando.Parameters["@mprodCar"].Value = IdCarro;
                Comando.Parameters["@mprodProd"].Value = IdProd;
                Comando.Parameters["@mprodCantidad"].Value = 1;
                
                return Comando.ExecuteNonQuery();
            }
        }

        public bool ValidarContador(string IdCarro, string IdProd) 
        {
            string Consulta = @"SELECT COUNT(*) FROM MisProductos WHERE mprodCar = @mprodCar AND mrpodProd=@mprodProd ;";
            using (SqlConnection Conn = ConnectionDB.StartConn())
            {
                SqlCommand cmd = new SqlCommand(Consulta, Conn);
                cmd.Parameters.AddWithValue("@mprodCar", IdCarro);
                cmd.Parameters.AddWithValue("@mprodProd",IdProd);
                int Count = Convert.ToInt32(cmd.ExecuteScalar());
                return Count == 0;
            }
        }

    }



}
