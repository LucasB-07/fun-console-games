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

        }
    }
}