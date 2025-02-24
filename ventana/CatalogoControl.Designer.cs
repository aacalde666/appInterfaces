using System.Windows.Forms;
using System;
using System.Drawing;

namespace ventana.UsersControl
{
    partial class CatalogoControl
    {
        private System.ComponentModel.IContainer components = null;
        private FlowLayoutPanel flowLayoutPanelCatalogo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.flowLayoutPanelCatalogo = new System.Windows.Forms.FlowLayoutPanel();
            this.textbusqueda = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // flowLayoutPanelCatalogo
            // 
            this.flowLayoutPanelCatalogo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelCatalogo.AutoScroll = true;
            this.flowLayoutPanelCatalogo.Location = new System.Drawing.Point(0, 30);
            this.flowLayoutPanelCatalogo.Name = "flowLayoutPanelCatalogo";
            this.flowLayoutPanelCatalogo.Size = new System.Drawing.Size(757, 447);
            this.flowLayoutPanelCatalogo.TabIndex = 0;
            // 
            // textbusqueda
            // 
            this.textbusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textbusqueda.Location = new System.Drawing.Point(3, 4);
            this.textbusqueda.Name = "textbusqueda";
            this.textbusqueda.Size = new System.Drawing.Size(754, 20);
            this.textbusqueda.TabIndex = 1;
            // 
            // CatalogoControl
            // 
            this.Controls.Add(this.textbusqueda);
            this.Controls.Add(this.flowLayoutPanelCatalogo);
            this.Name = "CatalogoControl";
            this.Size = new System.Drawing.Size(760, 480);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private Button btnEliminar;
        private TextBox textbusqueda;
    }
}
