using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace GingerBreadCalculator
{
    public partial class CalcFunctions
    {
        string operationOutput = "";
        string output = "";
        string operation = "";
        string lastOperation = "";
        double temp = 0;
        bool resultGiven = false;

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            string name = ((Button)sender).Name;

            string value = ((Button)sender).Content.ToString();


            if (resultGiven == false)
            {
                output += value;
                OutputTextBlock.Text = output;
            }
            else
            {
                Clear();
                output = value.ToString();
                OutputTextBlock.Text = output;
                resultGiven = false;
            }

            if (name == "ClearBtn")
            {
                Clear();
            }

            if (output == "0")
            {
                resultGiven = true;
            }
        }

        private void MathOperation(object sender, RoutedEventArgs e)
        {
            string name = ((Button)sender).Name;

            string value = ((Button)sender).Content.ToString();

            void MathOp()
            {
                operationOutput = temp + " " + value + " ";
                OperationTextBlock.Text = operationOutput;
            }

            lastOperation = value;

            if (output != "")
            {
                temp = double.Parse(output);
                output = "";
                operation = name;
                MathOp();
                resultGiven = false;
            }
        }

        void OperationBtn(double _outputTemp)
        {
            operationOutput = temp + " " + lastOperation + " " + output;
            OperationTextBlock.Text = operationOutput;
            output = _outputTemp.ToString();
            OutputTextBlock.Text = output;
        }
    }
}
