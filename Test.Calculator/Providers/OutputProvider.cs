using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Calculator.Services.Base;

namespace Test.Calculator.Providers
{
    public class OutputProvider
    {
        private readonly IEnumerable<IOutputService> _outputServices;

        public OutputProvider(IEnumerable<IOutputService> outputServices)
        {
            _outputServices = outputServices;
        }

        public void Print(string message)
        {
            if (_outputServices.Any())
            {
                foreach (var service in _outputServices)
                {
                    service.Print(message);
                }
            }
        }
    }
}
