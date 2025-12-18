// DISCLAIMER:
// This project is intended solely for educational and developmental purposes.
// It is not designed or suitable for real-world, production, operational or security-critical use.
// The author accepts no responsibility or liability for any consequences arising from misuse.
// MUST NOT BE USED IN PRODUCTION OR SECURITY-CRITICAL SYSTEMS.

using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Globalization;
using System.Security.Cryptography;

enum MenuOption
{
    PasswordGenerator = 1,
    Passwordchecker = 2,
    Exit = 3,
}

abstract class PasswordTool
{
    public abstract void Run();
}

class PasswordGeneratorTool : PasswordTool
{
    public override void Run()
    {
        PasswordGenerator.RunPasswordGenerator();
    }
}

class PasswordCheckerTool : PasswordTool
{
    public override void Run()
    {
        PasswordChecker.RunPasswordChecker();
    }
}

class PasswordTools
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        CultureInfo.CurrentCulture = new CultureInfo("en-US");

        Console.Title = "Password Tools";

        while (true)
        {
            Console.Clear();
            Console.WriteLine("< - - - - - - - - 🔐 Password Tools 🔐 - - - - - - - - >");
            Thread.Sleep(500);
            Console.WriteLine("Choose an option:");
            Thread.Sleep(500);
            Console.WriteLine("1. Password Generator");
            Thread.Sleep(300);
            Console.WriteLine("2. Password Checker");
            Thread.Sleep(300);
            Console.WriteLine("3. Exit");
            Thread.Sleep(500);
            Console.WriteLine("< - - - - - - - - - - - - - - - - - - - - - - - - - - - - >");

            Console.Write("Enter your choice (1-3): ");
            string choice = Console.ReadLine().Trim();
            System.Console.WriteLine();

            PasswordTool tool = null;

            switch (choice)
            {
                case "1":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nSending you to the Password Generator:");

                    for ( int j = 0; j < 3; j += 1)
                    {
                        Thread.Sleep(200);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(".");
                    }
                    Console.ResetColor();
                    tool = new PasswordGeneratorTool();
                    break;
                case "2":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nSending you to the Password Checker:");

                    for ( int k = 0; k < 13; k += 1)
                    {
                        
                    }
            }
        }
    }
}