using System.Windows.Forms;
using System;
using ventana.UsersControl;

namespace ventana
{
    partial class MainCatalogo
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelCatalogo;
        private Button btnGestionarCatalogo;
        private Button btnAgregarJuego;

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
            this.btnGestionarCatalogo = new System.Windows.Forms.Button();
            this.btnAgregarJuego = new System.Windows.Forms.Button();
            this.panelCatalogo = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnGestionarCatalogo
            // 
            this.btnGestionarCatalogo.Location = new System.Drawing.Point(20, 20);
            this.btnGestionarCatalogo.Name = "btnGestionarCatalogo";
            this.btnGestionarCatalogo.Size = new System.Drawing.Size(150, 30);
            this.btnGestionarCatalogo.TabIndex = 0;
            this.btnGestionarCatalogo.Text = "Gestionar Catálogo";
            this.btnGestionarCatalogo.UseVisualStyleBackColor = true;
            this.btnGestionarCatalogo.Click += new System.EventHandler(this.btnGestionarCatalogo_Click);
            // 
            // btnAgregarJuego
            // 
            this.btnAgregarJuego.Location = new System.Drawing.Point(180, 20);
            this.btnAgregarJuego.Name = "btnAgregarJuego";
            this.btnAgregarJuego.Size = new System.Drawing.Size(150, 30);
            this.btnAgregarJuego.TabIndex = 1;
            this.btnAgregarJuego.Text = "Agregar Juego";
            this.btnAgregarJuego.UseVisualStyleBackColor = true;
            this.btnAgregarJuego.Click += new System.EventHandler(this.btnAgregarJuego_Click);
            // 
            // panelCatalogo
            // 
            this.panelCatalogo.AutoScroll = true;
            this.panelCatalogo.Location = new System.Drawing.Point(20, 60);
            this.panelCatalogo.Name = "panelCatalogo";
            this.panelCatalogo.Size = new System.Drawing.Size(760, 480);
            this.panelCatalogo.TabIndex = 2;
            // 
            // MainCatalogo
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.panelCatalogo);
            this.Controls.Add(this.btnAgregarJuego);
            this.Controls.Add(this.btnGestionarCatalogo);
            this.Name = "MainCatalogo";
            this.Size = new System.Drawing.Size(800, 556);
            this.ResumeLayout(false);

        }
    }
}