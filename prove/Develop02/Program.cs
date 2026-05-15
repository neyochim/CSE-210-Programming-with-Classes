using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        string choice = "";

        while (choice != "5")
        {
            // Display the menu
            Console.WriteLine("\n=== Journal Program ===");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry(journal);
                    break;
                case "2":
                    DisplayJournal(journal);
                    break;
                case "3":
                    SaveJournal(journal);
                    break;
                case "4":
                    LoadJournal(journal);
                    break;
                case "5":
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    // Write a new entry to the journal
    static void WriteNewEntry(Journal journal)
    {
        string prompt = journal.GetRandomPrompt();
        Console.WriteLine($"\nPrompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();
        journal.AddEntry(prompt, response);
        Console.WriteLine("Entry added successfully!");
    }

    // Display all entries in the journal
    static void DisplayJournal(Journal journal)
    {
        Console.WriteLine("\n=== Journal Entries ===");
        journal.DisplayAll();
    }

    // Save the journal to a file
    static void SaveJournal(Journal journal)
    {
        Console.Write("\nEnter the filename to save to: ");
        string filename = Console.ReadLine();
        journal.SaveToFile(filename);
    }

    // Load the journal from a file
    static void LoadJournal(Journal journal)
    {
        Console.Write("\nEnter the filename to load from: ");
        string filename = Console.ReadLine();
        journal.LoadFromFile(filename);
    }
}