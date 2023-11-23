using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Calculator.Contracts;

namespace Test.Calculator.ExponentialOperation
{
    public class ExponentialOperation : IOperation
    {
        public string Name => "Exponential";

        public string ShortName => "e";

        public string Description => "Exponential operation between two numbers";

        public float Execute(float number1, float number2)
        {
            int int1 = Convert.ToInt16(number1);
            int int2 = Convert.ToInt16(number2);

            return (float)Math.Pow(int1, int2);
        }
    }
}
