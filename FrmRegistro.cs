using System;
using System.Drawing;
using System.Windows.Forms;
// Librerías necesarias.
using System.Data.SqlClient;
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
            if (txtName.Text == "" || txtLname.Text == "" || txtEmail.Text == "")
                return ErrorMessage("Datos personales", "Los datos personales deben estar completos.", txtName);
            else if (!rbtnFmale.Checked && !rbtnMale.Checked && !rbtnOther.Checked)
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
            // Validamos que se usen signos válidos para un correo.
            txtEmail.Text.ToLower();
            foreach (int Caracter in Encoding.ASCII.GetBytes(txtEmail.Text))
                if (Caracter != 46 && Caracter != 95 && Caracter != 45 && (Caracter < 64 || Caracter > 90) && (Caracter < 97 || Caracter > 122) && (Caracter < 48 || Caracter > 57))
                {
                    MessageBox.Show("Solo se pueden ingresar valores válidos", "Error de sintáxis",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    string Correcion = txtEmail.Text;
                    Correcion = Correcion.Remove(Correcion.Length - 1);
                    txtEmail.Text = Correcion;
                    txtEmail.SelectAll();
                }
        }

    }
}
