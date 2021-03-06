# RaceConsoleGame
This game is the Horse racing game but then on the console

# Cheat Sheet

### Assigning class variables

    public class Game
    {
    
    //Lijstjes maken van lijstjes waar je bij wilt komen
        private List<Horse> _horses { get; set; }
	//private heeft als naamgeving underscore en kleine letter & geen getter/setter
        private const int _lengthOfTrack = 100;

        public List<Gambler> Gamblers { get; set; }
        public List<Bet> Bets { get; set; }
        
    //Het type van de parameter die je mee wilt geven aan de constructor, (de class, interface of int/string/etc) en dan een naampje
	  //Dus int = het type, amountOfHorses = de naam
        public Game(int amountOfHorses)
        {
        //Een lijstje van het type Horse/Gambler en Bets heb je al. Nu alleen nog een lege lijstje meegeven om shit erin op te slaan
            _horses = new List<Horse>();
            Gamblers = new List<Gambler>();
            Bets = new List<Bet>();

            //Door te loopen door dit for-loopje, kun je bij elk einde van de loop een nieuw paardje toevoegen
            for (int i = 0; i < amountOfHorses; i++)
            {
	    	//Binnen het loopje wordt Huppelpaard toegevoegd
                _horses.Add(new Horse("Huppelpaard" + i));
            }
        }

        //Dit methode wordt aangemaakt voor het checken of de game aan de gang is
        public void StartGameLoop()
        {
         
         //Hier zetten we de game standaard op true omdat een boolean een false heeft als default.
            bool deGameIsAanDeGang = true;
            Console.WriteLine("What do you want to do?");
	
            while (deGameIsAanDeGang) //hier staat geen ==true achter omdat de while check standaard op true is
            {
                //game keuze menu voor als de game aan de gang is
                Console.WriteLine("\n1. Add Gambler");
                Console.WriteLine("2. Add a bet!");
                Console.WriteLine("3. Start race!"); 
                Console.WriteLine("4. Show All Gamblers");
                Console.WriteLine("5. Show All Bets");
                Console.WriteLine("6. Exit");

                //input van de user
                var userInput = Convert.ToInt32(Console.ReadLine());
  
                //aan de hand van de userinput kan je in de switch bepalen welke methode moet worden aangeroepen
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
                        
                        //alle andere input die eigenlijk niet valid zijn, maar je wilt niet dat je applicatie crashed.
                    default:
                        Console.WriteLine("Insert a valid number");
                        break;
                }
            }
            Console.WriteLine("Thanks for playing!");
        }

        //een methode om een gambler toe te voegen
        public void AddGambler()
        {
            Console.WriteLine("What's your name?");
            var name = Console.ReadLine();

            Console.WriteLine($"\n{name}, how much money do you have?");
            int cash;

            //als de speler iets anders invult dan int, bijv een string, dan geeft de applicatie aan dat dit niet kan
            while (!int.TryParse(Console.ReadLine(), out cash))
            {
                Console.WriteLine("\nI was asking about money, not about some weird shit.");
            }

            //als alles goed wordt ingevuld dan wordt er een nieuwe gambler toegevoegd met als parameters name & cash.
            Console.WriteLine($"\nYour total cash is {cash}");
            Gamblers.Add(new Gambler(name, cash));
            Console.WriteLine($"{name} is now added to the game");
        }

        public void ShowGamblers()
        {
            Console.WriteLine("\nAll participating gamblers:");
	    
	    //Door dit forloopje heen gaan en alle gamblers 
            for (int i = 0; i < Gamblers.Count; i++)
            {
                var gambler = Gamblers[i];
                Console.WriteLine($"{i + 1}.{gambler.Name}, {gambler.Cash}");
            }
        }
        
        //een bet toevoegen
        public void AddBet()
        {
        //checken of er uberhaupt gamblers in de game zitten
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
		
		//locale variable waarin de bet van de gambler wordt opgeslagen
                int gamblerBet;
		
                while (!int.TryParse(Console.ReadLine(), out gamblerBet))
                {
                    Console.WriteLine("\nThis is not money, please don't try to cheat");
                    Console.WriteLine("Let's try it once more, what's your bet?");
                }
		//Als de game bet minder is dan 5euro dan kun je niet inleggen
                if (gamblerBet < 5)
                {
                    Console.WriteLine("Don't be cheap, come back when you've got more money!");
                }
		//Als de gambler niet genoeg cash heeft, dan kan hij niet inleggen
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
		
		//De bet bedrag gaat af van het huidige geld van de gambler
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
		
	    //winner wordt als eerst op false gezet	
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
	    	//update de positie van het paard 
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

        //deze methode wordt alleen aangeroepen als er een winninghorse is
        public void PayOut(Horse winningHorse)
        {
            //dit for-loopje gaat door een lijstje met bets heen lopen
            for (int i = 0; i < Bets.Count; i++)
            {
                var bet = Bets[i];
      
      //alleen met bets kun je niks, dus deze if checkt of het winnende paard ook gelijk is aan het paard waarop is gebet.
                if (winningHorse == bet.Horse)
                {
                //als dat zo is, betaal dan de gambler uit met het dubbele bet bedrag bovenop zijn cash.
                    bet.Gambler.Cash += bet.BetAmount * 2;
                    Console.WriteLine($"{bet.Gambler.Name} has won {bet.BetAmount * 2}");
                }
            }
        }
    }
}
