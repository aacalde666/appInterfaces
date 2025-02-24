namespace ventana
{
    partial class CestaControl
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanelCesta = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // flowLayoutPanelCesta
            // 
            this.flowLayoutPanelCesta.AutoScroll = true;
            this.flowLayoutPanelCesta.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelCesta.Location = new System.Drawing.Point(0, 60);
            this.flowLayoutPanelCesta.Name = "flowLayoutPanelCesta";
            this.flowLayoutPanelCesta.Size = new System.Drawing.Size(335, 516);
            this.flowLayoutPanelCesta.TabIndex = 0;
            this.flowLayoutPanelCesta.WrapContents = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mistral", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(89, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 57);
            this.label1.TabIndex = 1;
            this.label1.Text = "CESTA";
            // 
            // CestaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanelCesta);
            this.Name = "CestaControl";
            this.Size = new System.Drawing.Size(335, 576);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelCesta;
        private System.Windows.Forms.Label label1;
    }
}
