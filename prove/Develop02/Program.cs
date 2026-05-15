using System;

class Program
{
    static void Main(string[] args)
    {
        Journal ney_journal = new Journal();
        string ney_choice = "";

        while (ney_choice != "5")
        {
            // Display the menu
            Console.WriteLine("\n=== Journal Program ===");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            ney_choice = Console.ReadLine();

            switch (ney_choice)
            {
                case "1":
                    WriteNewEntry(ney_journal);
                    break;
                case "2":
                    DisplayJournal(ney_journal);
                    break;
                case "3":
                    SaveJournal(ney_journal);
                    break;
                case "4":
                    LoadJournal(ney_journal);
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
    static void WriteNewEntry(Journal ney_journal)
    {
        string ney_prompt = ney_journal.GetRandomPrompt();
        Console.WriteLine($"\nPrompt: {ney_prompt}");
        Console.Write("Your response: ");
        string ney_response = Console.ReadLine();
        ney_journal.AddEntry(ney_prompt, ney_response);
        Console.WriteLine("Entry added successfully!");
    }

    // Display all entries in the journal
    static void DisplayJournal(Journal ney_journal)
    {
        Console.WriteLine("\n=== Journal Entries ===");
        ney_journal.DisplayAll();
    }

    // Save the journal to a file
    static void SaveJournal(Journal ney_journal)
    {
        Console.Write("\nEnter the filename to save to: ");
        string ney_filename = Console.ReadLine();
        ney_journal.SaveToFile(ney_filename);
    }

    // Load the journal from a file
    static void LoadJournal(Journal ney_journal)
    {
        Console.Write("\nEnter the filename to load from: ");
        string ney_filename = Console.ReadLine();
        ney_journal.LoadFromFile(ney_filename);
    }
}