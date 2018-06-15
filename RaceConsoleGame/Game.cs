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
            //Oh HUH is die 1 van case 1 int 1 als in user input 1???<--dus hiervan is het antwoord ja ja oooh Huuuuuuuuuuuhhhhhhhhhhhh hier kusje op je gezicht <3 bam :DLekker hmm ja jij ook
            //Maar ik bedoel ik doe die vergelijking nu toch nergens, hoe da fak weet ie dat
            //Wat case betekent is als userInput == 1 dan ga daarnaartoe
            //Dus effectief
            //staat er dit:
            //var userInput = Convert.ToInt32(Console.ReadLine());
            //if (userInput == 1)
            //{
            //    AddGambler();
            //}
            //else if (userInput == 2)
            //{
            //    AddBet();
            //}
            //die case switch compiled naar dat wat ik hierboven typ
            //Dus omdat je switch (userInput) doet weet hij dat hij bij case 1: die 1 moet vergelijken met userInput


            //Ok nu eerst inchecken en dan door met die bet
            //Oja en die int userInput moet hier nog weg want die was overbodig :) Dat blijf ik nog een lastig dingetje vinden :( Ja is goed
            //Ja ik kan dat beter in person uitleggen een keer
            //Ohja nu compiled de code niet meer
            //die moet je ook ff fixen
            //en daarna incheckereren :D 


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
            Console.WriteLine("\nAll gamblers:");
            for (int i = 0; i < Gamblers.Count; i++)
            {
                var gambler = Gamblers[i];
                Console.WriteLine($"{i + 1}.{gambler.Name}, {gambler.Cash}");
            }
        }
        public void AddBet()
        {
            //Ga zo ook ff inchecken :)
        }

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
