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
using MySql.Data.MySqlClient;

namespace CoursePaperNew.Forms
{
    public partial class AddCategory : Form
    {
        User currentUser;
        public AddCategory(User currentUser)
        {
            this.currentUser = currentUser;
            InitializeComponent();
        }

        private void categoryTextBox_MouseHover(object sender, EventArgs e)
        {
            this.categoryTooltip.SetToolTip(this.categoryTextBox, "Category name must be at least 3 symbols long.");
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            bool hasError = false;
            if (this.categoryTextBox.Text.Length < 3)
            {
                this.categoryErrorProvider.SetError(this.categoryTextBox, "Category name must be at least 3 symbols long!");
                hasError = true;
            }
            else
            {
                this.categoryErrorProvider.Clear();
            }
            if (!hasError)
            {
                try
                {
                    string categoryName = this.categoryTextBox.Text;
                    List<MySqlParameter> parameters = new List<MySqlParameter>()
                    {
                        new MySqlParameter("tableName", "categories"),
                        new MySqlParameter("element", categoryName),
                        new MySqlParameter("userID", this.currentUser.UserId)
                    };
                    if (DBConnector.ExecuteStoredProcedure("insert_author_or_category", parameters))
                    {
                        MessageBox.Show("Category added succesfully!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to add category!");
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
