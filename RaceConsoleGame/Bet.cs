using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceConsoleGame
{
    class Bet
    {
        //Zonder gambler heb je geen bet
        public Gambler Gambler { get; set; }
        //zonder paarden kun je niet gokken
        public Horse Horses { get; set; }
        //Het bet bedrag voor iedere speler
        public int BetAmount { get; set; }

        public Bet(Gambler gambler)
        {

        }
    }
}
