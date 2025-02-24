using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ventana.UsersControl;

namespace ventana
{
    public partial class MainCatalogo : UserControl
    {
        private SQL sql;
        private string user;
        public MainCatalogo(SQL sql, string user)
        {
            this.sql = sql;
            this.user = user;
            InitializeComponent();
            CargarCatalogo();
            if (sql.VerSiESUserOAdmin(user).Equals("user"))
            {
                btnAgregarJuego.Visible = false;
                btnGestionarCatalogo.Text = "Cargar Catalogo";
            }
        }
        // Método para cargar el catálogo
        private void CargarCatalogo()
        {
            // Limpiar cualquier control existente en el panel
            this.panelCatalogo.Controls.Clear();

            // Crear el control CatalogoControl y agregarlo al panel
            CatalogoControl catalogo = new CatalogoControl(sql, user);
            catalogo.Dock = DockStyle.Fill;  // Ajusta el control al tamaño del panel
            this.panelCatalogo.Controls.Add(catalogo);

            // Actualizar el catálogo para obtener los datos
            catalogo.ActualizarCatalogo();
        }

        // Método para cargar la ventana de agregar juego (admin)
        private void CargarJuegoControl()
        {
            // Limpiar cualquier control existente en el panel
            this.panelCatalogo.Controls.Clear();

            // Crear el control JuegoControl y agregarlo al panel
            JuegoControl juego = new JuegoControl(sql);
            juego.Dock = DockStyle.Fill;  // Ajusta el control al tamaño del panel
            this.panelCatalogo.Controls.Add(juego);
        }

        // Evento cuando el usuario hace clic en el botón "Gestionar Catálogo"
        private void btnGestionarCatalogo_Click(object sender, EventArgs e)
        {
            CargarCatalogo();
        }

        // Evento cuando el usuario hace clic en el botón "Agregar Juego" (solo admin)
        private void btnAgregarJuego_Click(object sender, EventArgs e)
        {
            CargarJuegoControl();
        }
    }
}
