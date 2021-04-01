
namespace Mi_mercadito
{
    partial class FrmRegistro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegistro));
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblDialogo = new System.Windows.Forms.Label();
            this.txtConfirmP = new System.Windows.Forms.TextBox();
            this.lblConfirmP = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.cmdAccept = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.chkboxTerms = new System.Windows.Forms.CheckBox();
            this.txtLname2 = new System.Windows.Forms.TextBox();
            this.lblLname2 = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtLname = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblLname = new System.Windows.Forms.Label();
            this.lblBirth = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.datepBirth = new System.Windows.Forms.DateTimePicker();
            this.lblSexo = new System.Windows.Forms.Label();
            this.rbtnFmale = new System.Windows.Forms.RadioButton();
            this.rbtnMale = new System.Windows.Forms.RadioButton();
            this.rbtnOther = new System.Windows.Forms.RadioButton();
            this.grpbPersonales = new System.Windows.Forms.GroupBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2.SuspendLayout();
            this.grpbPersonales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(148, 48);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPassword.MaxLength = 50;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(204, 22);
            this.txtPassword.TabIndex = 3;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(51, 52);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(85, 17);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Contraseña:";
            // 
            // lblDialogo
            // 
            this.lblDialogo.AutoSize = true;
            this.lblDialogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDialogo.Location = new System.Drawing.Point(40, 82);
            this.lblDialogo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDialogo.Name = "lblDialogo";
            this.lblDialogo.Size = new System.Drawing.Size(323, 25);
            this.lblDialogo.TabIndex = 0;
            this.lblDialogo.Text = "Favor de llenar los siguientes datos:";
            // 
            // txtConfirmP
            // 
            this.txtConfirmP.Location = new System.Drawing.Point(148, 80);
            this.txtConfirmP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtConfirmP.MaxLength = 50;
            this.txtConfirmP.Name = "txtConfirmP";
            this.txtConfirmP.PasswordChar = '*';
            this.txtConfirmP.Size = new System.Drawing.Size(204, 22);
            this.txtConfirmP.TabIndex = 5;
            // 
            // lblConfirmP
            // 
            this.lblConfirmP.AutoSize = true;
            this.lblConfirmP.Location = new System.Drawing.Point(8, 84);
            this.lblConfirmP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConfirmP.Name = "lblConfirmP";
            this.lblConfirmP.Size = new System.Drawing.Size(133, 17);
            this.lblConfirmP.TabIndex = 4;
            this.lblConfirmP.Text = "Repetir contraseña:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblUsername);
            this.groupBox2.Controls.Add(this.txtUsername);
            this.groupBox2.Controls.Add(this.txtConfirmP);
            this.groupBox2.Controls.Add(this.lblPassword);
            this.groupBox2.Controls.Add(this.lblConfirmP);
            this.groupBox2.Controls.Add(this.txtPassword);
            this.groupBox2.Location = new System.Drawing.Point(24, 346);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(387, 126);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos de usuario";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(8, 20);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(136, 17);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Nombre del usuario:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(148, 16);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUsername.MaxLength = 45;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(204, 22);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            // 
            // cmdAccept
            // 
            this.cmdAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdAccept.Location = new System.Drawing.Point(35, 521);
            this.cmdAccept.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdAccept.Name = "cmdAccept";
            this.cmdAccept.Size = new System.Drawing.Size(164, 28);
            this.cmdAccept.TabIndex = 4;
            this.cmdAccept.Text = "Terminar registro.";
            this.cmdAccept.UseVisualStyleBackColor = true;
            this.cmdAccept.Click += new System.EventHandler(this.cmdAccept_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdCancel.Location = new System.Drawing.Point(217, 521);
            this.cmdCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(164, 28);
            this.cmdCancel.TabIndex = 5;
            this.cmdCancel.Text = "Cancelar registro.";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // chkboxTerms
            // 
            this.chkboxTerms.AutoSize = true;
            this.chkboxTerms.Location = new System.Drawing.Point(96, 479);
            this.chkboxTerms.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkboxTerms.Name = "chkboxTerms";
            this.chkboxTerms.Size = new System.Drawing.Size(248, 21);
            this.chkboxTerms.TabIndex = 3;
            this.chkboxTerms.Text = "Acepto los términos y condiciones.";
            this.chkboxTerms.UseVisualStyleBackColor = true;
            // 
            // txtLname2
            // 
            this.txtLname2.Location = new System.Drawing.Point(141, 87);
            this.txtLname2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLname2.MaxLength = 45;
            this.txtLname2.Name = "txtLname2";
            this.txtLname2.Size = new System.Drawing.Size(221, 22);
            this.txtLname2.TabIndex = 5;
            this.txtLname2.TextChanged += new System.EventHandler(this.txtLname2_TextChanged);
            // 
            // lblLname2
            // 
            this.lblLname2.AutoSize = true;
            this.lblLname2.Location = new System.Drawing.Point(19, 91);
            this.lblLname2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLname2.Name = "lblLname2";
            this.lblLname2.Size = new System.Drawing.Size(118, 17);
            this.lblLname2.TabIndex = 4;
            this.lblLname2.Text = "Apellido materno:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(19, 123);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(128, 17);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "Correo electrónico:";
            // 
            // txtLname
            // 
            this.txtLname.Location = new System.Drawing.Point(141, 55);
            this.txtLname.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLname.MaxLength = 45;
            this.txtLname.Name = "txtLname";
            this.txtLname.Size = new System.Drawing.Size(221, 22);
            this.txtLname.TabIndex = 3;
            this.txtLname.TextChanged += new System.EventHandler(this.txtLname_TextChanged);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(155, 119);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(208, 22);
            this.txtEmail.TabIndex = 7;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // lblLname
            // 
            this.lblLname.AutoSize = true;
            this.lblLname.Location = new System.Drawing.Point(19, 59);
            this.lblLname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLname.Name = "lblLname";
            this.lblLname.Size = new System.Drawing.Size(115, 17);
            this.lblLname.TabIndex = 2;
            this.lblLname.Text = "Apellido paterno:";
            // 
            // lblBirth
            // 
            this.lblBirth.AutoSize = true;
            this.lblBirth.Location = new System.Drawing.Point(19, 155);
            this.lblBirth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBirth.Name = "lblBirth";
            this.lblBirth.Size = new System.Drawing.Size(143, 17);
            this.lblBirth.TabIndex = 8;
            this.lblBirth.Text = "Fecha de nacimiento:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(19, 27);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(62, 17);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Nombre:";
            // 
            // datepBirth
            // 
            this.datepBirth.CustomFormat = "dd/MM/yyyy";
            this.datepBirth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datepBirth.Location = new System.Drawing.Point(172, 148);
            this.datepBirth.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.datepBirth.Name = "datepBirth";
            this.datepBirth.Size = new System.Drawing.Size(191, 22);
            this.datepBirth.TabIndex = 9;
            // 
            // lblSexo
            // 
            this.lblSexo.AutoSize = true;
            this.lblSexo.Location = new System.Drawing.Point(19, 187);
            this.lblSexo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Size = new System.Drawing.Size(43, 17);
            this.lblSexo.TabIndex = 21;
            this.lblSexo.Text = "Sexo:";
            // 
            // rbtnFmale
            // 
            this.rbtnFmale.AutoSize = true;
            this.rbtnFmale.Location = new System.Drawing.Point(72, 185);
            this.rbtnFmale.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbtnFmale.Name = "rbtnFmale";
            this.rbtnFmale.Size = new System.Drawing.Size(91, 21);
            this.rbtnFmale.TabIndex = 10;
            this.rbtnFmale.TabStop = true;
            this.rbtnFmale.Text = "Femenino";
            this.rbtnFmale.UseVisualStyleBackColor = true;
            // 
            // rbtnMale
            // 
            this.rbtnMale.AutoSize = true;
            this.rbtnMale.Location = new System.Drawing.Point(172, 185);
            this.rbtnMale.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbtnMale.Name = "rbtnMale";
            this.rbtnMale.Size = new System.Drawing.Size(92, 21);
            this.rbtnMale.TabIndex = 11;
            this.rbtnMale.TabStop = true;
            this.rbtnMale.Text = "Masculino";
            this.rbtnMale.UseVisualStyleBackColor = true;
            // 
            // rbtnOther
            // 
            this.rbtnOther.AutoSize = true;
            this.rbtnOther.Location = new System.Drawing.Point(277, 185);
            this.rbtnOther.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbtnOther.Name = "rbtnOther";
            this.rbtnOther.Size = new System.Drawing.Size(57, 21);
            this.rbtnOther.TabIndex = 12;
            this.rbtnOther.TabStop = true;
            this.rbtnOther.Text = "Otro";
            this.rbtnOther.UseVisualStyleBackColor = true;
            // 
            // grpbPersonales
            // 
            this.grpbPersonales.Controls.Add(this.rbtnOther);
            this.grpbPersonales.Controls.Add(this.rbtnMale);
            this.grpbPersonales.Controls.Add(this.rbtnFmale);
            this.grpbPersonales.Controls.Add(this.lblSexo);
            this.grpbPersonales.Controls.Add(this.txtName);
            this.grpbPersonales.Controls.Add(this.datepBirth);
            this.grpbPersonales.Controls.Add(this.lblName);
            this.grpbPersonales.Controls.Add(this.lblBirth);
            this.grpbPersonales.Controls.Add(this.lblLname);
            this.grpbPersonales.Controls.Add(this.txtEmail);
            this.grpbPersonales.Controls.Add(this.txtLname);
            this.grpbPersonales.Controls.Add(this.lblEmail);
            this.grpbPersonales.Controls.Add(this.lblLname2);
            this.grpbPersonales.Controls.Add(this.txtLname2);
            this.grpbPersonales.Location = new System.Drawing.Point(24, 114);
            this.grpbPersonales.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpbPersonales.Name = "grpbPersonales";
            this.grpbPersonales.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpbPersonales.Size = new System.Drawing.Size(387, 224);
            this.grpbPersonales.TabIndex = 1;
            this.grpbPersonales.TabStop = false;
            this.grpbPersonales.Text = "Datos personales";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(85, 23);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtName.MaxLength = 45;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(277, 22);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(-11, -1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 108);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // FrmRegistro
            // 
            this.AcceptButton = this.cmdAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(443, 604);
            this.ControlBox = false;
            this.Controls.Add(this.chkboxTerms);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdAccept);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpbPersonales);
            this.Controls.Add(this.lblDialogo);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmRegistro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de nuevo usuario";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpbPersonales.ResumeLayout(false);
            this.grpbPersonales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblDialogo;
        private System.Windows.Forms.TextBox txtConfirmP;
        private System.Windows.Forms.Label lblConfirmP;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Button cmdAccept;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.CheckBox chkboxTerms;
        public System.Windows.Forms.TextBox txtLname2;
        private System.Windows.Forms.Label lblLname2;
        private System.Windows.Forms.Label lblEmail;
        public System.Windows.Forms.TextBox txtLname;
        public System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblLname;
        private System.Windows.Forms.Label lblBirth;
        private System.Windows.Forms.Label lblName;
        public System.Windows.Forms.DateTimePicker datepBirth;
        private System.Windows.Forms.Label lblSexo;
        public System.Windows.Forms.RadioButton rbtnFmale;
        public System.Windows.Forms.RadioButton rbtnMale;
        private System.Windows.Forms.RadioButton rbtnOther;
        private System.Windows.Forms.GroupBox grpbPersonales;
        public System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}