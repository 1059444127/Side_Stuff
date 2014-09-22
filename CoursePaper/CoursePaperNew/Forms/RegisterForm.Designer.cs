namespace CoursePaperNew
{
    partial class RegisterForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.registerCancelButton = new System.Windows.Forms.Button();
            this.registerOKButton = new System.Windows.Forms.Button();
            this.usernameRegisterBox = new System.Windows.Forms.TextBox();
            this.passwordRegisterBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.registerCancelButton);
            this.groupBox1.Controls.Add(this.registerOKButton);
            this.groupBox1.Controls.Add(this.usernameRegisterBox);
            this.groupBox1.Controls.Add(this.passwordRegisterBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(0, -2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 264);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // registerCancelButton
            // 
            this.registerCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.registerCancelButton.Location = new System.Drawing.Point(142, 173);
            this.registerCancelButton.Name = "registerCancelButton";
            this.registerCancelButton.Size = new System.Drawing.Size(51, 23);
            this.registerCancelButton.TabIndex = 3;
            this.registerCancelButton.Text = "Cancel";
            this.registerCancelButton.UseVisualStyleBackColor = true;
            this.registerCancelButton.Click += new System.EventHandler(this.registerCancelButton_Click);
            // 
            // registerOKButton
            // 
            this.registerOKButton.Location = new System.Drawing.Point(83, 173);
            this.registerOKButton.Name = "registerOKButton";
            this.registerOKButton.Size = new System.Drawing.Size(53, 23);
            this.registerOKButton.TabIndex = 2;
            this.registerOKButton.Text = "OK";
            this.registerOKButton.UseVisualStyleBackColor = true;
            this.registerOKButton.Click += new System.EventHandler(this.registerOKButton_Click);
            // 
            // usernameRegisterBox
            // 
            this.usernameRegisterBox.AccessibleName = "";
            this.usernameRegisterBox.Location = new System.Drawing.Point(83, 71);
            this.usernameRegisterBox.Name = "usernameRegisterBox";
            this.usernameRegisterBox.Size = new System.Drawing.Size(110, 20);
            this.usernameRegisterBox.TabIndex = 1;
            this.usernameRegisterBox.Text = "Username";
            // 
            // passwordRegisterBox
            // 
            this.passwordRegisterBox.Location = new System.Drawing.Point(83, 130);
            this.passwordRegisterBox.Name = "passwordRegisterBox";
            this.passwordRegisterBox.Size = new System.Drawing.Size(110, 20);
            this.passwordRegisterBox.TabIndex = 1;
            this.passwordRegisterBox.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AccessibleName = "usernameLoginBox";
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(108, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Username";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(108, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Password";
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.registerCancelButton;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.groupBox1);
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegisterForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox usernameRegisterBox;
        private System.Windows.Forms.TextBox passwordRegisterBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button registerOKButton;
        private System.Windows.Forms.Button registerCancelButton;
    }
}