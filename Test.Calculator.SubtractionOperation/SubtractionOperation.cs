using Test.Calculator.Contracts;

namespace Test.Calculator.SubtractionOperation
{
    public class SubtractionOperation : IOperation
    {
        public string Name => "Subtraction";

        public string ShortName => "-";

        public string Description => "Subtract two numbers";

        public float Execute(float number1, float number2)
        {
            return number1 - number2;
        }
    }
}
