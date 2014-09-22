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
using System.Text.RegularExpressions;

namespace CoursePaperNew.Forms
{
    public partial class MasterDetail : Form, IBuildsDataGrid
    {
        private string buildDataGridQuery;
        private User currentUser;
        private MainWindow parentForm;
        private string storedProcedure;
        private List<MySqlParameter> parameters;
        private int currentRowCount;

        public MasterDetail(User currentUser, MainWindow parentForm, string buildDataGridQuery = null, string storedProcedure = null, List<MySqlParameter> parameters = null)
        {
            InitializeComponent();
            this.parentForm = parentForm;
            this.buildDataGridQuery = buildDataGridQuery;
            this.storedProcedure = storedProcedure;
            this.parameters = parameters;
            this.currentUser = currentUser;
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

        public string BuildDataGridQuery
        {
            get
            {
                return this.buildDataGridQuery;
            }
        }

        public string StoredProcedure
        {
            get
            {
                return this.storedProcedure;
            }
            set
            {
                this.storedProcedure = value;
            }
        }

        public List<MySqlParameter> Parameters
        {
            get
            {
                return this.parameters;
            }
            set
            {
                this.parameters = value;
            }
        }

        public void BuildDataGrid(DataTable table)
        {
            this.bindingSource1.DataSource = table;
            this.bindingNavigator.BindingSource = this.bindingSource1;
            this.masterDetailDataGrid.DataSource = table;
            this.masterDetailDataGrid.Columns["Book ID"].Visible = false;
            this.masterDetailDataGrid.Columns["ISBN"].Visible = false;
            this.masterDetailDataGrid.Columns["user_id"].Visible = false;
            this.masterDetailDataGrid.Columns["author_id"].Visible = false;
            this.masterDetailDataGrid.Columns["category_id"].Visible = false;
            this.currentRowCount = this.masterDetailDataGrid.Rows.Count;
        }

        public void BuildDataGridFromProcedure(string storedProcedure, List<MySqlParameter> parameters)
        {
            DataTable masterTable = DBConnector.ExecuteStoredProcedureReturnTable(this.storedProcedure, this.parameters);
            this.bindingSource1.DataSource = masterTable;
            this.bindingNavigator.BindingSource = this.bindingSource1;
            this.masterDetailDataGrid.DataSource = masterTable;
            this.masterDetailDataGrid.Columns["Book ID"].Visible = false;
            this.masterDetailDataGrid.Columns["ISBN"].Visible = false;
            this.masterDetailDataGrid.Columns["user_id"].Visible = false;
            this.masterDetailDataGrid.Columns["author_id"].Visible = false;
            this.masterDetailDataGrid.Columns["category_id"].Visible = false;
            this.currentRowCount = this.masterDetailDataGrid.Rows.Count;
        }

        private void editionTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void masterDetailDataGrid_SelectionChanged_1(object sender, EventArgs e)
        {
            this.bindingSource1.Position = this.masterDetailDataGrid.CurrentCell.RowIndex;
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            int index = this.bindingSource1.Position;
            this.masterDetailDataGrid.Rows[index].Selected = true;
            this.headerErrorProvider.Clear();
            this.bodyErrorProvider.Clear();
            this.ISBNErrorProvider.Clear();

            if (this.bindingSource1.Position > this.currentRowCount - 1)
            {
                this.EditButton.Visible = false;
                this.authorComboBox.SelectedValue = 1;
                this.categoryComboBox.SelectedValue = 1;
                this.isbnTextBox.Text = "";
                this.titleTextBox.Text = "";
                this.editionTextBox.Text = "";
            }
            else
            {
                this.EditButton.Visible = true;
                this.titleTextBox.Text = this.masterDetailDataGrid.SelectedRows[0].Cells["Book Title"].Value.ToString();
                this.editionTextBox.Text = this.masterDetailDataGrid.SelectedRows[0].Cells["Book Edition"].Value.ToString();
                int authIndex = Convert.ToInt32(this.masterDetailDataGrid.SelectedRows[0].Cells["author_id"].Value);
                this.authorComboBox.SelectedValue = authIndex;
                int catIndex = Convert.ToInt32(this.masterDetailDataGrid.SelectedRows[0].Cells["category_id"].Value);
                this.categoryComboBox.SelectedValue = catIndex;
                this.isbnTextBox.Text = this.masterDetailDataGrid.SelectedRows[0].Cells["ISBN"].Value.ToString();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            int index = this.masterDetailDataGrid.CurrentCell.RowIndex;
            if (index <= this.currentRowCount - 1)
            {
                if (MessageBox.Show("Are you sure you want to delete this item?", "Confirm delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    long checkID = Convert.ToInt64(this.masterDetailDataGrid.SelectedRows[0].Cells["user_id"].Value);
                    if (this.currentUser.UserId != checkID && this.currentUser.Username.ToLower() != "admin")
                    {
                        MessageBox.Show("You cannot delete other users` books!");
                    }
                    else
                    {
                        long elementID = Convert.ToInt64(this.masterDetailDataGrid.SelectedRows[0].Cells["Book ID"].Value);
                        string tableName = "books";
                        string paramName = "book_id";
                        List<MySqlParameter> parameters = new List<MySqlParameter>();
                        parameters.Add(new MySqlParameter("tableName", tableName));
                        parameters.Add(new MySqlParameter("paramName", paramName));
                        parameters.Add(new MySqlParameter("paramValue", elementID));
                        try
                        {
                            if (DBConnector.ExecuteStoredProcedure("delete_entry", parameters))
                            {
                                this.parentForm.RefreshChildren();
                                MessageBox.Show("Book delete succesfully!");
                            }
                            else
                            {
                                MessageBox.Show("Failed to delete book!");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            else
            {
                this.bindingSource1.RemoveCurrent();
            }
        }

        private void masterDetailDataGrid_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    var hti = masterDetailDataGrid.HitTest(e.X, e.Y);
                    this.masterDetailDataGrid.ClearSelection();
                    this.masterDetailDataGrid.Rows[hti.RowIndex].Selected = true;
                }
                catch (ArgumentOutOfRangeException)
                {
                    this.masterDetailDataGrid.Rows[this.masterDetailDataGrid.Rows.Count - 1].Selected = true;
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.toolStripButton2_Click(sender, e);
        }

        private void masterDetailDataGrid_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                this.toolStripButton2_Click(sender, e);
            }
        }

        private void defaultFormAddButton_Click(object sender, EventArgs e)
        {
            AddElement addElementForm = new AddElement(this.currentUser, this.parentForm);
            addElementForm.ShowDialog();
        }

        private void defaultLayoutDeleteButton_Click(object sender, EventArgs e)
        {
            this.toolStripButton2_Click(sender, e);
        }

        private void defaultLayoutEditButton_Click(object sender, EventArgs e)
        {
            long bookID = Convert.ToInt64(this.masterDetailDataGrid.SelectedRows[0].Cells["Book ID"].Value);
            EditElement editForm = new EditElement(bookID, this.parentForm);
            editForm.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.parentForm.RefreshChildren();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {

            bool hasError = false;
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
                        this.parentForm.RefreshChildren();
                        MessageBox.Show("Book added succesfully!");
                    }
                    else
                    {
                        MessageBox.Show("Failed to add book!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            long bookID = Convert.ToInt64(this.masterDetailDataGrid.SelectedRows[0].Cells["Book ID"].Value);
            try
            {
                string bookTitle = this.titleTextBox.Text;
                string bookEdition = this.editionTextBox.Text;
                long authorID = Convert.ToInt64(this.authorComboBox.SelectedValue);
                long categoryID = Convert.ToInt64(this.categoryComboBox.SelectedValue);
                string isbn = this.isbnTextBox.Text;
                List<MySqlParameter> parameters = new List<MySqlParameter>()
                {
                    new MySqlParameter("bookTitle", bookTitle),
                    new MySqlParameter("bookEdition", bookEdition),
                    new MySqlParameter("isbn", isbn),
                    new MySqlParameter("authorID", authorID),
                    new MySqlParameter("categoryID", categoryID),
                    new MySqlParameter("bookID", bookID)
                };
                if (DBConnector.ExecuteStoredProcedure("edit_book", parameters))
                {
                    MessageBox.Show("Book edited succesfully!");
                    this.parentForm.RefreshChildren();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void titleTextBox_MouseHover(object sender, EventArgs e)
        {
            this.headerToolTip.SetToolTip(this.titleTextBox, "Book title must be at least 2 symbols long.");
        }

        private void editionTextBox_MouseHover(object sender, EventArgs e)
        {
            this.bodyToolTip.SetToolTip(this.editionTextBox, "Book edition must be exactly 4 digits long.");
        }

        private void isbnTextBox_MouseHover(object sender, EventArgs e)
        {
            this.ISBNToolTip.SetToolTip(this.isbnTextBox, "ISBN must be exactly 17 characters long and in the format \"978-XXX-XX-XXXX-X\".");
        }

        private void MasterDetail_Load(object sender, EventArgs e)
        {
            if (storedProcedure != null && parameters != null)
            {
                BuildDataGridFromProcedure(this.storedProcedure, this.parameters);
            }
            else
            {
                BuildDataGrid(DBConnector.Select(this.buildDataGridQuery));
            }
        }
    }
}
