using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RaceConsoleGame
{
    public class Game
    {
        private List<Horse> _horses { get; set; }
        private const int _lengthOfTrack = 100;
        private Logger _logger;

        public List<Gambler> Gamblers { get; set; }
        public List<Bet> Bets { get; set; }

        public Game(int amountOfHorses)
        {
            _logger = new Logger();
            _horses = new List<Horse>();
            Gamblers = new List<Gambler>();
            Bets = new List<Bet>();

            for (int i = 0; i < amountOfHorses; i++)
            {
                _horses.Add(new Horse(_logger, "Huppelpaard" + i));
            }
        }

        public void StartGameLoop()
        {
            bool deGameIsAanDeGang = true;
            _logger.Write("What do you want to do?");

            while (deGameIsAanDeGang) //==true is niet meer nodig, want hierboven heb ik al gespecificeerd dat de methode true is.
            {
                //game menu
                _logger.Write("\n1. Add Gambler");
                _logger.Write("2. Add a bet!");
                _logger.Write("3. Start race!");
                _logger.Write("4. Show All Gamblers");
                _logger.Write("5. Show All Bets");
                _logger.Write("6. Exit");

                //input van de user
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
                        ShowBet();
                        break;
                    case 6:
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
                Console.WriteLine("\nI was asking about money, not about some weird stuff.");
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
            if (Gamblers.Count > 0)
            {
                //1. Melding geven dat hij je naam nodig hebt
                Console.WriteLine("To place a bet, I need to know who you are");
                //2. Lijst uitprinten met alle namen
                ShowGamblers();

                //3. Waarde ophalen wat de user invult
                var input = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(input);
                //4. De bijbehordende gambler zoeken en in de variabele currentGambler stoppen
                var currentGambler = Gamblers[input - 1];

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

                else if (gamblerBet > currentGambler.Cash)
                {
                    Console.WriteLine("Nice try, but you don't have enough cash");
                }
                else
                {
                    Console.WriteLine($"Your bet is {gamblerBet}, on what horse do you want to bet on?");
                    ShowHorses();
                }

                //2. Lijst uitprinten met alle paarden

                //3. Waarde ophalen wat de user invult
                var selectHorse = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(selectHorse);
                //4. 

                var horse = _horses[selectHorse - 1];

                //1. De gambler: currentGambler
                //2. De amount: gamblerbet
                //3. Het paard: horse 

                currentGambler.Cash -= gamblerBet;

                var bet = new Bet(currentGambler, gamblerBet, horse);

                Bets.Add(bet);

                Console.WriteLine($"You've placed another bet on {bet.Horse.Name} with an amount of {bet.BetAmount}");
                ShowBet();
            }
        }

        public void ShowBet()
        {
            Console.WriteLine("All bets placed");

            for (int i = 0; i < Bets.Count; i++)
            {
                var bet = Bets[i];
                Console.WriteLine($"{i + 1}. {bet.Gambler.Name} has put a bet of: {bet.BetAmount} on {bet.Horse.Name}");
            }
        }
        public void ShowHorses()
        {
            Console.WriteLine("\nAll participating horses");

            for (int i = 0; i < _horses.Count; i++)
            {
                var horse = _horses[i];
                Console.WriteLine($"{i + 1} {horse.Name}");
            }
        }
        public void StartRace()
        {
            //Wat ik wil: Implementatie van Gamblers en Bets
            //1. Gamblers moeten zich voor de race registreren met een Naam
            //  - Maak een Gambler Klasse aan
            //  - Met fields: 1. Name, 2. Cash 
            //2. aan alle gamblers vragen op welke paarden ze willen betten
            //  - Elke bet heeft dus een Gambler, een amount en een Horse
            //3. de game laten spelen
            //4. de Gamblers uitbetalen

            bool winner = false;

            while (winner == false)
            {
                LaatDePaardjesEenStapLopen();

                foreach (var horse in _horses)
                {

                    if (HasWinner(horse))
                    {
                        winner = true;
                        Console.WriteLine($"{horse.Name} has won the race!");

                        PayOut(horse);
                        break;
                    }
                }
            }
            Thread.Sleep(100);
        }

        public void LaatDePaardjesEenStapLopen()
        {
            foreach (var huppelpaard in _horses)
            {
                huppelpaard.UpdatePosition();
            }
        }
        public bool HasWinner(Horse horse)
        {
            if (horse.Location >= _lengthOfTrack)
            {
                Console.WriteLine($"{horse.Name} has won the race!");
                return true;
            }
            return false;
        }

        public void PayOut(Horse winningHorse)
        {

            for (int i = 0; i < Bets.Count; i++)
            {
                var bet = Bets[i];

                if (winningHorse == bet.Horse)
                {

                    bet.Gambler.Cash += bet.BetAmount * 2;
                    Console.WriteLine($"{bet.Gambler.Name} has won {bet.BetAmount * 2}");
                }
            }
        }
        //In plaats van 3 paarden hardcoded, wil ik dat paarden automatisch worden aangemaakt
        //1. Ik wil dat gamblers op meer dan 1 paard kunnen inzetten
        //2. Ik wil dat 'cash' voor iedere speler wordt bijgehouden en die wordt uitbetaald na elke winnende race.
        //3. De gamestartloop moet worden uitgezet 

    }
}
