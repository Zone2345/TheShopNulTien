using System;
using System.Threading.Tasks;
using TheShop.Interfaces;

namespace TheShop.Common
{
    public class Logger : ILogger
    {
        public async Task Info(string message)
        {
            Console.WriteLine("Info: " + message);
        }

        public async Task Error(string message)
        {
            Console.WriteLine("Error: " + message);
        }

        public async Task Debug(string message)
        {
            Console.WriteLine("Debug: " + message);
        }
    }
}
