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

            //TODO: While not correct at guessed, ask question + hidden test trigger + validate input between 1-100 + attempts + hints + error handling

            //TODO: Congratulate + show attempts + play again prompt

            //TODO: Play again?
        }
    }
}