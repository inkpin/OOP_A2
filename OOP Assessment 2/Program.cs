using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assessment_2
{
    internal class Program
    {
        private static Three_or_More three_Or_More = new Three_or_More();
        private static Sevens_Out sevens_Out = new Sevens_Out();
        private static Testing debugging = new Testing();

        static void Main(string[] args)
        {
            //Going to run a couple tests to ensure that the program will work as expected.
            debugging.TestingRolls();
            debugging.TestingSevensOut();

            //Running the main menu
            Program program = new Program();
            program.MainMenu();
        }

        //Main menu, allows the user to select which game they wish to play, or exit.
        //Incorrect inputs are handled.
        public void MainMenu()
        {
            bool exit = false;
            Console.Clear();

            Console.WriteLine("**** Object-Oriented Programming. Assessment 2 - William Inkpin 28072184 ****");
            Console.WriteLine("\nWelcome to Sevens out or Three or More!\n\nYou have the option to decide on the game you wish to play, as well as " +
                "if you\nwould like to play with a friend or against the CPU.");


            string selectionText = "\nWhich game would you like to play?\n\n1.) Sevens Out\n2.) Three or More\n3.) Exit\n";
            Console.WriteLine(selectionText);

            //While loop allows the program to catch incorrect inputs.
            while (!exit)
            {
                ConsoleKeyInfo selectionKey = Console.ReadKey();
                int selection;


                if (int.TryParse(selectionKey.KeyChar.ToString(), out selection))
                {
                    switch (selection)
                    {
                        case 1:
                            sevens_Out.InitializeSevensOut();
                            break;
                        case 2:
                            three_Or_More.InitializeThreeOrMore();
                            break;
                        case 3:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("\nInvalid Input. Please enter a number between 1 and 3.");
                            Console.WriteLine(selectionText);
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\nInvalid Input. Please enter a number between 1 and 3.");
                    Console.WriteLine(selectionText);
                }
            }
        }
    }
}