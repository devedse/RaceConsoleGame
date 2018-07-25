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
        private readonly Logger _logger;

        public int Location { get; private set; }
        public string Name { get; set; }
        
        public Horse(Logger logger, string nameOfHorse) 
        {
            Name = nameOfHorse; 
            var guid = Guid.NewGuid();
            _speed = new Random(guid.GetHashCode());
            _logger = logger;
        }

        public void UpdatePosition()
        {
            Location += _speed.Next(1, 5);
            _logger.Write($"{Name}: {Location}");
        }
    }

}

