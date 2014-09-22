using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using CoursePaperNew.Classes;
using CoursePaperNew.Classes.Exceptions;

namespace CoursePaperNew
{
    public partial class LoginWindow : Form
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.FormClosed += (sender2, e2) =>
                {
                    this.usernameLoginBox.Text = registerForm.Username;
                };
            registerForm.ShowDialog();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = this.usernameLoginBox.Text;
            string password = this.passwordLoginBox.Text;
            try
            {
                User currentUser = User.LoginUser(username, password);
                MainWindow mainForm = new MainWindow(currentUser);
                this.Hide();
                mainForm.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
