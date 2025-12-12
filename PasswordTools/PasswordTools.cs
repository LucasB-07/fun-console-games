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
        Console.WriteLine("Press any key to return to the main menu...");
        Console.ReadKey();
    }

    static void RunPasswordChecker()
    {
        Console.Title = "Password Checker";

        Console.WriteLine("< - - - - - - - - 🔐 Password Checker 🔐 - - - - - - - - >");
        Thread.Sleep(1000);
        Console.WriteLine("Welcome to the Password Checker! Below is some information: ");
        Thread.Sleep(1000);
        Console.WriteLine("This application checks the strength of your password based on various criteria.");
        Thread.Sleep(1000);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("This project is intended solely for educational and developmental purposes. It is not designed or suitable for real-world, production, operational or security-critical use. The author accepts no responsibility or liability for any consequences arising from misuse. MUST NOT BE USED IN PRODUCTION OR SECURITY-CRITICAL SYSTEMS.\n");
        Console.ResetColor();
        Thread.Sleep(1000);
        Console.WriteLine("< - - - - - - - - - - - - - - - - - - -  - - - - - - - - >");

        bool checkAgain = true;
        while (checkAgain)
        {
            Console.Write("Enter a password to check its strength:");
            string password = ReadPassword();

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
                feedback += "⚠️ | Contains fair length (8-11 characters). Consider using a longer password.\n";
            }
            else
            {score += 5;
                feedback += "❌ | Contains poor length (<8 characters). Use a longer password.\n";
            }

            //2. Uppercase Letters
            if (Regex.IsMatch(password, @"[A-Z]"))
            {
                score += 15;
                if (Regex.IsMatch(password, @"(?=.*[A-Z].*[A-Z])"))
                {
                    score += 5;
                    feedback += "✅ | Contains multiple uppercase letters.\n";
                }
                feedback += "✅ | Contains uppercase letter.\n";
            }
            else
            {
                feedback += "❌ | No uppercase letters. Consider adding some.\n";
            }

            //3. Lowercase Letters
            if (Regex.IsMatch(password, @"[a-z]"))
            {
                score += 15;
                if (Regex.IsMatch(password, @"(?=.*[a-z].*[a-z])"))
                {
                    score += 5;
                    feedback += "✅ | Contains multiple lowercase letters.\n";
                }
                feedback += "✅ | Contains lowercase letter.\n";
            }
            else
            {
                feedback += "❌ | No lowercase letters. Consider adding some.\n";
            }

            //4. Digits
            if (Regex.IsMatch(password, @"\d"))
            {
                score += 15;
                if (Regex.IsMatch(password, @"(?=(.*\d){2,})"))
                {
                    score += 5;
                    feedback += "✅ | Contains multiple digits.\n";
                }
                feedback += "✅ | Contains digit.\n";
            }
            else
            {
                feedback += "❌ | No digits. Consider adding some.\n";
            }

            //5. Special Characters
            if (Regex.IsMatch(password, @"[\W_]"))
            {
                score += 15;
                if (Regex.IsMatch(password, @"(?=(.*[\W_]){2,})"))
                {
                    score += 5;
                    feedback += "✅ | Contains multiple special characters.\n";
                }
                feedback += "✅ | Contains special character.\n";
            }
            else
            {
                feedback += "❌ | No special characters. Consider adding some.\n";
            }

            //6. Common Patterns
            if (Regex.IsMatch(password, @"(123456|password|qwerty|!@#$%^&*()_|letmein|welcome|admin|iloveyou|token|secret|wasd|abc123|111111|123123|password123|lol|lol123|admin123|zxcvbn)", RegexOptions.IgnoreCase))
            {
                score -= 20;
                feedback += "❌ | Contains common patterns. Avoid using easily guessable passwords.\n";
            }

            score = Math.Clamp(score, 0, 100);

            //Results
            Console.WriteLine("\n" + new string('=', 60));
            Console.Write($"Password Strength: ");

            if (score >= 90)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("VERY STRONG");
            }
            else if (score >= 75)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("STRONG");
            }
            else if (score >= 60)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("MEDIUM");
            }
            else if(score >= 40)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("WEAK");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("VERY WEAK");
            }
            Console.ResetColor();

            Console.WriteLine($"Score: {score}/100");
            if (!string.IsNullOrEmpty(feedback.Trim()))
            {
                Console.WriteLine($"\nFeedback: \n{feedback.Trim()}");
            }
            Console.WriteLine(new string('=', 60) + "\n");

            while (true)
            {
                Console.Write("Do you want to check another password? (yes/no):");
                var answer = Console.ReadLine().ToLower().Trim();
                
                if (answer == "yes" || answer == "y")
                {
                    checkAgain = true;
                    break;
                }
                else if (answer == "no" || answer == "n")
                {
                    checkAgain = false;
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input! Please type 'yes' or 'no'.\n");
                    Console.ResetColor();
                }
            }
        }
        Console.WriteLine("Thank you for using the Password Generator!");
        Console.WriteLine("❤️ Made With Love By LucasB-07 ❤️\n");
        Console.WriteLine("Press any key to return to the main menu...");
        Console.ReadKey();
    }
    static string ReadPassword()
    {
        var password = new StringBuilder();
        while(true)
        {
            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Enter)
            {
                break;
            }
            if (key.Key == ConsoleKey.Backspace && password.Length > 0)
            {
                password.Length -= 1;
                Console.Write("\b \b");
            }
            else if (!char.IsControl(key.KeyChar))
            {
                password.Append(key.KeyChar);
                Console.Write("*");
            }
        }
        Console.WriteLine();
        return password.ToString();
    }
}