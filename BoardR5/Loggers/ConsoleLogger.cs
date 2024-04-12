using BoardR4.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardR5.Loggers
{
    internal class ConsoleLogger : ILogger
    {
        public void Log(string value)
        {
            Console.Write(value);
        }
    }
}
