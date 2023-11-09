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
    public partial class MainWindow : Window, IWindowInterface
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        #region Button Events
        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            string name = ((Button)sender).Name;

            string value = ((Button)sender).Content.ToString();

            CalcFunctions.SelectNumber(name, value, this);
        }

        private void MathOperation(object sender, RoutedEventArgs e)
        {
            string name = ((Button)sender).Name;

            string value = ((Button)sender).Content.ToString();

            CalcFunctions.MathOperation(name, value, this);
        }

        private void EqualsBtn_Click(object sender, RoutedEventArgs e)
        {
            CalcFunctions.GetResult(this);
        }
        private void DragBorder_MouseDown(object sender, MouseButtonEventArgs e) { if (e.LeftButton == MouseButtonState.Pressed) DragMove(); }

        private void CloseApp_Click(object sender, RoutedEventArgs e) => Application.Current.Shutdown();

        private void MaximizeApp_Click(object sender, RoutedEventArgs e) =>
            Application.Current.MainWindow.WindowState = Application.Current.MainWindow.WindowState != WindowState.Maximized ? WindowState.Maximized : WindowState.Normal;

        private void MinimizeApp_Click(object sender, RoutedEventArgs e) => Application.Current.MainWindow.WindowState = WindowState.Minimized;

        #endregion


        public void Output(string _text)
        {
            OutputTextBlock.Text = _text;
        }


        public void OperationOutput(string _text)
        {
            OperationTextBlock.Text = _text;
        }
    }
}