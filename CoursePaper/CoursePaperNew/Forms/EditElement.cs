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

namespace CoursePaperNew
{
    public partial class EditElement : Form
    {
        private long bookID;
        MainWindow parent;

        public long BookID
        {
            get { return this.bookID; }
        }

        public EditElement(long bookID, MainWindow parent)
        {
            this.bookID = bookID;
            this.parent = parent;
            InitializeComponent();
        }

        private void editFormEditButton_Click(object sender, EventArgs e)
        {
            try
            {
                string bookTitle = this.editBookTitleBox.Text;
                string bookEdition = this.editBookEditionBox.Text;
                long authorID = Convert.ToInt64(this.authorComboBox.SelectedValue);
                long categoryID = Convert.ToInt64(this.categoryComboBox.SelectedValue);
                string isbn = this.isbnBox.Text;
                List<MySqlParameter> parameters = new List<MySqlParameter>()
                {
                    new MySqlParameter("bookTitle", bookTitle),
                    new MySqlParameter("bookEdition", bookEdition),
                    new MySqlParameter("isbn", isbn),
                    new MySqlParameter("authorID", authorID),
                    new MySqlParameter("categoryID", categoryID),
                    new MySqlParameter("bookID", this.BookID)
                };
                if (DBConnector.ExecuteStoredProcedure("edit_book", parameters))
                {
                    MessageBox.Show("Book edited succesfully!");
                    this.parent.RefreshChildren();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EditElement_Load(object sender, EventArgs e)
        {
            string query = String.Format("SELECT * FROM edit_view WHERE book_id = {0}", this.bookID);
            DataTable editTable = DBConnector.Select(query);
            this.editBookTitleBox.Text = editTable.Rows[0]["book_title"].ToString();
            this.editBookEditionBox.Text = editTable.Rows[0]["book_edition"].ToString();
            DataTable authorsDataTable = DBConnector.Select("SELECT id, name FROM authors");
            DataTable categoriesDataTable = DBConnector.Select("SELECT id, name FROM categories");
            this.authorComboBox.DataSource = authorsDataTable;
            this.authorComboBox.DisplayMember = "name";
            this.authorComboBox.ValueMember = "id";
            this.authorComboBox.SelectedValue = Convert.ToInt64(editTable.Rows[0]["author_id"]);
            this.categoryComboBox.DataSource = categoriesDataTable;
            this.categoryComboBox.DisplayMember = "name";
            this.categoryComboBox.ValueMember = "id";
            long categoryID = Convert.ToInt64(editTable.Rows[0]["category_id"]);
            this.categoryComboBox.SelectedValue = categoryID;
            this.isbnBox.Text = editTable.Rows[0]["ISBN"].ToString();
        }

        private void editElementHeaderBox_MouseHover(object sender, EventArgs e)
        {

            this.headerBoxToolTip.SetToolTip(this.editBookTitleBox, "Book Title must be at least 2 characters long.");
        }

        private void editElementBodyBox_MouseHover(object sender, EventArgs e)
        {
            this.bodyBoxToolTip.SetToolTip(this.editBookEditionBox, "Book Edition must be exactly 4 characters long.");
        }

        private void editBookEditionBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }
    }
}
