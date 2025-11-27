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

        }
    }
}