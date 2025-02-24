namespace ventana
{
    partial class ventanaAdminForm
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
            this.fondo = new System.Windows.Forms.PictureBox();
            this.Creacionbtn = new System.Windows.Forms.Button();
            this.modificacionbtn = new System.Windows.Forms.Button();
            this.eliminarbtn = new System.Windows.Forms.Button();
            this.consultabtn = new System.Windows.Forms.Button();
            this.tablaConsulta = new System.Windows.Forms.DataGridView();
            this.textbusqueda = new System.Windows.Forms.TextBox();
            this.btnBusqueda = new System.Windows.Forms.Button();
            this.btnCatalogo = new System.Windows.Forms.Button();
            this.panelCatalogo = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.fondo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaConsulta)).BeginInit();
            this.SuspendLayout();
            // 
            // fondo
            // 
            this.fondo.Image = global::ventana.Properties.Resources._390395ce5a4898831f908cb7a30334b4_ba909e21fa91171dbf7d8b05150c20a2;
            this.fondo.Location = new System.Drawing.Point(1, -2);
            this.fondo.Name = "fondo";
            this.fondo.Size = new System.Drawing.Size(33, 27);
            this.fondo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.fondo.TabIndex = 0;
            this.fondo.TabStop = false;
            this.fondo.Click += new System.EventHandler(this.fondo_Click);
            // 
            // Creacionbtn
            // 
            this.Creacionbtn.Location = new System.Drawing.Point(42, 28);
            this.Creacionbtn.Name = "Creacionbtn";
            this.Creacionbtn.Size = new System.Drawing.Size(118, 44);
            this.Creacionbtn.TabIndex = 1;
            this.Creacionbtn.Text = "Crear Usuario";
            this.Creacionbtn.UseVisualStyleBackColor = true;
            this.Creacionbtn.Click += new System.EventHandler(this.Creacionbtn_Click);
            // 
            // modificacionbtn
            // 
            this.modificacionbtn.Location = new System.Drawing.Point(193, 28);
            this.modificacionbtn.Name = "modificacionbtn";
            this.modificacionbtn.Size = new System.Drawing.Size(118, 44);
            this.modificacionbtn.TabIndex = 2;
            this.modificacionbtn.Text = "Modicar Usuario";
            this.modificacionbtn.UseVisualStyleBackColor = true;
            this.modificacionbtn.Click += new System.EventHandler(this.modificacionbtn_Click);
            // 
            // eliminarbtn
            // 
            this.eliminarbtn.Location = new System.Drawing.Point(348, 28);
            this.eliminarbtn.Name = "eliminarbtn";
            this.eliminarbtn.Size = new System.Drawing.Size(118, 44);
            this.eliminarbtn.TabIndex = 3;
            this.eliminarbtn.Text = "Eliminar Usuario";
            this.eliminarbtn.UseVisualStyleBackColor = true;
            this.eliminarbtn.Click += new System.EventHandler(this.eliminarbtn_Click);
            // 
            // consultabtn
            // 
            this.consultabtn.Location = new System.Drawing.Point(499, 28);
            this.consultabtn.Name = "consultabtn";
            this.consultabtn.Size = new System.Drawing.Size(118, 44);
            this.consultabtn.TabIndex = 4;
            this.consultabtn.Text = "Consultar Usuario";
            this.consultabtn.UseVisualStyleBackColor = true;
            this.consultabtn.Click += new System.EventHandler(this.consultabtn_Click);
            // 
            // tablaConsulta
            // 
            this.tablaConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaConsulta.Location = new System.Drawing.Point(42, 107);
            this.tablaConsulta.MultiSelect = false;
            this.tablaConsulta.Name = "tablaConsulta";
            this.tablaConsulta.Size = new System.Drawing.Size(1298, 635);
            this.tablaConsulta.TabIndex = 5;
            // 
            // textbusqueda
            // 
            this.textbusqueda.Location = new System.Drawing.Point(894, 41);
            this.textbusqueda.Name = "textbusqueda";
            this.textbusqueda.Size = new System.Drawing.Size(324, 20);
            this.textbusqueda.TabIndex = 6;
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.Location = new System.Drawing.Point(1224, 28);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(116, 44);
            this.btnBusqueda.TabIndex = 7;
            this.btnBusqueda.Text = "Buscar";
            this.btnBusqueda.UseVisualStyleBackColor = true;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
            // 
            // btnCatalogo
            // 
            this.btnCatalogo.Location = new System.Drawing.Point(649, 28);
            this.btnCatalogo.Name = "btnCatalogo";
            this.btnCatalogo.Size = new System.Drawing.Size(118, 44);
            this.btnCatalogo.TabIndex = 8;
            this.btnCatalogo.Text = "Catalogo videojuegos";
            this.btnCatalogo.UseVisualStyleBackColor = true;
            this.btnCatalogo.Click += new System.EventHandler(this.btnCatalogo_Click);
            // 
            // panelCatalogo
            // 
            this.panelCatalogo.Location = new System.Drawing.Point(13, 86);
            this.panelCatalogo.Name = "panelCatalogo";
            this.panelCatalogo.Size = new System.Drawing.Size(39, 15);
            this.panelCatalogo.TabIndex = 9;
            // 
            // ventanaAdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1387, 778);
            this.Controls.Add(this.panelCatalogo);
            this.Controls.Add(this.btnCatalogo);
            this.Controls.Add(this.btnBusqueda);
            this.Controls.Add(this.textbusqueda);
            this.Controls.Add(this.tablaConsulta);
            this.Controls.Add(this.consultabtn);
            this.Controls.Add(this.eliminarbtn);
            this.Controls.Add(this.modificacionbtn);
            this.Controls.Add(this.Creacionbtn);
            this.Controls.Add(this.fondo);
            this.Name = "ventanaAdminForm";
            this.Text = "Admin";
            ((System.ComponentModel.ISupportInitialize)(this.fondo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaConsulta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox fondo;
        private System.Windows.Forms.Button Creacionbtn;
        private System.Windows.Forms.Button modificacionbtn;
        private System.Windows.Forms.Button eliminarbtn;
        private System.Windows.Forms.Button consultabtn;
        private System.Windows.Forms.DataGridView tablaConsulta;
        private System.Windows.Forms.TextBox textbusqueda;
        private System.Windows.Forms.Button btnBusqueda;
        private System.Windows.Forms.Button btnCatalogo;
        private System.Windows.Forms.Panel panelCatalogo;
    }
}