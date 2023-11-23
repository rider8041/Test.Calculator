using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Calculator.Services.Base;

namespace Test.Calculator.Shell.Services
{
    public class FileOutputService : OutputServiceBase
    {
        private const string FileName = "output.txt";
        private const string FolderName = "Logs";

        public override void Output(string message)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FolderName);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            using (var file = File.AppendText(Path.Combine(path, FileName)))
            {
                file.WriteLine(message);
            }
        }
    }
}
