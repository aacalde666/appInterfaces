using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ventana
{
    public partial class modificarUsuarioForm : Form
    {
        string id, nombre, contraseña, correo, rol, estado, clave, ban, user;
        SQL sql;
        ventanaAdminForm vaf;
        public modificarUsuarioForm(string id,string nombre,string contraseña,string correo,string rol,string estado,string clave,string ban,SQL sql,string user,ventanaAdminForm vaf)
        {
            InitializeComponent();
            this.id = id;
            this.nombre = nombre;
            this.contraseña = contraseña;
            this.correo = correo;
            this.rol = rol;
            this.estado = estado;
            this.clave = clave;
            this.ban = ban;
            this.sql = sql;
            this.user = user;
            this.vaf = vaf;
            textClave.Hide();
            lblClave.Hide();
            controles();
        }
        private void controles()
        {
            if (sql.VerSiESUserOAdmin(user).Equals("owner"))
            {
                textClave.Show();
                lblClave.Show();
                textClave.Text = clave;
                rolcombo.Enabled = true;
            }
            else
            {
                rolcombo.Enabled = false;
            }
            textusuario.Text = this.nombre;
            textcontraseña.Text = this.contraseña;
            textcontraseña.PasswordChar = '*';
            textcorreo.Text = this.correo;
            switch (this.rol)
            {
                case "user": rolcombo.SelectedIndex = 0; break;
                case "admin": rolcombo.SelectedIndex = 1; break;
                case "owner": rolcombo.SelectedIndex = 2; break;
            }
            switch (this.estado)
            {
                case "active": estadocheck.Checked = true; break;
                case "inactive": estadocheck.Checked = false; break;
            }
            switch (this.ban)
            {
                case "ban": banCheck.Checked = true; break;
                case "": banCheck.Checked = false; break;
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string estado = "";
            if (estadocheck.Checked)
            {
                estado = "active";
            }
            else
            {
                estado = "inactive";
            }
            string ban = "";
            if (banCheck.Checked)
            {
                ban = "ban";
            }
            else
            {
                ban = "";
            }
            if (sql.VerSiESUserOAdmin(user).Equals("owner"))
            {
                string rol = "";
                if (rolcombo.SelectedIndex == 0)
                {
                    rol = rolcombo.SelectedItem.ToString();
                    textClave.Text = "";
                }
                else
                {
                    rol = rolcombo.SelectedItem.ToString();
                }
                sql.ModificarUsuarioClave(id,rol, textClave.Text);
            }
            sql.ModificarUsuario(id, textusuario.Text, textcontraseña.Text, textcorreo.Text, estado, ban);
            vaf.refrescarTabla();
            this.Close();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
