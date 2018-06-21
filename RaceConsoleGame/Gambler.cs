using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceConsoleGame
{
    public class Gambler
    {
        public string Name { get; set; }
        public int Cash { get; set; }

        public Gambler(string name, int cash)
        {
            Name = name;
            Cash = cash;
        }
    }
}
