using Test.Calculator.Contracts;

namespace Test.Calculator.AdditionOperation
{
    public class AdditionOperation : IOperation
    {
        public string Name => "Additon";

        public string ShortName => "+";

        public string Description => "Adds two number";

        public float Execute(float number1, float number2)
        {
            return number1 + number2;
        }
    }
}
