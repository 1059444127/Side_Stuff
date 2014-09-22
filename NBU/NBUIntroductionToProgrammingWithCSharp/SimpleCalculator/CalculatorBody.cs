using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class CalculatorBody : Form
    {
        private const double InitialNumber = 0;

        private const List<char> PermittedCharacters = new List<char>()
        { 
            
            '/', '+', '-', '*', '.', '='
        };

        private string currentOperator;
        private double firstNumber;
        private double secondNumber;

        private bool calculationInProgress;
        private bool nextNumber;

        public CalculatorBody()
        {
            this.InitializeComponent();
            this.KeyPreview = true;
            this.currentOperator = string.Empty;
            this.firstNumber = this.secondNumber = InitialNumber;
            this.calculationInProgress = false;
            this.nextNumber = false;
        }

        private void CalculateExpression()
        {
            switch (this.currentOperator)
            {
                case "+":
                    this.firstNumber += this.secondNumber;
                    break;
                case "-":
                    this.firstNumber -= this.secondNumber;
                    break;
                case "/":
                    this.firstNumber /= this.secondNumber;
                    break;
                case "*":
                    this.firstNumber *= this.secondNumber;
                    break;
                default:
                    break;
            }
            this.secondNumber = 0;
        }

        private void CheckIfNextNumber()
        {
            if (this.nextNumber == true)
            {
                this.ResultBox.Text = string.Empty;
                this.nextNumber = false;
            }
        }

        private void OneButton_Click(object sender, EventArgs e)
        {
            this.ResultBox.Text += "1";
        }

        private void CalculatorBody_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                if (this.nextNumber)
                {
                    this.ResultBox.Text = string.Empty;
                    this.nextNumber = false;
                }
                this.ResultBox.Text += e.KeyChar;
            }
            else if (this.PermittedCharacters.Contains(e.KeyChar))
            {
                switch (e.KeyChar)
                {
                    case '/':
                        this.DivisionButton_Click(sender, e);
                        break;
                    case '*':
                        this.MultiplicationButton_Click(sender, e);
                        break;
                    case '+':
                        this.PlusButton_Click(sender, e);
                        break;
                    case '-':
                        this.MinusButton_Click(sender, e);
                        break;
                    case '.':
                        this.DotButton_Click(sender, e);
                        break;
                    case '=':
                        this.EqualsButton_Click(sender, e);
                        break;
                    default:
                        break;
                }
            }
            // Check for backspace and delete input accordingly
            else if ((Keys)e.KeyChar == Keys.Back) 
            {
                try
                {
                    this.ResultBox.Text = this.ResultBox.Text.Substring(0, this.ResultBox.Text.Length - 1);   
                }
                // Catch string empty exception
                catch (ArgumentOutOfRangeException) 
                {
                }
            }
            // Check if "c" button is pressed and clear the input
            else if (e.KeyChar == 'C' || e.KeyChar == 'c') 
            {
                this.ClearButton_Click(sender, e);
            }
        }

        // Button handlers
        private void ZeroButton_Click(object sender, EventArgs e)
        {
            this.CheckIfNextNumber();
            this.ResultBox.Text += "0";
        }

        private void TwoButton_Click(object sender, EventArgs e)
        {
            this.CheckIfNextNumber();
            this.ResultBox.Text += "2";
        }

        private void ThreeButton_Click(object sender, EventArgs e)
        {
            this.CheckIfNextNumber();
            this.ResultBox.Text += "3";
        }

        private void FourButton_Click(object sender, EventArgs e)
        {
            this.CheckIfNextNumber();
            this.ResultBox.Text += "4";
        }

        private void FiveButton_Click(object sender, EventArgs e)
        {
            this.CheckIfNextNumber();
            this.ResultBox.Text += "5";
        }

        private void SixButton_Click(object sender, EventArgs e)
        {
            this.CheckIfNextNumber();
            this.ResultBox.Text += "6";
        }

        private void SevenButton_Click(object sender, EventArgs e)
        {
            this.CheckIfNextNumber();
            this.ResultBox.Text += "7";
        }

        private void EightButton_Click(object sender, EventArgs e)
        {
            this.CheckIfNextNumber();
            this.ResultBox.Text += "8";
        }

        private void NineButton_Click(object sender, EventArgs e)
        {
            this.CheckIfNextNumber();
            this.ResultBox.Text += "9";
        }

        private void DotButton_Click(object sender, EventArgs e)
        {
            if (!this.ResultBox.Text.Contains('.') && this.ResultBox.Text != string.Empty)
            {
                this.ResultBox.Text += ".";
            }
        }

        // Clear the TextBox
        private void ClearButton_Click(object sender, EventArgs e)
        {
            this.ResultBox.Text = string.Empty;
            this.currentOperator = string.Empty;
            this.nextNumber = false;
            this.ArithmeticOperator.Text = string.Empty;
            this.calculationInProgress = false;
        }

        private void PlusButton_Click(object sender, EventArgs e)
        {
            if (this.ResultBox.Text != string.Empty)
            {
                if (this.calculationInProgress)
                {
                    this.EqualsButton_Click(sender, e);
                    this.firstNumber = double.Parse(this.ResultBox.Text);
                }
                else
                {
                    this.firstNumber = double.Parse(this.ResultBox.Text);
                }

                this.ArithmeticOperator.Text = "+";
                this.nextNumber = true;
                this.currentOperator = "+";

                if (this.currentOperator != string.Empty)
                {
                    this.calculationInProgress = true;
                }
            }
        }

        private void MinusButton_Click(object sender, EventArgs e)
        {
            if (this.ResultBox.Text != string.Empty)
            {
                if (this.calculationInProgress)
                {
                    this.EqualsButton_Click(sender, e);
                    this.firstNumber = double.Parse(this.ResultBox.Text);
                }
                else
                {
                    this.firstNumber = double.Parse(this.ResultBox.Text);
                }

                this.ArithmeticOperator.Text = "-";
                this.nextNumber = true;
                this.currentOperator = "-";

                if (this.currentOperator != string.Empty)
                {
                    this.calculationInProgress = true;
                }
            }
        }

        private void MultiplicationButton_Click(object sender, EventArgs e)
        {
            if (this.ResultBox.Text != string.Empty)
            {
                if (this.calculationInProgress)
                {
                    this.EqualsButton_Click(sender, e);
                    this.firstNumber = double.Parse(this.ResultBox.Text);
                }
                else
                {
                    this.firstNumber = double.Parse(this.ResultBox.Text);
                }

                this.ArithmeticOperator.Text = "*";
                this.nextNumber = true;
                this.currentOperator = "*";

                if (this.currentOperator != string.Empty)
                {
                    this.calculationInProgress = true;
                }
            }
        }

        private void DivisionButton_Click(object sender, EventArgs e)
        {
            if (this.ResultBox.Text != string.Empty)
            {
                if (this.calculationInProgress)
                {
                    this.EqualsButton_Click(sender, e);
                    this.firstNumber = double.Parse(this.ResultBox.Text);
                }
                else
                {
                    this.firstNumber = double.Parse(this.ResultBox.Text);
                }

                this.ArithmeticOperator.Text = "/";
                this.nextNumber = true;
                this.currentOperator = "/";

                if (this.currentOperator != string.Empty)
                {
                    this.calculationInProgress = true;
                }
            }
        }

        private void EqualsButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.secondNumber = double.Parse(this.ResultBox.Text);
                this.CalculateExpression();
                this.ResultBox.Text = this.firstNumber.ToString();
                this.firstNumber = 0;
                this.secondNumber = 0;
                this.calculationInProgress = false;
                this.currentOperator = string.Empty;
                this.ArithmeticOperator.Text = "=";
            }
            catch (FormatException)
            {
            }
        }
    }
}