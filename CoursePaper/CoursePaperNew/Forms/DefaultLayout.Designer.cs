namespace CoursePaperNew
{
    partial class DefaultLayout
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.defaultDataGrid = new System.Windows.Forms.DataGridView();
            this.dataGridContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultFormAddButton = new System.Windows.Forms.ToolStripButton();
            this.defaultLayoutDeleteButton = new System.Windows.Forms.ToolStripButton();
            this.defaultLayoutEditButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.defaultDataGrid)).BeginInit();
            this.dataGridContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.defaultFormAddButton,
            this.toolStripLabel2,
            this.defaultLayoutDeleteButton,
            this.toolStripLabel3,
            this.defaultLayoutEditButton,
            this.toolStripLabel4,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(884, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(29, 22);
            this.toolStripLabel1.Text = "Add";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(40, 22);
            this.toolStripLabel2.Text = "Delete";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(27, 22);
            this.toolStripLabel3.Text = "Edit";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(46, 22);
            this.toolStripLabel4.Text = "Refresh";
            // 
            // defaultDataGrid
            // 
            this.defaultDataGrid.AllowUserToAddRows = false;
            this.defaultDataGrid.AllowUserToDeleteRows = false;
            this.defaultDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.defaultDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.defaultDataGrid.ContextMenuStrip = this.dataGridContextMenu;
            this.defaultDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.defaultDataGrid.EnableHeadersVisualStyles = false;
            this.defaultDataGrid.Location = new System.Drawing.Point(0, 28);
            this.defaultDataGrid.MultiSelect = false;
            this.defaultDataGrid.Name = "defaultDataGrid";
            this.defaultDataGrid.RowHeadersVisible = false;
            this.defaultDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.defaultDataGrid.Size = new System.Drawing.Size(884, 435);
            this.defaultDataGrid.TabIndex = 1;
            this.defaultDataGrid.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.defaultDataGrid_CellMouseDoubleClick);
            this.defaultDataGrid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.defaultDataGrid_KeyUp);
            this.defaultDataGrid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.defaultDataGrid_MouseDown);
            // 
            // dataGridContextMenu
            // 
            this.dataGridContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.dataGridContextMenu.Name = "dataGridContextMenu";
            this.dataGridContextMenu.Size = new System.Drawing.Size(108, 70);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // defaultFormAddButton
            // 
            this.defaultFormAddButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.defaultFormAddButton.Image = global::CoursePaperNew.Properties.Resources.Add;
            this.defaultFormAddButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.defaultFormAddButton.Name = "defaultFormAddButton";
            this.defaultFormAddButton.Size = new System.Drawing.Size(23, 22);
            this.defaultFormAddButton.Text = "Add";
            this.defaultFormAddButton.ToolTipText = "Add new book";
            this.defaultFormAddButton.Click += new System.EventHandler(this.defaultFormAddButton_Click);
            // 
            // defaultLayoutDeleteButton
            // 
            this.defaultLayoutDeleteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.defaultLayoutDeleteButton.Image = global::CoursePaperNew.Properties.Resources.Delete;
            this.defaultLayoutDeleteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.defaultLayoutDeleteButton.Name = "defaultLayoutDeleteButton";
            this.defaultLayoutDeleteButton.Size = new System.Drawing.Size(23, 22);
            this.defaultLayoutDeleteButton.Text = "Delete";
            this.defaultLayoutDeleteButton.ToolTipText = "Delete selected book";
            this.defaultLayoutDeleteButton.Click += new System.EventHandler(this.defaultLayoutDeleteButton_Click);
            // 
            // defaultLayoutEditButton
            // 
            this.defaultLayoutEditButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.defaultLayoutEditButton.Image = global::CoursePaperNew.Properties.Resources.Edit;
            this.defaultLayoutEditButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.defaultLayoutEditButton.Name = "defaultLayoutEditButton";
            this.defaultLayoutEditButton.Size = new System.Drawing.Size(23, 22);
            this.defaultLayoutEditButton.Text = "Edit";
            this.defaultLayoutEditButton.ToolTipText = "Edit selected book";
            this.defaultLayoutEditButton.Click += new System.EventHandler(this.defaultLayoutEditButton_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::CoursePaperNew.Properties.Resources.Refresh;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Refresh contents";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // DefaultLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.defaultDataGrid);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "DefaultLayout";
            this.Text = "General";
            this.Load += new System.EventHandler(this.DefaultLayout_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.defaultDataGrid)).EndInit();
            this.dataGridContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton defaultFormAddButton;
        private System.Windows.Forms.DataGridView defaultDataGrid;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton defaultLayoutDeleteButton;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripButton defaultLayoutEditButton;
        private System.Windows.Forms.ContextMenuStrip dataGridContextMenu;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}