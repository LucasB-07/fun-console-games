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
            Console.WriteLine("< - - - - - - - - - - - - - - - - - - - - - - - - - - - - - >");

            var playAgain = true;
            Random random = new Random();

            while(playAgain)
            {
                //TODO: Add score tracking system
                
                Console.WriteLine();
                Console.WriteLine("Choose one of the following options:");
                Console.WriteLine("1. Rock");
                Console.WriteLine("2. Paper");
                Console.WriteLine("3. Scissors");
                Console.WriteLine();
                
                var playerChoice = "";
                var validChoice = false;
                while(!validChoice)
                {
                    tryCatchFinally(() =>
                    {
                        Console.Write("Enter your choice (rock, paper, scissors): ");
                        var answer = Console.ReadLine().Trim().ToLower();

                        if (answer == "test")
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

                string computerChoice = "";
                tryCatchFinally(() =>
                {
                    computerChoice = ConvertChoice(random.Next(1,4));
                    Console.WriteLine($"[COMPUTER]: I chose {computerChoice}.");
                });
                Console.WriteLine("═══════════════════════════════════════════════════════════════");

                string result = "";
                tryCatchFinally(() =>
                {
                    switch (playerChoice)
                    {
                        case "rock":
                            if (computerChoice == "rock")
                            {
                                result = "Its a tie!";
                            }
                            else if (computerChoice == "paper")
                            {
                                result = "Computer wins!";
                            }
                            else if (computerChoice == "scissors")
                            {
                                result = "You win!";
                            }
                            break;
                        case "paper":
                            if (computerChoice == "rock")
                            {
                                result = "You win!";
                            }
                            else if (computerChoice == "paper")
                            {
                                result = "Its a tie!";
                            }
                            else if (computerChoice == "scissors")
                            {
                                result = "Computer wins!";
                            }
                            break;
                        case "scissors":
                            if (computerChoice == "rock")
                            {
                                result = "Computer wins!";
                            }
                            else if (computerChoice == "paper")
                            {
                                result = "You win!";
                            }
                            else if (computerChoice == "scissors")
                            {
                                result = "Its a tie!";
                            }
                            break;
                        default:
                            throw new InvalidOperationException("An error occurred while determining the winner.");
                    }
                });
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(result);
                Console.ResetColor();
                Console.WriteLine("═══════════════════════════════════════════════════════════════");
                
                while (true)
                {
                    Console.Write("Do you want to play again? (yes/no): ");
                    var answer = Console.ReadLine().ToLower();

                    if (answer == "yes")
                    {
                        break;
                    }
                    else if (answer == "no")
                    {
                        playAgain = false;
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input! Please type 'yes' or 'no'.");
                        Console.WriteLine();
                        Console.ResetColor();
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("Thank you for using the Rock Paper Scissors Game!");
            Console.WriteLine("❤️ Made With Love By LucasB-07 ❤️\n");
        }
        
        private static string ConvertChoice(int choice)
        {
            switch(choice)
            {
                case 1:
                    return "rock";
                case 2:
                    return "paper";
                case 3:
                    return "scissors";
                default:
                    throw new ArgumentOutOfRangeException("Invalid choice number.");
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