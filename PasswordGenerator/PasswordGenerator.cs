using System;
using System.Threading;
using System.Globalization;
using System.Text;

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
        Console.WriteLine("You can use the generated password for securing your accounts. \n");
        Thread.Sleep(1000);
        Console.WriteLine("< - - - - - - - - - - - - - - - - - - - - - - - - - - - - - >");

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

        Random random = new Random();
        StringBuilder passwordBuilder = new StringBuilder();
        for (int i = 0; i < length; i += 1)
        {
            passwordBuilder.Append(chars[random.Next(chars.Length)]);
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
    }
}