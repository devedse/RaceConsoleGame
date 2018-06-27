using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceConsoleGame
{
    public class Bet
    {
        //Zonder gambler heb je geen bet
        public Gambler Gambler { get; private set; }
        //zonder paarden kun je niet gokken
        public Horse Horse { get; private set; }
        //Het bet bedrag voor iedere speler
        public int BetAmount { get; private set; }

        public Bet(Gambler gambler, int amount, Horse horse)
        {
            if (gambler == null)
            {
                throw new ArgumentNullException(nameof(gambler));
            }

            Gambler = gambler;
            BetAmount = amount;
            Horse = horse;
        }
    }
}
