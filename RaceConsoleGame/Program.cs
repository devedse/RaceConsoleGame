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
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Title = "RaceTrack by Ketty";
            Console.WriteLine();
          
            var game = new Game(7);
            game.StartGameLoop(); //<-- null reference exception
           
            Console.ReadLine();
        }
    }
}
