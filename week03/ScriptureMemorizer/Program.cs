using System;

class Program
{
    static void Main(string[] args)
    {
        var scriptures = new List<Scripture>
        {
            new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."),
            new Scripture(new Reference("Genesis", 1, 1), "In the beginning God created the heavens and the earth."),
            new Scripture(new Reference("Psalm", 23, 1), "The Lord is my shepherd, I lack nothing."),
            new Scripture(new Reference("Proverbs", 3, 5), "Trust in the Lord with all your heart and lean not on your own understanding."),
            new Scripture(new Reference("Matthew", 5, 9), "Blessed are the peacemakers, for they will be called children of God.")
        };

        var random = new Random();
        var selectedScripture = scriptures[random.Next(scriptures.Count)];

        while (!selectedScripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(selectedScripture.GetDisplayText());

            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
            {
                break;
            }
            selectedScripture.HideRandomWords(3);
        }
        Console.Clear();
        Console.WriteLine("All words are hidden. Program has ended.");
    }
}