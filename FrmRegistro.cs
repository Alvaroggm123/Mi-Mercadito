using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mi_mercadito
{
    public partial class FrmRegistro : Form
    {
        /* ========== | Comienzan los métodos | ========== */

        // Método que permite imprimir mensajes de error.
        private bool ErrorMessage(string Grupo, Control Enfoque)
        {
            string Mensaje = "Los datos " + Grupo + " deben estar completos o correctos.";
            string Titulo = "Error en " + Grupo;
            MessageBox.Show(Mensaje, Titulo);
            Enfoque.Focus();
            return false;
        }
        // == | Metodo de verificación de llenado de datos.
        private bool CheckData()
        {
            // Área de verificación de datos personales.
            if (txtName.Text == "" || txtLname.Text == "" || txtEmail.Text == "")
                return ErrorMessage("personales", txtName);
            else if (!rbtnFmale.Checked && !rbtnMale.Checked && !rbtnOther.Checked)
                return ErrorMessage("sobre el sexo", lblSexo);
            else if (datepBirth.Value.AddYears(18) > DateTime.Today)
                return ErrorMessage("la edad", lblSexo); // === | Caso especial, falta verificar | === //
            // Área de verificación de datos de contacto.
            else if (txtUsername.Text == "" || txtPassword.Text == "" || txtConfirmP.Text == "")
                return ErrorMessage("sobre el usuario", lblUsername);
            else if (txtPassword.Text != txtConfirmP.Text)
                return ErrorMessage("la contraseña", lblPassword);
            // Validamos que haya aceptado los terminos y condiciones.
            else if (!chkboxTerms.Checked) // === | Caso especial, falta verificar | === //
                return ErrorMessage("terminos y condiciones", lblPassword);
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
    }
}
