using MySql.Data.MySqlClient;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;
using Mysqlx.Crud;
using System.Collections.Generic;
using System.Collections;
using System.Transactions;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ventana
{
    public partial class SQL
    {
        // Constructor vacío
        public SQL() { }

        // Cadena de conexión para MySQL
        
        // Método para poner tu server(localhost o la ip donde este tu BBDD),BBDD,el usuario asignado y la contraseña
        public string ConnectionString()
        {
            string connectionString = "Server=aacal.ddns.net;Database=interfacesapp;Uid=root;Pwd=1234;";
            return connectionString;
        }

        // Método para comprobar la conexión
        public void ComprobacionConexion()
        {
            try
            {
                var client = new MongoClient("mongodb://aacal.ddns.net"); // Usa la URL correcta de tu MongoDB
                var database = client.GetDatabase("interfacesapp"); // Nombre de la base de datos
                var collection = database.GetCollection<BsonDocument>("videojuegos"); // Nombre de la colección

                // Verificar la conexión con un ping
                database.RunCommand<BsonDocument>(new BsonDocument("ping", 1));
                MessageBox.Show("Conexión exitosa a MongoDB", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Consultar todos los documentos en la colección
                var videojuegos = collection.Find(new BsonDocument()).ToList();

                // Mostrar los resultados
                foreach (var videojuego in videojuegos)
                {
                    MessageBox.Show(videojuego.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar a MongoDB: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            using (MySqlConnection connection = new MySqlConnection(ConnectionString()))
            {
                try
                {
                    connection.Open(); // Abrir la conexión
                    MessageBox.Show("¡Conexión exitosa BBDD!");
                    recargaId();
                    connection.Close(); // Cerrar la 
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al conectar la base de datos: {ex.Message}");
                    Environment.Exit(1); // Detener el programa si falla la conexión
                }
            }
        }
        public void recargaId()
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString()))
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand("ALTER TABLE users AUTO_INCREMENT = 1;ALTER TABLE videojuegos AUTO_INCREMENT = 1;ALTER TABLE valoraciones AUTO_INCREMENT = 1;ALTER TABLE biblioteca AUTO_INCREMENT = 1;", connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al conectar la base de datos: {ex.Message}");
                }
            }

        }
        // Método para insertar un usuario en la base de datos MySQL
        public void InsertarUsuarioSQL(string name,string email , string password)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString()))
            {
                try
                {
                    connection.Open(); // Abrir la conexión

                    // Consulta SQL para insertar
                    string query = "INSERT INTO users (name, passwd, email, rol, status) VALUES (@name, @password, @email,  @rol, @status)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Agregar parámetros para evitar inyección SQL
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@password", password);

                        // Manejar el parámetro `email` (puede ser NULL)
                        if (string.IsNullOrEmpty(email))
                        {
                            command.Parameters.AddWithValue("@email", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@email", email);
                        }

                        command.Parameters.AddWithValue("@rol", "user");

                        command.Parameters.AddWithValue("@status", "active");
                        // Ejecutar el comando
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error de MySQL: {ex.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error general: {ex.Message}");
                }
            }
        }
        public bool VerSiExisteUsuario(string name)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString()))
            {
                try
                {
                    connection.Open(); // Abrir conexión

                    // Consulta SQL para verificar la existencia del usuario
                    string query = "SELECT COUNT(*) FROM users WHERE name = @name OR email = @email";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Agregar parámetros
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@email", name);

                        // Ejecutar la consulta y obtener el resultado
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        connection.Close();
                        // Si el conteo es mayor a 0, el usuario existe
                        return count > 0;
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error de MySQL: {ex.Message}");
                    return false; // Devuelve falso en caso de error
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error general: {ex.Message}");
                    return false;
                }
            }
        }
        public bool VerSiExisteContraseña(string user, string passwd)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString()))
            {
                try
                {
                    connection.Open(); // Abrir conexión

                    // Consulta SQL para verificar la existencia del usuario
                    string query = "SELECT COUNT(*) FROM users WHERE name = @user AND passwd = @passwd";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Agregar parámetros
                        command.Parameters.AddWithValue("@user", user);
                        command.Parameters.AddWithValue("@passwd", passwd);

                        // Ejecutar la consulta y obtener el resultado
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        connection.Close();
                        // Si el conteo es mayor a 0, el usuario existe
                        return count > 0;
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error de MySQL: {ex.Message}");
                    return false; // Devuelve falso en caso de error
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error general: {ex.Message}");
                    return false;
                }
            }
        }
        public bool VerSiExisteUsuarioRegister(string name)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString()))
            {
                try
                {
                    connection.Open(); // Abrir conexión

                    // Consulta SQL para verificar la existencia del usuario
                    string query = "SELECT COUNT(*) FROM users WHERE name = @name";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Agregar parámetros
                        command.Parameters.AddWithValue("@name", name);

                        // Ejecutar la consulta y obtener el resultado
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        connection.Close();
                        // Si el conteo es mayor a 0, el usuario existe
                        return count > 0;
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error de MySQL: {ex.Message}");
                    return false; // Devuelve falso en caso de error
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error general: {ex.Message}");
                    return false;
                }
            }
        }
        public bool VerSiExisteCorreoRegister(string email)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString()))
            {
                try
                {
                    connection.Open(); // Abrir conexión

                    // Consulta SQL para verificar la existencia del usuario
                    string query = "SELECT COUNT(*) FROM users WHERE email = @email";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Agregar parámetros
                        command.Parameters.AddWithValue("@email", email);

                        // Ejecutar la consulta y obtener el resultado
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        connection.Close();
                        // Si el conteo es mayor a 0, el usuario existe
                        return count > 0;
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error de MySQL: {ex.Message}");
                    return false; // Devuelve falso en caso de error
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error general: {ex.Message}");
                    return false;
                }
            }
        }
        public string VerNombreUsuarioPorCorreo(string name)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString()))
            {
                try
                {
                    connection.Open(); // Abrir conexión

                    // Consulta SQL para verificar la existencia del usuario
                    string query = "SELECT name FROM users WHERE email = @email";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Agregar parámetros
                        command.Parameters.AddWithValue("@email", name);

                        object result = command.ExecuteScalar();
                        connection.Close();
                        // Si el conteo es mayor a 0, el usuario existe
                        return $"usuario: {result.ToString()}";
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error de MySQL: {ex.Message}");
                    return "Error en la base de datos";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error general: {ex.Message}");
                    return "Error en el proceso";
                }
            }
        }
        public string VerSiESUserOAdmin(string user)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString()))
            {
                try
                {
                    connection.Open(); // Abrir conexión

                    // Consulta SQL para verificar la existencia del usuario
                    string query = "SELECT rol FROM users WHERE name = @user";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Agregar parámetros
                        command.Parameters.AddWithValue("@user", user);

                        object result = command.ExecuteScalar();
                        connection.Close();
                        return $"{result.ToString()}";
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error de MySQL: {ex.Message}");
                    return "Error en la base de datos";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error general: {ex.Message}");
                    return "Error en el proceso";
                }
            }
        }
        public bool VerClave(string user, string clave)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString()))
            {
                try
                {
                    connection.Open(); // Abrir conexión

                    // Consulta SQL para verificar la existencia del usuario
                    string query = "SELECT clave FROM users WHERE name = @user AND clave = @clave";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Agregar parámetros
                        command.Parameters.AddWithValue("@user", user);
                        command.Parameters.AddWithValue("@clave", clave);

                        int count = Convert.ToInt32(command.ExecuteScalar());
                        connection.Close();
                        return count > 0;
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error de MySQL: {ex.Message}");
                    return false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error general: {ex.Message}");
                    return false;
                }
            }
        }
        public string IsUserBanned(string user)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString()))
            {
                try
                {
                    connection.Open(); // Abrir conexión

                    // Consulta SQL para verificar la existencia del usuario
                    string query = "SELECT ban FROM users WHERE name = @user";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Agregar parámetros
                        command.Parameters.AddWithValue("@user", user);

                        object result = command.ExecuteScalar();
                        connection.Close();
                        return $"{result.ToString()}";
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error de MySQL: {ex.Message}");
                    return "Error en la base de datos";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error general: {ex.Message}");
                    return "Error en el proceso";
                }
            }
        }
        public DataTable TablaConsulta()
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString())) // Cambiar a MySqlConnection
            {
                try
                {
                    connection.Open(); // Abrir conexión
                    string query = "SELECT * FROM users"; // Consulta SQL
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection); // Cambiar a MySqlDataAdapter
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable); // Llenar la tabla con los datos
                    connection.Close();
                    return dataTable; // Retornar el DataTable
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al consultar los datos: " + ex.Message);
                    return null;
                }
            }
        }
        public bool VerUsuario(string name)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString()))
            {
                try
                {
                    connection.Open(); // Abrir conexión

                    // Consulta SQL para verificar la existencia del usuario
                    string query = "SELECT * FROM users WHERE name = @user";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Agregar parámetros
                        command.Parameters.AddWithValue("@user", name);

                        int count = Convert.ToInt32(command.ExecuteScalar());
                        connection.Close();
                        return count > 0;
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error de MySQL: {ex.Message}");
                    return false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error general: {ex.Message}");
                    return false;
                }
            }
        }
        public void EliminarUsuario(string user)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString()))
            {
                try
                {
                    connection.Open();

                    string query = "DELETE FROM users WHERE name = @user";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {

                        // Agregar parámetros
                        command.Parameters.AddWithValue("@user", user);
                        int rowsAffected = command.ExecuteNonQuery();
                        connection.Close();
                        // Opcional: Mostrar mensaje si no se eliminó ningún usuario
                        if (rowsAffected == 0)
                        {
                            MessageBox.Show("No se encontró el usuario.");
                        }
                        else
                        {
                            MessageBox.Show("Usuario eliminado correctamente.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al consultar los datos: " + ex.Message);
                }
            }
        }
        public void ModificarUsuario(string id, string nombre, string contraseña, string correo, string estado, string ban)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString()))
            {
                try
                {
                    connection.Open(); // Abrir conexión

                    // Consulta SQL para verificar la existencia del usuario
                    string query = "UPDATE users SET name = @user, passwd = @contraseña, email = @correo, status = @estado, ban = @ban WHERE id = @id";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Agregar parámetros
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@user", nombre);
                        command.Parameters.AddWithValue("@contraseña", contraseña);
                        command.Parameters.AddWithValue("@correo", correo);
                        command.Parameters.AddWithValue("@estado", estado);
                        command.Parameters.AddWithValue("@ban", ban);

                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error de MySQL: {ex.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error general: {ex.Message}");
                }
            }
        }
        public void ModificarUsuarioClave(string id, string rol, string clave)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString()))
            {
                try
                {
                    connection.Open(); // Abrir conexión

                    // Consulta SQL para verificar la existencia del usuario
                    string query = "UPDATE users SET rol = @rol, clave = @clave WHERE id = @id";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Agregar parámetros
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@rol", rol);
                        command.Parameters.AddWithValue("@clave", clave);

                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error de MySQL: {ex.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error general: {ex.Message}");
                }
            }
        }
        public void CrearUsuario(string name, string password, string email,  string rol, string clave)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString()))
            {
                try
                {
                    connection.Open(); // Abrir la conexión

                    // Consulta SQL para insertar
                    string query = "INSERT INTO users (name, passwd, email, rol, status, clave) VALUES (@name, @password, @email, @rol, @status, @clave)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Agregar parámetros para evitar inyección SQL
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@password", password);
                        command.Parameters.AddWithValue("@rol", rol);
                        command.Parameters.AddWithValue("@clave", clave);

                        // Manejar el parámetro `email` (puede ser NULL)
                        if (string.IsNullOrEmpty(email))
                        {
                            command.Parameters.AddWithValue("@email", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@email", email);
                        }

                        command.Parameters.AddWithValue("@status", "active");
                        // Ejecutar el comando
                        command.ExecuteNonQuery();
                        connection.Close();

                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error de MySQL: {ex.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error general: {ex.Message}");
                }
            }
        }
        public void EliminarJuegoCatalogo(string titulo, string descripcion)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString()))
            {
                try
                {
                    connection.Open(); // Abrir la conexión

                    // Consulta SQL para insertar
                    string query = "DELETE FROM videojuegos WHERE titulo = @titulo and descripcion = @descripcion";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@titulo", titulo);
                        command.Parameters.AddWithValue("@descripcion", descripcion);
                        int rowsAffected = command.ExecuteNonQuery();
                        connection.Close();
                        // Opcional: Mostrar mensaje si no se eliminó ningún usuario
                        if (rowsAffected == 0)
                        {
                            MessageBox.Show("No se encontró el juego.");
                        }
                        else
                        {
                            MessageBox.Show("Juego eliminado correctamente.");
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error de MySQL: {ex.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error general: {ex.Message}");
                }
            }
        }
        public void GuardarJuego(string titulo,string descripcion,string precio,string imagen,string fecha_salida,string accion,
            string plataforma,string desarrollador,string editor,string modo_de_juego,string clas_edades,string requisitos,string idiomas,string dlc,
            int valoracion,int num_ventas)
        {
            string query = "INSERT INTO videojuegos (titulo, descripcion, precio, imagen, fecha_salida, genero, plataforma, desarrollador, editor, modo_de_juego, clasificacion_de_edades, requisitos, idiomas, dlc, valoracion, num_ventas) " +
                           "VALUES (@titulo, @descripcion, @precio, @imagen, @fecha_salida, @genero, @plataforma, @desarrollador, @editor, @modo_de_juego, @clasificacion_de_edades, @requisitos, @idiomas, @dlc, @valoracion, @num_ventas)";

            using (MySqlConnection connection = new MySqlConnection(ConnectionString()))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@titulo", titulo);
                command.Parameters.AddWithValue("@descripcion", descripcion);
                command.Parameters.AddWithValue("@precio", Convert.ToDecimal(precio));
                command.Parameters.AddWithValue("@imagen", File.ReadAllBytes(imagen));
                command.Parameters.AddWithValue("@fecha_salida", fecha_salida); // Coloca una fecha de salida
                command.Parameters.AddWithValue("@genero", accion); // Aquí debes capturar el género de alguna manera
                command.Parameters.AddWithValue("@plataforma", plataforma); // Lo mismo que el género
                command.Parameters.AddWithValue("@desarrollador", desarrollador);
                command.Parameters.AddWithValue("@editor", editor);
                command.Parameters.AddWithValue("@modo_de_juego", modo_de_juego);
                command.Parameters.AddWithValue("@clasificacion_de_edades", clas_edades);
                command.Parameters.AddWithValue("@requisitos", requisitos);
                command.Parameters.AddWithValue("@idiomas", idiomas);
                command.Parameters.AddWithValue("@dlc", dlc);
                command.Parameters.AddWithValue("@valoracion", valoracion);
                command.Parameters.AddWithValue("@num_ventas", num_ventas);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public void ActualizarJuego(int id, string titulo, string descripcion, string precio, string fecha_salida, string accion,
            string plataforma, string desarrollador, string editor, string modo_de_juego, string clas_edades, string requisitos, string idiomas, string dlc,
            int num_ventas)
        {
            string query = "UPDATE videojuegos SET titulo = @titulo, descripcion = @descripcion, precio = @precio," +
                "fecha_salida = @fecha_salida, genero = @genero, plataforma = @plataforma, desarrollador = @desarrollador, editor = @editor," +
                " modo_de_juego = @modo_de_juego, clasificacion_de_edades = @clasificacion_de_edades, requisitos = @requisitos, idiomas = @idiomas," +
                " dlc = @dlc, num_ventas = @num_ventas WHERE idVideojuego = @id";
             
            using (MySqlConnection connection = new MySqlConnection(ConnectionString()))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@titulo", titulo);
                command.Parameters.AddWithValue("@descripcion", descripcion);
                command.Parameters.AddWithValue("@precio", Convert.ToDecimal(precio));
                command.Parameters.AddWithValue("@fecha_salida", fecha_salida); // Coloca una fecha de salida
                command.Parameters.AddWithValue("@genero", accion); // Aquí debes capturar el género de alguna manera
                command.Parameters.AddWithValue("@plataforma", plataforma); // Lo mismo que el género
                command.Parameters.AddWithValue("@desarrollador", desarrollador);
                command.Parameters.AddWithValue("@editor", editor);
                command.Parameters.AddWithValue("@modo_de_juego", modo_de_juego);
                command.Parameters.AddWithValue("@clasificacion_de_edades", clas_edades);
                command.Parameters.AddWithValue("@requisitos", requisitos);
                command.Parameters.AddWithValue("@idiomas", idiomas);
                command.Parameters.AddWithValue("@dlc", dlc);
                command.Parameters.AddWithValue("@num_ventas", num_ventas);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public void ActualizarImagenJuego(int id, string imagen)
        {
            string query = "UPDATE videojuegos SET imagen = @imagen WHERE idVideojuego = @id";

            using (MySqlConnection connection = new MySqlConnection(ConnectionString()))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@imagen", File.ReadAllBytes(imagen));
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public void ActualizarValoracionJuego(int id, int valoracion)
        {
            string query = "UPDATE videojuegos SET valoracion = @valoracion WHERE idVideojuego = @id";

            using (MySqlConnection connection = new MySqlConnection(ConnectionString()))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@valoracion", valoracion);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public string IdUser(string user)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString()))
            {
                try
                {
                    connection.Open(); // Abrir conexión

                    // Consulta SQL para verificar la existencia del usuario
                    string query = "SELECT id FROM users WHERE name = @user";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Agregar parámetros
                        command.Parameters.AddWithValue("@user", user);

                        object result = command.ExecuteScalar();
                        connection.Close();
                        return $"{result.ToString()}";
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error de MySQL: {ex.Message}");
                    return "Error en la base de datos";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error general: {ex.Message}");
                    return "Error en el proceso";
                }
            }
        }
        public void EliminarReferenciaJuego(int idVideojuego)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString()))
            {
                try
                {
                    connection.Open();

                    string query = "DELETE FROM valoraciones WHERE idVideojuego = @idVideojuego";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Agregar parámetros
                        command.Parameters.AddWithValue("@idVideojuego", idVideojuego);
                        int rowsAffected = command.ExecuteNonQuery();
                        recargaId();
                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al consultar los datos: " + ex.Message);
                }
            }
        }
        public string estaEnLaCesta(int idUser, int idVideojuego)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString()))
            {
                try
                {
                    connection.Open();
                    string estaEnCesta = "SELECT cesta FROM valoraciones WHERE idUsuario = @idUser AND idVideojuego = @idVideojuego";
                    using (MySqlCommand command = new MySqlCommand(estaEnCesta, connection))
                    {
                        command.Parameters.AddWithValue("@idUser", idUser);
                        command.Parameters.AddWithValue("@idVideojuego", idVideojuego);
                        object result = command.ExecuteScalar();
                        connection.Close();
                        if (result != null)
                        {
                            return $"{result.ToString()}";
                        }
                        else
                        {
                            return "0";
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error de MySQL: {ex.Message}");
                    return "Error en la base de datos";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error general: {ex.Message}");
                    return "Error en el proceso";
                }
            }
        }
        public string estaEnLaCestaC(int idUser, int idVideojuego)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString()))
            {
                try
                {
                    connection.Open();
                    string estaEnCesta = "SELECT comprado FROM valoraciones WHERE idUsuario = @idUser AND idVideojuego = @idVideojuego";
                    using (MySqlCommand command = new MySqlCommand(estaEnCesta, connection))
                    {
                        command.Parameters.AddWithValue("@idUser", idUser);
                        command.Parameters.AddWithValue("@idVideojuego", idVideojuego);
                        object result = command.ExecuteScalar();
                        connection.Close();
                        if (result != null)
                        {
                            return $"{result.ToString()}";
                        }
                        else
                        {
                            return "0";
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error de MySQL: {ex.Message}");
                    return "Error en la base de datos";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error general: {ex.Message}");
                    return "Error en el proceso";
                }
            }
        }
        public void añadirALaCesta(int idUser, int idVideojuego, int cesta)
        {
            if (!EstaEnLaBiblioteca(idUser,idVideojuego))
            {
                string queryVerificar = "SELECT COUNT(*) FROM Valoraciones WHERE idUsuario = @idUsuario AND idVideojuego = @idVideojuego";
                string queryInsertar = "INSERT INTO Valoraciones (idUsuario, idVideojuego, cesta, comprado) VALUES (@idUsuario, @idVideojuego, @cesta, 0)";
                string queryActualizar = "UPDATE Valoraciones SET cesta = @cesta WHERE idUsuario = @idUsuario AND idVideojuego = @idVideojuego";
                using (MySqlConnection conn = new MySqlConnection(ConnectionString()))
                {
                    conn.Open();
                    using (MySqlCommand cmdVerificar = new MySqlCommand(queryVerificar, conn))
                    {
                        cmdVerificar.Parameters.AddWithValue("@idUsuario", idUser);
                        cmdVerificar.Parameters.AddWithValue("@idVideojuego", idVideojuego);
                        int existe = Convert.ToInt32(cmdVerificar.ExecuteScalar());

                        string query = existe > 0 ? queryActualizar : queryInsertar;

                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@idUsuario", idUser);
                            cmd.Parameters.AddWithValue("@idVideojuego", idVideojuego);
                            cmd.Parameters.AddWithValue("@cesta", cesta);
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Ya lo tienes en tu biblioteca de juegos");
            }
        }
        public void EliminarDeLaCesta(int idUser, int idVideojuego)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString()))
            {
                try
                {
                    connection.Open();

                    string query = "UPDATE valoraciones SET cesta = 0 WHERE idUsuario = @idUser AND idVideojuego = @idVideojuego";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Agregar parámetros
                        command.Parameters.AddWithValue("@idUser", idUser);
                        command.Parameters.AddWithValue("@idVideojuego", idVideojuego);
                        int rowsAffected = command.ExecuteNonQuery();
                        connection.Close();
                        MessageBox.Show("Juego eliminado de la cesta");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al consultar los datos: " + ex.Message);
                }
            }
        }
        public string VerCestaDeUsuario(int idUser)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString()))
            {
                try
                {
                    connection.Open();

                    // Verificar si el usuario tiene algún juego en la cesta
                    string estaEnCesta = "SELECT COUNT(*) FROM valoraciones WHERE idUsuario = @idUser AND cesta = 1";
                    using (MySqlCommand command = new MySqlCommand(estaEnCesta, connection))
                    {
                        command.Parameters.AddWithValue("@idUser", idUser);
                        int count = Convert.ToInt32(command.ExecuteScalar());

                        // Si no hay juegos en la cesta, retornar "0"
                        if (count == 0)
                        {
                            return "0"; // No hay juegos en la cesta
                        }
                        else
                        {
                            // Si hay juegos en la cesta, obtener los IDs de los juegos
                            string query = "SELECT idVideojuego FROM valoraciones WHERE idUsuario = @idUser AND cesta = 1";
                            using (MySqlCommand command2 = new MySqlCommand(query, connection))
                            {
                                command2.Parameters.AddWithValue("@idUser", idUser);
                                using (MySqlDataReader reader = command2.ExecuteReader())
                                {
                                    List<string> ids = new List<string>();
                                    while (reader.Read())
                                    {
                                        ids.Add(reader["idVideojuego"].ToString());
                                    }
                                    // Unir los IDs en un solo string separados por comas
                                    return string.Join(",", ids);
                                }
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error de MySQL: {ex.Message}");
                    return "Error en la base de datos";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error general: {ex.Message}");
                    return "Error en el proceso";
                }
            }
        }
        public string VerBibliotecaUsuario(int idUser)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString()))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT idVideojuego FROM biblioteca WHERE idUsuario = @idUser";
                    bool esta = false;
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idUser", idUser);
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        if (count > 0) { esta = true; } else { esta = false; }
                    }
                    if (esta)
                    {
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            // Agregar parámetros
                            command.Parameters.AddWithValue("@idUser", idUser);
                            using (MySqlDataReader reader = command.ExecuteReader())
                            {
                                List<string> ids = new List<string>();
                                while (reader.Read())
                                {
                                    ids.Add(reader["idVideojuego"].ToString());
                                }
                                // Unir los IDs en un solo string separados por comas
                                connection.Close();
                                return string.Join(",", ids);
                            }
                        }
                    }
                    else
                    {
                        return "0";
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error de MySQL: {ex.Message}");
                    return "Error en la base de datos";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error general: {ex.Message}");
                    return "Error en el proceso";
                }
            }
        }
        public void ComprarJuego(int idUser,int idVideojuego)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString()))
            {

                try
                {
                    connection.Open();

                    string query = "UPDATE valoraciones SET cesta = 0 WHERE idUsuario = @idUser AND idVideojuego = @idVideojuego";
                    string query2 = "UPDATE valoraciones SET comprado = 1 WHERE idUsuario = @idUser AND idVideojuego = @idVideojuego";
                    string query3 = "INSERT INTO biblioteca (idUsuario, idVideojuego) VALUES (@idUser, @idVideojuego)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idUser", idUser);
                        command.Parameters.AddWithValue("@idVideojuego", idVideojuego);
                        command.ExecuteNonQuery();
                    }

                    using (MySqlCommand command = new MySqlCommand(query2, connection))
                    {
                        command.Parameters.AddWithValue("@idUser", idUser);
                        command.Parameters.AddWithValue("@idVideojuego", idVideojuego);
                        command.ExecuteNonQuery();
                    }

                    using (MySqlCommand command = new MySqlCommand(query3, connection))
                    {
                        command.Parameters.AddWithValue("@idUser", idUser);
                        command.Parameters.AddWithValue("@idVideojuego", idVideojuego);
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                    MessageBox.Show("Juego Comprado");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al consultar los datos: " + ex.Message);
                }
            }
        }
        private bool EstaEnLaBiblioteca(int idUser, int idVideojuego)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString()))
            {
                try
                {
                    connection.Open(); // Abrir conexión

                    // Consulta SQL para verificar la existencia del usuario
                    string query = "SELECT COUNT(*) FROM biblioteca WHERE idUsuario = @idUser AND idVideojuego = @idVideojuego";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Agregar parámetros
                        command.Parameters.AddWithValue("@idUser", idUser);
                        command.Parameters.AddWithValue("@idVideojuego", idVideojuego);

                        int count = Convert.ToInt32(command.ExecuteScalar());
                        connection.Close();
                        return count > 0;
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error de MySQL: {ex.Message}");
                    return false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error general: {ex.Message}");
                    return false;
                }
            }
        }
    }
}
