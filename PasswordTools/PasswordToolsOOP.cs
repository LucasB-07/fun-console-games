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
                        Thread.Sleep(200);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(".");
                    }
                    Console.ResetColor();
                    tool = new PasswordCheckerTool();
                    break;
                case "3":
                    Console.WriteLine("Exiting the application. Goodbye!");
                    Thread.Sleep(700);
                    return;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                    Console.ResetColor();
                    continue;
            }
            tool.Run();
        }
    }
}

static class PasswordGenerator
{
    public static void RanPasswordGenerator()
    {
        Console.Title = "Password Generator";

        Thread.Sleep(1000);
        Console.WriteLine("\rWelcome to the Password Generator! Below is some information: ");
        Thread.Sleep(1000);
        Console.WriteLine("This application generates a random password based on the length you specify.");
        Thread.Sleep(1000);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("This project is intended solely for educational and developmental purposes. It is not designed or suitable for real-world, production, operational or security-critical use. The author accepts no responsibility or liability for any consequences arising from misuse. MUST NOT BE USED IN PRODUCTION OR SECURITY-CRITICAL SYSTEMS.\n");
        Console.ResetColor();
        Thread.Sleep(1000);
        Console.WriteLine("< - - - - - - - - - - - - - - - - - - - - - - - - - - - - - >");

        bool genereateAgain = true;
        while (generateAgain)
        {
            Console.Write("How long do you want your Password to be?: ");

            int length;
            while(!int.TryParse(Console.ReadLine(), out length) || length <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("❌ | Invalid input. Please enter a positive number: ");
                Console.ResetColor();
            }

            Console.Write("Do you want to include special characters? (yes/no): ");
            string includeSpecialChars = Console.ReadLine().Trim().ToLower();

            string chars;
            if (includeSpecialChars == "yes" || includeSpecialChars == "y")
            {
                chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_+[]{}|;:,.<>?";
            }
            else if (includeSpecialChars == "no" || includeSpecialChars == "n" )
            {
                chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("⚠️ | Invalid choice. Proceeding without special characters.");
                Console.ResetColor();
                chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            }

            StringBuilder passwordBuilder = new StringBuilder(length);
            for (int i = 0; i < length; i += 1)
            {
                int index = RandomNumberGenerator.GetInt32(chars.Length);
                passwordBuilder.Append(chars[index]);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n✅ | Password is generating");
            for (int j = 0; j < 13; j += 1)
            {
                Thread.Sleep(200);
                Console.Write(".");
            }
            Console.ResetColor();

            while (true)
            {
                Console.Write("\nDo you want to generate another password? (yes/no):");
                var answer = Console.ReadLine().Trim().ToLower();

                if (answer == "yes" || answer == "y")
                {
                    
                }
            }
        }
    }
}