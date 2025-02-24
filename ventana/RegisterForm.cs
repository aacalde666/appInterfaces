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
    public partial class RegisterForm : Form
    {
        private Label lblusername;
        private TextBox txtUsername;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnSubmit;
        private mainFrom mainFrom;
        private SQL sql;
        public RegisterForm(mainFrom mainFrom, SQL sql)
        {
            this.sql = sql;
            lblusername = new Label();
            lblusername.Location = new System.Drawing.Point(150, 50);
            lblusername.Text = "Username";

            txtUsername = new TextBox();
            txtUsername.Location = new System.Drawing.Point(50, 50);
            txtUsername.Text = "Enter username";
            txtUsername.ForeColor = System.Drawing.Color.Gray;
            txtUsername.Enter += TxtUsername_Enter;

            lblEmail = new Label();
            lblEmail.Location = new System.Drawing.Point(150, 100);
            lblEmail.Text = "Email";

            txtEmail = new TextBox();
            txtEmail.Location = new System.Drawing.Point(50, 100);
            txtEmail.Text = "Enter email";
            txtEmail.ForeColor = System.Drawing.Color.Gray;
            txtEmail.Enter += TxtEmail_Enter;

            lblPassword = new Label();
            lblPassword.Location = new System.Drawing.Point(150, 150);
            lblPassword.Text = "Password";

            txtPassword = new TextBox();
            txtPassword.Location = new System.Drawing.Point(50, 150);
            txtPassword.Text = "Enter password";
            txtPassword.ForeColor = System.Drawing.Color.Gray;
            txtPassword.PasswordChar = '*';
            txtPassword.Enter += TxtPassword_Enter;

            btnSubmit = new Button();
            btnSubmit.Text = "Register";
            btnSubmit.Location = new System.Drawing.Point(50, 200);
            btnSubmit.Click += BtnSubmit_Click;

            Controls.Add(lblusername);
            Controls.Add(lblEmail);
            Controls.Add(lblPassword);
            
            
            Controls.Add(txtUsername);
            Controls.Add(txtEmail);
            Controls.Add(txtPassword);

            Controls.Add(btnSubmit);
            this.mainFrom = mainFrom;
        }

        private void TxtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Enter username")
            {
                txtUsername.Text = "";
                txtUsername.ForeColor = System.Drawing.Color.Black;
                txtEmail.Text = "";
                txtEmail.ForeColor = System.Drawing.Color.Black;
                txtPassword.Text = "";
                txtPassword.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void TxtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Enter password")
            {
                txtUsername.Text = "";
                txtUsername.ForeColor = System.Drawing.Color.Black;
                txtEmail.Text = "";
                txtEmail.ForeColor = System.Drawing.Color.Black;
                txtPassword.Text = "";
                txtPassword.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void TxtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Enter email")
            {
                txtUsername.Text = "";
                txtUsername.ForeColor = System.Drawing.Color.Black;
                txtEmail.Text = "";
                txtEmail.ForeColor = System.Drawing.Color.Black;
                txtPassword.Text = "";
                txtPassword.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" && txtPassword.Text == "")
            {
                MessageBox.Show("No pueden estar los campos vacios");
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("No puede estar el campo contraseña vacio");
            }
            else
            {
                string username = txtUsername.Text;
                string email = txtEmail.Text;
                string password = txtPassword.Text;
				string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

				if (!sql.VerSiExisteUsuarioRegister(username))
                {
                    if (!sql.VerSiExisteCorreoRegister(email))
                    {
                        if (Regex.IsMatch(email, emailPattern) || email.Equals("") || email == null)
                        {
                            sql.InsertarUsuarioSQL(username, email, password);
                            MessageBox.Show("User registered successfully!");
                            Form1 form1 = new Form1(mainFrom, username, sql);
                            form1.Show();
                            this.Close();
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
        }
    }
}
