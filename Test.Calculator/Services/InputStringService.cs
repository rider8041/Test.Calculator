using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Calculator.Services
{
    public class InputStringService
    {
        public string? GetStringFromUser()
        {
            return Console.ReadLine();
        }
    }
}
