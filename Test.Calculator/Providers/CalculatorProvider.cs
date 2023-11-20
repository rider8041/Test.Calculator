using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Calculator.Factories;
using Test.Calculator.Services;
using Test.Calculator.Services.Base;

namespace Test.Calculator.Providers
{
    public class CalculatorProvider
    {
        private readonly IOutputService _outputService;

        public CalculatorProvider(OutputSelectionFactory outputSelectionFactory)
        {
            _outputService = outputSelectionFactory.GetOutputService();
        }

        public float? Compute(float number1, float number2, OperandType operand)
        {
            switch (operand)
            {
                case OperandType.Addition:
                    return number1 + number2;
                case OperandType.Substraction:
                    return number1 - number2;
                case OperandType.Multiplication:
                    return number1 * number2;
                case OperandType.Division:
                    if (number2 == 0)
                    {
                        _outputService.Print("Divide by zero. Error");
                        return null;
                    }
                    return number1 / number2;
            }

            return null;
        }
    }
}
