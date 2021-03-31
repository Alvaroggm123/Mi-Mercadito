
namespace Mi_mercadito
{
    partial class FrmCámara
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCámara));
            this.pbox_Camara = new System.Windows.Forms.PictureBox();
            this.cmdFoto = new System.Windows.Forms.Button();
            this.cbox_Camara = new System.Windows.Forms.ComboBox();
            this.cmdGrabar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_Camara)).BeginInit();
            this.SuspendLayout();
            // 
            // pbox_Camara
            // 
            this.pbox_Camara.Image = ((System.Drawing.Image)(resources.GetObject("pbox_Camara.Image")));
            this.pbox_Camara.Location = new System.Drawing.Point(10, 12);
            this.pbox_Camara.Name = "pbox_Camara";
            this.pbox_Camara.Size = new System.Drawing.Size(595, 610);
            this.pbox_Camara.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbox_Camara.TabIndex = 0;
            this.pbox_Camara.TabStop = false;
            // 
            // cmdFoto
            // 
            this.cmdFoto.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdFoto.Location = new System.Drawing.Point(456, 628);
            this.cmdFoto.Name = "cmdFoto";
            this.cmdFoto.Size = new System.Drawing.Size(128, 30);
            this.cmdFoto.TabIndex = 2;
            this.cmdFoto.Text = "Tomar Foto";
            this.cmdFoto.UseVisualStyleBackColor = true;
            this.cmdFoto.Click += new System.EventHandler(this.btn_CapturarFoto_Click);
            // 
            // cbox_Camara
            // 
            this.cbox_Camara.FormattingEnabled = true;
            this.cbox_Camara.Location = new System.Drawing.Point(50, 628);
            this.cbox_Camara.Name = "cbox_Camara";
            this.cbox_Camara.Size = new System.Drawing.Size(192, 21);
            this.cbox_Camara.TabIndex = 0;
            // 
            // cmdGrabar
            // 
            this.cmdGrabar.Location = new System.Drawing.Point(290, 628);
            this.cmdGrabar.Name = "cmdGrabar";
            this.cmdGrabar.Size = new System.Drawing.Size(128, 29);
            this.cmdGrabar.TabIndex = 1;
            this.cmdGrabar.Text = "Grabar";
            this.cmdGrabar.UseVisualStyleBackColor = true;
            this.cmdGrabar.Click += new System.EventHandler(this.btn_Grabar_Click);
            // 
            // FrmCámara
            // 
            this.AcceptButton = this.cmdGrabar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 674);
            this.Controls.Add(this.cmdGrabar);
            this.Controls.Add(this.cbox_Camara);
            this.Controls.Add(this.cmdFoto);
            this.Controls.Add(this.pbox_Camara);
            this.Name = "FrmCámara";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmCámara";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmCámara_FormClosed);
            this.Load += new System.EventHandler(this.FrmCámara_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbox_Camara)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button cmdFoto;
        private System.Windows.Forms.ComboBox cbox_Camara;
        private System.Windows.Forms.Button cmdGrabar;
        public System.Windows.Forms.PictureBox pbox_Camara;
    }
}