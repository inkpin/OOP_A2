using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assessment_2
{
    public class Testing
    {

        /// <summary>
        /// The purpose of the Debugging method is to comapre the values rolled in the game class and ensure they meet the criteria. 
        /// The method also compares the sum by adding the values from DiceResultLog
        /// </summary>

        private Sevens_Out sevensOut = new Sevens_Out();
        private Three_or_More threeOrMore = new Three_or_More();
        private Die die = new Die();

        //Rolling the dice 50 times and ensuring that none of the rolls fall out of the scope.
        public void TestingRolls()
        {
            List<int> rollResults = new List<int>();
            int numberOfRolls = 50;

            for (int i = 0; i < numberOfRolls; i++)
            {
                int roll = die.Roll();
                rollResults.Add(roll);
            }
            foreach (int roll in rollResults)
            {
                Debug.Assert(roll >= 1 && roll <= 6, $"The roll {roll} is out of range!!!");
            }
        }

        //A test to ensure that double rolls are to be handled correctly. Uses a method within the Sevens Out class.
        //If doubles aren't handled correctly, then there's likely to be a logic error within the sevens out game. 
        public void TestingSevensOut()
        {
            //Creating a list with an example of a double roll, in this case, two 4's
            List<int> doubleRolls = new List<int> {4,4};
            int expectedValue = 8;

            int actualScore = sevensOut.TestDoubleRolls(doubleRolls);
            Debug.Assert(actualScore == expectedValue, $"Error. Double rolls are incorrectly handled. Expected score: {expectedValue}. Actual score: {actualScore}");
        }

        //Simple test that takes a list parameter from the Three or More class and ensures that all rolls are within the scope.
        public void ThreeOrMoreTesting(List<int> rolls)
        {
            foreach (int roll in rolls)
            {
                Debug.Assert(roll >= 1 && roll <= 6, $"The roll {roll} is out of range!!!");
            }
        }
    }
}