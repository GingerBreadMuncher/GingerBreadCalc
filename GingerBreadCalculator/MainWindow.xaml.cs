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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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


        private void DragBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void CloseApp_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MaximizeApp_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow.WindowState != WindowState.Maximized)
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            else
                Application.Current.MainWindow.WindowState = WindowState.Normal;
        }

        private void MinimizeApp_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void Clear()
        {
            output = "";
            temp = 0;
            OutputTextBlock.Text = output;
            operationOutput = "";
            OperationTextBlock.Text = operationOutput;
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            string name = ((Button)sender).Name;

            string value = ((Button)sender).Content.ToString();

            void Btn()
            {
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
            }

            Btn();

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
            double outputTemp;

            void OperationBtn()
            {
                operationOutput = temp + " " + lastOperation + " " + output;
                OperationTextBlock.Text = operationOutput;
                output = outputTemp.ToString();
                OutputTextBlock.Text = output;
            }

            switch (operation)
            {
                case "PlusBtn":
                    outputTemp = temp + double.Parse(output);
                    OperationBtn();
                    break;

                case "MinusBtn":
                    outputTemp = temp - double.Parse(output);
                    OperationBtn();
                    break;

                case "MultiplyBtn":
                    outputTemp = temp * double.Parse(output);
                    OperationBtn();
                    break;

                case "DivideBtn":
                    outputTemp = temp / double.Parse(output);
                    OperationBtn();
                    break;
            }
            resultGiven = true;
        }
    }
}
