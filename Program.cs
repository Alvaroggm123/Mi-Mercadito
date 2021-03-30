using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;

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
                string format = "yyyy-MM-dd";

                SqlCommand Comando = new SqlCommand(
                    string.Format("Insert Into Users (usrUsrname, usrFname, usrLname, usrBirth, usrSex, usrEmail, usrPswrd, usrRegDate) " +
                    "values ('{0}','{1}','{2}','{3}','{4}','{5}','{ 6}','{7}')",
                    UsuarioReg.Username,
                    UsuarioReg.Fname,
                    UsuarioReg.Lname,
                    //* Fecha de nacimiento a string con formato de base de datos.
                    UsuarioReg.Birth.ToString(format),
                    UsuarioReg.Sex,
                    UsuarioReg.Email,
                    UsuarioReg.Paswrd,
                    //* Fecha de día de registro a string con formato de la base de datos.
                    DateTime.Today.ToString(format)), Conn);
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
}
