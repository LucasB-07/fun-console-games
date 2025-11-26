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

            Console.Title = "RockPaperScissors";

            Console.WriteLine("< - - - - - - - - ✊ Rock Paper Scissors ✋ - - - - - - - - >");
            Thread.Sleep(1000);
            Console.WriteLine("Welcome to the Rock Paper Scissors Game!");
        }
    }
}