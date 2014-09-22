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
using MySql.Data.MySqlClient;

namespace CoursePaperNew.Forms
{
    public partial class EditAuthor : Form
    {
        User currentUser;
        DataTable editTable;
        MainWindow parent;
        public EditAuthor(User currentUser, MainWindow parent)
        {
            this.currentUser = currentUser;
            this.parent = parent;
            InitializeComponent();
            this.editTable = DBConnector.Select("SELECT * FROM edit_author");
            this.editComboBox.DataSource = this.editTable;
            this.editComboBox.DisplayMember = "name";
            this.editComboBox.ValueMember = "author_id";
            this.editComboBox.SelectedIndex = 1;
        }

        private void editComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.editTextBox.Text = this.editComboBox.GetItemText(this.editComboBox.SelectedItem);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRowView dRV = (DataRowView)this.editComboBox.SelectedItem;
            long checkID = Convert.ToInt64(dRV[0]);
            if (this.currentUser.UserId != checkID && this.currentUser.Username.ToLower() != "admin")
            {
                MessageBox.Show("You cannot edit authors added by other users!");
            }
            else
            {
                string newAuthorName = this.editTextBox.Text;
                long authorID = Convert.ToInt64(dRV[1]);
                List<MySqlParameter> parameters = new List<MySqlParameter>()
                {
                    new MySqlParameter("tableName", "authors"),
                    new MySqlParameter("element", newAuthorName),
                    new MySqlParameter("elementID", authorID)
                };
                try
                {
                    if (DBConnector.ExecuteStoredProcedure("edit_authors_and_categories", parameters))
                    {
                        MessageBox.Show("Author edited succesfully!");
                        this.parent.RefreshChildren();
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("Failed to edit author!");
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
