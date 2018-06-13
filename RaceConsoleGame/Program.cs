using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceConsoleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The race is starting...");
            var game = new Game();
            game.Start(4);     

            Console.ReadLine();

        }
    }
}
