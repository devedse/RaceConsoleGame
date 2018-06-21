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
        private Random _speed;

        public int Location { get; private set; }
        public string Name { get; set; }
        
        public Horse(string nameOfHorse) 
        {
            Name = nameOfHorse; 
            var guid = Guid.NewGuid();
            _speed = new Random(guid.GetHashCode());
        }

        public void UpdatePosition()
        {
            Location += _speed.Next(1, 5);
            Console.WriteLine($"{Name}: {Location}");
        }
    }

}

