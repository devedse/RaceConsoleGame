﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceConsoleGame
{
    public class Gambler
    {
        public string Name { get; set; }
        private int Cash { get; set; }

        public Gambler(string name, int cash)
        {
            Name = name;
            Cash = cash;
        }

        #region cash handling
        public void AddCash(int amount)
        {

        }

        public void GiveAmount(int amount)
        {

        }

        public bool CheckBalance()
        {
            return false;
        }
        #endregion
    }
}
