using System;
using System.Globalization;
using System.Threading;

namespace DiceGame
{
    class DiceGame
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            CultureInfo.CurrentCulture = new CultureInfo("en-US");

            Console.Title = "Dice Game";

            Console.WriteLine("< - - - - - - - - 🎲 Dice Game 🎲 - - - - - - - - >");
            Thread.Sleep(1000);
            Console.WriteLine("Welcome to the Dice Game! Below is some information: ");
            Thread.Sleep(1000);
            Console.WriteLine("You play with a die, and have to keep rolling until you reach 30.");
            Thread.Sleep(1000);
            Console.WriteLine("The one who scores more than 30 points wins the game! Good luck and hav fun. \n");
            Thread.Sleep(1000);
            Console.WriteLine("< - - - - - - - - - - - - - - - - - - - - - - - - >");
            Thread.Sleep(1000);

            var playAgain = true;
            while (playAgain)
            {
                Random random = new Random();

                var score1 = 0;
                var score2 = 0;
                const int goal = 30;

                string player1 = "";
                string player2 = "";

                tryCatchFinally(() =>
                {
                    Console.Write("Player 1 name: ");
                    player1 = Console.ReadLine();
                    if (player1.ToLower() == "test")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Test Activated ✅");
                        Console.ResetColor();
                        player1 = "TestPlayer1";
                    }
                });
                tryCatchFinally(() =>
                {
                    Console.WriteLine("Player 2 name: ");
                    player2 = Console.ReadLine();
                    if (player2.ToLower() == "test")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Test Activated ✅");
                        Console.ResetColor();
                        player2 = "TestPlayer2";
                    }
                });

                Console.WriteLine();
                while (score1 < goal && score2 < goal)
                {
                    // Player 1 turn:
                    tryCatchFinally(() =>
                    {
                        Console.Write($"{player1}'s turn! Press Enter to roll the die: ");
                        Console.ReadLine();
                        if (player1.ToLower() == "test")
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            throw new ArgumentException($"Test Activated, for {player1} ✅");
                        }

                        var roll1 = random.Next(1, 7);
                        Console.WriteLine($"{player1} rolls the die! (rolled: {roll1})");

                        score1 += roll1;
                        Console.WriteLine($"Score: {score1} ");
                    });
                    // Player 2 turn:
                    tryCatchFinally(() =>
                    {
                        Console.Write($"{player2}'s turn! Press Enter to roll the die: ");
                        Console.ReadLine();
                        if (player1.ToLower() == "test")
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            throw new ArgumentException($"Test Activated, for {player2} ✅");
                        }

                        var roll2 = random.Next(1, 7);
                        Console.WriteLine($"{player2} rolls the die! (rolled: {roll2})");

                        score2 += roll2;
                        Console.WriteLine($"Score: {score2} ");
                    });
                }

                // Final Score:
                Console.WriteLine();
                Console.WriteLine("═══════════════════════════════");
                Console.WriteLine("🎉 FINAL SCORE 🎉");
                Console.WriteLine($"{player1}: {score1} points. ");
                Console.WriteLine($"{player2}: {score2} points. ");
                Console.WriteLine("═══════════════════════════════");

                // Determine Winner:
                string winner;
                if (score1 >= goal)
                {
                    winner = player1;
                }
                else if (score2 >= goal)
                {
                    winner = player2;
                }
                else
                {
                    winner = null;
                    Console.WriteLine("Unknown winner");
                }

                Console.WriteLine($"🏆 The winner is: {winner}, congrats! ");
                Console.WriteLine("═══════════════════════════════");
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