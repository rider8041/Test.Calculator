using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
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
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var services = new ServiceCollection();


            services.AddTransient<IOutputService, ConsoleOutputService>();
            services.AddTransient<IOutputService, MessageBoxOutputService>();
            services.AddTransient<IOutputService, FileOutputService>();
            services.AddTransient<IOutputService, ConsoleOutputService>();
            services.AddTransient<OutputProvider>();
            services.AddTransient<InputStringService>();
            services.AddTransient<InputFloatProvider>();
            services.AddTransient<InputOperandProvider>();
            services.AddTransient<CalculatorProvider>();
            services.AddTransient<OutputSelectionFactory>();
            services.AddOptions<ApplicationSettings>();
            services.Configure<ApplicationSettings>(configuration.GetSection(nameof(ApplicationSettings)));

            var container = services.BuildServiceProvider();


            var outputServices = container.GetServices<IOutputService>();
            var inputFloatProvider = container.GetRequiredService<InputFloatProvider>();
            var inputOpearndProvider = container.GetRequiredService<InputOperandProvider>();
            var calculatorProvider = container.GetRequiredService<CalculatorProvider>();
            var outputSelectionFactory = container.GetRequiredService<OutputSelectionFactory>();

            var outputService = outputSelectionFactory.GetOutputService();


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
                var provider = container.GetRequiredService<OutputProvider>();
                provider.Print(result.Value.ToString());
            }
        }
    }
}
