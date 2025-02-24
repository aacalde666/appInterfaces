using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ventana.UsersControl
{
    public partial class CatalogoControl : UserControl
    {
        private SQL sql;
        private string user;

        public CatalogoControl(SQL sql, string user)
        {
            this.sql = sql;
            this.user = user;
            InitializeComponent();
            textbusqueda.TextChanged += (s, e) =>
            {
                string filtro = textbusqueda.Text.ToLower();

                foreach (Control control in flowLayoutPanelCatalogo.Controls)
                {
                    if (control is Panel juegoPanel)
                    {
                        Label tituloLabel = juegoPanel.Controls.OfType<Label>().FirstOrDefault();
                        if (tituloLabel != null)
                        {
                            if (string.IsNullOrWhiteSpace(filtro)) // Si la búsqueda está vacía
                            {
                                juegoPanel.BackColor = Color.Transparent; // Restaurar fondo original
                            }
                            else if (tituloLabel.Text.ToLower().Contains(filtro))
                            {
                                juegoPanel.BackColor = Color.Yellow; // Resaltar si hay coincidencia
                            }
                            else
                            {
                                juegoPanel.BackColor = Color.Transparent; // Restaurar fondo si no hay coincidencia
                            }
                        }
                    }
                }
            };

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarCatalogo();
        }

        public void ActualizarCatalogo()
        {
            string connectionString = sql.ConnectionString();
            string query = "SELECT * FROM videojuegos";

            this.flowLayoutPanelCatalogo.Controls.Clear();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    // Panel para el videojuego
                    Panel juegoPanel = new Panel
                    {
                        Size = new Size(300, 150),
                        BorderStyle = BorderStyle.FixedSingle,
                        Margin = new Padding(10)
                    };

                    // Variables temporales renombradas para evitar confusión
                    string tempTitulo = row["titulo"].ToString();
                    string tempDescripcion = row["descripcion"].ToString();
                    string tempPrecio = row["precio"].ToString();

                    Label tituloLabel = new Label
                    {
                        Text = tempTitulo,
                        Location = new Point(10, 10),
                        Width = 130
                    };

                    Label descripcionLabel = new Label
                    {
                        Text = tempDescripcion,
                        Location = new Point(10, 40),
                        Width = 130,
                        Height = 40,
                        AutoSize = false
                    };

                    Label precioLabel = new Label
                    {
                        Text = tempPrecio+" €",
                        Location = new Point(10, 90)
                    };

                    // Imagen
                    PictureBox tempImagen = new PictureBox
                    {
                        Size = new Size(140, 130),
                        Location = new Point(150, 10),
                        SizeMode = PictureBoxSizeMode.Zoom
                    };

                    if (row["imagen"] != DBNull.Value)
                    {
                        byte[] imageBytes = (byte[])row["imagen"];
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            try
                            {
                                tempImagen.Image = Image.FromStream(ms);
                            }
                            catch (ArgumentException)
                            {
                                tempImagen.Image = null;
                            }
                        }
                    }
                    Label idVideojuegoTemp = new Label
                    {
                        Text = row["idVideojuego"].ToString()
                    };
                    // Si es admin, añadir botón eliminar
                    if (!sql.VerSiESUserOAdmin(user).Equals("user"))
                    {
                        Button btnEliminar = new Button
                        {
                            Text = "Eliminar",
                            Location = new Point(10, 110)
                        };
                        btnEliminar.Click += (s, e) =>
                        {
                            sql.EliminarReferenciaJuego(int.Parse(idVideojuegoTemp.Text));
                            sql.EliminarJuegoCatalogo(tempTitulo, tempDescripcion);
                            ActualizarCatalogo();
                        };
                        juegoPanel.Controls.Add(btnEliminar);
                    }

                    // Conversión segura de fecha
                    DateTime tempFechaSalida = row.IsNull("fecha_salida") ? DateTime.Today :
                        DateTime.TryParse(row["fecha_salida"].ToString(), out DateTime fecha) ? fecha : DateTime.Today;


                    // Acción al hacer doble clic
                    void AbrirEditorJuego(object sender, EventArgs e)
                    {
                        AbrirEditor(int.Parse(idVideojuegoTemp.Text),tempTitulo, tempDescripcion, tempPrecio, tempImagen,
                            tempFechaSalida, row["genero"].ToString(),
                            row["plataforma"].ToString(), row["desarrollador"].ToString(),
                            row["editor"].ToString(), row["modo_de_juego"].ToString(),
                            row["clasificacion_de_edades"].ToString(), row["requisitos"].ToString(),
                            row["idiomas"].ToString(), row["dlc"].ToString(),
                            int.Parse(row["valoracion"].ToString()), int.Parse(row["num_ventas"].ToString()));
                    }

                    juegoPanel.DoubleClick += AbrirEditorJuego;
                    tituloLabel.DoubleClick += AbrirEditorJuego;
                    descripcionLabel.DoubleClick += AbrirEditorJuego;
                    tempImagen.DoubleClick += AbrirEditorJuego;

                    // Agregar controles al panel del videojuego
                    juegoPanel.Controls.Add(tituloLabel);
                    juegoPanel.Controls.Add(descripcionLabel);
                    juegoPanel.Controls.Add(precioLabel);
                    juegoPanel.Controls.Add(tempImagen);

                    // Agregar el panel al catálogo
                    this.flowLayoutPanelCatalogo.Controls.Add(juegoPanel);
                }
            }
        }
        private Dictionary<int, EditorVideojuegoForm> editorForms = new Dictionary<int, EditorVideojuegoForm>();

        private void AbrirEditor(int idVideojuego, string titulo, string descripcion, string precio, PictureBox imagen,
            DateTime fechaSalida, string genero, string plataforma, string desarrollador, string editor,
            string modoDeJuego, string clasificacionEdades, string requisitos, string idiomas, string dlc,
            int valoracion, int numVentas)
        {
            if (editorForms.ContainsKey(idVideojuego))
            {
                editorForms[idVideojuego].BringToFront();
                editorForms[idVideojuego].Focus();
            }
            else
            {
                EditorVideojuegoForm editorVideojuegoForm = new EditorVideojuegoForm(
                    idVideojuego, titulo, descripcion, precio, imagen, fechaSalida, genero, plataforma, desarrollador,
                    editor, modoDeJuego, clasificacionEdades, requisitos, idiomas, dlc, valoracion, numVentas, sql, user, this);

                // Suscribir al evento FormClosed para eliminar el formulario del diccionario cuando se cierre
                editorVideojuegoForm.FormClosed += (s, e) =>
                {
                    editorForms.Remove(idVideojuego); // Eliminar del diccionario cuando se cierre
                };

                editorVideojuegoForm.Show();

                editorForms.Add(idVideojuego, editorVideojuegoForm);
            }
        }

    }
}
