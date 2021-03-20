
namespace Mi_mercadito
{
    partial class FrmMain
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
            this.lbl_miMercadito = new System.Windows.Forms.Label();
            this.txt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbl_miMercadito
            // 
            this.lbl_miMercadito.AutoSize = true;
            this.lbl_miMercadito.Location = new System.Drawing.Point(60, 27);
            this.lbl_miMercadito.Name = "lbl_miMercadito";
            this.lbl_miMercadito.Size = new System.Drawing.Size(68, 13);
            this.lbl_miMercadito.TabIndex = 0;
            this.lbl_miMercadito.Text = "Mi Mercadito";
            // 
            // txt
            // 
            this.txt.Location = new System.Drawing.Point(163, 20);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(205, 20);
            this.txt.TabIndex = 1;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 660);
            this.Controls.Add(this.txt);
            this.Controls.Add(this.lbl_miMercadito);
            this.Name = "FrmMain";
            this.Text = "FrmMain";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_miMercadito;
        private System.Windows.Forms.TextBox txt;
    }
}