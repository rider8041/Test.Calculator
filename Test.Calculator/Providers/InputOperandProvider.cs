﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Calculator.Services;
using Test.Calculator.Services.Base;

namespace Test.Calculator.Providers
{
    public class InputOperandProvider
    {
        private readonly IOutputService _outputService;
        private readonly InputStringService _inputStringService;

        public InputOperandProvider(IOutputService outputService, InputStringService inputStringService)
        {
            _outputService = outputService;
            _inputStringService = inputStringService;
        }

        public OperandType GetOperand()
        {
            _outputService.Print("Enter operand + - * /");
            string? operandString = _inputStringService.GetStringFromUser();

            return operandString switch
            {
                "+" => OperandType.Addition,
                "-" => OperandType.Substraction,
                "*" => OperandType.Multiplication,
                "/" => OperandType.Division,
                _ => OperandType.None
            };

        }

    }
}
