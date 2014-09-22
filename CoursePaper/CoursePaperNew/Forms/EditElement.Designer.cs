namespace CoursePaperNew
{
    partial class EditElement
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.editBookTitleBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.editBookEditionBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.editFormEditButton = new System.Windows.Forms.Button();
            this.headerBoxToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.bodyBoxToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.authorComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.isbnBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(92, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Edit book";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Book Title";
            // 
            // editBookTitleBox
            // 
            this.editBookTitleBox.Location = new System.Drawing.Point(86, 58);
            this.editBookTitleBox.Name = "editBookTitleBox";
            this.editBookTitleBox.Size = new System.Drawing.Size(100, 20);
            this.editBookTitleBox.TabIndex = 2;
            this.editBookTitleBox.MouseHover += new System.EventHandler(this.editElementHeaderBox_MouseHover);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Edition";
            // 
            // editBookEditionBox
            // 
            this.editBookEditionBox.Location = new System.Drawing.Point(86, 98);
            this.editBookEditionBox.Name = "editBookEditionBox";
            this.editBookEditionBox.Size = new System.Drawing.Size(100, 20);
            this.editBookEditionBox.TabIndex = 2;
            this.editBookEditionBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.editBookEditionBox_KeyPress);
            this.editBookEditionBox.MouseHover += new System.EventHandler(this.editElementBodyBox_MouseHover);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Author";
            // 
            // editFormEditButton
            // 
            this.editFormEditButton.Location = new System.Drawing.Point(96, 226);
            this.editFormEditButton.Name = "editFormEditButton";
            this.editFormEditButton.Size = new System.Drawing.Size(75, 23);
            this.editFormEditButton.TabIndex = 5;
            this.editFormEditButton.Text = "Edit";
            this.editFormEditButton.UseVisualStyleBackColor = true;
            this.editFormEditButton.Click += new System.EventHandler(this.editFormEditButton_Click);
            // 
            // headerBoxToolTip
            // 
            this.headerBoxToolTip.AutoPopDelay = 5000;
            this.headerBoxToolTip.InitialDelay = 200;
            this.headerBoxToolTip.ReshowDelay = 100;
            // 
            // bodyBoxToolTip
            // 
            this.bodyBoxToolTip.AutoPopDelay = 5000;
            this.bodyBoxToolTip.InitialDelay = 200;
            this.bodyBoxToolTip.ReshowDelay = 100;
            // 
            // authorComboBox
            // 
            this.authorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.authorComboBox.FormattingEnabled = true;
            this.authorComboBox.Location = new System.Drawing.Point(86, 130);
            this.authorComboBox.Name = "authorComboBox";
            this.authorComboBox.Size = new System.Drawing.Size(121, 21);
            this.authorComboBox.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Category";
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(86, 167);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(121, 21);
            this.categoryComboBox.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 202);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "ISBN";
            // 
            // isbnBox
            // 
            this.isbnBox.Location = new System.Drawing.Point(86, 199);
            this.isbnBox.Name = "isbnBox";
            this.isbnBox.Size = new System.Drawing.Size(100, 20);
            this.isbnBox.TabIndex = 8;
            // 
            // EditElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.isbnBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.categoryComboBox);
            this.Controls.Add(this.authorComboBox);
            this.Controls.Add(this.editFormEditButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.editBookEditionBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.editBookTitleBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditElement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Book";
            this.Load += new System.EventHandler(this.EditElement_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox editBookTitleBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox editBookEditionBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button editFormEditButton;
        private System.Windows.Forms.ToolTip headerBoxToolTip;
        private System.Windows.Forms.ToolTip bodyBoxToolTip;
        private System.Windows.Forms.ComboBox authorComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox isbnBox;
    }
}