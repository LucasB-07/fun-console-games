// DISCLAIMER:
// This project is intended solely for educational and developmental purposes.
// It is not designed or suitable for real-world, production, operational or security-critical use.
// The author accepts no responsibility or liability for any consequences arising from misuse.
// MUST NOT BE USED IN PRODUCTION OR SECURITY-CRITICAL SYSTEMS.
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

class PasswordChecker
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

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
        Console.WriteLine("< - - - - - - - - 🔐 Password Checker 🔐 - - - - - - - - >");

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
                feedback += "✅ Excellent length (16+ characters).\n";
            }
            else if (password.Length >= 12)
            {
                score += 25;
                feedback += "✅ Good length (12-15 characters).\n";
            }
            else if (password.Length >= 8)
            {
                score += 10;
                feedback += "⚠️ Fair length (8-11 characters). Consider using a longer password.\n";
            }
            else
            {score += 5;
                feedback += "❌ Poor length (<8 characters). Use a longer password.\n";
            }

            //2. Uppercase Letters
            if (Regex.IsMatch(password, @"[A-Z]"))
            {
                score += 15;
                if (Regex.IsMatch(password, @"(?=.*[A-Z].*[A-Z])"))
                {
                    score += 5;
                    feedback += "✅ Contains multiple uppercase letters.\n";
                }
                feedback += "✅ Contains uppercase letter.\n";
            }
            else
            {
                feedback += "❌ No uppercase letters. Consider adding some.\n";
            }
            
            //3. Lowercase Letters
            if (Regex.IsMatch(password, @"[a-z]"))
            {
                score += 15;
                if (Regex.IsMatch(password, @"(?=.*[a-z].*[a-z])"))
                {
                    score += 5;
                    feedback += "✅ Contains multiple lowercase letters.\n";
                }
                feedback += "✅ Contains lowercase letter.\n";
            }
            else
            {
                feedback += "❌ No lowercase letters. Consider adding some.\n";
            }

            //4. Digits
            if (Regex.IsMatch(password, @"\d"))
            {
                score += 15;
                if (Regex.IsMatch(password, @"(?=(.*\d){2,})"))
                {
                    score += 5;
                    feedback += "✅ Contains multiple digits.\n";
                }
                feedback += "✅ Contains digit.\n";
            }
            else
            {
                feedback += "❌ No digits. Consider adding some.\n";
            }
            //5. Special Characters
            if (Regex.IsMatch(password, @"[\W_]"))
            {
                score += 15;
                if (Regex.IsMatch(password, @"(?=(.*[\W_]){2,})"))
                {
                    score += 5;
                    feedback += "✅ Contains multiple special characters.\n";
                }
                feedback += "✅ Contains special character.\n";
            }
            else
            {
                feedback += "❌ No special characters. Consider adding some.\n";
            }

            //6. Common Patterns
            if (Regex.IsMatch(password, @"^(123456|password|qwerty|!@#$%^&*()_|letmein|welcome|admin|iloveyou|abc123|111111|123123)$", RegexOptions.IgnoreCase))
            {
                score -= 20;
                feedback += "❌ Contains common patterns. Avoid using easily guessable passwords.\n";
            }

            // Keep the score between 0 and 100
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
                Console.WriteLine($"\nFeedback: {feedback.Trim()}");
            }
        }
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