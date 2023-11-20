using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Test.Calculator.Factories;
using Test.Calculator.Providers;
using Test.Calculator.Services;
using Test.Calculator.Services.Base;

namespace Test.Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();

            services.AddTransient<IOutputService, ConsoleOutputService>();
            services.AddTransient<IOutputService, MessageBoxOutputService>();
            services.AddTransient<IOutputService, ConsoleOutputService>();
            services.AddTransient<InputStringService>();
            services.AddTransient<InputFloatProvider>();
            services.AddTransient<InputOperandProvider>();
            services.AddTransient<CalculatorProvider>();
            services.AddTransient<OutputSelectionFactory>();

            var container = services.BuildServiceProvider();

            var outputServices = container.GetServices<IOutputService>();
            var inputFloatProvider = container.GetRequiredService<InputFloatProvider>();
            var inputOpearndProvider = container.GetRequiredService<InputOperandProvider>();
            var calculatorProvider = container.GetRequiredService<CalculatorProvider>();

            var outputService = ProcessArguments(args, outputServices);


            outputService.Print("Test Calculator v1.0.0");

            outputService.Print("Enter the first number (float)");
            var number1 = inputFloatProvider.GetNumber();

            outputService.Print("Enter the second number (float)");
            var number2 = inputFloatProvider.GetNumber();

            var operand = inputOpearndProvider.GetOperand();
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

        private static IOutputService ProcessArguments(string[] args, IEnumerable<IOutputService> services)
        {
            if (!args.Any())
            {
                throw new ArgumentNullException(nameof(args));
            }

            var values = args[0].Split('=');

            if (values[1] == "console")
            {
                return services.First(x => x.GetType() == typeof(ConsoleOutputService));
            }

                return services.First(x => x.GetType() == typeof(MessageBoxOutputService));
        }
    }
}
