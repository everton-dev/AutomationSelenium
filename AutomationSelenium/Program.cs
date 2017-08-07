using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSelenium
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initializing Automation Process...");
            new InitAutomation().Start();
            Console.WriteLine("Type any to quit.");
            Console.ReadLine();
        }
    }
}
