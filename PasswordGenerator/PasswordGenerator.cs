// DISCLAIMER:
// This project is intended solely for educational and developmental purposes.
// It is not designed or suitable for real-world, production, operational or security-critical use.
// The author accepts no responsibility or liability for any consequences arising from misuse.
// MUST NOT BE USED IN PRODUCTION OR SECURITY-CRITICAL SYSTEMS.
using System;
using System.Threading;
using System.Globalization;
using System.Text;
using System.Security.Cryptography;

class PasswordGenerator
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        CultureInfo.CurrentCulture = new CultureInfo("en-US");

        Console.Title = "Password Generator";

        Console.WriteLine("< - - - - - - - - 🔐 Password Generator 🔐 - - - - - - - - >");
        Thread.Sleep(1000);
        Console.WriteLine("Welcome to the Password Generator! Below is some information: ");
        Thread.Sleep(1000);
        Console.WriteLine("This application generates a random password based on the length you specify.");
        Thread.Sleep(1000);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("This project is intended solely for educational and developmental purposes. It is not designed or suitable for real-world, production, operational or security-critical use. The author accepts no responsibility or liability for any consequences arising from the use of this software. MUST NOT BE USED IN PRODUCTION OR SECURITY-CRITICAL SYSTEMS.\n");
        Console.ResetColor();
        Thread.Sleep(1000);
        Console.WriteLine("< - - - - - - - - - - - - - - - - - - - - - - - - - - - - - >");

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
            Console.WriteLine("\n✅ | Password is generating");
            for (int j = 0; j < 13; j += 1)
            {
                Thread.Sleep(500);
                Console.Write(".");
            }
            Console.ResetColor();

            Console.Write($"\rGenerated Password: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(passwordBuilder.ToString());
            Console.ResetColor();

            while (true)
            {
                Console.Write("\nDo you want to generate another password? (yes/no): ");
                var answer = Console.ReadLine().ToLower().Trim();
                if (answer == "yes" || answer == "y")
                {
                    generateAgain = true;
                    break;
                }
                else if (answer == "no" || answer == "n")
                {
                    generateAgain = false;
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input! Type 'yes' or 'no'.");
                    Console.ResetColor();
                }
            }

        }
        Console.WriteLine("Thank you for using the Password Generator!");
        Console.WriteLine("❤️ Made With Love By LucasB-07 ❤️\n");
    }
}