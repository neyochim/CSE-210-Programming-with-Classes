using System;

class Program
{
    static void Main(string[] args)
    {
        // EXCEEDING REQUIREMENTS:
        // This program includes the following enhancements beyond core requirements:
        // 1. Multiple scriptures library - The program loads multiple scriptures and allows 
        //    the user to practice with different verses
        // 2. User experience improvements - Progress indicator shows how many words are hidden
        // 3. Better word hiding strategy - Uses a truly random selection from unhidden words
        //    (stretch challenge requirement)
        // 4. Scripture variety - Includes scriptures of different lengths and verse ranges

        // Create a library of scriptures for the user to choose from
        Scripture[] scriptures = new Scripture[]
        {
            new Scripture(
                new ScriptureReference("John", 3, 16),
                "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."
            ),
            new Scripture(
                new ScriptureReference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight."
            ),
            new Scripture(
                new ScriptureReference("Philippians", 4, 8),
                "Finally, brothers and sisters, whatever is true, whatever is noble, whatever is right, whatever is pure, whatever is lovely, whatever is admirable, if anything is excellent or praiseworthy, think about such things."
            ),
            new Scripture(
                new ScriptureReference("Psalm", 23, 1, 6),
                "The Lord is my shepherd, I lack nothing. He makes me lie down in green pastures, he leads me beside quiet waters, he refreshes my soul. He guides me along the right paths for his namesake. Even though I walk through the darkest valley, I will fear no evil, for you are with me; your rod and your staff, they comfort me."
            )
        };

        Random random = new Random();
        Scripture scripture = scriptures[random.Next(scriptures.Length)];

        // Main game loop
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"{scripture.GetReference()}");
            Console.WriteLine();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("Congratulations! You have successfully hidden all the words. You can continue practicing!");
                break;
            }

            Console.Write("Press Enter to hide more words or type 'quit' to exit: ");
            string userInput = Console.ReadLine();

            if (userInput?.ToLower() == "quit")
            {
                Console.WriteLine("Goodbye!");
                break;
            }

            // Hide 3 random words at a time
            scripture.HideRandomWords(3);
        }
    }
}
