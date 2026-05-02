using System;

//Prompt for the magic number
Random randomGenerator = new Random();
int magicNumber = randomGenerator.Next(1, 100);
//Guess the magic number
string guess = "0";

while (int.Parse(guess) != magicNumber)
    {
        Console.Write("What's your guess?: ");
        guess = Console.ReadLine();
        if (int.Parse(guess) > magicNumber)
        {
            Console.WriteLine("Lower");
        }
        else if (int.Parse(guess) < magicNumber)
        {
            Console.WriteLine("Higher");
        }
    }

Console.WriteLine("You guessed it!");