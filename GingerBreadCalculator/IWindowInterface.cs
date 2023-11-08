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

        void Clear();

        void OperationOutput(string _text);
    }
}
