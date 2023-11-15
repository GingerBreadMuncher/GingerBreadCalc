using CalculationAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GingerBreadCalculator_Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            ConsoleEngine engine = new ConsoleEngine();
            while (true)
            {
                engine.Action();
            }
        }

        public class ConsoleEngine : IWindowInterface
        {
            public void Action()
            {
                CalcFunctions.consoleOutput = true;
                Console.WriteLine("Enter first number:");
                double i = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter operation sign:");
                string sign = Console.ReadLine();
                Console.WriteLine("Enter second number:");
                double j = double.Parse(Console.ReadLine());

                CalcFunctions.SelectNumber("", i.ToString(), this);
                CalcFunctions.MathOperation(GetBtnName(sign), sign, this);
                CalcFunctions.SelectNumber("", j.ToString(), this);
                Console.WriteLine("And the result is:");
                CalcFunctions.GetResult(this);
                Console.WriteLine("\n");
            }

            public string GetBtnName(string s)
            {
                if (s == "+") return "PlusBtn";
                if (s == "-") return "MinusBtn";
                if (s == "*") return "MultiplyBtn";
                if (s == "/") return "DivideBtn";
                return "";
            }

            public void OperationOutput(string _text) => Output(_text);

            public void Output(string _text) => Console.Write(_text);
        }
    }
}
