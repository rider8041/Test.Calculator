using System;
using System.Linq;
using Test.Calculator.Providers;
using Test.Calculator.Services;
using Test.Calculator.Services.Base;

namespace Test.Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IOutputService outputService = ProcessArguments(args);

            var inputStringService = new InputStringService();
            var calculatorProvider = new CalculatorProvider(outputService);
            var inputService = new InputFloatProvider(outputService, inputStringService);
            var parseOperandService = new InputOperandProvider(outputService, inputStringService);

            outputService.Print("Test Calculator v1.0.0");

            outputService.Print("Enter the first number (float)");
            var number1 = inputService.GetNumber();

            outputService.Print("Enter the second number (float)");
            var number2 = inputService.GetNumber();

            var operand = parseOperandService.GetOperand();
            if (operand == OperandType.None)
            {
                outputService.Print("Wrong operand. Goodbye!");
                return;
            }

            var result = calculatorProvider.Compute(number1, number2, operand);

            if (result is not null)
            {
                outputService.Print(result.Value.ToString());
            }
        }

        private static IOutputService ProcessArguments(string[] args)
        {
            if (!args.Any())
            {
                throw new ArgumentNullException(nameof(args));
            }

            var values = args[0].Split('=');

            if (values[1] == "console")
            {
                return new ConsoleOutputService();
            }

                return new MessageBoxOutputService();
        }
    }
}
