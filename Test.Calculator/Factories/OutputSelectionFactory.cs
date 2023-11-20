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

        public OutputSelectionFactory(IEnumerable<IOutputService> outputServices)
        {
            _outputServices = outputServices;
        }

        public IOutputService GetOutputService(bool isUserConsole = true)
        {
            if (isUserConsole)
            {
                return _outputServices.First(x => x.GetType() == typeof(ConsoleOutputService));
            }

            return _outputServices.First(x => x.GetType() == typeof(MessageBoxOutputService));
        }
    }
}
