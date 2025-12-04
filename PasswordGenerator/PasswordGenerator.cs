using System;
using System.Drawing;
using System.Threading;
using System.Globalization;

class PasswordGenerator
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        CultureInfo.CurrentCulture = new CultureInfo("en-US");

        Console.Title = "Password Generator";

        //print information about the app
        Console.WriteLine("< - - - - - - - - 🔐 Password Generator 🔐 - - - - - - - - >");
        Thread.Sleep(1000);
        Console.WriteLine("Welcome to the Password Generator! Below is some information: ");
        Thread.Sleep(1000);
        Console.WriteLine("This application generates a random password based on the length you specify.");
        Thread.Sleep(1000);
        Console.WriteLine("You can use the generated password for securing your accounts. \n");
        Thread.Sleep(1000);

        Random random = new Random();
        string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        Console.Write("How long do you want your Password to be?: ");
        int length = Convert.ToInt32(Console.ReadLine());


    }
}