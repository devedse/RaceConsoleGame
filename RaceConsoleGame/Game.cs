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
        private Timer timer;

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
                Console.WriteLine("4. Exit");

                var userInput = Convert.ToInt32(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        AddGambler(1);
                     
                        break;
                    case 2:
                        AddBet();
                        break;
                    case 3:
                        StartRace();
                        break;
                    case 4:
                        deGameIsAanDeGang = false;
                        break;
                    default:
                        Console.WriteLine("Insert a valid number");
                        break;
                }
            }
            Console.WriteLine("Thanks for playing!");
        }
        public void AddGambler(int userInput)
        { 
            Gamblers = new List<Gambler>();
          
            //var resulInput = Convert.ToInt32(Console.ReadLine());

            if(userInput == 1)
                {
                Console.WriteLine("What's your name?");
                var Name = Console.ReadLine();

                Console.WriteLine($"\n{Name}, how much money do you have?");
                int Cash;

                while (!int.TryParse(Console.ReadLine(), out Cash))
                {
                    Console.WriteLine("\nThis is not money, please don't try to cheat" +
                                                  "\nSo I'm asking you one more time, how much?");
                }

                Console.WriteLine($"\nYour total cash is {Cash}");
                Gamblers.Add(new Gambler(Name, Cash));
            }

            //Willen we voor nu alleen gamblers kunnen toevoegen of ook dat ze een naam en cash meekrijgen?

            //Wat ik zou doen is dit:

            //Applictie vraagt what is your name
            //Dan doe je met die console readline van ok dit is de naam
            //Dan what is your money
            //zelfde
            //Dan in een gambler stoppen
            //en aan de lijst toeveogen
        }

        public void AddBet()
        {
  
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
