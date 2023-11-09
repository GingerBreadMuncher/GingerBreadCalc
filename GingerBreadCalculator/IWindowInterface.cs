using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GingerBreadCalculator
{
    public interface IWindowInterface
    {
        void Output(string _text);

        void OperationOutput(string _text);
    }
}
