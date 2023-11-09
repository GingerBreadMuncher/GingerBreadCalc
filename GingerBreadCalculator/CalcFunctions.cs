using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace GingerBreadCalculator
{
    public static class CalcFunctions
    {
        public static string operationOutput = "";
        public static string output = "";
        public static string operation = "";
        public static string lastOperation = "";
        public static double temp = 0;
        public static bool resultGiven = false;

        public static void SelectNumber(string _name, string _value, IWindowInterface _windowInterface)
        {
            string name = _name;
            
            string value = _value;


            if (resultGiven == false)
            {
                output += value;
            }
            else
            {
                Clear(_windowInterface);
                output = value.ToString();
                resultGiven = false;
            }
            _windowInterface.Output(output);

            if (name == "ClearBtn")
            {
                Clear(_windowInterface);
            }

            if (output == "0")
            {
                resultGiven = true;
            }
        }

        public static void MathOperation(string _name, string _value, IWindowInterface _windowInterface)
        {
            string name = _name;

            string value = _value;


            lastOperation = value;

            if (output != "")
            {
                temp = double.Parse(output);
                output = "";
                operation = name;
                operationOutput = temp + " " + value + " ";
                _windowInterface.OperationOutput(operationOutput);
                resultGiven = false;
            }
        }

        public static void DoOperation(double _outputTemp, IWindowInterface _windowInterface)
        {
            operationOutput = temp + " " + lastOperation + " " + output;
            _windowInterface.OperationOutput(operationOutput);
            output = _outputTemp.ToString();
            _windowInterface.Output(output);
        }

        public static void GetResult(IWindowInterface _windowInterface)
        {
            switch (operation)
            {
                case "PlusBtn":
                    DoOperation((temp + double.Parse(output)), _windowInterface);
                    break;

                case "MinusBtn":
                    DoOperation((temp - double.Parse(output)), _windowInterface);
                    break;

                case "MultiplyBtn":
                    DoOperation((temp * double.Parse(output)), _windowInterface);
                    break;

                case "DivideBtn":
                    DoOperation((temp / double.Parse(output)), _windowInterface);
                    break;
            }
            resultGiven = true;
        }

        public static void Clear(IWindowInterface _windowInterface)
        {
            output = "";
            temp = 0;
            _windowInterface.Output(output);
            operationOutput = "";
            _windowInterface.OperationOutput(operationOutput);
        }
    }
}
