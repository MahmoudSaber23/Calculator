using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        double FirstNumber = 0;
        double SecondNumber = 0;
        string OperationType = "";
        string CurrentNumber = "";


        private void btnNumber_Click(Object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            CurrentNumber += btn.Text;
            txtDisplay.Text += btn.Text;
        }

        private void btnOpeartionType_Click(Object sender, EventArgs e)
        {
            if (CurrentNumber == "")
            {
                return;
            }

            Button btn = (Button)sender;

            FirstNumber = Convert.ToDouble(CurrentNumber);

            OperationType = btn.Text;
            CurrentNumber = "";

            txtDisplay.Text = FirstNumber + " " + OperationType + " ";
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (CurrentNumber == "" || OperationType == "")
            {
                return;
            }

            SecondNumber = Convert.ToDouble(CurrentNumber);

            double result = 0;

            switch (OperationType)
            {
                case "+":

                    result = FirstNumber + SecondNumber;
                    break;

                case "-":

                    result = FirstNumber - SecondNumber;
                    break;

                case "x":

                    result = FirstNumber * SecondNumber;
                    break;

                case "÷":

                    if (SecondNumber == 0)
                    {
                        MessageBox.Show("Cannot Divide By Zero!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtDisplay.Clear();
                        return;
                    }

                    result = FirstNumber / SecondNumber;
                    break;
            }

            txtDisplay.Text += " = " + result;
            CurrentNumber = result.ToString();

            OperationType = "";
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txtDisplay.Clear();

            FirstNumber = 0;
            SecondNumber = 0;
            OperationType = "";
            CurrentNumber = "";
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            CurrentNumber = "";

            if (OperationType != "")
            {
                txtDisplay.Text = FirstNumber + " " + OperationType + " ";
            }
            else
            {
                txtDisplay.Clear();
            }
        }

        private void btndecimal_Click(object sender, EventArgs e)
        {
            if (!CurrentNumber.Contains("."))
            {
                if (CurrentNumber == "")
                {
                    CurrentNumber = "0.";
                    txtDisplay.Text += "0.";
                }
                else
                {
                    CurrentNumber += ".";
                    txtDisplay.Text += ".";
                }
            }
        }
    }
}
