
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
            this.pbox_Camara = new System.Windows.Forms.PictureBox();
            this.btn_CapturarFoto = new System.Windows.Forms.Button();
            this.cbox_Camara = new System.Windows.Forms.ComboBox();
            this.btn_Grabar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_Camara)).BeginInit();
            this.SuspendLayout();
            // 
            // pbox_Camara
            // 
            this.pbox_Camara.Location = new System.Drawing.Point(10, 12);
            this.pbox_Camara.Name = "pbox_Camara";
            this.pbox_Camara.Size = new System.Drawing.Size(595, 610);
            this.pbox_Camara.TabIndex = 0;
            this.pbox_Camara.TabStop = false;
            // 
            // btn_CapturarFoto
            // 
            this.btn_CapturarFoto.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_CapturarFoto.Location = new System.Drawing.Point(456, 628);
            this.btn_CapturarFoto.Name = "btn_CapturarFoto";
            this.btn_CapturarFoto.Size = new System.Drawing.Size(128, 30);
            this.btn_CapturarFoto.TabIndex = 1;
            this.btn_CapturarFoto.Text = "Tomar Foto";
            this.btn_CapturarFoto.UseVisualStyleBackColor = true;
            this.btn_CapturarFoto.Click += new System.EventHandler(this.btn_CapturarFoto_Click);
            // 
            // cbox_Camara
            // 
            this.cbox_Camara.FormattingEnabled = true;
            this.cbox_Camara.Location = new System.Drawing.Point(50, 628);
            this.cbox_Camara.Name = "cbox_Camara";
            this.cbox_Camara.Size = new System.Drawing.Size(192, 21);
            this.cbox_Camara.TabIndex = 2;
            // 
            // btn_Grabar
            // 
            this.btn_Grabar.Location = new System.Drawing.Point(290, 628);
            this.btn_Grabar.Name = "btn_Grabar";
            this.btn_Grabar.Size = new System.Drawing.Size(128, 29);
            this.btn_Grabar.TabIndex = 3;
            this.btn_Grabar.Text = "Grabar";
            this.btn_Grabar.UseVisualStyleBackColor = true;
            this.btn_Grabar.Click += new System.EventHandler(this.btn_Grabar_Click);
            // 
            // FrmCámara
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 674);
            this.Controls.Add(this.btn_Grabar);
            this.Controls.Add(this.cbox_Camara);
            this.Controls.Add(this.btn_CapturarFoto);
            this.Controls.Add(this.pbox_Camara);
            this.Name = "FrmCámara";
            this.Text = "FrmCámara";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmCámara_FormClosed);
            this.Load += new System.EventHandler(this.FrmCámara_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbox_Camara)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_CapturarFoto;
        private System.Windows.Forms.ComboBox cbox_Camara;
        private System.Windows.Forms.Button btn_Grabar;
        public System.Windows.Forms.PictureBox pbox_Camara;
    }
}