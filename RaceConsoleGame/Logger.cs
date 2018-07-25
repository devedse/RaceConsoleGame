using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceConsoleGame
{
    class Logger
    {
        public Logger()
        {
        }

        public void Write(string txt)
        {
            Console.WriteLine(txt);
            File.AppendAllText("output.txt", txt + Environment.NewLine);
        }
    }
}
