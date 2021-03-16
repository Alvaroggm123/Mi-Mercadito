using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Librerias necesarias
using System.Data.SqlClient;

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
        // == | Metodo de verificación de llenado de datos.
        private bool CheckData()
        {
            // Generamos usuario para validar si se ingreso un usuario correcto
            Usuarios Usuario = new Usuarios();
            // Área de verificación de datos personales.
            if (txtName.Text == "" || txtLname.Text == "" || txtEmail.Text == "")
                return ErrorMessage("Datos personales", "Los datos personales deben estar completos", txtName);
            else if (!rbtnFmale.Checked && !rbtnMale.Checked && !rbtnOther.Checked)
                return ErrorMessage("Definir sexo requerido", "Se requiere espesificar sexo, en caso de inclusividad seleccione \"otro\"", txtName);
            else if (datepBirth.Value.AddYears(13) > DateTime.Today)
                return ErrorMessage("Edad minima requerida", "Se requiere espesificar una edad mayor a 13 años.", lblSexo);
            // Área de verificación de datos de contacto.
            else if (txtUsername.Text == "" || txtPassword.Text == "" || txtConfirmP.Text == "")
                return ErrorMessage("Nombre de usuario", "Se requiere un nombre de usuario valido.", lblUsername);
            else if (txtUsername.Text.Length < 10)
                return ErrorMessage("Nombre de usuario", "Se requiere un nombre de usuario de al menos 10 caracteres.", lblPassword);
            else if (txtPassword.Text != txtConfirmP.Text)
                return ErrorMessage("Contraseña", "Las contraseñas no coinciden.", lblPassword);
            else if (!Usuario.Validar(txtUsername.Text))
                return ErrorMessage("Usuario ya registrado", "El usuario " + txtUsername.Text + " ya se encuentra registrado.", lblPassword);
            // Validamos que haya aceptado los terminos y condiciones.
            else if (!chkboxTerms.Checked) // === | Caso especial, falta verificar | === //
                return ErrorMessage("Terminos y condiciones", "Se deben aceptar los terminos y condiciones.", lblPassword);
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
            // Cerramos el formuario de registro.
            // Ventana de confirmación de salida del registro
            string Msg = "¿Desea cancelar el registro?", Title = "Cancelar registro";
            if (MessageBox.Show(Msg, Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Close();
        }

        private void cmdAccept_Click(object sender, EventArgs e)
        {
            // Llamamos  al  método  que  verifica que los campos hayan
            // sido llenados correctamente.
            if (CheckData())
            {
                // Creamos un objeto Usuario y le asignamos los valores
                Usuarios Usuario = new Usuarios(
                txtLname.Text,
                txtLname.Text + " " + txtLname2.Text,
                txtUsername.Text,
                txtPassword.Text,
                txtEmail.Text
                );
                // Enviamos  los  datos y un mensaje de confirmacion en
                // caso de que todo haya procedido correctamente.
                if (Usuario.Insertar(Usuario) > 0)
                    MessageBox.Show("!Enhora Buena¡, te haz registrado correctamente.", "Datos Guardado", MessageBoxButtons.OK);
                else
                    MessageBox.Show("No se pudieron guardar los datos", "Error de Guardado", MessageBoxButtons.OK);
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            // Validamos que el usuario que se este intentando registrar
            // no se encuentre ya registrado
            Usuarios Usuario = new Usuarios();
            if (txtUsername.Text.Length > 10)
            {
                if (!Usuario.Validar(txtUsername.Text))
                    txtUsername.BackColor = Color.Red;
                else txtUsername.BackColor = Color.White;
            }
        }
    }
}
