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

        public List<Gambler> Gamblers { get; set; }
        public List<Bet> Bets { get; set; }

        public Game(int amountOfHorses)
        {
            _horses = new List<Horse>();
            Gamblers = new List<Gambler>();
            Bets = new List<Bet>();

            for (int i = 0; i < amountOfHorses; i++)
            {
                _horses.Add(new Horse("Huppelpaard" + i));
            }
        }

        public void StartGameLoop()
        {
            bool deGameIsAanDeGang = true;
            Console.WriteLine("What do you want to do?");

            while (deGameIsAanDeGang) //==true is niet meer nodig, want hierboven heb je al gespecificeerd dat de methode true is.
            {
                //game menu
                Console.WriteLine("\n1. Add Gambler");
                Console.WriteLine("2. Add a bet!");
                Console.WriteLine("3. Start race!"); //huuuh de race werkt ni meer ;p zucht 
                Console.WriteLine("4. Show All Gamblers");
                Console.WriteLine("5. Show All Bets");
                Console.WriteLine("6. Exit");

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

                //Dit 2e stuk zou ik gewoon niet doen
                //Want je kan altijd nog een keer op 'placebet' drukken om  een nieuwe bet te plaatsen toch? je bedoeld als de speler nogmaals 2 selecteert? ok
                //ja maar er moet wel iets van output komen dan
                //Ja, maar is dat niet die showbets? hij moet dan ook ff laten zien op welke paard je hebt gegokt
                //Nog 1 dingetje wat er mist
                //ja dat kan
                //maar 1 dingetje wat er mist is dit:
                //Het geld afhalen van de currentGambler, ja dat wou ik doen bij Payout methode iegenlijk klopt :)
                //Ja maar daar krijg je het terug
                //Hier moet je het al wel er af halen toch
                //Want je betaald al wel om die bet te plaatsen lijkt mij?
                //Ok, kzou dat ff hier doen dan :D

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

            //Ok kom eens naar hier :)
            //woo :D
            //wacht ff kijken hoor
            //Kijk eens hier: https://github.com/devedse/RaceConsoleGame/commit/0a24ebe571bbfa8f0eeadfb38a2a35c0923afbc0
            //Daar heb je wat code uit deze methode gehaald
            //Kijk vooral eens hier: https://github.com/devedse/RaceConsoleGame/blob/ce79d20566d580b9265dfe333f2da09ed9006c64/RaceConsoleGame/Game.cs#L217
            //Dat is de  oude versie van je eigen code
            //Want je hebt het stukje eruit gehaald dat checkt of een paard een winner is die staat nu toch in haswinner?
            //uhu, maar roep je die methode al aan? oh nee xD   


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
                    }

                    //ok probeer het nog eens
                    //en dan inchecken ^^ze zijn nie meer random -.-
                    //hoezo? Huppelpaard 0:23 Huppelpaard1 ook weer 23 etc
                    //lol dan heeft die code van je collega het gesloopt maar hij had t de heletijd gedaan
                    //:D:D:D
                    //ow, zal is ff kijken
                    //Kan je is inchecken
                    //dan run ik hem ff lokaal
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

        public int PayOut(int cash, bool winner, Horse horse) //misschien is deze methode overbodig en kan dit ook hierboven worden gegplaatst bij 'eriseenwinnaar'.
        {
            if (winner == true)
            {
                cash += cash;
                return cash;
                //Console.WriteLine($"{} has won {...cash...}");
            }
            return 0;
        }
        //In plaats van 3 paarden hardcoded, wil ik dat paarden automatisch worden aangemaakt
        //1. Ik wil dat gamblers op meer dan 1 paard kunnen inzetten
        //2. Ik wil dat 'cash' voor iedere speler wordt bijgehouden en die wordt uitbetaald na elke winnende race.
        //3. De gamestartloop moet worden uitgezet 

    }
}
