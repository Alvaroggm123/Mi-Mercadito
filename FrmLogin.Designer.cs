
namespace Mi_mercadito
{
    partial class FrmLogin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.CmdAccept = new System.Windows.Forms.Button();
            this.CmdRegister = new System.Windows.Forms.Button();
            this.lblTerminos = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.ttLogin = new System.Windows.Forms.ToolTip(this.components);
            this.lblUsuarioRip = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxLogo
            // 
            this.pbxLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbxLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbxLogo.BackgroundImage")));
            this.pbxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbxLogo.Location = new System.Drawing.Point(49, 15);
            this.pbxLogo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbxLogo.Name = "pbxLogo";
            this.pbxLogo.Size = new System.Drawing.Size(333, 282);
            this.pbxLogo.TabIndex = 0;
            this.pbxLogo.TabStop = false;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(12, 319);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(172, 23);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Nombre de usuario:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(189, 319);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(209, 22);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(189, 351);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(209, 22);
            this.txtPassword.TabIndex = 3;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(77, 350);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(104, 23);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Contraseña:";
            // 
            // CmdAccept
            // 
            this.CmdAccept.FlatAppearance.BorderColor = System.Drawing.Color.Purple;
            this.CmdAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdAccept.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdAccept.Location = new System.Drawing.Point(240, 402);
            this.CmdAccept.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CmdAccept.Name = "CmdAccept";
            this.CmdAccept.Size = new System.Drawing.Size(143, 42);
            this.CmdAccept.TabIndex = 4;
            this.CmdAccept.Text = "Iniciar sesión ";
            this.CmdAccept.UseVisualStyleBackColor = true;
            this.CmdAccept.Click += new System.EventHandler(this.CmdAccept_Click);
            // 
            // CmdRegister
            // 
            this.CmdRegister.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.CmdRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdRegister.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdRegister.Location = new System.Drawing.Point(49, 402);
            this.CmdRegister.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CmdRegister.Name = "CmdRegister";
            this.CmdRegister.Size = new System.Drawing.Size(141, 42);
            this.CmdRegister.TabIndex = 5;
            this.CmdRegister.Text = "Registrarme";
            this.CmdRegister.UseVisualStyleBackColor = true;
            this.CmdRegister.Click += new System.EventHandler(this.CmdRegister_Click);
            // 
            // lblTerminos
            // 
            this.lblTerminos.AutoSize = true;
            this.lblTerminos.Location = new System.Drawing.Point(131, 468);
            this.lblTerminos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTerminos.Name = "lblTerminos";
            this.lblTerminos.Size = new System.Drawing.Size(157, 17);
            this.lblTerminos.TabIndex = 6;
            this.lblTerminos.Text = "Términos y condiciones";
            // 
            // ttLogin
            // 
            this.ttLogin.AutomaticDelay = 100;
            this.ttLogin.AutoPopDelay = 5000;
            this.ttLogin.InitialDelay = 100;
            this.ttLogin.IsBalloon = true;
            this.ttLogin.ReshowDelay = 20;
            this.ttLogin.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.ttLogin.ToolTipTitle = "Alerta";
            // 
            // lblUsuarioRip
            // 
            this.lblUsuarioRip.AutoSize = true;
            this.lblUsuarioRip.ForeColor = System.Drawing.Color.DarkRed;
            this.lblUsuarioRip.Location = new System.Drawing.Point(186, 301);
            this.lblUsuarioRip.Name = "lblUsuarioRip";
            this.lblUsuarioRip.Size = new System.Drawing.Size(137, 17);
            this.lblUsuarioRip.TabIndex = 7;
            this.lblUsuarioRip.Text = "¡El usuario no existe!";
            this.lblUsuarioRip.Visible = false;
            // 
            // FrmLogin
            // 
            this.AcceptButton = this.CmdAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(431, 503);
            this.Controls.Add(this.lblUsuarioRip);
            this.Controls.Add(this.CmdRegister);
            this.Controls.Add(this.CmdAccept);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.pbxLogo);
            this.Controls.Add(this.lblTerminos);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "iniciar sesión ";
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxLogo;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Button CmdAccept;
        private System.Windows.Forms.Button CmdRegister;
        private System.Windows.Forms.Label lblTerminos;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolTip ttLogin;
        private System.Windows.Forms.Label lblUsuarioRip;
    }
}

