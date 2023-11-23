using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Test.Calculator.Providers;
using Test.Calculator.Contracts;
using Test.Calculator.Shell.Services.Base;
using Test.Calculator.Shell.Services;
using Test.Calculator.Shell.Factories;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Test.Calculator.Shell
{
    public static class DependencyContainer
    {
        public static IServiceProvider GetContainer()
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
            services.AddTransient<OutputSelectionFactory>();
            services.AddOptions<ApplicationSettings>();
            services.Configure<ApplicationSettings>(configuration.GetSection(nameof(ApplicationSettings)));

            //services.AddTransient<IOperation, AdditionOperation>();
            //services.AddTransient<IOperation, SubtractionOperation>();
            //services.AddTransient<IOperation, MultiplicationOperation>();
            //services.AddTransient<IOperation, DivisionOperation>();

            var pluginsFoler = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins");

            if (!Directory.Exists(pluginsFoler))
            {
                return services.BuildServiceProvider();
            }

            var files = Directory.GetFiles(pluginsFoler, "*.dll");

            if (!files.Any())
            {
                return services.BuildServiceProvider();
            }

            foreach (var file in files)
            {
                var assembly = Assembly.LoadFile(file);
                var types = assembly.GetExportedTypes().Where(x => x.IsAssignableTo(typeof(IOperation))).ToList();

                foreach (var type in types)
                {
                    services.AddTransient(typeof(IOperation), type);
                }
            }

            return services.BuildServiceProvider();
        }
    }
}