using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var activities = new List<Activity>
        {
            new Running(new DateTime(2022,11,3), 30, 3.0),
            new Cycling(new DateTime(2022,11,3), 45, 12.0),
            new Swimming(new DateTime(2022,11,3), 60, 40)
        };

        foreach (var a in activities)
        {
            Console.WriteLine(a.GetSummary());
        }
    }
}