namespace ventana
{
    partial class EditorVideojuegoForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblGenero;
        private System.Windows.Forms.Label lblPlataforma;
        private System.Windows.Forms.Label lblDesarrollador;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblFechaSalida;
        private System.Windows.Forms.Label lblEditor;
        private System.Windows.Forms.Label lblModoDeJuego;
        private System.Windows.Forms.Label lblClasificacionDeEdades;
        private System.Windows.Forms.Label lblRequisitos;
        private System.Windows.Forms.Label lblIdiomas;
        private System.Windows.Forms.Label lblDLC;
        private System.Windows.Forms.Label lblValoracion;
        private System.Windows.Forms.Label lblNumVentas;

        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.TextBox txtDesarrollador;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtEditor;
        private System.Windows.Forms.TextBox txtRequisitos;
        private System.Windows.Forms.TextBox txtDLC;
        private System.Windows.Forms.TextBox txtIdiomas;

        private System.Windows.Forms.ComboBox cmbPlataforma;
        private System.Windows.Forms.ComboBox cmbGenero;
        private System.Windows.Forms.ComboBox cmbModoDeJuego;
        private System.Windows.Forms.ComboBox cmbClasificacionDeEdades;
        private System.Windows.Forms.DateTimePicker dtpFechaSalida;

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.PictureBox pbImagen;
        private System.Windows.Forms.Button btnSeleccionarImagen;
        private System.Windows.Forms.Button btnEditar;

        private System.Windows.Forms.Label lblValoracionSeleccionada;
        private System.Windows.Forms.Panel pnlValoracion;

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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblGenero = new System.Windows.Forms.Label();
            this.lblPlataforma = new System.Windows.Forms.Label();
            this.lblDesarrollador = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblFechaSalida = new System.Windows.Forms.Label();
            this.lblEditor = new System.Windows.Forms.Label();
            this.lblModoDeJuego = new System.Windows.Forms.Label();
            this.lblClasificacionDeEdades = new System.Windows.Forms.Label();
            this.lblRequisitos = new System.Windows.Forms.Label();
            this.lblIdiomas = new System.Windows.Forms.Label();
            this.lblDLC = new System.Windows.Forms.Label();
            this.lblValoracion = new System.Windows.Forms.Label();
            this.lblNumVentas = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.txtDesarrollador = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtEditor = new System.Windows.Forms.TextBox();
            this.txtRequisitos = new System.Windows.Forms.TextBox();
            this.txtDLC = new System.Windows.Forms.TextBox();
            this.txtIdiomas = new System.Windows.Forms.TextBox();
            this.cmbPlataforma = new System.Windows.Forms.ComboBox();
            this.cmbGenero = new System.Windows.Forms.ComboBox();
            this.cmbModoDeJuego = new System.Windows.Forms.ComboBox();
            this.cmbClasificacionDeEdades = new System.Windows.Forms.ComboBox();
            this.dtpFechaSalida = new System.Windows.Forms.DateTimePicker();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSeleccionarImagen = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.lblValoracionSeleccionada = new System.Windows.Forms.Label();
            this.pnlValoracion = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblNvent = new System.Windows.Forms.Label();
            this.lblSimboloDinero = new System.Windows.Forms.Label();
            this.pbImagen = new System.Windows.Forms.PictureBox();
            this.btnCesta = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(20, 32);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(38, 13);
            this.lblTitulo.TabIndex = 35;
            this.lblTitulo.Text = "Título:";
            // 
            // lblGenero
            // 
            this.lblGenero.AutoSize = true;
            this.lblGenero.Location = new System.Drawing.Point(20, 185);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Size = new System.Drawing.Size(45, 13);
            this.lblGenero.TabIndex = 34;
            this.lblGenero.Text = "Género:";
            // 
            // lblPlataforma
            // 
            this.lblPlataforma.AutoSize = true;
            this.lblPlataforma.Location = new System.Drawing.Point(20, 117);
            this.lblPlataforma.Name = "lblPlataforma";
            this.lblPlataforma.Size = new System.Drawing.Size(60, 13);
            this.lblPlataforma.TabIndex = 33;
            this.lblPlataforma.Text = "Plataforma:";
            // 
            // lblDesarrollador
            // 
            this.lblDesarrollador.AutoSize = true;
            this.lblDesarrollador.Location = new System.Drawing.Point(20, 153);
            this.lblDesarrollador.Name = "lblDesarrollador";
            this.lblDesarrollador.Size = new System.Drawing.Size(72, 13);
            this.lblDesarrollador.TabIndex = 32;
            this.lblDesarrollador.Text = "Desarrollador:";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(20, 76);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(66, 13);
            this.lblDescripcion.TabIndex = 30;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(20, 220);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(40, 13);
            this.lblPrecio.TabIndex = 29;
            this.lblPrecio.Text = "Precio:";
            // 
            // lblFechaSalida
            // 
            this.lblFechaSalida.AutoSize = true;
            this.lblFechaSalida.Location = new System.Drawing.Point(20, 257);
            this.lblFechaSalida.Name = "lblFechaSalida";
            this.lblFechaSalida.Size = new System.Drawing.Size(85, 13);
            this.lblFechaSalida.TabIndex = 28;
            this.lblFechaSalida.Text = "Fecha de salida:";
            // 
            // lblEditor
            // 
            this.lblEditor.AutoSize = true;
            this.lblEditor.Location = new System.Drawing.Point(20, 294);
            this.lblEditor.Name = "lblEditor";
            this.lblEditor.Size = new System.Drawing.Size(37, 13);
            this.lblEditor.TabIndex = 27;
            this.lblEditor.Text = "Editor:";
            // 
            // lblModoDeJuego
            // 
            this.lblModoDeJuego.AutoSize = true;
            this.lblModoDeJuego.Location = new System.Drawing.Point(20, 330);
            this.lblModoDeJuego.Name = "lblModoDeJuego";
            this.lblModoDeJuego.Size = new System.Drawing.Size(81, 13);
            this.lblModoDeJuego.TabIndex = 26;
            this.lblModoDeJuego.Text = "Modo de juego:";
            // 
            // lblClasificacionDeEdades
            // 
            this.lblClasificacionDeEdades.AutoSize = true;
            this.lblClasificacionDeEdades.Location = new System.Drawing.Point(20, 366);
            this.lblClasificacionDeEdades.Name = "lblClasificacionDeEdades";
            this.lblClasificacionDeEdades.Size = new System.Drawing.Size(122, 13);
            this.lblClasificacionDeEdades.TabIndex = 25;
            this.lblClasificacionDeEdades.Text = "Clasificación de edades:";
            // 
            // lblRequisitos
            // 
            this.lblRequisitos.AutoSize = true;
            this.lblRequisitos.Location = new System.Drawing.Point(20, 402);
            this.lblRequisitos.Name = "lblRequisitos";
            this.lblRequisitos.Size = new System.Drawing.Size(59, 13);
            this.lblRequisitos.TabIndex = 24;
            this.lblRequisitos.Text = "Requisitos:";
            // 
            // lblIdiomas
            // 
            this.lblIdiomas.AutoSize = true;
            this.lblIdiomas.Location = new System.Drawing.Point(20, 448);
            this.lblIdiomas.Name = "lblIdiomas";
            this.lblIdiomas.Size = new System.Drawing.Size(46, 13);
            this.lblIdiomas.TabIndex = 23;
            this.lblIdiomas.Text = "Idiomas:";
            // 
            // lblDLC
            // 
            this.lblDLC.AutoSize = true;
            this.lblDLC.Location = new System.Drawing.Point(20, 494);
            this.lblDLC.Name = "lblDLC";
            this.lblDLC.Size = new System.Drawing.Size(31, 13);
            this.lblDLC.TabIndex = 22;
            this.lblDLC.Text = "DLC:";
            // 
            // lblValoracion
            // 
            this.lblValoracion.AutoSize = true;
            this.lblValoracion.Location = new System.Drawing.Point(20, 529);
            this.lblValoracion.Name = "lblValoracion";
            this.lblValoracion.Size = new System.Drawing.Size(60, 13);
            this.lblValoracion.TabIndex = 21;
            this.lblValoracion.Text = "Valoración:";
            // 
            // lblNumVentas
            // 
            this.lblNumVentas.AutoSize = true;
            this.lblNumVentas.Location = new System.Drawing.Point(20, 566);
            this.lblNumVentas.Name = "lblNumVentas";
            this.lblNumVentas.Size = new System.Drawing.Size(97, 13);
            this.lblNumVentas.TabIndex = 20;
            this.lblNumVentas.Text = "Número de ventas:";
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(148, 20);
            this.txtTitulo.Multiline = true;
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(200, 34);
            this.txtTitulo.TabIndex = 0;
            // 
            // txtDesarrollador
            // 
            this.txtDesarrollador.Location = new System.Drawing.Point(148, 141);
            this.txtDesarrollador.Multiline = true;
            this.txtDesarrollador.Name = "txtDesarrollador";
            this.txtDesarrollador.Size = new System.Drawing.Size(200, 35);
            this.txtDesarrollador.TabIndex = 3;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(148, 60);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(200, 48);
            this.txtDescripcion.TabIndex = 5;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(148, 217);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(200, 20);
            this.txtPrecio.TabIndex = 6;
            // 
            // txtEditor
            // 
            this.txtEditor.Location = new System.Drawing.Point(148, 280);
            this.txtEditor.Multiline = true;
            this.txtEditor.Name = "txtEditor";
            this.txtEditor.Size = new System.Drawing.Size(200, 41);
            this.txtEditor.TabIndex = 8;
            // 
            // txtRequisitos
            // 
            this.txtRequisitos.Location = new System.Drawing.Point(148, 390);
            this.txtRequisitos.Multiline = true;
            this.txtRequisitos.Name = "txtRequisitos";
            this.txtRequisitos.Size = new System.Drawing.Size(200, 38);
            this.txtRequisitos.TabIndex = 11;
            // 
            // txtDLC
            // 
            this.txtDLC.Location = new System.Drawing.Point(148, 482);
            this.txtDLC.Multiline = true;
            this.txtDLC.Name = "txtDLC";
            this.txtDLC.Size = new System.Drawing.Size(200, 38);
            this.txtDLC.TabIndex = 13;
            // 
            // txtIdiomas
            // 
            this.txtIdiomas.Location = new System.Drawing.Point(148, 434);
            this.txtIdiomas.Multiline = true;
            this.txtIdiomas.Name = "txtIdiomas";
            this.txtIdiomas.Size = new System.Drawing.Size(200, 42);
            this.txtIdiomas.TabIndex = 12;
            // 
            // cmbPlataforma
            // 
            this.cmbPlataforma.FormattingEnabled = true;
            this.cmbPlataforma.Items.AddRange(new object[] {
            "PC",
            "PlayStation 5",
            "Xbox Series X",
            "Nintendo Switch"});
            this.cmbPlataforma.Location = new System.Drawing.Point(148, 114);
            this.cmbPlataforma.Name = "cmbPlataforma";
            this.cmbPlataforma.Size = new System.Drawing.Size(200, 21);
            this.cmbPlataforma.TabIndex = 2;
            // 
            // cmbGenero
            // 
            this.cmbGenero.FormattingEnabled = true;
            this.cmbGenero.Items.AddRange(new object[] {
            "Acción",
            "Aventura",
            "RPG",
            "Estrategia",
            "Deportes"});
            this.cmbGenero.Location = new System.Drawing.Point(148, 182);
            this.cmbGenero.Name = "cmbGenero";
            this.cmbGenero.Size = new System.Drawing.Size(200, 21);
            this.cmbGenero.TabIndex = 1;
            // 
            // cmbModoDeJuego
            // 
            this.cmbModoDeJuego.FormattingEnabled = true;
            this.cmbModoDeJuego.Items.AddRange(new object[] {
            "Un jugador",
            "Multijugador",
            "Cooperativo"});
            this.cmbModoDeJuego.Location = new System.Drawing.Point(148, 327);
            this.cmbModoDeJuego.Name = "cmbModoDeJuego";
            this.cmbModoDeJuego.Size = new System.Drawing.Size(200, 21);
            this.cmbModoDeJuego.TabIndex = 9;
            // 
            // cmbClasificacionDeEdades
            // 
            this.cmbClasificacionDeEdades.FormattingEnabled = true;
            this.cmbClasificacionDeEdades.Items.AddRange(new object[] {
            "PEGI 3",
            "PEGI 7",
            "PEGI 12",
            "PEGI 16",
            "PEGI 18"});
            this.cmbClasificacionDeEdades.Location = new System.Drawing.Point(148, 363);
            this.cmbClasificacionDeEdades.Name = "cmbClasificacionDeEdades";
            this.cmbClasificacionDeEdades.Size = new System.Drawing.Size(200, 21);
            this.cmbClasificacionDeEdades.TabIndex = 10;
            // 
            // dtpFechaSalida
            // 
            this.dtpFechaSalida.Location = new System.Drawing.Point(148, 254);
            this.dtpFechaSalida.Name = "dtpFechaSalida";
            this.dtpFechaSalida.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaSalida.TabIndex = 7;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(102, 605);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 16;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(182, 605);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSeleccionarImagen
            // 
            this.btnSeleccionarImagen.Location = new System.Drawing.Point(371, 180);
            this.btnSeleccionarImagen.Name = "btnSeleccionarImagen";
            this.btnSeleccionarImagen.Size = new System.Drawing.Size(150, 23);
            this.btnSeleccionarImagen.TabIndex = 19;
            this.btnSeleccionarImagen.Text = "Seleccionar Imagen";
            this.btnSeleccionarImagen.UseVisualStyleBackColor = true;
            this.btnSeleccionarImagen.Click += new System.EventHandler(this.btnSeleccionarImagen_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(21, 605);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 36;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            // 
            // lblValoracionSeleccionada
            // 
            this.lblValoracionSeleccionada.AutoSize = true;
            this.lblValoracionSeleccionada.Location = new System.Drawing.Point(148, 529);
            this.lblValoracionSeleccionada.Name = "lblValoracionSeleccionada";
            this.lblValoracionSeleccionada.Size = new System.Drawing.Size(13, 13);
            this.lblValoracionSeleccionada.TabIndex = 37;
            this.lblValoracionSeleccionada.Text = "0";
            // 
            // pnlValoracion
            // 
            this.pnlValoracion.Location = new System.Drawing.Point(148, 526);
            this.pnlValoracion.Name = "pnlValoracion";
            this.pnlValoracion.Size = new System.Drawing.Size(200, 20);
            this.pnlValoracion.TabIndex = 38;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(263, 605);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 39;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // lblNvent
            // 
            this.lblNvent.AutoSize = true;
            this.lblNvent.Location = new System.Drawing.Point(148, 566);
            this.lblNvent.Name = "lblNvent";
            this.lblNvent.Size = new System.Drawing.Size(13, 13);
            this.lblNvent.TabIndex = 40;
            this.lblNvent.Text = "0";
            // 
            // lblSimboloDinero
            // 
            this.lblSimboloDinero.AutoSize = true;
            this.lblSimboloDinero.Location = new System.Drawing.Point(355, 220);
            this.lblSimboloDinero.Name = "lblSimboloDinero";
            this.lblSimboloDinero.Size = new System.Drawing.Size(13, 13);
            this.lblSimboloDinero.TabIndex = 42;
            this.lblSimboloDinero.Text = "€";
            // 
            // pbImagen
            // 
            this.pbImagen.Location = new System.Drawing.Point(371, 20);
            this.pbImagen.Name = "pbImagen";
            this.pbImagen.Size = new System.Drawing.Size(150, 150);
            this.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImagen.TabIndex = 18;
            this.pbImagen.TabStop = false;
            // 
            // btnCesta
            // 
            this.btnCesta.Location = new System.Drawing.Point(344, 605);
            this.btnCesta.Name = "btnCesta";
            this.btnCesta.Size = new System.Drawing.Size(103, 23);
            this.btnCesta.TabIndex = 43;
            this.btnCesta.Text = "Añadir a la cesta";
            this.btnCesta.UseVisualStyleBackColor = true;
            this.btnCesta.Click += new System.EventHandler(this.btnCesta_Click);
            // 
            // EditorVideojuegoForm
            // 
            this.ClientSize = new System.Drawing.Size(544, 645);
            this.Controls.Add(this.btnCesta);
            this.Controls.Add(this.lblSimboloDinero);
            this.Controls.Add(this.lblNvent);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.pnlValoracion);
            this.Controls.Add(this.lblValoracionSeleccionada);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnSeleccionarImagen);
            this.Controls.Add(this.pbImagen);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.dtpFechaSalida);
            this.Controls.Add(this.cmbClasificacionDeEdades);
            this.Controls.Add(this.cmbModoDeJuego);
            this.Controls.Add(this.cmbGenero);
            this.Controls.Add(this.cmbPlataforma);
            this.Controls.Add(this.txtDLC);
            this.Controls.Add(this.txtRequisitos);
            this.Controls.Add(this.txtEditor);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtDesarrollador);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.txtIdiomas);
            this.Controls.Add(this.lblNumVentas);
            this.Controls.Add(this.lblValoracion);
            this.Controls.Add(this.lblDLC);
            this.Controls.Add(this.lblIdiomas);
            this.Controls.Add(this.lblRequisitos);
            this.Controls.Add(this.lblClasificacionDeEdades);
            this.Controls.Add(this.lblModoDeJuego);
            this.Controls.Add(this.lblEditor);
            this.Controls.Add(this.lblFechaSalida);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblDesarrollador);
            this.Controls.Add(this.lblPlataforma);
            this.Controls.Add(this.lblGenero);
            this.Controls.Add(this.lblTitulo);
            this.Name = "EditorVideojuegoForm";
            this.Text = "Editor de Videojuegos";
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lblNvent;
        private System.Windows.Forms.Label lblSimboloDinero;
        private System.Windows.Forms.Button btnCesta;
    }
}