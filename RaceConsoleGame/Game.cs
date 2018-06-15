using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RaceConsoleGame
{

    public class Game
    {
        private List<Horse> Horses { get; set; }

        public List<Gambler> Gamblers { get; set; }
        private const int LengthOfTrack = 100;

        public Game(int AmountOfHorses)
        {
            Horses = new List<Horse>();
            Gamblers = new List<Gambler>();

            for (int i = 0; i < AmountOfHorses; i++)
            {
                Horses.Add(new Horse("Huppelpaard" + i));
            }
        }

        public void StartGameLoop()
        {
            bool deGameIsAanDeGang = true;
            Console.WriteLine("What do you want to do?");

            while (deGameIsAanDeGang == true)
            {
                Console.WriteLine("\n1. Add Gambler");
                Console.WriteLine("2. Add bet");
                Console.WriteLine("3. Start race!");
                Console.WriteLine("4. Show All Gamblers");
                Console.WriteLine("5. Exit");

                var userInput = Convert.ToInt32(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        AddGambler();
                        break;
                    case 2:
                        AddBet();
                        break;
                    case 3:
                        StartRace();
                        break;
                    case 4:
                        ShowGamblers();
                        break;
                    case 5:
                        deGameIsAanDeGang = false;
                        break;
                    default:
                        Console.WriteLine("Insert a valid number");
                        break;
                }
            }
            Console.WriteLine("Thanks for playing!");
        }

        public void AddGambler()
        {
            Console.WriteLine("What's your name?");
            var name = Console.ReadLine();

            Console.WriteLine($"\n{name}, how much money do you have?");
            int cash;

            while (!int.TryParse(Console.ReadLine(), out cash))
            {
                Console.WriteLine("\nThis is not money, please don't try to cheat");
                Console.WriteLine("So I'm asking you one more time, how much?");
            }

            Console.WriteLine($"\nYour total cash is {cash}");

            Gamblers.Add(new Gambler(name, cash));
            Console.WriteLine($"{name} is now added to the game");
        }

        public void ShowGamblers()
        {
            Console.WriteLine("\nAll participating gamblers:");
            for (int i = 0; i < Gamblers.Count; i++)
            {
                var gambler = Gamblers[i];
                Console.WriteLine($"{i + 1}.{gambler.Name}, {gambler.Cash}");
            }
        }
        public void AddBet()
        {
            //een manier vinden om de gamblers te linken met het bet
            if (Gamblers == null)
            {
                var betAmount = new Bet(); //<-- not sure though
                Console.WriteLine("\nInsert your bet here:");
                int bet = Convert.ToInt32(Console.ReadLine());

                if (bet < 5)
                {
                    Console.WriteLine("Don't be cheap. Come back when you have more money");
                }
                else
                {
                    Console.WriteLine($"Your bet is {bet}");
                }
            }
            else
            {
                Console.WriteLine("No players, no game");
            }
        }

        public void ShowBet()
        {
            Console.WriteLine("All bets placed");

        }
        //Een manier zien te vinden om gambler te linken met de bet.

        public void StartRace()
        {

            //Wat we willen: Implementatie van Gamblers en Bets
            //1. Gamblers moeten zich voor de race registreren met een Naam
            //- Maak een Gambler Klasse aan
            //- Met fields: 1. Name, 2. Cash 
            //2. We moeten dan aan alle gamblers vragen op welke paarden ze willen betten
            //      Elke bet heeft dus een Gambler, een amount en een Horse
            //3. We moeten de game laten spelen
            //4. We moeten de Gamblers uitbetalen

            bool erIsEenWinnaar = false;

            while (erIsEenWinnaar == false)
            {
                LaatDePaardjesEenStapLopen();

                foreach (var horse in Horses)
                {
                    if (horse.location >= LengthOfTrack)
                    {
                        erIsEenWinnaar = true;
                        Console.WriteLine($"{horse.Name} has won the race!");
                    }
                }
                Thread.Sleep(100);
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
        //In plaats van 3 paarden hardcoded, wil ik dat paarden automatisch worden aangemaakt

    }
}
