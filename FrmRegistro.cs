using System;
using System.Drawing;
using System.Windows.Forms;
// Librerías necesarias.
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Text;

namespace Mi_mercadito
{
    public partial class FrmRegistro : Form
    {
        /* ========== | Comienzan los métodos | ========== */

        // Método que permite imprimir mensajes de error.
        private bool ErrorMessage(string Grupo, string Mensaje, Control Enfoque)
        {
            string Titulo = "Error en " + Grupo;
            MessageBox.Show(Mensaje, Titulo);
            Enfoque.Focus();
            return false;
        }
        // == | Método de verificación de llenado de datos. | == //
        private bool CheckData()
        {
            // Generamos [Usuario] para validar si se ingresó un usuario correcto.
            Usuarios Usuario = new Usuarios();
            // Área de verificación de datos personales.
            if (txtName.Text == "" || txtLname.Text == "" || txtLname2.Text == "" || txtEmail.Text == "")
                return ErrorMessage("Datos personales", "Los datos personales deben estar completos.", txtName);
            else
            {
                // Conversión automática de la primera letra a mayúscula - Nombre
                SepararNombres(txtName);
                // Conversión automática de la primera letra a mayúscula - Apellido paterno
                SepararNombres(txtLname);
                // Conversión automática de la primera letra a mayúscula - Apellido materno
                SepararNombres(txtLname2);
                //Validar formato de Email
                if (!FormatoEmail(txtEmail.Text))
                    ErrorMessage("Datos personales", "El correo no tiene un formato válido", txtEmail);
                // Termina la validación de los datos personales

                //FALTA EVITAR LOS SIGNOS DE INTERROGACIÓN
                //if (txtEmail.Text.Contains("?"))
                //{
                //    for (int i = 0; i < (txtEmail.Text.Length); i++)
                //    {
                //        char LetraAux = Convert.ToChar(txtEmail.Text.Substring(i, 1));
                //        if (LetraAux == '?')
                //        {
                //            char[] SignoInterr[i] = SignosINT(txtEmail.Text);

                //            foreach (char SignoInt in txtEmail.Text) { }
                //            txtEmail.Text.IndexOfAny
                //            txtEmail.Text.Remove(txtEmail.Text.Length - 1, 1);
                //        }
                //    }
                //}
            }
            if (!rbtnFmale.Checked && !rbtnMale.Checked && !rbtnOther.Checked)
                return ErrorMessage("Definir sexo requerido", "Se requiere especificar sexo, en caso de inclusividad seleccione \"otro\".", txtName);
            else if (datepBirth.Value.AddYears(13) > DateTime.Today)
                return ErrorMessage("Edad mínima requerida", "Se requiere especificar una edad mayor a 13 años.", lblSexo);

            // Área de verificación de datos de contacto.
            else if (txtUsername.Text == "" || txtPassword.Text == "" || txtConfirmP.Text == "")
                return ErrorMessage("Nombre de usuario", "Se requiere un nombre de usuario válido.", lblUsername);
            else if (txtUsername.Text.Length < 10)
                return ErrorMessage("Nombre de usuario", "Se requiere un nombre de usuario de al menos 10 caracteres.", lblPassword);
            else if (txtPassword.Text != txtConfirmP.Text)
                return ErrorMessage("Contraseña", "Las contraseñas no coinciden.", lblPassword);
            else if (!Usuario.Validar(txtUsername.Text))
                return ErrorMessage("Usuario ya registrado", "El usuario " + txtUsername.Text + " ya se encuentra registrado.", lblUsername);

            // Validamos que haya aceptado los términos y condiciones.
            else if (!chkboxTerms.Checked) // === | Caso especial, falta verificar | === //
                return ErrorMessage("Términos y condiciones", "Se deben aceptar los términos y condiciones.", lblPassword);
            else
                return true;
        }
        // Validación [CARACTERES PERMITIDOS]
        private void ValidarCarac(TextBox CajaTexto)
        {
            foreach (byte Caracter in Encoding.ASCII.GetBytes(CajaTexto.Text))
                //-Espacio-//      //--Acento--//     //-----Letras mayúsculas-----//     //-----Letras minúsculas-----//
                if (Caracter != 32 && Caracter != 239 && (Caracter < 65 || Caracter > 90) && (Caracter < 97 || Caracter > 122) && Caracter != 63)
                {
                    byte AuxUbi = Convert.ToByte(CajaTexto.Text.IndexOf(Convert.ToChar(Caracter)));
                    MessageBox.Show("Solo se pueden ingresar valores válidos [(a), (A), (á), (Á)]", "Error de sintáxis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CajaTexto.Text = CajaTexto.Text.Remove(AuxUbi, 1);
                    CajaTexto.SelectionStart = AuxUbi;
                }
            
        }
        private string ValidarCaracEmail(TextBox CajaTexto)
        {
            // Validamos que se usen signos válidos para un correo.
            foreach (int Caracter in Encoding.ASCII.GetBytes(CajaTexto.Text))
                if (Caracter != 46 && Caracter != 95 && Caracter != 45 && (Caracter < 64 || Caracter > 90) && (Caracter < 97 || Caracter > 122) && (Caracter < 48 || Caracter > 57))
                {
                    byte AuxUbi = Convert.ToByte(CajaTexto.Text.IndexOf(Convert.ToChar(Caracter)));
                    MessageBox.Show("Solo se pueden ingresar valores válidos [(Letras), (números), (@), (.), (-), (_)]", "Error de sintáxis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CajaTexto.Text = CajaTexto.Text.Remove(AuxUbi, 1);
                    CajaTexto.SelectionStart = AuxUbi;
                }
            return CajaTexto.Text;
        }
        private void SepararNombres(Control CajaTexto)
        {
            if (CajaTexto.Text.StartsWith(" "))
                ErrorMessage("Datos personales", "Nombres/Apellidos no deben comenzar con [ESPACIO]", txtName);
            else
            {
                // Conversión automática de la primera letra a mayúscula - Nombre/s
                string[] NombresSeparados = CajaTexto.Text.ToLower().Split();
                CajaTexto.ResetText();
                for (int i = 0; i < NombresSeparados.Length; i++)
                {
                    CajaTexto.Text = string.Concat(CajaTexto.Text, NombresSeparados[i].Substring(0, 1).ToUpper(), NombresSeparados[i].Substring(1, NombresSeparados[i].Length - 1), " ");
                }
                if (NombresSeparados.Length >= 1)
                    CajaTexto.Text = CajaTexto.Text.Remove(CajaTexto.Text.LastIndexOf(' '));
            }

        }
        private bool FormatoEmail(string TextoEmail)
        {
            // Validar formato de Correo electrónico
            string expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(TextoEmail, expresion))
            {
                if (Regex.Replace(TextoEmail, expresion, string.Empty).Length == 0)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        /* ========== | FIN de los métodos | ========== */
        public FrmRegistro()
        {
            InitializeComponent();
        }
        /* ========== | Comienzan los eventos | ========== */
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            // Cerramos el formulario de registro.
            // Ventana de confirmación de salida del registro.
            string Msg = "¿Desea cancelar el registro?", Title = "Cancelar registro";
            if (MessageBox.Show(Msg, Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Close();
        }

        private void cmdAccept_Click(object sender, EventArgs e)
        {
            // Llamamos al método que verifica que los campos hayan sido llenados correctamente.
        
            if (CheckData())
            {
                // Validamos el sexo.
                char Sex = 'F';
                if (rbtnMale.Checked) Sex = 'M';
                else if (rbtnOther.Checked) Sex = 'O';
                // Creamos un objeto [Usuario] y le asignamos los valores.
                Usuarios Usuario = new Usuarios(
                txtUsername.Text,
                txtName.Text,
                txtLname.Text + " " + txtLname2.Text,
                datepBirth.Value,
                Sex,
                txtEmail.Text,
                txtPassword.Text
                );
                // Enviamos los datos y un mensaje de confirmación en caso de que todo haya procedido correctamente.
                if (MessageBox.Show("¿Sus datos son correctos?", "Confirmar registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    if (Usuario.Insertar(Usuario) > 0)
                    {
                        MessageBox.Show("¡Enhorabuena!, te haz registrado correctamente, regresa para loguearte.", "Datos guardados", MessageBoxButtons.OK);
                        Close();
                    }
                    else
                        MessageBox.Show("No se pudieron guardar los datos.", "Error de guardado", MessageBoxButtons.OK);
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            // Validamos que el usuario que se esté intentando registrar no se encuentre ya registrado.
            Usuarios Usuario = new Usuarios();
            if (txtUsername.Text.Length > 10)
            {
                if (!Usuario.Validar(txtUsername.Text))
                    txtUsername.BackColor = Color.Red;
                else txtUsername.BackColor = Color.White;
            }
        }
        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            //Valiadación [CARACTERES PERMITIDOS] - Email
            //Llamada del método ValidarCaracEmail();
            txtEmail.Text = ValidarCaracEmail(txtEmail);
            txtEmail.SelectionStart = txtEmail.Text.Length;
        }
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            // Validación [CARACTERES PERMITIDOS] - Nombre
            //Llamada del método ValidarCarac();
            ValidarCarac(txtName);

        }
        private void txtLname_TextChanged(object sender, EventArgs e)
        {
            // Validación [CARACTERES PERMITIDOS] - Apellido paterno
            //Llamada del método ValidarCarac();
            ValidarCarac(txtLname);

        }
        private void txtLname2_TextChanged(object sender, EventArgs e)
        {
            // Validación [CARACTERES PERMITIDOS] - Apellido paterno
            //Llamada del método ValidarCarac();
            ValidarCarac(txtLname2);
        }

    }
}
