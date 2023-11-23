using Test.Calculator.Contracts;

namespace Test.Calculator.MultiplicationOperation
{
    public class MultiplicationOperation : IOperation
    {
        public string Name => "Mulitiplication";

        public string ShortName => "*";

        public string Description => "Multiply two numbers";

        public float Execute(float number1, float number2)
        {
            return number1 * number2;
        }
    }
}
