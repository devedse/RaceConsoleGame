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
        public List<Bet> Bets { get; set; }
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
                Console.WriteLine("2. Start race!");
                Console.WriteLine("3. Show All Gamblers");
                Console.WriteLine("4. Exit");

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
                Console.WriteLine("\nI was asking about money, not about some weird shit.");
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
            //Deze code mag later weg
            var gamblerDavy = new Gambler("Davy", int.MaxValue);
            var hetPaardWaarDavyOpBet = new Horse("Hupperbeestunitpaard");
            var davyBet = new Bet(gamblerDavy, 1001, hetPaardWaarDavyOpBet);

            //Thanks, what Horse do you want to Bet on?:
            //Huppelpaard 1
            //Huppelpaard 2 Ja er kwam ff een schoonmaak wijf langs mn tafel back to business 
            //Ok 
            //Ik zou als ik jou was gewoon de code die je gebruikt om die int value op te vragen voor gambler copy pasten naar onder
            //en dan rewriten voor horses

            if (Gamblers.Count > 0)
            {
                //Dus ga hier eens dat stuk wat ik hierboven typ uitprogrammeren

                //1. Melding geven dat hij je naam nodig hebt
                Console.WriteLine("To place a bet, I need to know who you are");
                //2. Lijst uitprinten met alle namen
                ShowGamblers();

                //3. Waarde ophalen wat de user invult
                var input = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(input);
                //4. De bijbehordende gambler zoeken en in de variabele currentGambler stoppen
                var currentGambler = Gamblers[input];

                Console.WriteLine("\nInsert your bet here:");

                int gamblerBet;

                while (!int.TryParse(Console.ReadLine(), out gamblerBet))
                {
                    Console.WriteLine("\nThis is not money, please don't try to cheat");
                    Console.WriteLine("Let's try it once more, what's your bet?");
                }

                if (gamblerBet < 5)
                {
                    Console.WriteLine("Don't be cheap, come back when you've got more money!");
                }
                else
                {
                    Console.WriteLine($"Your bet is {gamblerBet}, on what horse do you want to bet on?");
                }


                //2. Lijst uitprinten met alle paarden
                ShowHorses();
                //3. Waarde ophalen wat de user invult
                var selectHorse = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(selectHorse);
                //4. 
                //Dus je moet nu alleen nog een bet aanmake oh ik wou net vragen, wat is daar dan mee haha
                var horse = Horses[selectHorse];

                //1. De gambler: currentGambler
                //2. De amount: gamblerBet <-- oja deze klopt niet, want waar staat het bet amount in wat je hebt opgehaald
                //3. Het paard: horse 

                //Variabelen erin en done :D
                //
                // 
                //dus nu
                //1. Maak een nieuwe Bet aan
                var bet = new Bet(currentGambler, gamblerBet, horse);
                Bets.Add(bet); //to hier hah maar ik zie je en kus je vanvaond wel dan :D
                //succes <3 xx ja 1x in de 10 jr zijn ze hier haha<33


                //^^ ok, ik ga nu snel hardlopen
                //maar ga maar ff inchecken wel, aaaffkkkkkk
                //en als je wat eerder wilt komen mag ook, dan kunnen we wat langer together zijn
                //maar kijkmaar
                //je fam is ook importante
                //ja daarom
                //<3 kettytje
            }
        }

        public void ShowBet()
        {
            Console.WriteLine("All bets placed");

            for (int i = 0; i < Bets.Count; i++)
            {
                var bet = Bets[i];
                Console.WriteLine($"{i + 1}{bet.Gambler.Name} has put a bet of:{bet.BetAmount} {bet.Horse.Name}");
            }

        }

        public void ShowHorses()
        {
            Console.WriteLine("All participating horses");

            for (int i = 0; i < Horses.Count; i++)
            {
                var horse = Horses[i];
                Console.WriteLine($"{i + 1}{horse.Name}");
            }
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
