using Test.Calculator.Contracts;

namespace Test.Calculator.DivisionOperation
{
    public class DivisionOperation : IOperation
    {
        public string Name => "Division";

        public string ShortName => "/";

        public string Description => "Divide two numbers";

        public float Execute(float number1, float number2)
        {
            if (number2 == 0f)
            {
                return 0;
            }

            return number1 / number2;
        }
    }
}
