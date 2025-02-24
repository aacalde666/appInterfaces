﻿using MySql.Data.MySqlClient;
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

namespace ventana
{
    public partial class CestaControl : UserControl
    {
        SQL sql;
        string user;
        int idUser;
        public CestaControl(SQL sql, string user)
        {
            InitializeComponent();
            this.sql = sql;
            this.user = user;
            this.idUser = int.Parse(sql.IdUser(user));
        }
        public void actualizarCesta()
        {
            creacionCesta();
        }
        private void creacionCesta()
        {
            string connectionString = sql.ConnectionString();

            this.flowLayoutPanelCesta.Controls.Clear();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string idVideojuego = sql.VerCestaDeUsuario(int.Parse(sql.IdUser(user)));
                // Construir la consulta con IN para múltiples IDs
                string query = $"SELECT * FROM videojuegos WHERE idVideojuego IN ({idVideojuego})";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command))
                    {
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
                                Text = tempPrecio + " €",
                                Location = new Point(10, 90)
                            };

                            // Imagen
                            PictureBox tempImagen = new PictureBox
                            {
                                Size = new Size(130, 130),
                                Location = new Point(165, 10),
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
                            Button btnEliminar = new Button
                            {
                                Text = "Eliminar",
                                Location = new Point(10, 110)
                            };
                            btnEliminar.Click += (s, e) =>
                            {
                                sql.EliminarDeLaCesta(idUser, int.Parse(idVideojuegoTemp.Text));
                                actualizarCesta();
                            };
                            Button btnComprar = new Button
                            {
                                Text = "Comprar",
                                Location = new Point(85, 110)
                            };
                            btnComprar.Click += (s, e) =>
                            {
                                sql.ComprarJuego(idUser, int.Parse(idVideojuegoTemp.Text));
                                actualizarCesta();
                            };
                            juegoPanel.Controls.Add(btnComprar);
                            juegoPanel.Controls.Add(btnEliminar);
                            juegoPanel.Controls.Add(tituloLabel);
                            juegoPanel.Controls.Add(descripcionLabel);
                            juegoPanel.Controls.Add(precioLabel);
                            juegoPanel.Controls.Add(tempImagen);

                            // Agregar el panel al catálogo
                            this.flowLayoutPanelCesta.Controls.Add(juegoPanel);
                        }
                    }
                }
            }
        }
    }
}
