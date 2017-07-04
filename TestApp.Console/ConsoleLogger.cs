using System.Diagnostics;
using TestApp.Core;

namespace TestApp.Console
{
    public class ConsoleLogger : ILogger
    {
        public void Add(string log)
        {
            System.Console.WriteLine(log);
        }
    }
}