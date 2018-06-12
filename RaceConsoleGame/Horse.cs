using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace RaceConsoleGame
{
    public class Horse
    {
        //private Random Speed { get; set; }
        private int location = 0;
        public string Name { get; set; }
        private Random random;

        public Horse(string nameOfHorse, Random random)
        {
            this.Name = nameOfHorse;
            this.random = random;
        }
        //test
        public void UpdatePos()
        {
            location += random.Next(1, 5);
            Console.WriteLine($"{Name}: {location}");
        }
    }

}

