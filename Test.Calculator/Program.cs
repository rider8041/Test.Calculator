using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using Test.Calculator.Providers;
using Test.Calculator.Services;
using Test.Calculator.Services.Base;
using Test.Calculator.Shell.Factories;

namespace Test.Calculator.Shell
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var container = DependencyContainer.GetContainer();


            var inputFloatProvider = container.GetRequiredService<InputFloatProvider>();
            var inputOpearndProvider = container.GetRequiredService<InputOperandProvider>();
            var outputSelectionFactory = container.GetRequiredService<OutputSelectionFactory>();

            var outputService = outputSelectionFactory.GetOutputService();


            outputService.Print("Test Calculator v1.0.0");

            outputService.Print("Enter the first number (float)");
            var number1 = inputFloatProvider.GetNumber();

            outputService.Print("Enter the second number (float)");
            var number2 = inputFloatProvider.GetNumber();

            var operation = inputOpearndProvider.GetOperand();
            if (operation == null)
            {
                outputService.Print("Wrong operand. Goodbye!");
                return;
            }

            var result = operation.Execute(number1, number2);
            outputService.Print(result.ToString());
        }
    }
}
