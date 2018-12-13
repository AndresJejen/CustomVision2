namespace Intefaz
{
    partial class FCustomVision
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnPathImg = new System.Windows.Forms.Button();
            this.TxtResultado = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // BtnPathImg
            // 
            this.BtnPathImg.Location = new System.Drawing.Point(52, 30);
            this.BtnPathImg.Name = "BtnPathImg";
            this.BtnPathImg.Size = new System.Drawing.Size(157, 59);
            this.BtnPathImg.TabIndex = 0;
            this.BtnPathImg.Text = "Buscar imagen";
            this.BtnPathImg.UseVisualStyleBackColor = true;
            this.BtnPathImg.Click += new System.EventHandler(this.BtnPathImg_Click);
            // 
            // TxtResultado
            // 
            this.TxtResultado.Location = new System.Drawing.Point(52, 95);
            this.TxtResultado.Name = "TxtResultado";
            this.TxtResultado.Size = new System.Drawing.Size(532, 614);
            this.TxtResultado.TabIndex = 1;
            this.TxtResultado.Text = "";
            // 
            // FCustomVision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 732);
            this.Controls.Add(this.TxtResultado);
            this.Controls.Add(this.BtnPathImg);
            this.Name = "FCustomVision";
            this.Text = "CustomVision";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnPathImg;
        private System.Windows.Forms.RichTextBox TxtResultado;
    }
}

