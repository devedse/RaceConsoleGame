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
            this.Name = name;
            this.Cash = cash;
            //ok maar stel ik doe:
            //<-- dit staat nog steeds compleet los van die 'Name' uit de methode in de gameklasse
            //Nou  doe eerst maar eens wat je hierboven typt dan gaan we terug naar de game klasse

            //Nou het werkt hetzelfde als bij al die andere dingen
            //Kijk eens in Horse
        }
    }
}
