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
using CoursePaperNew.Forms;
using System.Text.RegularExpressions;

namespace CoursePaperNew
{
    public partial class AddElement : Form
    {
        private User currentUser;
        private DefaultLayout senderForm;
        private bool hasError = false;
        private MainWindow parent;
        
        public MainWindow Parent
        {
            get
            {
                return this.parent;
            }
        }
        public AddElement(User user, MainWindow parent, DefaultLayout senderForm = null)
        {
            this.currentUser = user;
            this.senderForm = senderForm;
            this.parent = parent;
            InitializeComponent();
            RefreshAuthors();
            RefreshCategories();
        }

        public void RefreshAuthors()
        {
            DataTable authorsDataTable = DBConnector.Select("SELECT id, name FROM authors");
            this.authorComboBox.DataSource = authorsDataTable;
            this.authorComboBox.ValueMember = "id";
            this.authorComboBox.DisplayMember = "name";
        }

        public void RefreshCategories()
        {
            DataTable categoriesDataTable = DBConnector.Select("SELECT id, name FROM categories");
            this.categoryComboBox.DataSource = categoriesDataTable;
            this.categoryComboBox.ValueMember = "id";
            this.categoryComboBox.DisplayMember = "name";
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            hasError = false;
            if (this.titleTextBox.Text.Length < 2)
            {
                this.headerErrorProvider.SetError(this.titleTextBox, "Book title must be at least 2 symbols!");
                hasError = true;
            }
            else
            {
                this.headerErrorProvider.Clear();
            }
            if (this.editionTextBox.Text.Length < 4 || this.editionTextBox.Text.Length > 4)
            {
                this.bodyErrorProvider.SetError(this.editionTextBox, "Book edition must be 4 digits long!");
                hasError = true;
            }
            else
            {
                this.bodyErrorProvider.Clear();
            }
            Regex r = new Regex("(978|979)[ |-][0-9]{1,5}[ |-][0-9]{1,7}[ |-][0-9]{1,7}[0-9]{1}");
            Match m = r.Match(this.isbnTextBox.Text);
            if (this.isbnTextBox.Text.Length < 17 || this.isbnTextBox.Text.Length > 17)
            {
                this.ISBNErrorProvider.SetError(this.isbnTextBox, "ISBN must be exactly 17 characters long!");
                hasError = true;
            }
            else if (!m.Success)
            {
                this.ISBNErrorProvider.SetError(this.isbnTextBox, "ISBN is not in the format \"978-XXX-XX-XXXX-X\"");
                hasError = true;
            }
            else
            {
                this.ISBNErrorProvider.Clear();
            }
            if (!hasError)
            {
                try
                {
                    string isbn = this.isbnTextBox.Text;
                    long userID = this.currentUser.UserId;
                    long authorID = Convert.ToInt64(this.authorComboBox.SelectedValue);
                    long categoryID = Convert.ToInt64(this.categoryComboBox.SelectedValue);
                    string bookTitle = this.titleTextBox.Text;
                    string bookEdition = this.editionTextBox.Text;
                    List<MySqlParameter> parameters = new List<MySqlParameter>();
                    parameters.Add(new MySqlParameter("userID", userID));
                    parameters.Add(new MySqlParameter("authorID", authorID));
                    parameters.Add(new MySqlParameter("categoryID", categoryID));
                    parameters.Add(new MySqlParameter("bookTitle", bookTitle));
                    parameters.Add(new MySqlParameter("bookEdition", bookEdition));
                    parameters.Add(new MySqlParameter("bookISBN", isbn));

                    if (DBConnector.ExecuteStoredProcedure("insert_book", parameters))
                    {
                        this.parent.RefreshChildren();
                        MessageBox.Show("Book added succesfully!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to add book!");
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void headerTextBox_MouseHover(object sender, EventArgs e)
        {
            this.headerToolTip.SetToolTip(this.titleTextBox, "Book title must be at least 2 symbols long.");
        }

        private void bodyTextBox_MouseHover(object sender, EventArgs e)
        {
            this.bodyToolTip.SetToolTip(this.editionTextBox, "Book edition must be exactly 4 digits long.");
        }

        private void editionTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void addAuthor_Click(object sender, EventArgs e)
        {
            AddAuthor addAuthorForm = new AddAuthor(this.currentUser);
            addAuthorForm.FormClosed += new FormClosedEventHandler(AddAuthorClosed);
            addAuthorForm.ShowDialog();
        }

        void AddAuthorClosed(object sender, FormClosedEventArgs e)
        {
            RefreshAuthors();
        }

        private void addCategory_Click(object sender, EventArgs e)
        {
            AddCategory addCategoryForm = new AddCategory(this.currentUser);
            addCategoryForm.FormClosed += new FormClosedEventHandler(AddCategoryClosed);
            addCategoryForm.ShowDialog();
        }

        void AddCategoryClosed(object sender, FormClosedEventArgs e)
        {
            RefreshCategories();
        }

        private void isbnBoxOne_TextChanged(object sender, EventArgs e)
        {

        }

        private void isbnTextBox_MouseHover(object sender, EventArgs e)
        {
            this.ISBNToolTip.SetToolTip(this.isbnTextBox, "ISBN must be exactly 17 characters long and in the format \"978-XXX-XX-XXXX-X\".");
        }
    }
}
