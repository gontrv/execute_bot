using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteBot
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Numbers for execution: ");
                int count = int.Parse(Console.ReadLine());

                BotExecuter botExecuter = new BotExecuter(count);
                Console.WriteLine("Press enter to execute...");
                Console.ReadLine();
                botExecuter.ExecuteBot();

            } while (true);
        }
    }
}
