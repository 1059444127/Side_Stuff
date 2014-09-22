namespace CoursePaperNew.Forms
{
    partial class SearchForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.editionTextBox = new System.Windows.Forms.TextBox();
            this.categoryTextBox = new System.Windows.Forms.TextBox();
            this.authorTextBox = new System.Windows.Forms.TextBox();
            this.editionCheckBox = new System.Windows.Forms.CheckBox();
            this.categoryCheckBox = new System.Windows.Forms.CheckBox();
            this.authorCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.isbnTextBox = new System.Windows.Forms.TextBox();
            this.radioButtonFilter = new System.Windows.Forms.RadioButton();
            this.radioButtonTitle = new System.Windows.Forms.RadioButton();
            this.radioButtonISBN = new System.Windows.Forms.RadioButton();
            this.generalView = new System.Windows.Forms.Button();
            this.masterDetail = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(148, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.masterDetail);
            this.groupBox1.Controls.Add(this.generalView);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.radioButtonFilter);
            this.groupBox1.Controls.Add(this.radioButtonTitle);
            this.groupBox1.Controls.Add(this.radioButtonISBN);
            this.groupBox1.Location = new System.Drawing.Point(2, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(351, 365);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Criteria";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.editionTextBox);
            this.groupBox4.Controls.Add(this.categoryTextBox);
            this.groupBox4.Controls.Add(this.authorTextBox);
            this.groupBox4.Controls.Add(this.editionCheckBox);
            this.groupBox4.Controls.Add(this.categoryCheckBox);
            this.groupBox4.Controls.Add(this.authorCheckBox);
            this.groupBox4.Location = new System.Drawing.Point(10, 186);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(331, 114);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            // 
            // editionTextBox
            // 
            this.editionTextBox.Location = new System.Drawing.Point(123, 83);
            this.editionTextBox.Name = "editionTextBox";
            this.editionTextBox.ReadOnly = true;
            this.editionTextBox.Size = new System.Drawing.Size(137, 20);
            this.editionTextBox.TabIndex = 7;
            this.editionTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.editionTextBox_KeyPress);
            // 
            // categoryTextBox
            // 
            this.categoryTextBox.Location = new System.Drawing.Point(123, 50);
            this.categoryTextBox.Name = "categoryTextBox";
            this.categoryTextBox.ReadOnly = true;
            this.categoryTextBox.Size = new System.Drawing.Size(137, 20);
            this.categoryTextBox.TabIndex = 7;
            // 
            // authorTextBox
            // 
            this.authorTextBox.Location = new System.Drawing.Point(123, 17);
            this.authorTextBox.Name = "authorTextBox";
            this.authorTextBox.ReadOnly = true;
            this.authorTextBox.Size = new System.Drawing.Size(137, 20);
            this.authorTextBox.TabIndex = 7;
            // 
            // editionCheckBox
            // 
            this.editionCheckBox.AutoSize = true;
            this.editionCheckBox.Enabled = false;
            this.editionCheckBox.Location = new System.Drawing.Point(6, 85);
            this.editionCheckBox.Name = "editionCheckBox";
            this.editionCheckBox.Size = new System.Drawing.Size(73, 17);
            this.editionCheckBox.TabIndex = 6;
            this.editionCheckBox.Text = "By Edition";
            this.editionCheckBox.UseVisualStyleBackColor = true;
            this.editionCheckBox.CheckedChanged += new System.EventHandler(this.editionCheckBox_CheckedChanged);
            // 
            // categoryCheckBox
            // 
            this.categoryCheckBox.AutoSize = true;
            this.categoryCheckBox.Enabled = false;
            this.categoryCheckBox.Location = new System.Drawing.Point(6, 52);
            this.categoryCheckBox.Name = "categoryCheckBox";
            this.categoryCheckBox.Size = new System.Drawing.Size(83, 17);
            this.categoryCheckBox.TabIndex = 5;
            this.categoryCheckBox.Text = "By Category";
            this.categoryCheckBox.UseVisualStyleBackColor = true;
            this.categoryCheckBox.CheckedChanged += new System.EventHandler(this.categoryCheckBox_CheckedChanged);
            // 
            // authorCheckBox
            // 
            this.authorCheckBox.AutoSize = true;
            this.authorCheckBox.Enabled = false;
            this.authorCheckBox.Location = new System.Drawing.Point(6, 19);
            this.authorCheckBox.Name = "authorCheckBox";
            this.authorCheckBox.Size = new System.Drawing.Size(72, 17);
            this.authorCheckBox.TabIndex = 4;
            this.authorCheckBox.Text = "By Author";
            this.authorCheckBox.UseVisualStyleBackColor = true;
            this.authorCheckBox.CheckedChanged += new System.EventHandler(this.authorCheckBox_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.titleTextBox);
            this.groupBox3.Location = new System.Drawing.Point(10, 112);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(331, 45);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(82, 19);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(165, 20);
            this.titleTextBox.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.isbnTextBox);
            this.groupBox2.Location = new System.Drawing.Point(10, 44);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(331, 45);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // isbnTextBox
            // 
            this.isbnTextBox.Location = new System.Drawing.Point(82, 19);
            this.isbnTextBox.Name = "isbnTextBox";
            this.isbnTextBox.Size = new System.Drawing.Size(165, 20);
            this.isbnTextBox.TabIndex = 8;
            // 
            // radioButtonFilter
            // 
            this.radioButtonFilter.AutoSize = true;
            this.radioButtonFilter.Location = new System.Drawing.Point(10, 163);
            this.radioButtonFilter.Name = "radioButtonFilter";
            this.radioButtonFilter.Size = new System.Drawing.Size(47, 17);
            this.radioButtonFilter.TabIndex = 3;
            this.radioButtonFilter.Text = "Filter";
            this.radioButtonFilter.UseVisualStyleBackColor = true;
            this.radioButtonFilter.CheckedChanged += new System.EventHandler(this.radioButtonFilter_CheckedChanged);
            // 
            // radioButtonTitle
            // 
            this.radioButtonTitle.AutoSize = true;
            this.radioButtonTitle.Location = new System.Drawing.Point(10, 95);
            this.radioButtonTitle.Name = "radioButtonTitle";
            this.radioButtonTitle.Size = new System.Drawing.Size(60, 17);
            this.radioButtonTitle.TabIndex = 2;
            this.radioButtonTitle.Text = "By Title";
            this.radioButtonTitle.UseVisualStyleBackColor = true;
            this.radioButtonTitle.CheckedChanged += new System.EventHandler(this.radioButtonTitle_CheckedChanged);
            // 
            // radioButtonISBN
            // 
            this.radioButtonISBN.AutoSize = true;
            this.radioButtonISBN.Checked = true;
            this.radioButtonISBN.Location = new System.Drawing.Point(10, 30);
            this.radioButtonISBN.Name = "radioButtonISBN";
            this.radioButtonISBN.Size = new System.Drawing.Size(65, 17);
            this.radioButtonISBN.TabIndex = 1;
            this.radioButtonISBN.TabStop = true;
            this.radioButtonISBN.Text = "By ISBN";
            this.radioButtonISBN.UseVisualStyleBackColor = true;
            this.radioButtonISBN.CheckedChanged += new System.EventHandler(this.radioButtonISBN_CheckedChanged);
            // 
            // generalView
            // 
            this.generalView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.generalView.Location = new System.Drawing.Point(61, 320);
            this.generalView.Name = "generalView";
            this.generalView.Size = new System.Drawing.Size(88, 23);
            this.generalView.TabIndex = 5;
            this.generalView.Text = "General  View";
            this.generalView.UseVisualStyleBackColor = true;
            this.generalView.Click += new System.EventHandler(this.generalView_Click);
            // 
            // masterDetail
            // 
            this.masterDetail.Location = new System.Drawing.Point(195, 320);
            this.masterDetail.Name = "masterDetail";
            this.masterDetail.Size = new System.Drawing.Size(89, 23);
            this.masterDetail.TabIndex = 5;
            this.masterDetail.Text = "Master-Detail";
            this.masterDetail.UseVisualStyleBackColor = true;
            this.masterDetail.Click += new System.EventHandler(this.masterDetail_Click);
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(355, 401);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchForm";
            this.Text = "SearchForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonISBN;
        private System.Windows.Forms.RadioButton radioButtonTitle;
        private System.Windows.Forms.RadioButton radioButtonFilter;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox isbnTextBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox authorCheckBox;
        private System.Windows.Forms.CheckBox categoryCheckBox;
        private System.Windows.Forms.CheckBox editionCheckBox;
        private System.Windows.Forms.TextBox editionTextBox;
        private System.Windows.Forms.TextBox categoryTextBox;
        private System.Windows.Forms.TextBox authorTextBox;
        private System.Windows.Forms.Button masterDetail;
        private System.Windows.Forms.Button generalView;

    }
}