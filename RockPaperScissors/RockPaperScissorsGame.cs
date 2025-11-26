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

            
        }
    }
}