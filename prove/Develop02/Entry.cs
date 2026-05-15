using System;

public class Entry
{
    // Properties for storing the journal entry data
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }

    // Constructor
    public Entry(string prompt, string response, string date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }

    // Display the entry in a formatted way
    public void Display()
    {
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"Response: {Response}");
        Console.WriteLine();
    }

    // Convert entry to file format using | as separator
    public string ToFileFormat()
    {
        return $"{Date}|{Prompt}|{Response}";
    }

    // Create entry from file format
    public static Entry FromFileFormat(string ney_line)
    {
        string[] ney_parts = ney_line.Split('|');
        if (ney_parts.Length == 3)
        {
            return new Entry(ney_parts[1], ney_parts[2], ney_parts[0]);
        }
        return null;
    }
}