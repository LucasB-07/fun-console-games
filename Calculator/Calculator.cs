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
                //REBUILDING: Input for numbers with error handling and validation and operation

                var num1 = 0;
                var validNum1 = false;
                while (!validNum1)
                {
                    tryCatchFinally(() =>
                    {
                        Console.Write("Enter first number: ");
                        var num1 = Convert.ToDouble(Console.ReadLine());
                        var validNum1 = true;
                    });
                }

                var operation = "";
                var validOperation = false;
                while (validOperation)
                {
                    tryCatchFinally(() =>
                    {
                        Console.Write("Enter an operator (+, -, *, /): ");
                        var operation = Console.ReadLine().Trim();

                        if (operation != "+" && operation != "-" && operation != "*" && operation != "/")
                        {
                            throw new InvalidOperationException("Invalid operator. Please use +, -, *, or /.");
                        }
                        validOperation = true;
                    });
                }

                var num2 = 0;
                var validNum2 = false;
                while(!validNum2)
                {
                    tryCatchFinally(() =>
                    {
                       Console.Write("Enter second number: ");
                       var num2 = Convert.ToDouble(Console.ReadLine());
                       var validNum2 = true;
                    });
                }
                
                tryCatchFinally(() =>
                {
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
            Console.WriteLine("Thank you for using the calculator!");
            Console.WriteLine("❤️ Made With Love By LucasB-07 ❤️\n");
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