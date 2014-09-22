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
using CoursePaperNew.Forms;

namespace CoursePaperNew
{
    public partial class MainWindow : Form
    {
        private User currentUser;

        public User CurrentUser
        {
            get { return this.currentUser; }
        }

        public MainWindow(User currentUser)
        {
            this.currentUser = currentUser;
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            DefaultLayout defaultForm = new DefaultLayout(this.CurrentUser, this, "SELECT * FROM default_view");
            defaultForm.MdiParent = this;
            defaultForm.Show();
        }

        public void RefreshChildren()
        {
            foreach (IBuildsDataGrid form in this.MdiChildren)
            {
                if (form.BuildDataGridQuery == null)
                {
                    form.BuildDataGridFromProcedure(form.StoredProcedure, form.Parameters);
                }
                else
                {
                    form.BuildDataGrid(DBConnector.Select(form.BuildDataGridQuery));
                }
            }
        }

        private void cascadeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void horizontalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void verticalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var windows in this.MdiChildren)
            {
                windows.Close();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About aboutForm = new About();
            aboutForm.ShowDialog();
        }

        private void addAuthorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddAuthor addAuthorForm = new AddAuthor(this.currentUser);
            addAuthorForm.ShowDialog();
        }

        private void addCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCategory addCategoryForm = new AddCategory(this.currentUser);
            addCategoryForm.ShowDialog();
        }

        private void addBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddElement addBookForm = new AddElement(this.currentUser, this);
            addBookForm.ShowDialog();
        }

        private void editAuthorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditAuthor editAuthorForm = new EditAuthor(this.currentUser, this);
            editAuthorForm.ShowDialog();
        }

        private void editCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditCategory editCategoryForm = new EditCategory(this.currentUser, this);
            editCategoryForm.ShowDialog();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchForm searchForm = new SearchForm(this.currentUser, this);
            searchForm.ShowDialog();
        }

        private void generalViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form form in this.MdiChildren)
            {
                if (form is DefaultLayout && form.Text == "General")
                {
                    this.ActivateMdiChild(form);
                    form.BringToFront();
                    isOpen = true;
                }
            }
            if (!isOpen)
            {
                DefaultLayout defaultForm = new DefaultLayout(this.currentUser, this, "SELECT * FROM default_view");
                defaultForm.MdiParent = this;
                defaultForm.Show();
            }
        }

        private void masterDetailViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form form in this.MdiChildren)
            {
                if (form is MasterDetail && form.Text == "Master-Detail View")
                {
                    this.ActivateMdiChild(form);
                    form.BringToFront();
                    isOpen = true;
                }
            }
            if (!isOpen)
            {
                MasterDetail masterDetailForm = new MasterDetail(this.currentUser, this, "SELECT * FROM default_view");
                masterDetailForm.MdiParent = this;
                masterDetailForm.Show();
            }
        }
    }
}
