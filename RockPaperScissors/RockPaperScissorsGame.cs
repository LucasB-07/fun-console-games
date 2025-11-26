using System;
using System.Globalization;
using System.Threading;

namespace RockPaperScissors
{
    class RockPaperScissors
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            CultureInfo.CurrentCulture = new CultureInfo("en-US");

            Console.Title = "Rock Paper Scissors";

            Console.WriteLine("< - - - - - - - - ✊ Rock Paper Scissors ✋ - - - - - - - - >");
            Thread.Sleep(1000);
            Console.WriteLine("Welcome to the Rock Paper Scissors Game! Below is some information: ");
            Thread.Sleep(1000);
            Console.WriteLine("You will be playing against the computer.");
            Thread.Sleep(1000);
            Console.WriteLine("Choose Rock, Paper, or Scissors to play. Rock beats Scissors, Scissors beats Paper, and Paper beats Rock.");
            Thread.Sleep(1000);
            Console.WriteLine("Try to win as many rounds as possible! Good luck and have fun. \n");
            Thread.Sleep(1000);

            var playAgain = true;
            Random random = new Random();

            while(playAgain)
            {
                Console.WriteLine();
                Console.WriteLine("Choose one of the following options:");
                Console.WriteLine("1. Rock");
                Console.WriteLine("2. Paper");
                Console.WriteLine("3. Scissors");
                Console.WriteLine();
                
                //player input with validation
                var playerChoice = "";
                var validChoice = false;
                while(!validChoice)
                {
                    tryCatchFinally(() =>
                    {
                        Console.Write("Enter your choice (rock, paper, scissors): ");
                        var answer = Console.ReadLine().Trim().ToLower();

                        if (answer.ToLower() == "test")
                        {
                            throw new ArgumentException("Test Activated ✅");
                        }
                        if (answer != "rock" && answer != "paper" && answer != "scissors")
                        {
                            throw new InvalidOperationException("Invalid choice. Please choose rock, paper, or scissors.");
                        }
                        playerChoice = answer;
                        validChoice = true;
                    });
                }
                //TODO: computer choice
            }
        }

        private static void tryCatchFinally(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[ERROR]: {ex.Message}");
                Console.ResetColor();
            }
            finally
            {
                Console.WriteLine("↪ try-catch has ended");
                Console.WriteLine();
            }
        }
    }
}