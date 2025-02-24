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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace ventana
{
    public partial class ventanaAdminForm : Form
    {
        private Form1 form1;
        private SQL sql = new SQL();
        private string user;
        MainCatalogo cat;
        CrerUsuarioForm cuf;
        modificarUsuarioForm muf;
        public ventanaAdminForm(Form1 form1, string user, string rol, MainCatalogo cat)
        {
            InitializeComponent();
            this.form1 = form1;
            this.Text = rol+": "+user;
            this.user = user;
            fondo.Dock = DockStyle.Fill;
            fondo.Image = form1.fondo.Image;
            panelCatalogo.Visible = false;
            this.cat = cat;
        }
        public void refrescarTabla()
        {
            DataTable dataTable = sql.TablaConsulta();
            

            if (dataTable != null)
            {
                // Asignar el DataTable al DataGridView
                tablaConsulta.DataSource = dataTable;
                tablaConsulta.ClearSelection();
            }
            else
            {
                MessageBox.Show("No se pudieron cargar los datos.");
            }
            if (sql.VerSiESUserOAdmin(user).Equals("admin"))
            {
                if (tablaConsulta.Columns.Contains("clave"))
                {
                    tablaConsulta.Columns["clave"].Visible = false;
                }
                if (tablaConsulta.Columns.Contains("passwd"))
                {
                    tablaConsulta.Columns["passwd"].Visible = false;
                }
            }

        }
        private void consultabtn_Click(object sender, EventArgs e)
        {
            refrescarTabla();
            visibilidadContenido();
        }
        private void eliminarbtn_Click(object sender, EventArgs e)
        {
            string nombre = "";
            if (tablaConsulta.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = tablaConsulta.SelectedRows[0];
                nombre = filaSeleccionada?.Cells["name"].Value.ToString();
                DialogResult result = MessageBox.Show(this, "Estas seguro de eliminar al usuario seleccionado?", "Help caption", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                MessageBoxOptions.RightAlign);
                if (result == DialogResult.Yes)
                {
                    if (sql.VerSiESUserOAdmin(nombre).Equals("user")||sql.VerSiESUserOAdmin(user).Equals("owner"))
                    {
                        sql.EliminarUsuario(nombre);
                    }
                    else
                    {
                        MessageBox.Show("Solo el owner puede eliminar");
                    }
                }
                else
                {
                    MessageBox.Show(nombre + " no se eliminara");
                }
            }
            else if (tablaConsulta.CurrentCell != null)
            {
                nombre = tablaConsulta.CurrentCell.Value.ToString();
                if (sql.VerUsuario(nombre))
                {
                    sql.EliminarUsuario(nombre);
                }
                else
                {
                    MessageBox.Show("Usuario o fila no seleccionada");
                }
            }
            sql.recargaId();
            refrescarTabla();
            
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            string busqueda = textbusqueda.Text.ToLower();
            foreach (DataGridViewRow fila in tablaConsulta.Rows)
            {
                if (fila.Cells["name"].Value != null &&
                    fila.Cells["name"].Value.ToString().ToLower().Contains(busqueda))
                {
                    fila.Selected = true;
                    tablaConsulta.FirstDisplayedScrollingRowIndex = fila.Index;
                    return;
                }
            }
        }

        private void modificacionbtn_Click(object sender, EventArgs e)
        {
            if (tablaConsulta.SelectedRows.Count > 0) // Verificar que hay una fila seleccionada
            {
                // Obtener la primera fila seleccionada
                DataGridViewRow filaSeleccionada = tablaConsulta.SelectedRows[0];

                string id = filaSeleccionada.Cells["id"].Value.ToString();
                string nombre = filaSeleccionada.Cells["name"].Value.ToString();
                string contraseña = filaSeleccionada.Cells["passwd"].Value.ToString();
                string correo = filaSeleccionada.Cells["email"].Value?.ToString();
                string rol = filaSeleccionada.Cells["rol"].Value.ToString();
                string estado = filaSeleccionada.Cells["status"].Value.ToString();
                string clave = filaSeleccionada.Cells["clave"].Value.ToString();
                string ban = filaSeleccionada.Cells["ban"].Value.ToString();
                if (muf == null || muf.IsDisposed)
                {
                    muf = new modificarUsuarioForm(id, nombre, contraseña, correo, rol, estado, clave, ban, sql, user, this);
                }
                muf.Show();
                muf.BringToFront();

                if (sql.VerSiESUserOAdmin(user).Equals("admin"))
                {
                    if (rol.Equals("owner") || rol.Equals("admin"))
                    {
                        MessageBox.Show("Un admin solo puede modificar a los users");
                    }
                    else
                    {
                        muf.Show();
                    }
                }
            }
        }

        private void Creacionbtn_Click(object sender, EventArgs e)
        {
            visibilidadContenido();
            if (cuf == null || cuf.IsDisposed)
            {
                cuf = new CrerUsuarioForm(sql, user, this);
            }
            cuf.Show();
            cuf.BringToFront();
        }

        private void btnCatalogo_Click(object sender, EventArgs e)
        {
            btnBusqueda.Visible = false;
            textbusqueda.Visible = false;
            panelCatalogo.Visible = true;
            panelCatalogo.Size = new Size(1362, 680);
            panelCatalogo.Controls.Clear();
            cat.Dock = DockStyle.Fill;  // Ajusta el control al tamaño del panel
            this.panelCatalogo.Controls.Add(cat);
        }
        private void visibilidadContenido()
        {
            btnBusqueda.Visible = true;
            textbusqueda.Visible = true;
            panelCatalogo.Visible = false;
        }

        private void fondo_Click(object sender, EventArgs e)
        {
            visibilidadContenido();
        }
    }
}
