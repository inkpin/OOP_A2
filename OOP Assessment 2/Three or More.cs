using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assessment_2
{
    internal class Three_or_More : Game
    {
        //Initializing the die and main menu classes
        private const int targetScore = 20;

        //Method to store the variables for the statistics
        public void StatVariables()
        {
            NumberGamesPlayed = 0;
            SumOfDiceRolls = 0;
            NumberOfDiceRolls = 0;
        }

        //Initializer, just allows the user to select if they want to play singleplayer, multiplayer or see the statistics. 
        public void InitializeThreeOrMore()
        {
            bool inputValidation = false;
            Console.Clear();
            Console.WriteLine("Welcome to Three or More!");
            Console.WriteLine("\nRules: Roll 5 dice, hoping for 3 of a kind or better. If you don't score 3 of a kind, you score 0.\n" +
                "3 of a kind = 3 points.\n4 of a kind = 6 points.\n5 of a kind = 12 points.\nFirst to 20 points wins!");
            string threeOrMoreText = "\nHow would you like to play?\n\n1.) Singleplayer\n2.) Multiplayer\n3.) Statistics\n4.) Return to main menu\n5.) Exit\n";
            Console.WriteLine(threeOrMoreText);

            while (!inputValidation)
            {
                ConsoleKeyInfo selectionKey = Console.ReadKey();
                int selection;

                if (int.TryParse(selectionKey.KeyChar.ToString(), out selection))
                {
                    switch (selection)
                    {
                        case 1:
                            NumberGamesPlayed++;
                            Singleplayer();
                            break;
                        case 2:
                            NumberGamesPlayed++;
                            Multiplayer();
                            break;
                        case 3:
                            Statistics();
                            break;
                        case 4:
                            mainmenu.MainMenu();
                            break;
                        case 5:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Invalid Input. Please enter a number between 1-4!");
                            Console.WriteLine(threeOrMoreText);
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Input. Please enter a number between 1-4!");
                    Console.WriteLine(threeOrMoreText);
                }
            }
        }

        /// <summary>
        /// Method for the singleplayer aspect of the program. The user plays against the CPU. Simple method that handles the rolling and win conditions. 
        /// This method does not compute the scoring combinations.
        /// </summary>
        private void Singleplayer()
        {
            Console.Clear();
            Console.WriteLine("**** Three or More - Single Player ****\n");
            //Initialising the scores for both the user and the CPU
            int playerScore = 0;
            int computerScore = 0;

            //Game runs inside a win condition loop
            while (playerScore < targetScore && computerScore < targetScore)
            {
                Console.WriteLine("Press any key to roll the dice...");
                Console.ReadKey(true);
                Console.Clear();

                //Once the player presses a key, playerpoints holds the return value of the SingleplayerRoll method. This value is then added to the players score
                int playerPoints = Combinations();
                playerScore += playerPoints;

                //Win condition for the user
                if (playerScore >= targetScore)
                {
                    Console.Clear();
                    Console.WriteLine("**** Well Done! You've beaten the computer and reached the target score first! ****");
                    Console.WriteLine("\nPress any key to return to the main menu...");
                    Console.ReadKey();
                    mainmenu.MainMenu();
                    break;
                }
                else
                {
                    Console.WriteLine($"Your current score: {playerScore}");
                    Console.WriteLine($"You still need {targetScore - playerScore} to win!\n");
                }

                //CPU has a go, holds the return value of SingleplayerRoll in computerPoints, then adds it to the computerScore.
                int computerPoints = Combinations();
                computerScore += computerPoints;

                //Win condition for CPU
                if (computerScore >= targetScore)
                {
                    Console.Clear();
                    Console.WriteLine("**** Unfortunately, the computer has reached the target score first! Better luck next time! ****");
                    Console.WriteLine("\nPress any key to return to the main menu...");
                    Console.ReadKey();
                    mainmenu.MainMenu();
                    break;
                }
                else
                {
                    Console.WriteLine($"The computer's current score is: {computerScore}");
                    Console.WriteLine($"The computer needs {targetScore - computerScore} to win.\n");
                }
            }
        }

        /// <summary>
        ///Method for the multiplayer game mode of three or more. Allows two players to play against eachother to see who wins! Starts by asking for names to make the experience more personalised.  
        /// </summary>
        private void Multiplayer()
        {
            Console.Clear();
            Console.WriteLine("**** Three or More - Multiplayer ****\n");

            //Giving the users the option to enter their names, it will make the game feel more personalised
            string player1Name = "";
            string player2Name = "";
            Console.WriteLine("Please enter your names! (Must be greater than one character)");
            while (player1Name.Length < 1)
            {
                Console.Write("\nPlayer 1: ");
                player1Name = Console.ReadLine();
            }

            while (player2Name.Length < 1)
            {
                Console.Write("Player 2: ");
                player2Name = Console.ReadLine();
            }

            // Declaring variables to store player scores
            int player1Score = 0;
            int player2Score = 0;

            // Game loop until one player reaches the target score
            while (player1Score < targetScore && player2Score < targetScore)
            {
                Console.WriteLine($"\n{player1Name}'s turn. Press any key to roll the dice...");
                Console.ReadKey(true);
                Console.Clear();

                // Player 1's turn
                int player1Points = Combinations();
                player1Score += player1Points;

                // Win condition for player 1
                if (player1Score >= targetScore)
                {
                    Console.Clear();
                    Console.WriteLine($"**** Congratulations, {player1Name}! You've won the game! ****");
                    Console.WriteLine("\nPress any key to return to the main menu...");
                    Console.ReadKey();
                    mainmenu.MainMenu();
                    break;
                }
                else
                {
                    Console.WriteLine($"\n{player1Name}, your current score: {player1Score}");
                    Console.WriteLine($"{player2Name}'s current score: {player2Score}");
                    Console.WriteLine($"\n{player1Name}, you still need {targetScore - player1Score}!");
                }

                Console.WriteLine($"\n{player2Name}'s turn. Press any key to roll the dice...");
                Console.ReadKey(true);
                Console.Clear();

                // Player 2's turn
                int player2Points = Combinations();
                player2Score += player2Points;

                // Win condition for player 2
                if (player2Score >= targetScore)
                {
                    Console.Clear();
                    Console.WriteLine($"**** Congratulations, {player2Name}! You've won the game! ****");
                    Console.WriteLine("\nPress any key to return to the main menu...");
                    Console.ReadKey();
                    mainmenu.MainMenu();
                    break;
                }
                else
                {
                    Console.WriteLine($"\n{player2Name}, your current score: {player2Score}");
                    Console.WriteLine($"{player1Name}'s current score: {player1Score}");
                    Console.WriteLine($"\n{player2Name}, you still need {targetScore - player2Score}!");
                }
            }
        }

        /// <summary>
        /// Helper method for returning a value to either the player or the CPU's points variable. This method will roll the dice, save it to a list and then compare the values to see
        /// if there's a combination that can be counted as a score.
        /// </summary>
        private int Combinations()
        {
            Testing debugging = new Testing();

            //Creating a list named rolls, then rolling the dice 5 times in an interation loop. All 5 values are saved to the list. 
            List<int> rolls = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                rolls.Add(die.Roll());
            }

            debugging.ThreeOrMoreTesting(rolls);

            //string.Join used to display all of the values of the list, instead of System.Collections.Generic.List
            Console.WriteLine("Rolled: " + string.Join(", ", rolls));

            //Creating a new array with a length of 7
            int[] counting = new int[7];

            //Iterator roll holds each value in the list rolls then increments the list to keep track of the mode (highest occuring) roll.
            //For example if there's four 3's, the index point for 3 will contain the number 4.
            foreach (int roll in rolls)
            {
                counting[roll]++;
            }

            //Starts by initialising two integers. maxCount is for keeping track of the mode. maxValue is for keeping track of which dice has it's value inside maxCount.
            int maxCount = 0;
            int maxValue = 0;

            //For loop that will go through 6 times and checks if the value in the array is higher than the maxCount value. If so, the array index point is added to maxValue.
            for (int i = 1; i <= 6; i++)
            {
                if (counting[i] > maxCount)
                {
                    maxCount = counting[i];
                    maxValue = i;
                }
            }

            //Creating a variable that will keep track of the users score.
            int score = 0;

            //If statement that runs if the value in maxCount is higher than or equal to 3.
            if (maxCount >= 3)
            {
                //Switch statement that will assign the score depending on the maxCount value
                switch (maxCount)
                {
                    case 3:
                        score = 3;
                        Console.WriteLine($"This turn resulted in: {maxCount} {maxValue}'s! (+3 points)");
                        break;
                    case 4:
                        score = 6;
                        Console.WriteLine($"This turn resulted in: {maxCount} {maxValue}'s! (+6 points)");
                        break;
                    case 5:
                        score = 12;
                        Console.WriteLine($"This turn resulted in: {maxCount} {maxValue}'s! (+12 points)");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Unfortunately a combination wasn't rolled! (+0 points)");
            }

            //Updating statistic values
            NumberOfDiceRolls += 5;
            SumOfDiceRolls += rolls.Sum();

            //Return the score value so it can be assigned to a points variable within a different method.
            return score;
        }

        //Statistics method. Simply outputs the variables that are created at the start of the class
        public void Statistics()
        {
            Console.Clear();
            Console.WriteLine("Three or More Statistics\nNote: Singleplayer computer rolls are not counted.");
            Console.WriteLine($"\nGames played: {NumberGamesPlayed}");
            Console.WriteLine($"Sum of all dice rolls: {SumOfDiceRolls}");
            Console.WriteLine($"Number of dice rolled: {NumberOfDiceRolls}");
            Console.WriteLine("\nPress any key to return to the main menu...");
            Console.ReadKey();
            mainmenu.MainMenu();
        }
    }
}
