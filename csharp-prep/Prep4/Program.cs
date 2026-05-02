using System;
using System.Globalization;
int number = 1000;
List<int> numbers;
numbers = new List<int>();

Console.WriteLine("Enter a list of numbers, type 0 when finished.");
while (number != 0)
{
    Console.Write("Enter number: ");
    number = int.Parse(Console.ReadLine());
    if (number != 0)
    {
        numbers.Add(number);
    }
}

Console.WriteLine($"The sum is: {numbers.Sum()}");
Console.WriteLine($"The average is: {numbers.Average()}");
Console.WriteLine($"The largest number is: {numbers.Max()}");