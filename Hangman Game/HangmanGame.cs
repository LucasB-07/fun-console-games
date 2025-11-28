using System;
using System.Globalization;
using System.Threading;

namespace HangmanGame
{
    class Hangman
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            CultureInfo.CurrentCulture = new CultureInfo("en-US");
            Console.Title = "Hangman Game";

            Console.WriteLine("< - - - - - - - - 🪢 Hangman Game 🪢 - - - - - - - - >");
            Thread.Sleep(1000);
            Console.WriteLine("Welcome to the Hangman Game! Below is some information: ");
            Thread.Sleep(1000);
            Console.WriteLine("Try to guess the secret word one letter at a time.");
            Thread.Sleep(1000);
            Console.WriteLine("You have 7 attempts to guess the word correctly before the hangman is completed.");
            Thread.Sleep(1000);
            Console.WriteLine("Good luck and have fun! \n");
            Thread.Sleep(1000);
            Console.WriteLine("< - - - - - - - - - - - - - - - - - - - - - - - - - - - >");

            string[] words = { "computer", "hangman", "gaming", "csharp", "software" };
            Random random = new Random();

            string secretWord = words[random.Next(words.Length)];
            char[] display = new string('_', secretWord.Length).ToCharArray();

            int attemptLeft = 7;
            string guessedLetters = "";

            //Game loop, continues until attempts run out or word is guessed
            while (attemptLeft > 0 && new string(display).Contains('_'))
            {
                Console.WriteLine($"Word: {new string(display)}");
                Console.WriteLine($"Attempts left: {attemptLeft}");
                Console.WriteLine($"Guessed letters: {guessedLetters}");
                Console.Write("Guess a letter: ");
                
                //rest of the code
                //Checking if string input is valid, not longer than 1 char and not already guessed
                string input = Console.ReadLine().ToLower();
                if (input.Length != 1 )
                {
                    System.Console.WriteLine("Please enter a single letter.\n");
                    continue;
                }
                char guessedLetter = input[0];

                //check if the input is a letter
                if (!char.IsLetter(guessedLetter))
                {
                    Console.WriteLine("Please enter a valid letter (a-z).\n");
                    continue;
                }

                //Takes the first character of the input string
                if (guessedLetters.Contains(guessedLetter))
                {
                    Console.WriteLine("You already guessed that letter. Try again.\n");
                    continue;
                }
                
                //Add guessed letter with a space for reading clarity
                guessedLetters += guessedLetter + " ";

                //Check if guessed letter is in the secret word
                if (secretWord.Contains(guessedLetter))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Correct guess!\n");
                    Console.ResetColor();

                    //Replace underscores with correctly guessed letters
                    for (int i = 0; i < secretWord.Length; i +=1)
                    {
                        if (secretWord[i] == guessedLetter)
                        {
                            display[i] = guessedLetter;
                        }
                    }
                }
                else
                {
                    attemptLeft -= 1;
                    PrintHangman(attemptLeft);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong guess!\n");
                    Console.ResetColor();
                }
            }

            //rest of the code
            //Game over, display result
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            if (!new string(display).Contains('_'))
            {
                Console.WriteLine($"Congratulations! You've guessed the word: {secretWord}");
            }
            else
            {
                Console.WriteLine($"Game Over! The correct word was: {secretWord}");
            }
            Console.WriteLine("═══════════════════════════════════════════════════════════════");

            Console.WriteLine("Thank you for using the Hangman game!");
            Console.WriteLine("❤️ Made With Love By LucasB-07 ❤️\n");
        }

        static void PrintHangman(int attemptsLeft)
        {
            if (attemptsLeft < 0)
            {
                attemptsLeft = 0;
            }
            if (attemptsLeft > 7)
            {
                attemptsLeft = 7;
            }
            string[] hangman = new string[]
            {
                @"
      _______
     |/      |
     |      ( )
     |      /|\
     |      / \
     |
    _|___",
                @"
      _______
     |/      |
     |      ( )
     |      /|\
     |      /
     |
    _|___",
                @"
      _______
     |/      |
     |      ( )
     |      /|\
     |
     |
    _|___",
                @"
      _______
     |/      |
     |      ( )
     |      /|
     |
     |
    _|___",
                @"
      _______
     |/      |
     |      ( )
     |       |
     |
     |
    _|___",
                @"
      _______
     |/      |
     |      ( )
     |
     |
     |
    _|___",
                @"
      _______
     |/      |
     |
     |
     |
     |
    _|___",
                @"
      _______
     |/
     |
     |
     |
     |
    _|___"
            
            };
            Console.WriteLine(hangman[7 - attemptsLeft]);
        }
    }
}