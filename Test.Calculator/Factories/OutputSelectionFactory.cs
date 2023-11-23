using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Calculator.Services;
using Test.Calculator.Services.Base;

namespace Test.Calculator.Factories
{
    public class OutputSelectionFactory
    {
        private readonly IEnumerable<IOutputService> _outputServices;
        private readonly ApplicationSettings _applicatonSettings;

        public OutputSelectionFactory(IEnumerable<IOutputService> outputServices, IOptions<ApplicationSettings> options)
        {
            _outputServices = outputServices;
            _applicatonSettings = options.Value;
        }

        public IOutputService GetOutputService()
        {
            var value = _applicatonSettings.DefaultService;

            return value switch
            {
                "Console" => _outputServices.First(x => x.GetType() == typeof(ConsoleOutputService)),
                "MessageBox" => _outputServices.First(x => x.GetType() == typeof(MessageBoxOutputService)),
                "File" => _outputServices.First(x => x.GetType() == typeof(FileOutputService)),
                _ => throw new ArgumentException()
            };
        }
    }
}
