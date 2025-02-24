namespace ventana
{
    partial class modificarUsuarioForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textusuario = new System.Windows.Forms.TextBox();
            this.textcorreo = new System.Windows.Forms.TextBox();
            this.textcontraseña = new System.Windows.Forms.TextBox();
            this.banCheck = new System.Windows.Forms.CheckBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.estadocheck = new System.Windows.Forms.CheckBox();
            this.rolcombo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblClave = new System.Windows.Forms.Label();
            this.textClave = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(414, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "Modificar Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Usuario";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Correo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(40, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Contraseña";
            // 
            // textusuario
            // 
            this.textusuario.Location = new System.Drawing.Point(154, 123);
            this.textusuario.Name = "textusuario";
            this.textusuario.Size = new System.Drawing.Size(291, 20);
            this.textusuario.TabIndex = 5;
            // 
            // textcorreo
            // 
            this.textcorreo.Location = new System.Drawing.Point(154, 161);
            this.textcorreo.Name = "textcorreo";
            this.textcorreo.Size = new System.Drawing.Size(291, 20);
            this.textcorreo.TabIndex = 6;
            // 
            // textcontraseña
            // 
            this.textcontraseña.Location = new System.Drawing.Point(154, 200);
            this.textcontraseña.Name = "textcontraseña";
            this.textcontraseña.Size = new System.Drawing.Size(291, 20);
            this.textcontraseña.TabIndex = 7;
            // 
            // banCheck
            // 
            this.banCheck.AutoSize = true;
            this.banCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.banCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.banCheck.Location = new System.Drawing.Point(370, 239);
            this.banCheck.Name = "banCheck";
            this.banCheck.Size = new System.Drawing.Size(75, 24);
            this.banCheck.TabIndex = 8;
            this.banCheck.Text = "Baneo";
            this.banCheck.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(285, 290);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(82, 23);
            this.btnGuardar.TabIndex = 9;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(373, 290);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(40, 239);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Rol";
            // 
            // estadocheck
            // 
            this.estadocheck.AutoSize = true;
            this.estadocheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.estadocheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.estadocheck.Location = new System.Drawing.Point(154, 289);
            this.estadocheck.Name = "estadocheck";
            this.estadocheck.Size = new System.Drawing.Size(69, 24);
            this.estadocheck.TabIndex = 13;
            this.estadocheck.Text = "activo";
            this.estadocheck.UseVisualStyleBackColor = true;
            // 
            // rolcombo
            // 
            this.rolcombo.FormattingEnabled = true;
            this.rolcombo.Items.AddRange(new object[] {
            "user",
            "admin",
            "owner"});
            this.rolcombo.Location = new System.Drawing.Point(154, 241);
            this.rolcombo.Name = "rolcombo";
            this.rolcombo.Size = new System.Drawing.Size(121, 21);
            this.rolcombo.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(40, 290);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "Estado";
            // 
            // lblClave
            // 
            this.lblClave.AutoSize = true;
            this.lblClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClave.Location = new System.Drawing.Point(40, 332);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(48, 20);
            this.lblClave.TabIndex = 16;
            this.lblClave.Text = "Clave";
            // 
            // textClave
            // 
            this.textClave.Location = new System.Drawing.Point(154, 331);
            this.textClave.Name = "textClave";
            this.textClave.Size = new System.Drawing.Size(291, 20);
            this.textClave.TabIndex = 17;
            // 
            // modificarUsuarioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 382);
            this.Controls.Add(this.textClave);
            this.Controls.Add(this.lblClave);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.rolcombo);
            this.Controls.Add(this.estadocheck);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.banCheck);
            this.Controls.Add(this.textcontraseña);
            this.Controls.Add(this.textcorreo);
            this.Controls.Add(this.textusuario);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "modificarUsuarioForm";
            this.Text = "modificarUsuarioForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textusuario;
        private System.Windows.Forms.TextBox textcorreo;
        private System.Windows.Forms.TextBox textcontraseña;
        private System.Windows.Forms.CheckBox banCheck;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox estadocheck;
        private System.Windows.Forms.ComboBox rolcombo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.TextBox textClave;
    }
}