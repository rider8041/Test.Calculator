using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test.Calculator.Services.Base;

namespace Test.Calculator.Services
{
    public class MessageBoxOutputService : OutputServiceBase
    {
        public override void Output(string message)
        {
            MessageBox.Show(message);
        }
    }
}
