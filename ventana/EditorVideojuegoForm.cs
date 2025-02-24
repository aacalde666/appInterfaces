using Google.Protobuf.Reflection;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Drawing;
using System.Windows.Forms;
using ventana.UsersControl;

namespace ventana
{
    //Nueva tabla en la base de datos de valoraciones (revisar)
    public partial class EditorVideojuegoForm : Form
    {
        private int valoracionSeleccionada = 0;
        private float valoracionHover = 0;
        SQL sql;
        string user;
        int idVideojuego, idUser;
        PictureBox imagen;
        DateTime fecha_salida;
        CatalogoControl cl;
        CestaControl cs;
        string titulo, descripcion, precio, accion, plataforma, desarrollador, editor, modo_de_juego, clas_edades, requisitos, idiomas, dlc;
        int valoracion, num_ventas;

        public EditorVideojuegoForm(int idVideojuego, string titulo, string descripcion, string precio, PictureBox imagen, DateTime fecha_salida, string accion,
            string plataforma, string desarrollador, string editor, string modo_de_juego, string clas_edades, string requisitos, string idiomas, string dlc,
            int valoracion, int num_ventas, SQL sql, string user, CatalogoControl cl)
        {
            InitializeComponent();
            this.titulo = titulo;
            this.descripcion = descripcion;
            this.precio = precio;
            this.fecha_salida = fecha_salida;
            this.accion = accion;
            this.plataforma = plataforma;
            this.desarrollador = desarrollador;
            this.editor = editor;
            this.modo_de_juego = modo_de_juego;
            this.clas_edades = clas_edades;
            this.requisitos = requisitos;
            this.idiomas = idiomas;
            this.dlc = dlc;
            this.valoracion = valoracion;
            this.num_ventas = num_ventas;

            txtTitulo.Text = titulo;
            txtTitulo.ScrollBars = ScrollBars.Vertical;
            txtDescripcion.Text = descripcion;
            txtDescripcion.ScrollBars = ScrollBars.Vertical;
            txtPrecio.Text = precio;
            pbImagen.Image = imagen.Image;
            dtpFechaSalida.Value = fecha_salida;
            txtDesarrollador.Text = desarrollador;
            txtDesarrollador.ScrollBars = ScrollBars.Vertical;
            txtEditor.Text = editor;
            txtEditor.ScrollBars = ScrollBars.Vertical;
            txtRequisitos.Text = requisitos;
            txtRequisitos.ScrollBars = ScrollBars.Vertical;
            txtIdiomas.Text = idiomas;
            txtIdiomas.ScrollBars = ScrollBars.Vertical;
            txtDLC.Text = dlc;
            txtDLC.ScrollBars = ScrollBars.Vertical;
            lblNvent.Text = num_ventas + "";
            valoracionSeleccionada = valoracion;

            this.sql = sql;
            this.user = user;
            this.idVideojuego = idVideojuego;
            this.idUser = int.Parse(sql.IdUser(user));
            this.imagen = imagen;
            this.cl = cl;
            this.cs = new CestaControl(sql,user);

            switch (accion)
            {
                case "Acción":
                    cmbGenero.SelectedItem = "Acción";
                    break;
                case "Aventura":
                    cmbGenero.SelectedItem = "Aventura"; 
                    break;
                case "RPG":
                    cmbGenero.SelectedItem = "RPG"; 
                    break;
                case "Estrategia":
                    cmbGenero.SelectedItem = "Estrategia";
                    break;
                case "Deportes":
                    cmbGenero.SelectedItem = "Deportes"; 
                    break;
            }

            // Para Plataforma
            switch (plataforma)
            {
                case "PC":
                    cmbPlataforma.SelectedItem = "PC";
                    break;
                case "PlayStation 5":
                    cmbPlataforma.SelectedItem = "PlayStation 5"; 
                    break;
                case "Xbox Series X":
                    cmbPlataforma.SelectedItem = "Xbox Series X"; 
                    break;
                case "Nintendo Switch":
                    cmbPlataforma.SelectedItem = "Nintendo Switch"; 
                    break;
            }

            // Para Modo de Juego
            switch (modo_de_juego)
            {
                case "Un jugador":
                    cmbModoDeJuego.SelectedItem = "Un jugador"; 
                    break;
                case "Multijugador":
                    cmbModoDeJuego.SelectedItem = "Multijugador"; 
                    break;
                case "Cooperativo":
                    cmbModoDeJuego.SelectedItem = "Cooperativo"; 
                    break;
            }

            // Para Clasificación de Edades
            switch (clas_edades)
            {
                case "PEGI 3":
                    cmbClasificacionDeEdades.SelectedItem = "PEGI 3"; 
                    break;
                case "PEGI 7":
                    cmbClasificacionDeEdades.SelectedItem = "PEGI 7"; 
                    break;
                case "PEGI 12":
                    cmbClasificacionDeEdades.SelectedItem = "PEGI 12"; 
                    break;
                case "PEGI 16":
                    cmbClasificacionDeEdades.SelectedItem = "PEGI 16"; 
                    break;
                case "PEGI 18":
                    cmbClasificacionDeEdades.SelectedItem = "PEGI 18"; 
                    break;
            }

            // Asignamos la valoración directamente al panel
            pnlValoracion.Tag = valoracion; 

            // El evento de las estrellas
            pnlValoracion.Paint += pnlValoracion_Paint;
            pnlValoracion.MouseMove += pnlValoracion_MouseMove;
            pnlValoracion.MouseClick += pnlValoracion_MouseClick;

            btnEditar.Click += btnEditar_Click;
            btnGuardar.Click += btnGuardar_Click;
            btnCancelar.Click += btnCancelar_Click;

            ToggleTextBoxVisibility(false);
            ToggleTextBoxReadOnly(true);
            if (sql.VerSiESUserOAdmin(user).Equals("user"))
            {
                ToggleTextBoxVisibility(false);
                ToggleTextBoxReadOnly(true);
                btnEditar.Visible = false;
                btnGuardar.Visible = false;
                btnCancelar.Visible = false;
                btnSeleccionarImagen.Visible = false;
            }
            pnlValoracion.Enabled = false;
            if (sql.estaEnLaCestaC(idUser,idVideojuego).Equals("1"))
            {
                pnlValoracion.Enabled = true;
            }
        }

        private void pnlValoracion_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int starSize = pnlValoracion.Height;
            int spacing = 5;
            pnlValoracion.BackColor = Color.LightGray;

            for (int i = 0; i < 5; i++)
            {
                int x = i * (starSize + spacing);
                Brush brush = Brushes.Gray;

                if (valoracionSeleccionada >= i + 1)
                {
                    brush = Brushes.Gold; // Estrella seleccionada
                }
                else if (valoracionHover >= i + 1)
                {
                    brush = Brushes.LightGoldenrodYellow; // Hover
                }
                else if (valoracionHover >= i + 1)
                {
                    brush = Brushes.Gold; // Pintamos la valoración media en oro
                }
                else if (valoracionHover > i && valoracionHover < i + 1)
                {
                    brush = Brushes.Orange; // Estrella parcialmente pintada
                }

                DrawStar(g, x, 0, starSize, brush);
            }
        }

        private void DrawStar(Graphics g, int x, int y, int size, Brush brush)
        {
            PointF[] starPoints = {
                new PointF(x + size * 0.5f, y),
                new PointF(x + size * 0.62f, y + size * 0.38f),
                new PointF(x + size, y + size * 0.38f),
                new PointF(x + size * 0.68f, y + size * 0.62f),
                new PointF(x + size * 0.8f, y + size),
                new PointF(x + size * 0.5f, y + size * 0.75f),
                new PointF(x + size * 0.2f, y + size),
                new PointF(x + size * 0.32f, y + size * 0.62f),
                new PointF(x, y + size * 0.38f),
                new PointF(x + size * 0.38f, y + size * 0.38f)
            };
            g.FillPolygon(brush, starPoints);
        }

        private void pnlValoracion_MouseMove(object sender, MouseEventArgs e)
        {
            int starSize = pnlValoracion.Height; // Tamaño de cada estrella
            int spacing = 5; // Espaciado entre estrellas
            int numStars = 5;

            // Calculamos la estrella en la que está el mouse
            int hoveredStar = e.X / (starSize + spacing);

            // Nos aseguramos de que no exceda el número máximo de estrellas
            if (hoveredStar >= 0 && hoveredStar < numStars)
            {
                valoracionHover = hoveredStar + 1; // Ajuste para que cuente desde 1
            }
            else
            {
                valoracionHover = 0; // Si el ratón está fuera, no se ilumina nada
            }

            pnlValoracion.Invalidate(); // Redibujar
        }

        private void pnlValoracion_MouseClick(object sender, MouseEventArgs e)
        {
            int starSize = pnlValoracion.Height;
            int spacing = 5;
            int numStars = 5;

            int clickedStar = e.X / (starSize + spacing);
            if (clickedStar >= 0 && clickedStar < numStars)
            {
                valoracionSeleccionada = clickedStar + 1;
                lblValoracionSeleccionada.Text = valoracionSeleccionada.ToString();

                // Guardar valoración en la base de datos
                GuardarValoracion(idUser, idVideojuego, valoracionSeleccionada);
            }

            pnlValoracion.Invalidate(); // Redibujar estrellas
        }


        private void btnEditar_Click(object sender, EventArgs e)
        {
            ToggleTextBoxVisibility(true);
            ToggleTextBoxReadOnly(false);

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ToggleTextBoxVisibility(false);
            ToggleTextBoxReadOnly(true);
            sql.ActualizarJuego(idVideojuego, txtTitulo.Text, txtDescripcion.Text, txtPrecio.Text, dtpFechaSalida.Value.ToString("yyyy-MM-dd"),
                cmbGenero.SelectedItem.ToString(), cmbPlataforma.SelectedItem.ToString(), txtDesarrollador.Text, txtEditor.Text, 
                cmbModoDeJuego.SelectedItem.ToString(), cmbClasificacionDeEdades.SelectedItem.ToString(), txtRequisitos.Text, txtIdiomas.Text, 
                txtDLC.Text, int.Parse(lblNvent.Text));
            if (pbImagen.Image != imagen.Image)
            {
                sql.ActualizarImagenJuego(idVideojuego, pbImagen.ImageLocation);
            }
            cl.ActualizarCatalogo();
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtTitulo.Text = titulo;
            txtDescripcion.Text = descripcion;
            txtPrecio.Text = precio;
            pbImagen.Image = imagen.Image;
            dtpFechaSalida.Value = fecha_salida;
            txtDesarrollador.Text = desarrollador;
            txtEditor.Text = editor;
            txtRequisitos.Text = requisitos;
            txtIdiomas.Text = idiomas;
            txtDLC.Text = dlc;
            lblNvent.Text = num_ventas + "";
            valoracionSeleccionada = valoracion;
            ToggleTextBoxVisibility(false);
            ToggleTextBoxReadOnly(true);
        }
        private void ToggleTextBoxReadOnly(bool enable)
        {
            txtTitulo.ReadOnly = enable;
            txtDesarrollador.ReadOnly = enable;
            txtDescripcion.ReadOnly = enable;
            txtPrecio.ReadOnly = enable;
            txtEditor.ReadOnly = enable;
            txtRequisitos.ReadOnly = enable;
            txtIdiomas.ReadOnly = enable;
            txtDLC.ReadOnly = enable;
        }
        private void ToggleTextBoxVisibility(bool enable)
        {
            cmbGenero.Enabled = enable;
            cmbPlataforma.Enabled = enable;
            dtpFechaSalida.Enabled = enable;
            cmbModoDeJuego.Enabled = enable;
            cmbClasificacionDeEdades.Enabled = enable;
            btnSeleccionarImagen.Enabled = enable;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSeleccionarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pbImagen.ImageLocation = openFileDialog.FileName;
            }
        }
        private void btnCesta_Click(object sender, EventArgs e)
        {   if (sql.estaEnLaCesta(idUser,idVideojuego).Equals("0")&&sql.estaEnLaCestaC(idUser,idVideojuego).Equals("0")){
                MessageBox.Show("Juego añadido a la cesta");
            }
            else if (sql.estaEnLaCesta(idUser, idVideojuego).Equals("1") && sql.estaEnLaCestaC(idUser, idVideojuego).Equals("0"))
            {
                MessageBox.Show("Ya esta en la cesta");
            }
            sql.añadirALaCesta(idUser,idVideojuego,1);
            cs.actualizarCesta();
            
        }
        private void GuardarValoracion(int idUsuario, int idVideojuego, int valoracion)
        {
            string connectionString = sql.ConnectionString();

            string queryVerificar = "SELECT COUNT(*) FROM Valoraciones WHERE idUsuario = @idUsuario AND idVideojuego = @idVideojuego";
            string queryInsertar = "INSERT INTO Valoraciones (idUsuario, idVideojuego, valoracion) VALUES (@idUsuario, @idVideojuego, @valoracion)";
            string queryActualizar = "UPDATE Valoraciones SET valoracion = @valoracion WHERE idUsuario = @idUsuario AND idVideojuego = @idVideojuego";

            using (MySqlConnection conn = new MySqlConnection(connectionString)) // Supongo que tienes un método para obtener la conexión
            {
                conn.Open();
                using (MySqlCommand cmdVerificar = new MySqlCommand(queryVerificar, conn))
                {
                    cmdVerificar.Parameters.AddWithValue("@idUsuario", idUsuario);
                    cmdVerificar.Parameters.AddWithValue("@idVideojuego", idVideojuego);
                    int existe = Convert.ToInt32(cmdVerificar.ExecuteScalar());

                    string query = existe > 0 ? queryActualizar : queryInsertar;

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                        cmd.Parameters.AddWithValue("@idVideojuego", idVideojuego);
                        cmd.Parameters.AddWithValue("@valoracion", valoracion);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            ActualizarValoracionPromedio(idVideojuego);
        }
        private void ActualizarValoracionPromedio(int idVideojuego)
        {
            string connectionString = sql.ConnectionString();
            string query = "SELECT AVG(valoracion) FROM valoraciones WHERE idVideojuego = @idVideojuego";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idVideojuego", idVideojuego);
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        
                        int valoracionPromedio = Convert.ToInt32(result);

                        lblValoracionSeleccionada.Text = valoracionPromedio.ToString();
                        sql.ActualizarValoracionJuego(idVideojuego, int.Parse(lblValoracionSeleccionada.Text));
                        pnlValoracion.Invalidate();
                    }
                    else
                    {
                        lblValoracionSeleccionada.Text = "0";
                        pnlValoracion.Invalidate();
                    }
                }
            }
        }
    }
}
