using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GingerBreadCalculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string operationOutput = "";
        string output = "";
        string operation = "";
        string lastOperation = "";
        double temp = 0;
        bool resultGiven = false;

        private void Clear()
        {
            output = "";
            temp = 0;
            OutputTextBlock.Text = output;
            operationOutput = "";
            OperationTextBlock.Text = operationOutput;
        }

        #region Button Events
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

            lastOperation = value;

            void MathOp()
            {
                operationOutput = temp + " " + value + " ";
                OperationTextBlock.Text = operationOutput;
            }

            if (output != "")
            {
                temp = double.Parse(output);
                output = "";
                operation = name;
                MathOp();
                resultGiven = false;
            }
        }

        private void EqualsBtn_Click(object sender, RoutedEventArgs e)
        {
            switch (operation)
            {
                case "PlusBtn":
                    OperationBtn(temp + double.Parse(output));
                    break;

                case "MinusBtn":
                    OperationBtn(temp - double.Parse(output));
                    break;

                case "MultiplyBtn":
                    OperationBtn(temp * double.Parse(output));
                    break;

                case "DivideBtn":
                    OperationBtn(temp / double.Parse(output));
                    break;
            }
            resultGiven = true;
        }
        private void DragBorder_MouseDown(object sender, MouseButtonEventArgs e) { if (e.LeftButton == MouseButtonState.Pressed) DragMove(); }

        private void CloseApp_Click(object sender, RoutedEventArgs e) => Application.Current.Shutdown();

        private void MaximizeApp_Click(object sender, RoutedEventArgs e) =>
            Application.Current.MainWindow.WindowState = Application.Current.MainWindow.WindowState != WindowState.Maximized ? WindowState.Maximized : WindowState.Normal;

        private void MinimizeApp_Click(object sender, RoutedEventArgs e) => Application.Current.MainWindow.WindowState = WindowState.Minimized;

        #endregion

        void OperationBtn(double _outputTemp)
        {
            operationOutput = temp + " " + lastOperation + " " + output;
            OperationTextBlock.Text = operationOutput;
            output = _outputTemp.ToString();
            OutputTextBlock.Text = output;
        }
    }
}