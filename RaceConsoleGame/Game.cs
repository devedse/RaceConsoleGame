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

        public bool HasWinner(Horse horse)
        {
            if (horse.location >= LengthOfTrack)
            {
                Console.WriteLine($"{horse.Name} has won the race!");
                return true;
            }
            return false;
        }
        //1. Ik wil dat de methode checkt of er een paard heeft gewonnen of niet
        //ok, hoe gaan we dat doen:
        //      a. Check of er een paard LengthOfTrack heeft geraakt, dus 100.

    }
}
