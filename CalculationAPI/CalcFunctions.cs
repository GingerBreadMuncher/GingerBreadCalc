
using System.Runtime.InteropServices;

namespace CalculationAPI
{
    public static class CalcFunctions
    {
        public static string operationOutput { get; private set; } = "";
        public static string output { get; private set; } = "";
        public static string operation { get; private set; } = "";
        public static string lastOperation { get; private set; } = "";
        public static double temp { get; private set; } = 0;
        public static bool resultGiven { get; private set; } = false;
        public static double outputTemp { get; private set; } = 0;
        public static bool consoleOutput = false;

        public static void SelectNumber(string _name, string _value, IWindowInterface _windowInterface)
        {
            if (_name == "ClearBtn") { Clear(_windowInterface); return; }
            if (resultGiven == false) { output += _value; }
            else
            {
                Clear(_windowInterface);
                output = _value.ToString();
                resultGiven = false;
            }
            if (consoleOutput == false) { _windowInterface.Output(output); }

            if (output == "0") resultGiven = true;
        }

        public static void MathOperation(string _name, string _value, IWindowInterface _windowInterface)
        {
            lastOperation = _value;

            if (output != "" && consoleOutput == false)
            {
                temp = double.Parse(output);
                output = "";
                operation = _name;
                if (resultGiven == true) { operationOutput = $"{outputTemp} {_value}"; temp = outputTemp; } 
                else { operationOutput = $"{temp} {_value}"; }
                _windowInterface.OperationOutput(operationOutput);
                resultGiven = false;
            }
            else if (output != "" & consoleOutput == true)
            {
                temp = double.Parse(output);
                output = "";
                operation = _name;
                resultGiven = false;
            }
        }

        public static void DoOperation(IWindowInterface _windowInterface)
        {
            if (consoleOutput == false)
            {
                operationOutput = $"{temp} {lastOperation} {output}";
                _windowInterface.OperationOutput(operationOutput);
                _windowInterface.Output(outputTemp.ToString());
            }
            else
                _windowInterface.Output(outputTemp.ToString());
        }

        public static void GetResult(IWindowInterface _windowInterface)
        {
            switch (operation)
            {
                case "PlusBtn":
                    Add(temp, double.Parse(output));
                    DoOperation(_windowInterface);
                    break;

                case "MinusBtn":
                    Subtract(temp, double.Parse(output));
                    DoOperation(_windowInterface);
                    break;

                case "MultiplyBtn":
                    Multiply(temp, double.Parse(output));
                    DoOperation(_windowInterface);
                    break;

                case "DivideBtn":
                    Divide(temp, double.Parse(output));
                    DoOperation(_windowInterface);
                    break;
            }
            resultGiven = true;
        }

        public static double Add(double a, double b) { return outputTemp = a + b; }

        public static double Subtract(double a, double b) { return outputTemp = a - b; }

        public static double Multiply(double a, double b) { return outputTemp = a * b; }

        public static double Divide(double a, double b) { return outputTemp = a / b; }

        public static void Clear(IWindowInterface _windowInterface)
        {
            output = "";
            temp = 0;
            outputTemp = 0;
            _windowInterface.Output(output);
            operationOutput = "";
            _windowInterface.OperationOutput(operationOutput);
        }
    }
}