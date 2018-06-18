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
        public int location = 0;
        public string Name { get; set; }
        private Random random;
        public Horse(string nameOfHorse) 
        {
            this.Name = nameOfHorse; //maar hier specifier je hem in de constructor, ja dat is toch ook wat we willen,  :), want je geeft ze al mee aan de constructor
            var guid = Guid.NewGuid();
            random = new Random(guid.GetHashCode());
        }
        //test
        public void UpdatePos()
        {
            location += random.Next(1, 5);
            Console.WriteLine($"{Name}: {location}");
        }
    }

}

