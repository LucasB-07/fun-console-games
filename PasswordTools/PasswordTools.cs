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

class PasswordTools
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        CultureInfo.CurrentCulture = new CultureInfo("en-US");

        Console.Title = "Password Tools";

        while(true)
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

            if (choice == "1")
            {
                // Future Method
                RunPasswordGenerator();
            }
            else if (choice == "2")
            {
                // Future Method
                RunPasswordChecker();
            }
            else if (choice == "3")
            {
                Console.WriteLine("Exiting Password Tools. Goodbye!");
                Thread.Sleep(700);
                break;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Invalid choice. Press any key to try again...");
                Console.ResetColor();
                Console.ReadKey();
            }
        }
        Console.WriteLine("❤️ Made With Love By LucasB-07 ❤️\n");
    }

    static void RunPasswordGenerator()
    {
        bool generateAgain = true;
        while (generateAgain)
        {
            Console.Write("How long do you want your Password to be?: ");
            int length;
            while (!int.TryParse(Console.ReadLine(), out length) || length <= 0)
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
                chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_+-=[]{}|;:,.<>?";
            }
            else if (includeSpecialChars == "no" || includeSpecialChars == "n")
            {
                chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            }

        }
    }
}