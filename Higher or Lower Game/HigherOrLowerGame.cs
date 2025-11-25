using System;
using System.Globalization;
using System.Threading;

namespace HigherOrLowerGame
{
    class HigherOrLowerGame
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            CultureInfo.CurrentCulture = new CultureInfo("en-US");

            Console.Title = "Higher or Lower Game";
            Console.WriteLine("< - - - - - - - - 📈 Higher or Lower Game 📉 - - - - - - - - >");
            Thread.Sleep(1000);
            Console.WriteLine("Welcome to the Higher or Lower Game! Below is some information: ");
            Thread.Sleep(1000);
            Console.WriteLine("The computer picks a random number between 1 and 100.");
            Thread.Sleep(1000);
            Console.WriteLine("You must guess the number. After each guess, the computer will tell you whether you need to go higher or lower.");
            Thread.Sleep(1000);
            Console.WriteLine("Try to guess the number in as few attempts as possible! Good luck and have fun. \n");
            Thread.Sleep(1000);
            Console.WriteLine("< - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - >");

            //TODO: While true loop to play again + generate random number
            var playAgain = true;
            while (playAgain)
            {
                Random random = new Random();
                var secretNumber = random.Next(1, 101);
                var attempts = 0;
                var guessed = false;

                Console.WriteLine("[COMPUTER]: I have chosen a number between 1 and 100. Can you guess it?");

                //TODO: While not correct at guessed, ask question + hidden test trigger + validate input between 1-100
                //+ attempts + hints + error handling
                while (!guessed)
                {
                    tryCatchFinally(() =>
                    {
                        Console.Write("Enter your guess: ");
                        var inputGuess = Console.ReadLine();

                        if (inputGuess.ToLower() == "test")
                        {
                            throw new ArgumentException($"Test Activated ✅");
                        }

                        var guess;
                        if (!int.TryParse(inputGuess, out guess) || guess < 1 || guess > 100)
                        {
                            throw new ArgumentOutOfRangeException("Please enter a valid number between 1 and 100.");
                            return;
                        }
                    });
                }
            }


            //TODO: Congratulate + show attempts + play again prompt

            //TODO: Play again?
        }

        // Error handling method
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