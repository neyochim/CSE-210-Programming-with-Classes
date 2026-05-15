using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    // List to store all entries
    private List<Entry> ney_entries = new List<Entry>();

    // List of prompts to choose from
    private List<string> ney_prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What did I learn today?",
        "What am I grateful for today?",
        "What challenged me today?"
    };

    // Get a random prompt from the list
    public string GetRandomPrompt()
    {
        Random ney_random = new Random();
        int ney_index = ney_random.Next(ney_prompts.Count);
        return ney_prompts[ney_index];
    }

    // Add a new entry to the journal
    public void AddEntry(string ney_prompt, string ney_response)
    {
        string ney_date = DateTime.Now.ToString("yyyy-MM-dd");
        Entry ney_entry = new Entry(ney_prompt, ney_response, ney_date);
        ney_entries.Add(ney_entry);
    }

    // Display all entries in the journal
    public void DisplayAll()
    {
        if (ney_entries.Count == 0)
        {
            Console.WriteLine("No entries in the journal yet.");
            return;
        }

        foreach (var ney_entry in ney_entries)
        {
            ney_entry.Display();
        }
    }

    // Save the journal to a file
    public void SaveToFile(string ney_filename)
    {
        try
        {
            using (StreamWriter ney_writer = new StreamWriter(ney_filename))
            {
                foreach (var ney_entry in ney_entries)
                {
                    ney_writer.WriteLine(ney_entry.ToFileFormat());
                }
            }
            Console.WriteLine($"Journal saved to {ney_filename}");
        }
        catch (Exception ney_ex)
        {
            Console.WriteLine($"Error saving file: {ney_ex.Message}");
        }
    }

    // Load the journal from a file
    public void LoadFromFile(string ney_filename)
    {
        try
        {
            if (!File.Exists(ney_filename))
            {
                Console.WriteLine($"File {ney_filename} not found.");
                return;
            }

            ney_entries.Clear();

            using (StreamReader ney_reader = new StreamReader(ney_filename))
            {
                string ney_line;
                while ((ney_line = ney_reader.ReadLine()) != null)
                {
                    Entry ney_entry = Entry.FromFileFormat(ney_line);
                    if (ney_entry != null)
                    {
                        ney_entries.Add(ney_entry);
                    }
                }
            }

            Console.WriteLine($"Journal loaded from {ney_filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading file: {ex.Message}");
        }
    }

    // Get the count of entries
    public int GetEntryCount()
    {
        return _entries.Count;
    }
}