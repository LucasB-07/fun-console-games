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
                //+ attempts + hints + congratulations message
                while (!guessed)
                {
                    //REBUILDING: Input for guess with error handling and validation
                    int guess = 0;
                    var valid = false;
                    while (!valid)
                    {
                        tryCatchFinally(() =>
                        {
                            Console.Write("Enter your guess: ");
                            var inputGuess = Console.ReadLine();

                            if (inputGuess.ToLower() == "test")
                            {
                                throw new ArgumentException($"Test Activated ✅");
                            }

                            if (!int.TryParse(inputGuess, out guess) || guess < 1 || guess > 100)
                            {
                                throw new ArgumentOutOfRangeException("Please enter a valid number between 1 and 100.");
                            }
                            valid = true;
                        });
                    }
                    //REBUILDING: Check guess against secret number + give hints + track attempts + congratulate
                    tryCatchFinally(() =>
                    {
                        attempts +=1;

                        if (guess < secretNumber)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("[COMPUTER]: Higher! ⬆");
                            Console.ResetColor();
                        }
                        else if (guess > secretNumber)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("[COMPUTER]: Lower! ⬇");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine("═══════════════════════════════════════════════════════════════");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"[COMPUTER]: Congratulations! You've guessed the number {secretNumber} in {attempts} attempts! 🎉");
                            Console.ResetColor();
                            Console.WriteLine("═══════════════════════════════════════════════════════════════");
                            guessed = true;
                        }
                    });
                }
                //TODO: Play again?
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
                        Console.ResetColor();
                    }
                }
            }
            Console.WriteLine("Thank you for using the calculator");
            Console.WriteLine("❤️ Made With Love By LucasB-07 ❤️\n");
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