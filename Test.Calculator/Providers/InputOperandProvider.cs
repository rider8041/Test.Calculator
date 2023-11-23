using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Calculator.Contracts;
using Test.Calculator.Shell.Factories;
using Test.Calculator.Shell.Services;
using Test.Calculator.Shell.Services.Base;

namespace Test.Calculator.Providers
{
    public class InputOperandProvider
    {
        private readonly IOutputService _outputService;
        private readonly IEnumerable<IOperation> _operations;
        private readonly InputStringService _inputStringService;

        public InputOperandProvider(IEnumerable<IOperation> operations, OutputSelectionFactory outputSelectionFactory, InputStringService inputStringService)
        {
            _outputService = outputSelectionFactory.GetOutputService();
            _operations = operations;
            _inputStringService = inputStringService;
        }

        public IOperation? GetOperand()
        {
            if (!_operations.Any())
            {
                return null;
            }

            var messages = _operations.Select(x => $"[{x.ShortName}] {x.Name}. {x.Description}");

            _outputService.Print("Select operations: ");
            _outputService.Print(string.Join("\n", messages));

            string? operandString = _inputStringService.GetStringFromUser();

            return _operations.FirstOrDefault(x => x.ShortName.Equals(operandString));
        }

    }
}
