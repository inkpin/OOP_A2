using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assessment_2
{
    //This is a class that will demonstrate inheritance. Private variables are declared here, as well as initializing the program and die classes
    internal class Game
    {
        /// <summary>
        /// These three variables are used by both the sevens out and three or more classes, therefore allowing both of those classes to inherit from 
        /// this class will improve code readability and demonstrate inheritance.
        /// </summary>
        protected int NumberGamesPlayed { get; set; }
        protected int SumOfDiceRolls { get; set; }
        protected int NumberOfDiceRolls { get; set; }


        protected Program mainmenu = new Program();
        protected Die die = new Die();
    }
}
