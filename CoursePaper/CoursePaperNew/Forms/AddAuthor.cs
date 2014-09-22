using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoursePaperNew.Classes.Exceptions;
using CoursePaperNew.Classes;
using MySql.Data.MySqlClient;

namespace CoursePaperNew.Forms
{
    public partial class AddAuthor : Form
    {
        User currentUser;
        public AddAuthor(User currentUser)
        {
            this.currentUser = currentUser;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool hasError = false;
            if (this.authorNameBox.Text.Length < 2)
            {
                this.authorNameErrorProvider.SetError(this.authorNameBox, "Author name must be at least 2 symbols!");
                hasError = true;
            }
            else
            {
                this.authorNameErrorProvider.Clear();
            }
            if (!hasError)
            {
                try
                {
                    string authorName = this.authorNameBox.Text;
                    List<MySqlParameter> parameters = new List<MySqlParameter>()
                    {
                        new MySqlParameter("tableName", "authors"),
                        new MySqlParameter("element", authorName),
                        new MySqlParameter("userID", this.currentUser.UserId)
                    };
                    if (DBConnector.ExecuteStoredProcedure("insert_author_or_category", parameters))
                    {
                        MessageBox.Show("Author added succesfully!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to add author!");
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void authorNameBox_MouseHover(object sender, EventArgs e)
        {
            this.authorNameToolTip.SetToolTip(this.authorNameBox, "Author name must be at least 2 symbols.");
        }
    }
}
