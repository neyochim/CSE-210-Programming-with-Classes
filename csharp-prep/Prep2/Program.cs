using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        int ney_percentage = int.Parse(Console.ReadLine());

        string ney_letter;

        if (ney_percentage >= 90)
        {
            ney_letter = "A";
        }
        else if (ney_percentage >= 80)
        {
            ney_letter = "B";
        }
        else if (ney_percentage >= 70)
        {
            ney_letter = "C";
        }
        else if (ney_percentage >= 60)
        {
            ney_letter = "D";
        }
        else
        {
            ney_letter = "F";
        }

        int ney_lastDigit = ney_percentage % 10;
        string ney_sign;

        if (ney_lastDigit >= 7)
        {
            ney_sign = "+";
        }
        else if (ney_lastDigit < 3)
        {
            ney_sign = "-";
        }
        else
        {
            ney_sign = "";
        }

        if (ney_letter == "A" && ney_percentage >= 93)
        {
            ney_sign = "";
        }

        if (ney_letter == "F")
        {
            ney_sign = "";
        }

        Console.WriteLine($"Your grade is {ney_letter}{ney_sign}.");

        if (ney_percentage >= 70)
        {
            Console.WriteLine("Congratulations, you passed the course!");
        }
        else
        {
            Console.WriteLine("Keep trying, and you can do better next time.");
        }
    }
}