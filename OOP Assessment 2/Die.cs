using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assessment_2
{
    internal class Die
    {
        private static Random random = new Random();

        public int LastRoll { get; private set; }

        //Rolls a value between 1,6
        public int Roll()
        {
            LastRoll = random.Next(1, 7);
            return LastRoll;
        }
    }
}
