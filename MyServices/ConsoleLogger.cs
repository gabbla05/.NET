using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyServices
{
    public class ConsoleLogger : ILoggerService
    {
        public void Log(string message)
        {
           Console.WriteLine($"[LOG]: {message}");
        }
    }
}
