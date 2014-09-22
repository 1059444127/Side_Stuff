namespace SimpleCalculatorVS2010
{
    partial class SimpleCalculator
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
            this.ArithmeticOperator = new System.Windows.Forms.TextBox();
            this.ClearButton = new System.Windows.Forms.Button();
            this.ResultBox = new System.Windows.Forms.TextBox();
            this.PlusButton = new System.Windows.Forms.Button();
            this.MinusButton = new System.Windows.Forms.Button();
            this.DivisionButton = new System.Windows.Forms.Button();
            this.MultiplicationButton = new System.Windows.Forms.Button();
            this.EqualsButton = new System.Windows.Forms.Button();
            this.ThreeButton = new System.Windows.Forms.Button();
            this.SixButton = new System.Windows.Forms.Button();
            this.NineButton = new System.Windows.Forms.Button();
            this.DotButton = new System.Windows.Forms.Button();
            this.TwoButton = new System.Windows.Forms.Button();
            this.FiveButton = new System.Windows.Forms.Button();
            this.EightButton = new System.Windows.Forms.Button();
            this.ZeroButton = new System.Windows.Forms.Button();
            this.OneButton = new System.Windows.Forms.Button();
            this.FourButton = new System.Windows.Forms.Button();
            this.SevenButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ArithmeticOperator
            // 
            this.ArithmeticOperator.Enabled = false;
            this.ArithmeticOperator.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ArithmeticOperator.Location = new System.Drawing.Point(3, 23);
            this.ArithmeticOperator.Name = "ArithmeticOperator";
            this.ArithmeticOperator.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ArithmeticOperator.Size = new System.Drawing.Size(36, 22);
            this.ArithmeticOperator.TabIndex = 37;
            this.ArithmeticOperator.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(126, 65);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(96, 23);
            this.ClearButton.TabIndex = 36;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // ResultBox
            // 
            this.ResultBox.Enabled = false;
            this.ResultBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResultBox.Location = new System.Drawing.Point(61, 23);
            this.ResultBox.Name = "ResultBox";
            this.ResultBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ResultBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ResultBox.Size = new System.Drawing.Size(161, 22);
            this.ResultBox.TabIndex = 35;
            this.ResultBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PlusButton
            // 
            this.PlusButton.Location = new System.Drawing.Point(186, 258);
            this.PlusButton.Name = "PlusButton";
            this.PlusButton.Size = new System.Drawing.Size(34, 26);
            this.PlusButton.TabIndex = 34;
            this.PlusButton.Text = "+";
            this.PlusButton.UseVisualStyleBackColor = true;
            this.PlusButton.Click += new System.EventHandler(this.PlusButton_Click);
            // 
            // MinusButton
            // 
            this.MinusButton.Location = new System.Drawing.Point(186, 202);
            this.MinusButton.Name = "MinusButton";
            this.MinusButton.Size = new System.Drawing.Size(34, 26);
            this.MinusButton.TabIndex = 33;
            this.MinusButton.Text = "-";
            this.MinusButton.UseVisualStyleBackColor = true;
            this.MinusButton.Click += new System.EventHandler(this.MinusButton_Click);
            // 
            // DivisionButton
            // 
            this.DivisionButton.Location = new System.Drawing.Point(186, 148);
            this.DivisionButton.Name = "DivisionButton";
            this.DivisionButton.Size = new System.Drawing.Size(34, 26);
            this.DivisionButton.TabIndex = 32;
            this.DivisionButton.Text = "/";
            this.DivisionButton.UseVisualStyleBackColor = true;
            this.DivisionButton.Click += new System.EventHandler(this.DivisionButton_Click);
            // 
            // MultiplicationButton
            // 
            this.MultiplicationButton.Location = new System.Drawing.Point(186, 94);
            this.MultiplicationButton.Name = "MultiplicationButton";
            this.MultiplicationButton.Size = new System.Drawing.Size(34, 26);
            this.MultiplicationButton.TabIndex = 31;
            this.MultiplicationButton.Text = "*";
            this.MultiplicationButton.UseVisualStyleBackColor = true;
            this.MultiplicationButton.Click += new System.EventHandler(this.MultiplicationButton_Click);
            // 
            // EqualsButton
            // 
            this.EqualsButton.Location = new System.Drawing.Point(126, 258);
            this.EqualsButton.Name = "EqualsButton";
            this.EqualsButton.Size = new System.Drawing.Size(34, 26);
            this.EqualsButton.TabIndex = 30;
            this.EqualsButton.Text = "=";
            this.EqualsButton.UseVisualStyleBackColor = true;
            this.EqualsButton.Click += new System.EventHandler(this.EqualsButton_Click);
            // 
            // ThreeButton
            // 
            this.ThreeButton.Location = new System.Drawing.Point(126, 202);
            this.ThreeButton.Name = "ThreeButton";
            this.ThreeButton.Size = new System.Drawing.Size(34, 26);
            this.ThreeButton.TabIndex = 29;
            this.ThreeButton.Text = "3";
            this.ThreeButton.UseVisualStyleBackColor = true;
            this.ThreeButton.Click += new System.EventHandler(this.ThreeButton_Click);
            // 
            // SixButton
            // 
            this.SixButton.Location = new System.Drawing.Point(126, 148);
            this.SixButton.Name = "SixButton";
            this.SixButton.Size = new System.Drawing.Size(34, 26);
            this.SixButton.TabIndex = 28;
            this.SixButton.Text = "6";
            this.SixButton.UseVisualStyleBackColor = true;
            this.SixButton.Click += new System.EventHandler(this.SixButton_Click);
            // 
            // NineButton
            // 
            this.NineButton.Location = new System.Drawing.Point(126, 94);
            this.NineButton.Name = "NineButton";
            this.NineButton.Size = new System.Drawing.Size(34, 26);
            this.NineButton.TabIndex = 27;
            this.NineButton.Text = "9";
            this.NineButton.UseVisualStyleBackColor = true;
            this.NineButton.Click += new System.EventHandler(this.NineButton_Click);
            // 
            // DotButton
            // 
            this.DotButton.Location = new System.Drawing.Point(61, 258);
            this.DotButton.Name = "DotButton";
            this.DotButton.Size = new System.Drawing.Size(34, 26);
            this.DotButton.TabIndex = 26;
            this.DotButton.Text = ".";
            this.DotButton.UseVisualStyleBackColor = true;
            this.DotButton.Click += new System.EventHandler(this.DotButton_Click);
            // 
            // TwoButton
            // 
            this.TwoButton.Location = new System.Drawing.Point(61, 202);
            this.TwoButton.Name = "TwoButton";
            this.TwoButton.Size = new System.Drawing.Size(34, 26);
            this.TwoButton.TabIndex = 25;
            this.TwoButton.Text = "2";
            this.TwoButton.UseVisualStyleBackColor = true;
            this.TwoButton.Click += new System.EventHandler(this.TwoButton_Click);
            // 
            // FiveButton
            // 
            this.FiveButton.Location = new System.Drawing.Point(61, 148);
            this.FiveButton.Name = "FiveButton";
            this.FiveButton.Size = new System.Drawing.Size(34, 26);
            this.FiveButton.TabIndex = 24;
            this.FiveButton.Text = "5";
            this.FiveButton.UseVisualStyleBackColor = true;
            this.FiveButton.Click += new System.EventHandler(this.FiveButton_Click);
            // 
            // EightButton
            // 
            this.EightButton.Location = new System.Drawing.Point(61, 94);
            this.EightButton.Name = "EightButton";
            this.EightButton.Size = new System.Drawing.Size(34, 26);
            this.EightButton.TabIndex = 23;
            this.EightButton.Text = "8";
            this.EightButton.UseVisualStyleBackColor = true;
            this.EightButton.Click += new System.EventHandler(this.EightButton_Click);
            // 
            // ZeroButton
            // 
            this.ZeroButton.Location = new System.Drawing.Point(3, 258);
            this.ZeroButton.Name = "ZeroButton";
            this.ZeroButton.Size = new System.Drawing.Size(34, 26);
            this.ZeroButton.TabIndex = 22;
            this.ZeroButton.Text = "0";
            this.ZeroButton.UseVisualStyleBackColor = true;
            this.ZeroButton.Click += new System.EventHandler(this.ZeroButton_Click);
            // 
            // OneButton
            // 
            this.OneButton.Location = new System.Drawing.Point(3, 202);
            this.OneButton.Name = "OneButton";
            this.OneButton.Size = new System.Drawing.Size(34, 26);
            this.OneButton.TabIndex = 21;
            this.OneButton.Text = "1";
            this.OneButton.UseVisualStyleBackColor = true;
            this.OneButton.Click += new System.EventHandler(this.OneButton_Click);
            // 
            // FourButton
            // 
            this.FourButton.Location = new System.Drawing.Point(3, 148);
            this.FourButton.Name = "FourButton";
            this.FourButton.Size = new System.Drawing.Size(34, 26);
            this.FourButton.TabIndex = 20;
            this.FourButton.Text = "4";
            this.FourButton.UseVisualStyleBackColor = true;
            this.FourButton.Click += new System.EventHandler(this.FourButton_Click);
            // 
            // SevenButton
            // 
            this.SevenButton.Location = new System.Drawing.Point(3, 94);
            this.SevenButton.Name = "SevenButton";
            this.SevenButton.Size = new System.Drawing.Size(34, 26);
            this.SevenButton.TabIndex = 19;
            this.SevenButton.Text = "7";
            this.SevenButton.UseVisualStyleBackColor = true;
            this.SevenButton.Click += new System.EventHandler(this.SevenButton_Click);
            // 
            // SimpleCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 294);
            this.Controls.Add(this.ArithmeticOperator);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.ResultBox);
            this.Controls.Add(this.PlusButton);
            this.Controls.Add(this.MinusButton);
            this.Controls.Add(this.DivisionButton);
            this.Controls.Add(this.MultiplicationButton);
            this.Controls.Add(this.EqualsButton);
            this.Controls.Add(this.ThreeButton);
            this.Controls.Add(this.SixButton);
            this.Controls.Add(this.NineButton);
            this.Controls.Add(this.DotButton);
            this.Controls.Add(this.TwoButton);
            this.Controls.Add(this.FiveButton);
            this.Controls.Add(this.EightButton);
            this.Controls.Add(this.ZeroButton);
            this.Controls.Add(this.OneButton);
            this.Controls.Add(this.FourButton);
            this.Controls.Add(this.SevenButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SimpleCalculator";
            this.Text = "Calculator";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SimpleCalculator_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ArithmeticOperator;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.TextBox ResultBox;
        private System.Windows.Forms.Button PlusButton;
        private System.Windows.Forms.Button MinusButton;
        private System.Windows.Forms.Button DivisionButton;
        private System.Windows.Forms.Button MultiplicationButton;
        private System.Windows.Forms.Button EqualsButton;
        private System.Windows.Forms.Button ThreeButton;
        private System.Windows.Forms.Button SixButton;
        private System.Windows.Forms.Button NineButton;
        private System.Windows.Forms.Button DotButton;
        private System.Windows.Forms.Button TwoButton;
        private System.Windows.Forms.Button FiveButton;
        private System.Windows.Forms.Button EightButton;
        private System.Windows.Forms.Button ZeroButton;
        private System.Windows.Forms.Button OneButton;
        private System.Windows.Forms.Button FourButton;
        private System.Windows.Forms.Button SevenButton;

    }
}

