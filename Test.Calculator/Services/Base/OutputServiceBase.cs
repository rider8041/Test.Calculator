using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Calculator.Shell.Services.Base;

namespace Test.Calculator.Services.Base
{
    public abstract class OutputServiceBase : IOutputService
    {
        public void Print(string message)
        {
            if (message is null)
                throw new ArgumentNullException(nameof(message));

            Output(message);
        }

        public abstract void Output(string message);
    }
}
