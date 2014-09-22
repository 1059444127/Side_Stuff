namespace CoursePaperNew
{
    partial class AddElement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddElement));
            this.addElementLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.editionTextBox = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.headerErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.bodyErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.headerToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.bodyToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.authorComboBox = new System.Windows.Forms.ComboBox();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.addAuthor = new System.Windows.Forms.Button();
            this.addCategory = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.isbnTextBox = new System.Windows.Forms.TextBox();
            this.ISBNToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ISBNErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.headerErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bodyErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ISBNErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // addElementLabel
            // 
            resources.ApplyResources(this.addElementLabel, "addElementLabel");
            this.addElementLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.addElementLabel.Name = "addElementLabel";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // titleTextBox
            // 
            resources.ApplyResources(this.titleTextBox, "titleTextBox");
            this.titleTextBox.Name = "titleTextBox";
            this.headerToolTip.SetToolTip(this.titleTextBox, resources.GetString("titleTextBox.ToolTip"));
            this.titleTextBox.MouseHover += new System.EventHandler(this.headerTextBox_MouseHover);
            // 
            // editionTextBox
            // 
            resources.ApplyResources(this.editionTextBox, "editionTextBox");
            this.editionTextBox.Name = "editionTextBox";
            this.bodyToolTip.SetToolTip(this.editionTextBox, resources.GetString("editionTextBox.ToolTip"));
            this.editionTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.editionTextBox_KeyPress);
            this.editionTextBox.MouseHover += new System.EventHandler(this.bodyTextBox_MouseHover);
            // 
            // addButton
            // 
            resources.ApplyResources(this.addButton, "addButton");
            this.addButton.Name = "addButton";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // headerErrorProvider
            // 
            this.headerErrorProvider.ContainerControl = this;
            // 
            // bodyErrorProvider
            // 
            this.bodyErrorProvider.ContainerControl = this;
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
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // authorComboBox
            // 
            this.authorComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.authorComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.authorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.authorComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.authorComboBox, "authorComboBox");
            this.authorComboBox.Name = "authorComboBox";
            this.authorComboBox.Sorted = true;
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.categoryComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.categoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.categoryComboBox, "categoryComboBox");
            this.categoryComboBox.Name = "categoryComboBox";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // addAuthor
            // 
            resources.ApplyResources(this.addAuthor, "addAuthor");
            this.addAuthor.Name = "addAuthor";
            this.addAuthor.UseVisualStyleBackColor = true;
            this.addAuthor.Click += new System.EventHandler(this.addAuthor_Click);
            // 
            // addCategory
            // 
            resources.ApplyResources(this.addCategory, "addCategory");
            this.addCategory.Name = "addCategory";
            this.addCategory.UseVisualStyleBackColor = true;
            this.addCategory.Click += new System.EventHandler(this.addCategory_Click);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // isbnTextBox
            // 
            resources.ApplyResources(this.isbnTextBox, "isbnTextBox");
            this.isbnTextBox.Name = "isbnTextBox";
            this.isbnTextBox.TextChanged += new System.EventHandler(this.isbnBoxOne_TextChanged);
            this.isbnTextBox.MouseHover += new System.EventHandler(this.isbnTextBox_MouseHover);
            // 
            // ISBNToolTip
            // 
            this.ISBNToolTip.AutoPopDelay = 3000;
            this.ISBNToolTip.InitialDelay = 200;
            this.ISBNToolTip.IsBalloon = true;
            this.ISBNToolTip.ReshowDelay = 100;
            this.ISBNToolTip.ShowAlways = true;
            // 
            // ISBNErrorProvider
            // 
            this.ISBNErrorProvider.ContainerControl = this;
            // 
            // AddElement
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Controls.Add(this.isbnTextBox);
            this.Controls.Add(this.addCategory);
            this.Controls.Add(this.addAuthor);
            this.Controls.Add(this.categoryComboBox);
            this.Controls.Add(this.authorComboBox);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.editionTextBox);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addElementLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddElement";
            ((System.ComponentModel.ISupportInitialize)(this.headerErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bodyErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ISBNErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label addElementLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.TextBox editionTextBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.ErrorProvider headerErrorProvider;
        private System.Windows.Forms.ErrorProvider bodyErrorProvider;
        private System.Windows.Forms.ToolTip headerToolTip;
        private System.Windows.Forms.ToolTip bodyToolTip;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox authorComboBox;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button addCategory;
        private System.Windows.Forms.Button addAuthor;
        private System.Windows.Forms.TextBox isbnTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolTip ISBNToolTip;
        private System.Windows.Forms.ErrorProvider ISBNErrorProvider;
    }
}