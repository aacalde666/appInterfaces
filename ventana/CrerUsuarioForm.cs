using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ventana
{
    public partial class CrerUsuarioForm : Form
    {
        SQL sql;
        string user;
        ventanaAdminForm vaf;
        public CrerUsuarioForm(SQL sql, string user, ventanaAdminForm vaf)
        {
            InitializeComponent();
            this.sql = sql;
            this.user = user;
            this.vaf = vaf;
            if (sql.VerSiESUserOAdmin(user).Equals("owner"))
            {
                textClave.Show();
                lblClave.Show();
                rolcombo.Enabled = true;
                rolcombo.SelectedIndex = 0;
            }
            else
            {
                textClave.Hide();
                lblClave.Hide();
                rolcombo.Enabled = false;
                rolcombo.SelectedIndex = 0;
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!sql.VerSiExisteUsuario(textusuario.Text))
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
                string email = textcorreo.Text;
                string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                if (!sql.VerSiExisteCorreoRegister(email))
                {
                    if (Regex.IsMatch(email, emailPattern) || email.Equals("") || email == null)
                    {
                        if (rolcombo.SelectedItem.Equals("admin")&&textClave.Text.Equals(""))
                        {
                            MessageBox.Show("Deves poner una clave si el usuario va a ser admin");
                        }
                        else
                        {
                            if (!rolcombo.SelectedItem.Equals("owner"))
                            {
                                sql.CrearUsuario(textusuario.Text, textcontraseña.Text, textcorreo.Text, rol, textClave.Text);
                                vaf.refrescarTabla();
                                this.Close();
                            }
                            else if (sql.VerSiESUserOAdmin(user).Equals("owner"))
                            {
                                if (textClave.Text.Equals(""))
                                {
                                    MessageBox.Show("Deves poner una clave si el usuario va a ser owner");
                                }
                                else
                                {
                                    sql.CrearUsuario(textusuario.Text, textcontraseña.Text, textcorreo.Text, rol, textClave.Text);
                                    vaf.refrescarTabla();
                                    this.Close();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Un admin no puede dar privilegios de owner");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Correo incorrecto");
                    }
                }
                else
                {
                    MessageBox.Show("Correo existente");
                }
            }
            else
            {
                MessageBox.Show("User existente");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
