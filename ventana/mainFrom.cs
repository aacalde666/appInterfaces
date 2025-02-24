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
    public partial class mainFrom : System.Windows.Forms.Form
    {
        private Button btnLogin;
        private Button btnRegister;
        private Form1 form1;
        private SQL sql = new SQL();
        public mainFrom()
        {
            InitializeComponent();
            sql.ComprobacionConexion();
            btnLogin = new Button();
            btnLogin.Text = "Login";
            btnLogin.Location = new System.Drawing.Point(50, 50);
            btnLogin.Click += BtnLogin_Click;

            btnRegister = new Button();
            btnRegister.Text = "Register";
            btnRegister.Location = new System.Drawing.Point(50, 100);
            btnRegister.Click += BtnRegister_Click;

            Controls.Add(btnLogin);
            Controls.Add(btnRegister);
            
        }
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm(this, sql);
            loginForm.Show();
            this.Hide();
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm(this, sql);
            registerForm.Show();
            this.Hide();
        }
    }
}
