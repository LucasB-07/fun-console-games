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
    PasswordChecker = 2,
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
                    Console.WriteLine("\nSending you to the Password Generator");

                    for (int j = 0; j < 13; j += 1)
                    {
                        Thread.Sleep(200);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(".");
                    }
                    Console.ResetColor();
                    //RunPasswordGenerator();
                    tool = new PasswordGeneratorTool();
                    break;

                case "2":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nSending you to the Password Checker");

                    for (int k = 0; k < 13; k += 1)
                    {
                        Thread.Sleep(200);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(".");
                    }
                    Console.ResetColor();
                    //RunPasswordChecker();
                    tool = new PasswordCheckerTool();
                    break;

                case "3":
                    Console.WriteLine("Exiting Password Tools. Goodbye!");
                    Thread.Sleep(700);
                    return;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("❌ Invalid choice. Press any key to try again...");
                    Console.ResetColor();
                    Console.ReadKey();
                    //break;
                    continue;
            }
            tool.Run();
        }
    }
}

static class PasswordGenerator
{
    public static void RunPasswordGenerator()
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

            Console.Write($"\r🔐 | Generated Password: ");
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
                    Console.WriteLine("❌ | Invalid input. Please enter 'yes' or 'no'.");
                    Console.ResetColor();
                }
            }
        }
        Console.WriteLine("Thank you for using the Password Generator!");
        Console.WriteLine("❤️ Made With Love By LucasB-07 ❤️\n");
        Console.WriteLine("Press any key to return to the main menu...");
        Console.ReadKey();
    }
}

static class PasswordChecker
{
    public static void RunPasswordChecker()
    {
        Console.Title = "Password Checker";

        Thread.Sleep(1000);
        Console.WriteLine("\rWelcome to the Password Checker! Below is some information: ");
        Thread.Sleep(1000);
        Console.WriteLine("This application checks the strength of your password based on various criteria.");
        Thread.Sleep(1000);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("This project is intended solely for educational and developmental purposes. It is not designed or suitable for real-world, production, operational or security-critical use. The author accepts no responsibility or liability for any consequences arising from misuse. MUST NOT BE USED IN PRODUCTION OR SECURITY-CRITICAL SYSTEMS.");
        Console.ResetColor();
        Thread.Sleep(1000);
        Console.WriteLine("< - - - - - - - - - - - - - - - - - - - - - - - - - - >");

        bool checkAgain = true;
        while (checkAgain)
        {
            Console.Write("Enter a password to check its strength: ");
            //string password = ReadPassword();
            string password = PasswordUtils.ReadPassword();

            if (string.IsNullOrWhiteSpace(password))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ | Password cannot be empty. Please try again.\n");
                Console.ResetColor();
                continue;
            }
            int score = 0;
            string feedback = "";

            //1. Length
            if (password.Length >= 16)
            {
                score += 30;
                feedback += "✅ | Contains excellent length (16+ characters).\n";
            }
            else if (password.Length >= 12)
            {
                score += 25;
                feedback += "✅ | Contains good length (12-15 characters).\n";
            }
            else if (password.Length >= 8)
            {
                score += 10;
                feedback += "Contains fair length (8-11 characters). Consider using a longer password.\n";
            }
            else
            {
                score += 5;
                feedback += "Contains poor length ( <8 characters). Use a longer password.\n";
            }

            //2. Uppercase Letters
            if (Regex.IsMatch(password, @"(?=.*[A-Z].*[A-Z])"))
            {
                score += 20;
                feedback += "✅ | Contains multiple uppercase letters.\n";
            }
            else if (Regex.IsMatch(password, @"[A-Z]"))
            {
                score += 15;
                feedback += "✅ | Contains uppercase letter.\n";
            }
            else
            {
                feedback += "❌ | No uppercase letters. Consider adding some.\n";
            }

            //3. Lowercase Letters
            if (Regex.IsMatch(password, @"(?=.*[a-z].*[a-z])"))
            {
                score += 20;
                feedback += "✅ | Contains multiple lowercase letters.\n";
            }
            else if (Regex.IsMatch(password, @"[a-z]"))
            {
                score += 15;
                feedback += "✅ | Contains lowercase letter.\n";
            }
            else
            {
                feedback += "❌ | No lowercase letters. Consider adding some.\n";
            }
        }
    }
}

