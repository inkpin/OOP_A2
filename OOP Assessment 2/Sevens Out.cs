using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assessment_2
{ 
    internal class Sevens_Out : Game
    {
        //Initializing the die class, as well as setting variables for the target score and the players/cpu's score
        private const int targetNumber = 77;

        //Method to store the variables for the statistics
        public void StatVariables()
        {
            NumberGamesPlayed = 0;
            SumOfDiceRolls = 0;
            NumberOfDiceRolls = 0;
        }

        /// <summary>
        /// Method to start the Sevens Out game. The user has the option to play singleplayer (against the CPU), or multiplayer as long as both players have access to the same machine.
        /// There is also the option for a statistics page which will display how many games have been played and how many dice have been rolled. 
        /// </summary>
        public void InitializeSevensOut()
        {
            //Boolean variable will handle incorrect inputs
            bool inputValidation = false;
            Console.Clear();
            Console.WriteLine("Welcome to Sevens Out!");
            Console.WriteLine("\nRules: At the press of a key, the player will roll two dice. The sum of the dice rolls are \nadded to a total, first to 77 wins!\n" +
                "If you roll a double, your score is doubled. If you roll a 7, you miss a turn!");
            string sevensOutText = "\nHow would you like to play?\n\n1.) Singleplayer\n2.) Multiplayer\n3.) Statistics\n4.) Return to the main menu\n5.) Exit\n";
            Console.WriteLine(sevensOutText);

            //Switch statement allowing the user to select singleplayer, multiplayer, statistics or to return to the main menu
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
                            SinglePlayer();
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
                            Console.WriteLine(sevensOutText);
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Input. Please enter a number between 1-4!");
                    Console.WriteLine(sevensOutText);
                }
            }
        }

        //Method for the singleplayer logic. There's variables to store the data for both the user and the CPU.
        private void SinglePlayer()
        {
            Console.Clear();
            Console.WriteLine("**** Sevens Out - Single Player ****\n");
            int playerScore = 0;
            int computerScore = 0;

            //Runs until win condition met
            while (playerScore < targetNumber && computerScore < targetNumber)
            {
                Console.WriteLine("Press any key to roll the dice...");
                Console.ReadKey(true);
                Console.Clear();

                //Rolling two dice for the user and saving the result to playerTotal.
                int playerRoll1 = die.Roll();
                int playerRoll2 = die.Roll();
                int playerTotal = playerRoll1 + playerRoll2;

                //Updating number and sum of dice rolls for statistics
                if (playerRoll1 != 7 && playerRoll2 != 7)
                {
                    NumberOfDiceRolls += 2;
                    SumOfDiceRolls += playerRoll1 + playerRoll2;
                }

                //Checking if the user has rolled a 7, if so they miss a turn
                if (playerTotal == 7)
                {
                    Console.WriteLine($"You rolled a {playerRoll1} and a {playerRoll2}! This equals 7! You missed this turn.");
                }
                else
                {
                    Console.WriteLine($"You rolled: {playerRoll1} and {playerRoll2} (Total: {playerTotal})");

                    //Checking if the user has rolled a double
                    if (playerRoll1 == playerRoll2)
                    {
                        playerTotal *= 2;
                        Console.WriteLine("You rolled a double! Your score for this turn is doubled!");
                    }

                    playerScore += playerTotal;
                }

                //Checking win condition for user
                if (playerScore >= targetNumber)
                {
                    Console.Clear();
                    Console.WriteLine("**** Well Done! You've beaten the computer and rolled 77 or higher first! ****");
                    Console.WriteLine("\nPress any key to return to the main menu...");
                    Console.ReadKey();
                    mainmenu.MainMenu();
                    break;
                }
                else
                {
                    Console.WriteLine($"Current score: {playerScore}");
                    Console.WriteLine($"You still need {targetNumber - playerScore}!");

                    //CPU's turn
                    int computerRoll1 = die.Roll();
                    int computerRoll2 = die.Roll();
                    int computerTotal = computerRoll1 + computerRoll2;

                    //Checking if the CPU rolls a 7
                    if (computerTotal == 7)
                    {
                        Console.WriteLine($"\nThe computer has rolled a {computerRoll1} and a {computerRoll2}! This equals 7! This turn was missed.");
                    }
                    else
                    {
                        Console.WriteLine($"\nComputer rolled: {computerRoll1} and {computerRoll2} (Total: {computerTotal})");

                        //Checking for CPU double rolls
                        if (computerRoll1 == computerRoll2)
                        {
                            computerTotal *= 2;
                            Console.WriteLine("The CPU has rolled a double. Their score is doubled for this round!");
                        }

                        computerScore += computerTotal;
                    }

                    //Checking win condition for CPU
                    if (computerScore >= targetNumber)
                    {
                        Console.Clear();
                        Console.WriteLine("**** Unfortunately, the computer has rolled to 77 first! Better luck next time! ****");
                        Console.WriteLine("\nPress any key to return to the main menu...");
                        Console.ReadKey();
                        mainmenu.MainMenu();
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"The computer's current score is: {computerScore}");
                        Console.WriteLine($"The computer needs {targetNumber - computerScore} to win.\n");
                    }
                }
            }
        }

        //Method for multiplayer. Two players can play this, game logic near enough the same but modified to allow to players to compete against eachother
        private void Multiplayer()
        {
            Console.Clear();
            Console.WriteLine("**** Sevens Out - Multiplayer ****\n");

            //Giving the users the chance to input their names to make it seem more personal. No need for error checking here, user can input whatever they wish
            Console.Write("Enter Player 1's name: ");
            string player1Name = Console.ReadLine();
            Console.Write("Enter Player 2's name: ");
            string player2Name = Console.ReadLine();

            //Declaring variables to store player scores
            int player1Score = 0;
            int player2Score = 0;

            //Same as singleplayer method, runs until the win condition is met
            while (player1Score < targetNumber && player2Score < targetNumber)
            {
                Console.WriteLine($"\n{player1Name}'s turn. Press any key to roll the dice...");
                Console.ReadKey(true);
                Console.Clear();

                //Rolling 2 dice for player 1
                int player1Roll1 = die.Roll();
                int player1Roll2 = die.Roll();
                int player1Total = player1Roll1 + player1Roll2;

                //Updating number and sum of dice rolls for the statistics
                if (player1Roll1 != 7 && player1Roll2 != 7)
                {
                    NumberOfDiceRolls += 2;
                    SumOfDiceRolls += player1Roll1 + player1Roll2;
                }

                //Checking to see if the player rolled a 7, if so they miss a turn
                if (player1Total == 7)
                {
                    Console.WriteLine($"{player1Name} rolled a {player1Roll1} and a {player1Roll2}! This equals 7! {player1Name} misses this turn.");
                }
                else
                {
                    Console.WriteLine($"{player1Name} rolled: {player1Roll1} and {player1Roll2} (Total: {player1Total})");

                    //Checking if player 1 rolled a double
                    if (player1Roll1 == player1Roll2)
                    {
                        player1Total *= 2;
                        Console.WriteLine($"{player1Name} rolled a double! {player1Name}'s score for this turn is {player1Total}");
                    }
                    player1Score += player1Total;
                }

                //Win condition for player 1
                if (player1Score >= targetNumber)
                {
                    Console.Clear();
                    Console.WriteLine($"**** Congratulations, {player1Name}! You've won the game! ****");
                    Console.WriteLine("\nPress any key to return the the main menu...");
                    Console.ReadKey();
                    mainmenu.MainMenu();
                    break;
                }
                else
                {
                    Console.WriteLine($"\n{player1Name}, your current score: {player1Score}");
                    Console.WriteLine($"{player2Name}'s current score: {player2Score}");
                    Console.WriteLine($"\nYou still need {targetNumber - player1Score}!");
                }

                Console.WriteLine($"\n{player2Name}'s turn. Press any key to roll the dice...");
                Console.ReadKey(true);
                Console.Clear();

                //Rolling the dice for player 2
                int player2Roll1 = die.Roll();
                int player2Roll2 = die.Roll();
                int player2Total = player2Roll1 + player2Roll2;

                //Again updating variables for the statiscits, but for player 2's rolls
                if (player2Roll1 != 7 && player2Roll2 != 7)
                {
                    NumberOfDiceRolls += 2;
                    SumOfDiceRolls += player2Roll1 + player2Roll2;
                }

                //Checking if player 2 rolled a 7
                if (player2Total == 7)
                {
                    Console.WriteLine($"{player2Name} rolled a {player2Roll1} and a {player2Roll2}! This equals 7! {player2Name} misses this turn.");
                }
                else
                {
                    Console.WriteLine($"{player2Name} rolled: {player2Roll1} and {player2Roll2} (Total: {player2Total})");

                    if (player2Roll1 == player2Roll2)
                    {
                        player2Total *= 2;
                        Console.WriteLine($"{player2Name} rolled a double! {player2Name}'s score for this turn is: {player2Total}");
                    }
                    player2Score += player2Total;
                }

                //Win condition for player 2
                if (player2Score >= targetNumber)
                {
                    Console.Clear();
                    Console.WriteLine($"**** Congratulations, {player2Name}! You've won the game! ****");
                    Console.WriteLine("\nPress any key to return the the main menu...");
                    Console.ReadKey();
                    mainmenu.MainMenu();
                    break;
                }
                else
                {
                    Console.WriteLine($"\n{player2Name}, your current score = {player2Score}");
                    Console.WriteLine($"{player1Name}'s current score = {player1Score}");
                    Console.WriteLine($"\nYou still need {targetNumber - player2Score}!");
                }
            }
        }

        //Method for testing double rolls.
        public int TestDoubleRolls(List<int> rolls)
        {
            int score = 0;
            if (rolls.Count == 2 && rolls[0] == rolls[1])
            {
                score = rolls[0] * 2;
            }
            return score;
        }

        //Statistics method, the statistics are counted as the games are played and then displayed here if the user wishes to see them. Simple method to output data.
        public void Statistics()
        {
            Console.Clear();
            Console.WriteLine("Sevens Out Statistics\nNote: Singleplayer computer rolls are not counted.");
            Console.WriteLine($"\nGames played: {NumberGamesPlayed}");
            Console.WriteLine($"Sum of all dice rolls: {SumOfDiceRolls}");
            Console.WriteLine($"Number of dice rolled: {NumberOfDiceRolls}");
            Console.WriteLine("\nPress any key to return to the main menu...");
            Console.ReadKey();
            mainmenu.MainMenu();
        }
    }
}