using System;
using System.Globalization;
using System.Threading;

namespace HangmanGame
{
    class Hangman
    {
        static void Main()
        {
            string[] words = { "computer", "hangman", "gaming", "csharp", "software" };
            Random random = new Random();

            string secretWord = words[random.Next(words.Length)];
            char[] display = new string('_', secretWord.Length).ToCharArray();

            int attemptLeft = 7;
            string guessedLetters = "";

            Console.WriteLine("Hangman (Basic Version, for now)");

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
                //Takes the first character of the input string
                char guessedLetter = input[0];
                if (guessedLetters.Contains(guessedLetter))
                {
                    Console.WriteLine("You already guessed that letter. Try again.\n");
                    continue;
                }
            }

            //rest of the code

        }
    }
}