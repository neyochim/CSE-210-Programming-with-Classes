using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your first name? ");
        string ney_firstName = Console.ReadLine();

        Console.Write("What is your last name? ");
        string ney_lastName = Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine($"Your name is {ney_lastName}, {ney_firstName} {ney_lastName}.");
    }
}