using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimpleCalculatorVS2010
{
    public partial class SimpleCalculator : Form
    {
        private List<char> permittedCharacters = new List<char>() { '/', '+', '-', '*', '.', '=' };

        private string currentOperator = String.Empty;
        private double firstNumber = 0;
        private double secondNumber = 0;

        // Holds the state of the calculator, either a calculation has started and switch between the first number and the second number
        // or a calculation hasn't started and fill the first number
        private bool calculationInProgress = false;
        // Holds whether a result of an arithmetic operation is displayed in the ResultBox.
        // If it is, at the start of typing a new number, clear the ResultBox to avoid collision
        private bool nextNumber = false;

        private void CalculateExpression()
        {
            switch (currentOperator)
            {
                case "+":
                    firstNumber += secondNumber;
                    break;
                case "-":
                    firstNumber -= secondNumber;
                    break;
                case "/":
                    firstNumber /= secondNumber;
                    break;
                case "*":
                    firstNumber *= secondNumber;
                    break;
                default:
                    break;
            }
            secondNumber = 0;
        }

        public SimpleCalculator()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void SimpleCalculator_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                if (this.nextNumber)
                {
                    this.ResultBox.Text = String.Empty;
                    this.nextNumber = false;
                }
                this.ResultBox.Text += e.KeyChar;
            }
            else if (permittedCharacters.Contains(e.KeyChar))
            {
                switch (e.KeyChar)
                {
                    case '/':
                        DivisionButton_Click(sender, e);
                        break;
                    case '*':
                        MultiplicationButton_Click(sender, e);
                        break;
                    case '+':
                        PlusButton_Click(sender, e);
                        break;
                    case '-':
                        MinusButton_Click(sender, e);
                        break;
                    case '.':
                        DotButton_Click(sender, e);
                        break;
                    case '=':
                        EqualsButton_Click(sender, e);
                        break;
                    default:
                        break;
                }
            }
            else if ((Keys)e.KeyChar == Keys.Back) // Check for backspace and delete input accordingly
            {
                try
                {
                    this.ResultBox.Text = this.ResultBox.Text.Substring(0, this.ResultBox.Text.Length - 1);
                }
                catch (ArgumentOutOfRangeException) // Catch string empty exception
                {

                }
            }
            else if (e.KeyChar == 'C' || e.KeyChar == 'c') // Check if "c" button is pressed and clear the input
            {
                this.ClearButton_Click(sender, e);
            }
        }

        // Button Handlers

        private void ZeroButton_Click(object sender, EventArgs e)
        {
            if (this.nextNumber)
            {
                this.ResultBox.Text = String.Empty;
                this.nextNumber = false;
            }
            this.ResultBox.Text += "0";
        }

        private void OneButton_Click(object sender, EventArgs e)
        {
            if (this.nextNumber)
            {
                this.ResultBox.Text = String.Empty;
                this.nextNumber = false;
            }
            this.ResultBox.Text += "1";
        }

        private void TwoButton_Click(object sender, EventArgs e)
        {

            if (this.nextNumber)
            {
                this.ResultBox.Text = String.Empty;
                this.nextNumber = false;
            }
            this.ResultBox.Text += "2";
        }

        private void ThreeButton_Click(object sender, EventArgs e)
        {

            if (this.nextNumber)
            {
                this.ResultBox.Text = String.Empty;
                this.nextNumber = false;
            }
            this.ResultBox.Text += "3";
        }

        private void FourButton_Click(object sender, EventArgs e)
        {

            if (this.nextNumber)
            {
                this.ResultBox.Text = String.Empty;
                this.nextNumber = false;
            }
            this.ResultBox.Text += "4";
        }

        private void FiveButton_Click(object sender, EventArgs e)
        {

            if (this.nextNumber)
            {
                this.ResultBox.Text = String.Empty;
                this.nextNumber = false;
            }
            this.ResultBox.Text += "5";
        }

        private void SixButton_Click(object sender, EventArgs e)
        {

            if (this.nextNumber)
            {
                this.ResultBox.Text = String.Empty;
                this.nextNumber = false;
            }
            this.ResultBox.Text += "6";
        }

        private void SevenButton_Click(object sender, EventArgs e)
        {

            if (this.nextNumber)
            {
                this.ResultBox.Text = String.Empty;
                this.nextNumber = false;
            }
            this.ResultBox.Text += "7";
        }

        private void EightButton_Click(object sender, EventArgs e)
        {

            if (this.nextNumber)
            {
                this.ResultBox.Text = String.Empty;
                this.nextNumber = false;
            }
            this.ResultBox.Text += "8";
        }

        private void NineButton_Click(object sender, EventArgs e)
        {

            if (this.nextNumber)
            {
                this.ResultBox.Text = String.Empty;
                this.nextNumber = false;
            }
            this.ResultBox.Text += "9";
        }

        // The decimal dot button
        private void DotButton_Click(object sender, EventArgs e)
        {
            if (!this.ResultBox.Text.Contains('.') && this.ResultBox.Text != String.Empty)
            {
                this.ResultBox.Text += ".";
            }
        }

        // Clear button
        private void ClearButton_Click(object sender, EventArgs e)
        {
            this.ResultBox.Text = String.Empty;
            this.currentOperator = String.Empty;
            this.nextNumber = false;
            this.ArithmeticOperator.Text = String.Empty;
            this.calculationInProgress = false;
        }

        // Arithmetic operations buttons
        private void PlusButton_Click(object sender, EventArgs e)
        {
            if (this.ResultBox.Text != String.Empty)
            {
                if (calculationInProgress)
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

                if (this.currentOperator != String.Empty)
                {
                    CalculateExpression();
                    calculationInProgress = true;
                }
            }
        }

        private void MinusButton_Click(object sender, EventArgs e)
        {
            if (this.ResultBox.Text != String.Empty)
            {
                if (calculationInProgress)
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

                if (this.currentOperator != String.Empty)
                {
                    calculationInProgress = true;
                    CalculateExpression();
                }
            }
        }

        private void DivisionButton_Click(object sender, EventArgs e)
        {
            if (this.ResultBox.Text != String.Empty)
            {
                if (calculationInProgress)
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

                if (this.currentOperator != String.Empty)
                {
                    calculationInProgress = true;
                }
            }
        }

        private void MultiplicationButton_Click(object sender, EventArgs e)
        {
            if (this.ResultBox.Text != String.Empty)
            {
                if (calculationInProgress)
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

                if (this.currentOperator != String.Empty)
                {
                    calculationInProgress = true;
                }
            }
        }

        // Equals button
        private void EqualsButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.secondNumber = double.Parse(this.ResultBox.Text);
                this.CalculateExpression();
                this.ResultBox.Text = firstNumber.ToString();
                this.firstNumber = 0;
                this.secondNumber = 0;
                this.nextNumber = true;
                this.calculationInProgress = false;
                this.currentOperator = String.Empty;
                this.ArithmeticOperator.Text = "=";
            }
            catch (FormatException)
            {

            }
        }


    }
}
