
namespace Mi_mercadito
{
    partial class FrmCamara
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCamara));
            this.pbox_Camara = new System.Windows.Forms.PictureBox();
            this.cmdFoto = new System.Windows.Forms.Button();
            this.cboxCamara = new System.Windows.Forms.ComboBox();
            this.cmdGrabar = new System.Windows.Forms.Button();
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.pbxmin2 = new System.Windows.Forms.PictureBox();
            this.pbxX2 = new System.Windows.Forms.PictureBox();
            this.pbxX = new System.Windows.Forms.PictureBox();
            this.pbxmin = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_Camara)).BeginInit();
            this.pnlLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxmin2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxX2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxmin)).BeginInit();
            this.SuspendLayout();
            // 
            // pbox_Camara
            // 
            this.pbox_Camara.Image = ((System.Drawing.Image)(resources.GetObject("pbox_Camara.Image")));
            this.pbox_Camara.Location = new System.Drawing.Point(13, 56);
            this.pbox_Camara.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pbox_Camara.Name = "pbox_Camara";
            this.pbox_Camara.Size = new System.Drawing.Size(793, 610);
            this.pbox_Camara.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbox_Camara.TabIndex = 0;
            this.pbox_Camara.TabStop = false;
            // 
            // cmdFoto
            // 
            this.cmdFoto.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdFoto.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.cmdFoto.FlatAppearance.BorderSize = 2;
            this.cmdFoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdFoto.Location = new System.Drawing.Point(608, 672);
            this.cmdFoto.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmdFoto.Name = "cmdFoto";
            this.cmdFoto.Size = new System.Drawing.Size(171, 30);
            this.cmdFoto.TabIndex = 2;
            this.cmdFoto.Text = "Tomar Foto";
            this.cmdFoto.UseVisualStyleBackColor = true;
            this.cmdFoto.Click += new System.EventHandler(this.cmdCapturarFoto_Click);
            // 
            // cboxCamara
            // 
            this.cboxCamara.FormattingEnabled = true;
            this.cboxCamara.Location = new System.Drawing.Point(67, 672);
            this.cboxCamara.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboxCamara.Name = "cboxCamara";
            this.cboxCamara.Size = new System.Drawing.Size(255, 21);
            this.cboxCamara.TabIndex = 0;
            // 
            // cmdGrabar
            // 
            this.cmdGrabar.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.cmdGrabar.FlatAppearance.BorderSize = 2;
            this.cmdGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdGrabar.Location = new System.Drawing.Point(387, 672);
            this.cmdGrabar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmdGrabar.Name = "cmdGrabar";
            this.cmdGrabar.Size = new System.Drawing.Size(171, 29);
            this.cmdGrabar.TabIndex = 1;
            this.cmdGrabar.Text = "Grabar";
            this.cmdGrabar.UseVisualStyleBackColor = true;
            this.cmdGrabar.Click += new System.EventHandler(this.cmdGrabar_Click);
            // 
            // pnlLogin
            // 
            this.pnlLogin.BackColor = System.Drawing.Color.SteelBlue;
            this.pnlLogin.Controls.Add(this.pbxmin2);
            this.pnlLogin.Controls.Add(this.pbxX2);
            this.pnlLogin.Controls.Add(this.pbxX);
            this.pnlLogin.Controls.Add(this.pbxmin);
            this.pnlLogin.Location = new System.Drawing.Point(-3, 0);
            this.pnlLogin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(827, 32);
            this.pnlLogin.TabIndex = 0;
            // 
            // pbxmin2
            // 
            this.pbxmin2.Image = global::Mi_mercadito.Properties.Resources.btn_min21;
            this.pbxmin2.Location = new System.Drawing.Point(741, 1);
            this.pbxmin2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pbxmin2.Name = "pbxmin2";
            this.pbxmin2.Size = new System.Drawing.Size(40, 30);
            this.pbxmin2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxmin2.TabIndex = 13;
            this.pbxmin2.TabStop = false;
            this.pbxmin2.Visible = false;
            this.pbxmin2.Click += new System.EventHandler(this.pbxmin2_Click);
            this.pbxmin2.MouseLeave += new System.EventHandler(this.pbxmin2_MouseLeave);
            // 
            // pbxX2
            // 
            this.pbxX2.Image = global::Mi_mercadito.Properties.Resources.btn_X2;
            this.pbxX2.Location = new System.Drawing.Point(784, 1);
            this.pbxX2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pbxX2.Name = "pbxX2";
            this.pbxX2.Size = new System.Drawing.Size(40, 30);
            this.pbxX2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxX2.TabIndex = 26;
            this.pbxX2.TabStop = false;
            this.pbxX2.Visible = false;
            this.pbxX2.Click += new System.EventHandler(this.pbxX2_Click);
            this.pbxX2.MouseLeave += new System.EventHandler(this.pbxX2_MouseLeave);
            // 
            // pbxX
            // 
            this.pbxX.Image = global::Mi_mercadito.Properties.Resources.btn_X;
            this.pbxX.Location = new System.Drawing.Point(784, 1);
            this.pbxX.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pbxX.Name = "pbxX";
            this.pbxX.Size = new System.Drawing.Size(40, 30);
            this.pbxX.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxX.TabIndex = 10;
            this.pbxX.TabStop = false;
            this.pbxX.MouseLeave += new System.EventHandler(this.pbxX_MouseLeave);
            this.pbxX.MouseHover += new System.EventHandler(this.pbxX_MouseHover);
            // 
            // pbxmin
            // 
            this.pbxmin.Image = global::Mi_mercadito.Properties.Resources.btn_min1;
            this.pbxmin.Location = new System.Drawing.Point(741, 1);
            this.pbxmin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pbxmin.Name = "pbxmin";
            this.pbxmin.Size = new System.Drawing.Size(40, 30);
            this.pbxmin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxmin.TabIndex = 0;
            this.pbxmin.TabStop = false;
            this.pbxmin.MouseLeave += new System.EventHandler(this.pbxmin_MouseLeave);
            this.pbxmin.MouseHover += new System.EventHandler(this.pbxmin_MouseHover);
            // 
            // FrmCamara
            // 
            this.AcceptButton = this.cmdGrabar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(823, 717);
            this.Controls.Add(this.pnlLogin);
            this.Controls.Add(this.cmdGrabar);
            this.Controls.Add(this.cboxCamara);
            this.Controls.Add(this.cmdFoto);
            this.Controls.Add(this.pbox_Camara);
            this.Font = new System.Drawing.Font("Perpetua Titling MT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FrmCamara";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmCámara";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmCamara_FormClosed);
            this.Load += new System.EventHandler(this.FrmCámara_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbox_Camara)).EndInit();
            this.pnlLogin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxmin2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxX2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxmin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button cmdFoto;
        private System.Windows.Forms.ComboBox cboxCamara;
        private System.Windows.Forms.Button cmdGrabar;
        public System.Windows.Forms.PictureBox pbox_Camara;
        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.PictureBox pbxX;
        private System.Windows.Forms.PictureBox pbxmin;
        private System.Windows.Forms.PictureBox pbxX2;
        private System.Windows.Forms.PictureBox pbxmin2;
    }
}