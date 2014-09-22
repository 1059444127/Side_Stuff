using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoursePaperNew.Classes;
using CoursePaperNew.Classes.Exceptions;

namespace CoursePaperNew
{
    public partial class RegisterForm : Form
    {
        private string username;

        public string Username
        {
            get { return this.username; }
            private set { this.username = value; }
        }

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void registerOKButton_Click(object sender, EventArgs e)
        {
            string username = this.usernameRegisterBox.Text;
            string password = this.passwordRegisterBox.Text;

            try
            {
                if (User.RegisterUser(this.usernameRegisterBox.Text, this.passwordRegisterBox.Text))
                {
                    MessageBox.Show("Registration succesful!");
                    this.Username = username;
                    this.Close();
                }
            }
            catch (FailedValidationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (UserExistsException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void registerCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
