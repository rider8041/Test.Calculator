using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Calculator.Shell.Factories;
using Test.Calculator.Shell.Services;
using Test.Calculator.Shell.Services.Base;

namespace Test.Calculator.Providers
{
    public class InputFloatProvider
    {
        private IOutputService _outputService;
        private readonly InputStringService _inputStringService;

        public InputFloatProvider(OutputSelectionFactory outputSelectionFactory, InputStringService inputStringService)
        {
            _outputService = outputSelectionFactory.GetOutputService();
            _inputStringService = inputStringService;
        }

        public float GetNumber()
        {
            float number;
            bool isInputValid;

            do
            {
                string? numberString = _inputStringService.GetStringFromUser();
                var numberParsed = float.TryParse(numberString, out number);
                isInputValid = numberParsed;

                if (!numberParsed)
                {
                    _outputService.Print("Wrong number, please try again enter a valid float number:");
                }
            } while (!isInputValid);





            return number;
        }
    }
}
