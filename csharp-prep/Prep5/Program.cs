using System;

static void DisplayWelcome()
{
    Console.WriteLine("Welcome to the program!");
}

static string PromptUserName()
{
    Console.Write("Please enter your name: ");
    string userName = Console.ReadLine(); 
    return userName;
}

static int PromptUserNumber()
{
    Console.Write("Please enter your favorite number: ");
    int userNumber = int.Parse(Console.ReadLine()); 
    return userNumber;
}

static int PromtUserBirthYear()
{
    Console.Write("Please enter the year you were born: ");
    int userYear = int.Parse(Console.ReadLine()); 
    return userYear;
}

static int SquareNumber(int userNumber)
{
    int square = userNumber * userNumber;
    return square;
}

static void DisplayResult(string userName, int square, int userYear)
{
    Console.WriteLine($"{userName}, the square of your number is {square}.");
    Console.WriteLine($"{userName}, you will turn {DateTime.Now.Year - userYear} this year.");
}

static void Main()
{
    DisplayWelcome();
    string userName = PromptUserName();
    int userNumber = PromptUserNumber();
    int userYear = PromtUserBirthYear();
    int square = SquareNumber(userNumber);
    DisplayResult(userName, square, userYear);
}

Main();