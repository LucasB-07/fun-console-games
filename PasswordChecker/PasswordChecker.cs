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
    }
}