﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Calculator.Services;
using Test.Calculator.Services.Base;

namespace Test.Calculator.Providers
{
    public class InputFloatProvider
    {
        private IOutputService _outputService;
        private readonly InputStringService _inputStringService;

        public InputFloatProvider(IOutputService outputService, InputStringService inputStringService)
        {
            _outputService = outputService;
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
