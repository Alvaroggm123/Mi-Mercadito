﻿
namespace Mi_mercadito
{
    partial class FrmDespliegue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDespliegue));
            this.cmdAccept = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblDialogo = new System.Windows.Forms.Label();
            this.grpbDatos = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grpbDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdAccept
            // 
            this.cmdAccept.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.cmdAccept.FlatAppearance.BorderSize = 2;
            this.cmdAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdAccept.Location = new System.Drawing.Point(120, 240);
            this.cmdAccept.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmdAccept.Name = "cmdAccept";
            this.cmdAccept.Size = new System.Drawing.Size(164, 23);
            this.cmdAccept.TabIndex = 2;
            this.cmdAccept.Text = "Terminar registro";
            this.cmdAccept.UseVisualStyleBackColor = true;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(12, 33);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(130, 13);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Nombre de usuario:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(152, 30);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.ReadOnly = true;
            this.txtUsername.Size = new System.Drawing.Size(204, 21);
            this.txtUsername.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(79, 56);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(277, 21);
            this.txtName.TabIndex = 3;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 59);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(54, 13);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Nombre";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(148, 82);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(208, 21);
            this.txtEmail.TabIndex = 5;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(12, 85);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(141, 13);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Correo electrónico:";
            // 
            // lblDialogo
            // 
            this.lblDialogo.AutoSize = true;
            this.lblDialogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDialogo.Location = new System.Drawing.Point(101, 9);
            this.lblDialogo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDialogo.Name = "lblDialogo";
            this.lblDialogo.Size = new System.Drawing.Size(256, 60);
            this.lblDialogo.TabIndex = 0;
            this.lblDialogo.Text = "Sus datos han sido registrados \r\nsatisfactoriamente, puede regresar\r\npara iniciar" +
    " sesión.";
            // 
            // grpbDatos
            // 
            this.grpbDatos.Controls.Add(this.lblUsername);
            this.grpbDatos.Controls.Add(this.txtUsername);
            this.grpbDatos.Controls.Add(this.txtName);
            this.grpbDatos.Controls.Add(this.lblName);
            this.grpbDatos.Controls.Add(this.txtEmail);
            this.grpbDatos.Controls.Add(this.lblEmail);
            this.grpbDatos.Location = new System.Drawing.Point(13, 113);
            this.grpbDatos.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grpbDatos.Name = "grpbDatos";
            this.grpbDatos.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grpbDatos.Size = new System.Drawing.Size(387, 121);
            this.grpbDatos.TabIndex = 1;
            this.grpbDatos.TabStop = false;
            this.grpbDatos.Text = "Datos registrados";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(-8, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(125, 79);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // FrmDespliegue
            // 
            this.AcceptButton = this.cmdAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(432, 272);
            this.Controls.Add(this.cmdAccept);
            this.Controls.Add(this.lblDialogo);
            this.Controls.Add(this.grpbDatos);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Perpetua Titling MT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FrmDespliegue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Datos registrados correctamente";
            this.grpbDatos.ResumeLayout(false);
            this.grpbDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cmdAccept;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblDialogo;
        private System.Windows.Forms.GroupBox grpbDatos;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}