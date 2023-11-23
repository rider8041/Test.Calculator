using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Calculator.Contracts
{
    public interface IOperation
    {
        string Name { get; }
        string ShortName { get; }
        string Description { get; }
        float Execute(float number1, float number2);
    }
}
