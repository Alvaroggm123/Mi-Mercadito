﻿
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
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.pbxX = new System.Windows.Forms.PictureBox();
            this.pbxmin = new System.Windows.Forms.PictureBox();
            this.pbxmin2 = new System.Windows.Forms.PictureBox();
            this.pbxX2 = new System.Windows.Forms.PictureBox();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.pnlLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxmin2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxX2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Baskerville Old Face", 12F);
            this.lblUsername.Location = new System.Drawing.Point(38, 423);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(169, 23);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Nombre de usuario:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(177, 421);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(235, 30);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(177, 457);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(235, 30);
            this.txtPassword.TabIndex = 3;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Baskerville Old Face", 12F);
            this.lblPassword.Location = new System.Drawing.Point(87, 459);
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
            this.CmdAccept.Font = new System.Drawing.Font("Baskerville Old Face", 12F);
            this.CmdAccept.Location = new System.Drawing.Point(270, 515);
            this.CmdAccept.Margin = new System.Windows.Forms.Padding(4);
            this.CmdAccept.Name = "CmdAccept";
            this.CmdAccept.Size = new System.Drawing.Size(161, 47);
            this.CmdAccept.TabIndex = 4;
            this.CmdAccept.Text = "Iniciar sesión ";
            this.CmdAccept.UseVisualStyleBackColor = true;
            this.CmdAccept.Click += new System.EventHandler(this.CmdAccept_Click);
            // 
            // CmdRegister
            // 
            this.CmdRegister.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.CmdRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdRegister.Font = new System.Drawing.Font("Baskerville Old Face", 12F);
            this.CmdRegister.Location = new System.Drawing.Point(55, 515);
            this.CmdRegister.Margin = new System.Windows.Forms.Padding(4);
            this.CmdRegister.Name = "CmdRegister";
            this.CmdRegister.Size = new System.Drawing.Size(159, 47);
            this.CmdRegister.TabIndex = 5;
            this.CmdRegister.Text = "Registrarme";
            this.CmdRegister.UseVisualStyleBackColor = true;
            this.CmdRegister.Click += new System.EventHandler(this.CmdRegister_Click);
            // 
            // lblTerminos
            // 
            this.lblTerminos.AutoSize = true;
            this.lblTerminos.Location = new System.Drawing.Point(147, 588);
            this.lblTerminos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTerminos.Name = "lblTerminos";
            this.lblTerminos.Size = new System.Drawing.Size(198, 23);
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
            this.lblUsuarioRip.Location = new System.Drawing.Point(174, 399);
            this.lblUsuarioRip.Name = "lblUsuarioRip";
            this.lblUsuarioRip.Size = new System.Drawing.Size(309, 23);
            this.lblUsuarioRip.TabIndex = 7;
            this.lblUsuarioRip.Text = "¡El usuario o contraseña es incorrecto!";
            this.lblUsuarioRip.Visible = false;
            // 
            // pnlLogin
            // 
            this.pnlLogin.BackColor = System.Drawing.Color.Azure;
            this.pnlLogin.Controls.Add(this.pbxX);
            this.pnlLogin.Controls.Add(this.pbxmin);
            this.pnlLogin.Location = new System.Drawing.Point(0, 0);
            this.pnlLogin.Margin = new System.Windows.Forms.Padding(4);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(485, 44);
            this.pnlLogin.TabIndex = 8;
            this.pnlLogin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlLogin_MouseDown);
            // 
            // pbxX
            // 
            this.pbxX.Image = global::Mi_mercadito.Properties.Resources.btn_X;
            this.pbxX.Location = new System.Drawing.Point(438, 1);
            this.pbxX.Margin = new System.Windows.Forms.Padding(4);
            this.pbxX.Name = "pbxX";
            this.pbxX.Size = new System.Drawing.Size(45, 42);
            this.pbxX.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxX.TabIndex = 10;
            this.pbxX.TabStop = false;
            this.pbxX.MouseLeave += new System.EventHandler(this.pbxX_MouseLeave);
            this.pbxX.MouseHover += new System.EventHandler(this.pbxX_MouseHover);
            // 
            // pbxmin
            // 
            this.pbxmin.Image = global::Mi_mercadito.Properties.Resources.btn_min1;
            this.pbxmin.Location = new System.Drawing.Point(388, 1);
            this.pbxmin.Margin = new System.Windows.Forms.Padding(4);
            this.pbxmin.Name = "pbxmin";
            this.pbxmin.Size = new System.Drawing.Size(45, 42);
            this.pbxmin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxmin.TabIndex = 0;
            this.pbxmin.TabStop = false;
            this.pbxmin.MouseHover += new System.EventHandler(this.pbxmin_MouseHover);
            // 
            // pbxmin2
            // 
            this.pbxmin2.Image = global::Mi_mercadito.Properties.Resources.btn_min21;
            this.pbxmin2.Location = new System.Drawing.Point(388, 1);
            this.pbxmin2.Margin = new System.Windows.Forms.Padding(4);
            this.pbxmin2.Name = "pbxmin2";
            this.pbxmin2.Size = new System.Drawing.Size(45, 42);
            this.pbxmin2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxmin2.TabIndex = 12;
            this.pbxmin2.TabStop = false;
            this.pbxmin2.Visible = false;
            this.pbxmin2.Click += new System.EventHandler(this.pbxmin2_Click);
            this.pbxmin2.MouseLeave += new System.EventHandler(this.pbxmin2_MouseLeave);
            // 
            // pbxX2
            // 
            this.pbxX2.Image = global::Mi_mercadito.Properties.Resources.btn_X2;
            this.pbxX2.Location = new System.Drawing.Point(438, 1);
            this.pbxX2.Margin = new System.Windows.Forms.Padding(4);
            this.pbxX2.Name = "pbxX2";
            this.pbxX2.Size = new System.Drawing.Size(45, 42);
            this.pbxX2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxX2.TabIndex = 11;
            this.pbxX2.TabStop = false;
            this.pbxX2.Visible = false;
            this.pbxX2.Click += new System.EventHandler(this.pbxX2_Click);
            this.pbxX2.MouseLeave += new System.EventHandler(this.pbxX2_MouseLeave);
            // 
            // pbxLogo
            // 
            this.pbxLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbxLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbxLogo.BackgroundImage")));
            this.pbxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbxLogo.Location = new System.Drawing.Point(55, 79);
            this.pbxLogo.Margin = new System.Windows.Forms.Padding(4);
            this.pbxLogo.Name = "pbxLogo";
            this.pbxLogo.Size = new System.Drawing.Size(375, 317);
            this.pbxLogo.TabIndex = 0;
            this.pbxLogo.TabStop = false;
            // 
            // FrmLogin
            // 
            this.AcceptButton = this.CmdAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(485, 641);
            this.Controls.Add(this.pbxmin2);
            this.Controls.Add(this.pbxX2);
            this.Controls.Add(this.pnlLogin);
            this.Controls.Add(this.lblUsuarioRip);
            this.Controls.Add(this.CmdRegister);
            this.Controls.Add(this.CmdAccept);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.pbxLogo);
            this.Controls.Add(this.lblTerminos);
            this.Font = new System.Drawing.Font("Baskerville Old Face", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmLogin";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "iniciar sesión ";
            this.pnlLogin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxmin2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxX2)).EndInit();
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
        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.PictureBox pbxmin;
        private System.Windows.Forms.PictureBox pbxX;
        private System.Windows.Forms.PictureBox pbxX2;
        private System.Windows.Forms.PictureBox pbxmin2;
    }
}

