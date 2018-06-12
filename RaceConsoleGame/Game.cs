using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RaceConsoleGame
{

    public class Game
    {
        public List<Horse> Horses { get; set; }
        private const int LengthOfTrack = 100;

        public void Start(int AmountOfHorses)
        {
            Horses = new List<Horse>();
            Random random = new Random();
            for (int i = 0; i < AmountOfHorses; i++)
            {
                Horses.Add(new Horse("Huppelpaard" + i, random));

            }
        }

        public void LaatDePaardjesEenStapLopen()
        {
            foreach (var huppelpaard in Horses)
            {
                huppelpaard.UpdatePos();
            }



        }
        //public bool ShowWinner()
        //{
        //    if(....) //Als het einde race is, toon welke paard;
        //    return true;
        //}
        //return false;
    }
}
