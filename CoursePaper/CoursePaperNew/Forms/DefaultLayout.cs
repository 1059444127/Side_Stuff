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
    public partial class DefaultLayout : Form, IBuildsDataGrid
    {
        private string buildDataGridQuery;
        private User currentUser;
        MainWindow parentForm;

        public MainWindow ParentForm
        {
            get
            {
                return this.parentForm;
            }
        }

        public string BuildDataGridQuery
        {
            get { return this.buildDataGridQuery; }
        }

        string storedProcedure;
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
        List<MySqlParameter> parameters;
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
            this.defaultDataGrid.DataSource = table;
            this.defaultDataGrid.Columns["Book ID"].Visible = false;
            this.defaultDataGrid.Columns["ISBN"].Visible = false;
            this.defaultDataGrid.Columns["user_id"].Visible = false;
            this.defaultDataGrid.Columns["author_id"].Visible = false;
            this.defaultDataGrid.Columns["category_id"].Visible = false;
        }

        public void BuildDataGridFromProcedure(string procedure, List<MySqlParameter> parameters)
        {
            DataTable table = DBConnector.ExecuteStoredProcedureReturnTable(procedure, parameters);
            this.defaultDataGrid.DataSource = table;
            this.defaultDataGrid.Columns["Book ID"].Visible = false;
            this.defaultDataGrid.Columns["ISBN"].Visible = false;
            this.defaultDataGrid.Columns["user_id"].Visible = false;
            this.defaultDataGrid.Columns["author_id"].Visible = false;
            this.defaultDataGrid.Columns["category_id"].Visible = false;
        }

        public DefaultLayout(User user, MainWindow parent, string query = null, string storedProcedure = null, List<MySqlParameter> parameters = null)
        {
            InitializeComponent();
            this.parentForm = parent;
            this.buildDataGridQuery = query;
            this.storedProcedure = storedProcedure;
            this.parameters = parameters;
            this.currentUser = user;
        }

        private void defaultFormAddButton_Click(object sender, EventArgs e)
        {
            AddElement addElementForm = new AddElement(this.currentUser, this.parentForm, this);
            addElementForm.ShowDialog();
        }


        private void defaultLayoutDeleteButton_Click(object sender, EventArgs e)
        {
            long checkID = Convert.ToInt64(this.defaultDataGrid.SelectedRows[0].Cells["user_id"].Value);
            if (this.currentUser.UserId != checkID && this.currentUser.Username.ToLower() != "admin")
            {
                MessageBox.Show("You cannot delete other users` books!");
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to delete this element?", "Confirm delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    long elementID = Convert.ToInt64(this.defaultDataGrid.SelectedRows[0].Cells["Book ID"].Value);
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

        private void defaultLayoutEditButton_Click(object sender, EventArgs e)
        {
            long elementID = Convert.ToInt64(this.defaultDataGrid.SelectedRows[0].Cells["Book ID"].Value);
            string query = String.Format("SELECT * FROM edit_view WHERE book_id = {0}", elementID);
            DataTable editTable = DBConnector.Select(query);
            long checkID = Convert.ToInt64(this.defaultDataGrid.SelectedRows[0].Cells["user_id"].Value);
            if (this.currentUser.UserId != checkID && this.currentUser.Username.ToLower() != "admin")
            {
                MessageBox.Show("You cannot edit other users` books!");
            }
            else
            {
                EditElement editElementForm = new EditElement(elementID, this.ParentForm);
                editElementForm.ShowDialog();
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            defaultFormAddButton_Click(sender, e);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            defaultLayoutEditButton_Click(sender, e);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            defaultLayoutDeleteButton_Click(sender, e);
        }

        private void defaultDataGrid_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    var hti = defaultDataGrid.HitTest(e.X, e.Y);
                    this.defaultDataGrid.ClearSelection();
                    this.defaultDataGrid.Rows[hti.RowIndex].Selected = true;
                }
                catch (ArgumentOutOfRangeException)
                {
                    this.defaultDataGrid.Rows[this.defaultDataGrid.Rows.Count - 1].Selected = true;
                }
            }
        }

        private void defaultDataGrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.defaultLayoutEditButton_Click(sender, e);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.parentForm.RefreshChildren();
        }

        private void defaultDataGrid_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                defaultLayoutDeleteButton_Click(sender, e);
            }
        }

        private void DefaultLayout_Load(object sender, EventArgs e)
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
