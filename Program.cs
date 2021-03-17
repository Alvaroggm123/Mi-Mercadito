using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

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
    // Clase que permitira obtener los valores del usuario a registrar
    public class Usuarios
    {
        public string Usuario { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public char Sex { get; set; }
        public string Clave { get; set; }
        public string Correo { get; set; }
        public Usuarios() { }

        public Usuarios(string Usuario, string Nombre, string Apellidos, string Date, char Sex,  string Correo, string Clave)
        {
            this.Usuario = Usuario;
            this.Nombre = Nombre;
            this.Apellidos = Apellidos;
            this.Sex = Sex;
            this.Correo = Correo;
            this.Clave = Clave;
        }
        public int Insertar(Usuarios UsuarioReg)
        {
            using (SqlConnection Conn = ConnectionDB.StartConn())
            {
                SqlCommand Comando = new SqlCommand(
                    string.Format("Insert Into Users (usrUsrname,usrFname,usrLname,usrSex,usrEmail,usrPswrd) " +
                    "values ('{0}','{1}','{2}','{3}','{4}','{5}')",
                    UsuarioReg.Usuario,
                    UsuarioReg.Nombre,
                    UsuarioReg.Apellidos,
                    // UsuarioReg.Birth, /* Queda pendiente su implementacion*/
                    UsuarioReg.Sex,
                    UsuarioReg.Correo,
                    UsuarioReg.Clave), Conn);
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
    }
    // Creamos clase que permite la coneccion con la base de datos
    public class ConnectionDB
    {
        public static SqlConnection StartConn()
        {
            // Configuración de los parametros para conectar con la base de datos.
            string[] Config = { "Data Source = mercadito.database.windows.net;",
            /*                 */"Initial Catalog=Mercadito;",
            /*                 */"User Id=axolotl;",
            /*                 */"Password=Mercadito3312"};
            string Connection = Config[0] + Config[1] + Config[2] + Config[3];
            SqlConnection Conn = new SqlConnection(Connection);
            Conn.Open();
            return Conn;
        }

    }
}
