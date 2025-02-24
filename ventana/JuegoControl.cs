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
    public partial class JuegoControl : UserControl
    {
        SQL sql;
        public JuegoControl(SQL sql)
        {
            InitializeComponent();
            this.sql = sql;
            Load += JuegoControl_Load;
        }
        private void JuegoControl_Load(object sender, EventArgs e)
        {
            dtpFechaSalida.Value = DateTime.Now; // Ahora dtpFechaSalida está inicializado
            dtpFechaSalida.Visible = false;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            sql.GuardarJuego(txtTitulo.Text,txtDescripcion.Text,txtPrecio.Text,pbImagen.ImageLocation,dtpFechaSalida.Value.ToString("yyyy-MM-dd"), "Acción",
                "PC","Desarrollador","Editor","Un jugador","PEGI 18","Windows 10","Español, Ingles","Si",0,10000);
            txtTitulo.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            pbImagen.ImageLocation = null;
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
    }
}
