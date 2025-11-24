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
                    Console.Write("Enter first number: ");
                    var num1 = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Enter an operator (+, -, *, /): ");
                    var operation = Console.ReadLine();

                    Console.Write("Enter second number: ");
                    var num2 = Convert.ToDouble(Console.ReadLine());

                    //TODO: switch case for operations
                    double result = 0;
                    switch (operation)
                    {
                        case "+":
                            result = num1 + num2;
                            break;
                        case "-": 
                            result = num1 - num2;
                            break;
                        case "*":
                            result = num1 * num2;
                            break;
                        case "/":
                            if (num2 == 0)
                            {
                                throw new DivideByZeroException("Cannot divide by zero.");
                            }
                            result = num1 / num2;
                            break;
                        default:
                            throw new InvalidOperationException("Invalid operator. Please use +, -, *, or /.");
                    }

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"Result: {num1} {operation} {num2} = {result}");
                    Console.ResetColor();
                });

                //TODO: ask to calculate again
                while (true)
                {
                    Console.Write("Do you want to calculate again? (yes/no): ");
                    var answer = Console.ReadLine().ToLower();
                    
                    if (answer == "yes")
                    {
                        break;
                    }
                    else if (answer == "no")
                    {
                        calculateAgain = false;
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
            //TODO: outro message
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