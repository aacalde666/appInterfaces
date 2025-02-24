using MySql.Data.MySqlClient;
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
using System.Xml;

namespace ventana
{
    public partial class LoginForm : Form
    {
        private Label lblusername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnLogin;
        private mainFrom mainFrom;
        private SQL sql;
        public LoginForm(mainFrom mainFrom, SQL sql)
        {
            this.mainFrom = mainFrom;
            this.sql = sql;

            lblusername = new Label();
            lblusername.Location = new System.Drawing.Point(150, 50);
            lblusername.Text = "Username";

            txtUsername = new TextBox();
            txtUsername.Location = new System.Drawing.Point(50, 50);
            txtUsername.ForeColor = System.Drawing.Color.Gray;

            lblPassword = new Label();
            lblPassword.Location = new System.Drawing.Point(150, 100);
            lblPassword.Text = "Password";

            txtPassword = new TextBox();
            txtPassword.Location = new System.Drawing.Point(50, 100);
            txtPassword.ForeColor = System.Drawing.Color.Gray;
            txtPassword.PasswordChar = '*';

            btnLogin = new Button();
            btnLogin.Text = "Login";
            btnLogin.Location = new System.Drawing.Point(50, 150);
            btnLogin.Click += BtnLogin_Click;

            Controls.Add(lblusername);
            Controls.Add(lblPassword);
            Controls.Add(txtUsername);
            Controls.Add(txtPassword);
            Controls.Add(btnLogin);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            if (sql.VerSiExisteUsuario(username))
            {
                if (!sql.IsUserBanned(username).Equals("ban"))
                {
                    if (!sql.VerSiExisteContraseña(username, password))
                    {
                        MessageBox.Show("Passwd incorrect!");
                    }
                    else
                    {
                        Form1 form1;
                        MessageBox.Show("Login successful!");
                        string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                        if (Regex.IsMatch(username, emailPattern))
                        {
                            String user = sql.VerNombreUsuarioPorCorreo(username);
                            MessageBox.Show("Bienvenido" + user);
                        }
                        else
                        {
                            MessageBox.Show("Bienvenido " + username);
                        }
                        form1 = new Form1(mainFrom, username, sql);
                        form1.Show();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Usuario baneado");
                }
            }
            else if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("No has puesto usuario, ve a la zona de registro");
                mainFrom.Show();
                this.Close();
            }
            else 
            {
                MessageBox.Show("No existe ese usuario, ve a la zona de registro");
                mainFrom.Show();
                this.Close();
            }
        }
    }
}
