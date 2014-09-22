namespace CoursePaperNew.Forms
{
    partial class MasterDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MasterDetail));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.defaultFormAddButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.defaultLayoutDeleteButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.defaultLayoutEditButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.detailGroupBox = new System.Windows.Forms.GroupBox();
            this.addCategory = new System.Windows.Forms.Button();
            this.addAuthor = new System.Windows.Forms.Button();
            this.isbnTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.authorComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.editionTextBox = new System.Windows.Forms.TextBox();
            this.EditButton = new System.Windows.Forms.Button();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.bindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.navigatorDeleteButton = new System.Windows.Forms.ToolStripButton();
            this.masterGroupBox = new System.Windows.Forms.GroupBox();
            this.masterDetailDataGrid = new System.Windows.Forms.DataGridView();
            this.masterDetailContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.headerErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.bodyErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.ISBNErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.headerToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.bodyToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ISBNToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip1.SuspendLayout();
            this.detailGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator)).BeginInit();
            this.bindingNavigator.SuspendLayout();
            this.masterGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.masterDetailDataGrid)).BeginInit();
            this.masterDetailContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bodyErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ISBNErrorProvider)).BeginInit();
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
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(29, 22);
            this.toolStripLabel1.Text = "Add";
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
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(40, 22);
            this.toolStripLabel2.Text = "Delete";
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
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(27, 22);
            this.toolStripLabel3.Text = "Edit";
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
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(46, 22);
            this.toolStripLabel4.Text = "Refresh";
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
            // detailGroupBox
            // 
            this.detailGroupBox.Controls.Add(this.addCategory);
            this.detailGroupBox.Controls.Add(this.addAuthor);
            this.detailGroupBox.Controls.Add(this.isbnTextBox);
            this.detailGroupBox.Controls.Add(this.label5);
            this.detailGroupBox.Controls.Add(this.label4);
            this.detailGroupBox.Controls.Add(this.categoryComboBox);
            this.detailGroupBox.Controls.Add(this.label3);
            this.detailGroupBox.Controls.Add(this.label2);
            this.detailGroupBox.Controls.Add(this.authorComboBox);
            this.detailGroupBox.Controls.Add(this.label1);
            this.detailGroupBox.Controls.Add(this.editionTextBox);
            this.detailGroupBox.Controls.Add(this.EditButton);
            this.detailGroupBox.Controls.Add(this.titleTextBox);
            this.detailGroupBox.Controls.Add(this.AddButton);
            this.detailGroupBox.Controls.Add(this.bindingNavigator);
            this.detailGroupBox.Location = new System.Drawing.Point(12, 440);
            this.detailGroupBox.Name = "detailGroupBox";
            this.detailGroupBox.Size = new System.Drawing.Size(860, 159);
            this.detailGroupBox.TabIndex = 3;
            this.detailGroupBox.TabStop = false;
            this.detailGroupBox.Text = "Detail";
            // 
            // addCategory
            // 
            this.addCategory.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.addCategory.Location = new System.Drawing.Point(514, 56);
            this.addCategory.Name = "addCategory";
            this.addCategory.Size = new System.Drawing.Size(41, 23);
            this.addCategory.TabIndex = 11;
            this.addCategory.Text = "Add";
            this.addCategory.UseVisualStyleBackColor = true;
            this.addCategory.Click += new System.EventHandler(this.addCategory_Click);
            // 
            // addAuthor
            // 
            this.addAuthor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.addAuthor.Location = new System.Drawing.Point(514, 19);
            this.addAuthor.Name = "addAuthor";
            this.addAuthor.Size = new System.Drawing.Size(41, 23);
            this.addAuthor.TabIndex = 10;
            this.addAuthor.Text = "Add";
            this.addAuthor.UseVisualStyleBackColor = true;
            this.addAuthor.Click += new System.EventHandler(this.addAuthor_Click);
            // 
            // isbnTextBox
            // 
            this.isbnTextBox.Location = new System.Drawing.Point(702, 40);
            this.isbnTextBox.Name = "isbnTextBox";
            this.isbnTextBox.Size = new System.Drawing.Size(100, 20);
            this.isbnTextBox.TabIndex = 9;
            this.isbnTextBox.MouseHover += new System.EventHandler(this.isbnTextBox_MouseHover);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(643, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "ISBN";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(326, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Category";
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.categoryComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.categoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(408, 56);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(100, 21);
            this.categoryComboBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(326, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Author";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(28, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Year of edition";
            // 
            // authorComboBox
            // 
            this.authorComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.authorComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.authorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.authorComboBox.FormattingEnabled = true;
            this.authorComboBox.Location = new System.Drawing.Point(408, 19);
            this.authorComboBox.Name = "authorComboBox";
            this.authorComboBox.Size = new System.Drawing.Size(100, 21);
            this.authorComboBox.Sorted = true;
            this.authorComboBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(28, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Title";
            // 
            // editionTextBox
            // 
            this.editionTextBox.Location = new System.Drawing.Point(135, 56);
            this.editionTextBox.Name = "editionTextBox";
            this.editionTextBox.Size = new System.Drawing.Size(100, 20);
            this.editionTextBox.TabIndex = 3;
            this.editionTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.editionTextBox_KeyPress);
            this.editionTextBox.MouseHover += new System.EventHandler(this.editionTextBox_MouseHover);
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(394, 105);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(75, 23);
            this.EditButton.TabIndex = 4;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(135, 19);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(100, 20);
            this.titleTextBox.TabIndex = 4;
            this.titleTextBox.MouseHover += new System.EventHandler(this.titleTextBox_MouseHover);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(394, 105);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 4;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // bindingNavigator
            // 
            this.bindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator.DeleteItem = null;
            this.bindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.bindingNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.navigatorDeleteButton});
            this.bindingNavigator.Location = new System.Drawing.Point(358, 131);
            this.bindingNavigator.MoveFirstItem = null;
            this.bindingNavigator.MoveLastItem = null;
            this.bindingNavigator.MoveNextItem = null;
            this.bindingNavigator.MovePreviousItem = null;
            this.bindingNavigator.Name = "bindingNavigator";
            this.bindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator.Size = new System.Drawing.Size(154, 25);
            this.bindingNavigator.TabIndex = 3;
            this.bindingNavigator.Text = "Navigator";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // navigatorDeleteButton
            // 
            this.navigatorDeleteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.navigatorDeleteButton.Image = global::CoursePaperNew.Properties.Resources.Delete;
            this.navigatorDeleteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.navigatorDeleteButton.Name = "navigatorDeleteButton";
            this.navigatorDeleteButton.Size = new System.Drawing.Size(23, 22);
            this.navigatorDeleteButton.Text = "Delete";
            this.navigatorDeleteButton.ToolTipText = "Delete selected item";
            this.navigatorDeleteButton.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // masterGroupBox
            // 
            this.masterGroupBox.Controls.Add(this.masterDetailDataGrid);
            this.masterGroupBox.Location = new System.Drawing.Point(12, 28);
            this.masterGroupBox.Name = "masterGroupBox";
            this.masterGroupBox.Size = new System.Drawing.Size(860, 406);
            this.masterGroupBox.TabIndex = 4;
            this.masterGroupBox.TabStop = false;
            this.masterGroupBox.Text = "Master";
            // 
            // masterDetailDataGrid
            // 
            this.masterDetailDataGrid.AllowUserToAddRows = false;
            this.masterDetailDataGrid.AllowUserToDeleteRows = false;
            this.masterDetailDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.masterDetailDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.masterDetailDataGrid.ContextMenuStrip = this.masterDetailContextMenu;
            this.masterDetailDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.masterDetailDataGrid.EnableHeadersVisualStyles = false;
            this.masterDetailDataGrid.Location = new System.Drawing.Point(6, 19);
            this.masterDetailDataGrid.MultiSelect = false;
            this.masterDetailDataGrid.Name = "masterDetailDataGrid";
            this.masterDetailDataGrid.RowHeadersVisible = false;
            this.masterDetailDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.masterDetailDataGrid.Size = new System.Drawing.Size(848, 381);
            this.masterDetailDataGrid.TabIndex = 2;
            this.masterDetailDataGrid.SelectionChanged += new System.EventHandler(this.masterDetailDataGrid_SelectionChanged_1);
            this.masterDetailDataGrid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.masterDetailDataGrid_KeyUp);
            this.masterDetailDataGrid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.masterDetailDataGrid_MouseDown);
            // 
            // masterDetailContextMenu
            // 
            this.masterDetailContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.masterDetailContextMenu.Name = "masterDetailContextMenu";
            this.masterDetailContextMenu.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // bindingSource1
            // 
            this.bindingSource1.CurrentChanged += new System.EventHandler(this.bindingSource1_CurrentChanged);
            // 
            // headerErrorProvider
            // 
            this.headerErrorProvider.ContainerControl = this;
            // 
            // bodyErrorProvider
            // 
            this.bodyErrorProvider.ContainerControl = this;
            // 
            // ISBNErrorProvider
            // 
            this.ISBNErrorProvider.ContainerControl = this;
            // 
            // headerToolTip
            // 
            this.headerToolTip.AutoPopDelay = 3000;
            this.headerToolTip.InitialDelay = 200;
            this.headerToolTip.IsBalloon = true;
            this.headerToolTip.ReshowDelay = 100;
            this.headerToolTip.ShowAlways = true;
            // 
            // bodyToolTip
            // 
            this.bodyToolTip.AutoPopDelay = 3000;
            this.bodyToolTip.InitialDelay = 200;
            this.bodyToolTip.IsBalloon = true;
            this.bodyToolTip.ReshowDelay = 100;
            this.bodyToolTip.ShowAlways = true;
            // 
            // ISBNToolTip
            // 
            this.ISBNToolTip.AutoPopDelay = 3000;
            this.ISBNToolTip.InitialDelay = 200;
            this.ISBNToolTip.IsBalloon = true;
            this.ISBNToolTip.ReshowDelay = 100;
            this.ISBNToolTip.ShowAlways = true;
            // 
            // MasterDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(884, 611);
            this.Controls.Add(this.masterGroupBox);
            this.Controls.Add(this.detailGroupBox);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MasterDetail";
            this.Text = "Master-Detail View";
            this.Load += new System.EventHandler(this.MasterDetail_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.detailGroupBox.ResumeLayout(false);
            this.detailGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator)).EndInit();
            this.bindingNavigator.ResumeLayout(false);
            this.bindingNavigator.PerformLayout();
            this.masterGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.masterDetailDataGrid)).EndInit();
            this.masterDetailContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bodyErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ISBNErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton defaultFormAddButton;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton defaultLayoutDeleteButton;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripButton defaultLayoutEditButton;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.GroupBox detailGroupBox;
        private System.Windows.Forms.GroupBox masterGroupBox;
        private System.Windows.Forms.DataGridView masterDetailDataGrid;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.TextBox editionTextBox;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.ComboBox authorComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox isbnTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button addCategory;
        private System.Windows.Forms.Button addAuthor;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.BindingNavigator bindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton navigatorDeleteButton;
        private System.Windows.Forms.ContextMenuStrip masterDetailContextMenu;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ErrorProvider headerErrorProvider;
        private System.Windows.Forms.ErrorProvider bodyErrorProvider;
        private System.Windows.Forms.ErrorProvider ISBNErrorProvider;
        private System.Windows.Forms.ToolTip headerToolTip;
        private System.Windows.Forms.ToolTip bodyToolTip;
        private System.Windows.Forms.ToolTip ISBNToolTip;
    }
}