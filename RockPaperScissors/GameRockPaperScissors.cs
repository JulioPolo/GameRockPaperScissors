using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    class GameRockPaperScissors
    {
        private Random rng;
        private int ties = 0;
        private int wins = 0;
        private int loses = 0;

        public GameRockPaperScissors()
        {
            rng = new Random();
        }

        public void Play()
        {
            string userChoice;

            userChoice = GetUserChoice();

            while (userChoice != "Q")
            {
                string computerChoice = GetComputerChoice();
                Console.WriteLine();
                DetermineWinner(userChoice, computerChoice);
                PrintScore();
                Console.Clear();
                userChoice = GetUserChoice();
            }
            PrintScore();
        }
        public void PlayComputer()
        {
            string length = GetNumberOfPlays();

            for (int i = 1; i <= int.Parse(length); i++)
            {
                string c1 = GetComputerChoice();
                string c2 = GetComputerChoice();
                DetermineWinner(c1, c2);
            }
            PrintScore();
        }

        private static string GetNumberOfPlays()
        {
            Console.Write("Enter the number of plays ");
            string length = Console.ReadLine();
            return length;
        }

        private void PrintScore()
        {
            double TotalPlays = 100d / (wins + loses + ties);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("Wins: \t\t{0} \t{1:0.00}%", wins, (wins * TotalPlays));
            Console.WriteLine("Losses: \t{0} \t{1:0.00}%", loses, (loses * TotalPlays));
            Console.WriteLine("Ties: \t\t{0} \t{1:0.00}%", ties, (ties * TotalPlays));
            Console.WriteLine();
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void DetermineWinner(string userChoice, string computerChoice)
        {
            if (userChoice == computerChoice)
            {
                ties++;
                Console.WriteLine("You both picked {0}, you tied!", ConvertChoiceToWord(userChoice));
            }
            else if ((userChoice == "R" && computerChoice == "S") || (userChoice == "S" && computerChoice == "P") || (userChoice == "P" && computerChoice == "R"))
            {
                wins++;
                Console.WriteLine("You picked {0} and the computer picked {1}, you WIN!", ConvertChoiceToWord(userChoice), ConvertChoiceToWord(computerChoice));
            }
            else
            {
                loses++;
                Console.WriteLine("You picked {0} and the computer picked {1}, you lose!", ConvertChoiceToWord(userChoice), ConvertChoiceToWord(computerChoice));
            }

        }

        private string ConvertChoiceToWord(string choice)
        {
            if (choice == "R")
                return "Rock";
            else if (choice == "P")
                return "Paper";
            else return "Scissors";
        }

        private string GetComputerChoice()
        {
            int choice = rng.Next(1, 4);

            if (choice == 1)
                return "R";
            else if (choice == 2)
                return "P";
            else
                return "S";
        }

        private string GetUserChoice()
        {
            string userInput = "";
            while (true)
            {
                Console.Write("Enter your play: [R]ock, [P]aper, [S]cissors or [Q]uit  ");
                userInput = Console.ReadLine().ToUpper();

                if((userInput == "R") || (userInput == "P") || (userInput == "S") || (userInput == "Q"))
                    return userInput;
                else
                    Console.WriteLine("You enter the wrong key!");
            }

        }
    }
}
