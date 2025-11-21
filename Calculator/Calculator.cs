using System;
using System.Globalization;

namespace Calculator
{
    class Calculator
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            CultureInfo.CurrentCulture = new CultureInfo("en-US");

            Console.Title = "Calculator";

            Console.WriteLine("< - - - - - - - - 🖩 Calculator 🖩 - - - - - - - - >");
            Thread.Sleep(1000);
            Console.WriteLine("you can choose from the following operations: ");
            Thread.Sleep(700);
            Console.WriteLine("1. Addition (+) ");
            Thread.Sleep(400);
            Console.WriteLine("2. Subtraction (-) ");
            Thread.Sleep(400);
            Console.WriteLine("3. Multiplication (*) ");
            Thread.Sleep(400);
            Console.WriteLine("4. Division (/) ");
            Thread.Sleep(1000);
            Console.WriteLine("< - - - - - - - - - - - - - - - - - - - - - - - - >");

            var calculateAgain = true;
            while (calculateAgain)
            {
                tryCatchFinally(() =>
                {

                });
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