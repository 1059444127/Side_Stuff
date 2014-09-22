using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using CoursePaperNew.Classes;
using MySql.Data.MySqlClient;

namespace CoursePaperNew.Forms
{
    public partial class SearchForm : Form
    {
        User currentUser;
        MainWindow parent;

        public SearchForm(User currentUser, MainWindow parent)
        {
            this.currentUser = currentUser;
            this.parent = parent;
            InitializeComponent();
        }

        private void radioButtonFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonFilter.Checked == true)
            {
                this.authorCheckBox.Enabled = true;
                this.categoryCheckBox.Enabled = true;
                this.editionCheckBox.Enabled = true;
            }
            else
            {
                this.authorCheckBox.Enabled = false;
                this.categoryCheckBox.Enabled = false;
                this.editionCheckBox.Enabled = false;
            }
        }

        private void radioButtonISBN_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonISBN.Checked == true)
            {
                this.isbnTextBox.ReadOnly = false;
            }
            else
            {
                this.isbnTextBox.ReadOnly = true;
            }
        }

        private void radioButtonTitle_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonTitle.Checked == true)
            {
                this.titleTextBox.ReadOnly = false;
            }
            else
            {
                this.titleTextBox.ReadOnly = true;
            }
        }

        private void authorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.authorCheckBox.Checked == true)
            {
                this.authorTextBox.ReadOnly = false;
            }
            else
            {
                this.authorTextBox.ReadOnly = true;
            }
        }

        private void categoryCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.categoryCheckBox.Checked == true)
            {
                this.categoryTextBox.ReadOnly = false;
            }
            else
            {
                this.categoryTextBox.ReadOnly = true;
            }
        }

        private void editionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.editionCheckBox.Checked == true)
            {
                this.editionTextBox.ReadOnly = false;
            }
            else
            {
                this.editionTextBox.ReadOnly = true;
            }
        }

        private void Search(Form form)
        {
            if (this.radioButtonISBN.Checked == true)
            {
                Regex r = new Regex("(978|979)[ |-][0-9]{1,5}[ |-][0-9]{1,7}[ |-][0-9]{1,7}[0-9]{1}");
                Match m = r.Match(this.isbnTextBox.Text);
                if ((this.isbnTextBox.Text.Length < 17 || this.isbnTextBox.Text.Length > 17) || !m.Success)
                {
                    MessageBox.Show("The isbn number must be exactly 17 characters long and in the format \"978-XXX-XX-XXXX-X!\"");
                }
                else
                {
                    List<MySqlParameter> parameters = new List<MySqlParameter>()
                    {
                        new MySqlParameter("ISBN", this.isbnTextBox.Text)
                    };
                    (form as IBuildsDataGrid).StoredProcedure = "search_isbn";
                    (form as IBuildsDataGrid).Parameters = parameters;

                    try
                    {
                        (form as IBuildsDataGrid).BuildDataGridFromProcedure((form as IBuildsDataGrid).StoredProcedure, (form as IBuildsDataGrid).Parameters);
                        form.Text = "Search by ISBN " + this.isbnTextBox.Text;
                        form.MdiParent = this.parent;
                        this.Close();
                        form.Show();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else if (this.radioButtonTitle.Checked == true)
            {
                if (this.titleTextBox.Text.Length <= 2)
                {
                    MessageBox.Show("Search title must be at least 3 characters long!");
                }
                else
                {
                    List<MySqlParameter> parameters = new List<MySqlParameter>()
                    {
                        new MySqlParameter("title", this.titleTextBox.Text)
                    };
                    (form as IBuildsDataGrid).StoredProcedure = "search_title";
                    (form as IBuildsDataGrid).Parameters = parameters;
                    try
                    {
                        (form as IBuildsDataGrid).BuildDataGridFromProcedure((form as IBuildsDataGrid).StoredProcedure, (form as IBuildsDataGrid).Parameters);
                        form.Text = String.Format("Search By Title \"{0}\"", this.titleTextBox.Text);
                        form.MdiParent = this.parent;
                        this.Close();
                        form.Show();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else if (this.radioButtonFilter.Checked == true)
            {
                bool hasError = false;
                List<MySqlParameter> parameters = new List<MySqlParameter>();
                if (this.authorCheckBox.Checked == true)
                {
                    if (this.authorTextBox.Text.Length > 0)
                    {
                        parameters.Add(new MySqlParameter("authorName", this.authorTextBox.Text));
                    }
                    else
                    {
                        parameters.Add(new MySqlParameter("authorName", null));
                    }
                }
                else
                {
                    parameters.Add(new MySqlParameter("authorName", null));
                }
                if (this.categoryCheckBox.Checked == true)
                {
                    if (this.categoryTextBox.Text.Length > 0)
                    {
                        parameters.Add(new MySqlParameter("categoryName", this.categoryTextBox.Text));
                    }
                    else
                    {
                        parameters.Add(new MySqlParameter("categoryName", null));
                    }
                }
                else
                {
                    parameters.Add(new MySqlParameter("categoryName", null));
                }
                if (this.editionCheckBox.Checked == true)
                {
                    if (this.editionTextBox.Text.Length == 4)
                    {
                        parameters.Add(new MySqlParameter("edition", this.editionTextBox.Text));
                    }
                    else
                    {
                        MessageBox.Show("Edition year must be exactly 4 digits!");
                        hasError = true;
                    }
                }
                else
                {
                    parameters.Add(new MySqlParameter("edition", null));
                }
                if (!hasError)
                {
                    try
                    {
                        (form as IBuildsDataGrid).StoredProcedure = "search_filter";
                        (form as IBuildsDataGrid).Parameters = parameters;
                        (form as IBuildsDataGrid).BuildDataGridFromProcedure((form as IBuildsDataGrid).StoredProcedure, (form as IBuildsDataGrid).Parameters);
                        form.Text = "Filter";
                        form.MdiParent = this.parent;
                        this.Close();
                        form.Show();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void editionTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void generalView_Click(object sender, EventArgs e)
        {
            DefaultLayout form = new DefaultLayout(this.currentUser, this.parent);
            Search(form);
        }

        private void masterDetail_Click(object sender, EventArgs e)
        {
            MasterDetail form = new MasterDetail(this.currentUser, this.parent);
            Search(form);
        }
    }
}
