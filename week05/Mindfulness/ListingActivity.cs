class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts = new List<string>
    {
        "List things you are grateful for.",
        "List your personal strengths.",
        "List positive experiences from the past week."
    };

    public ListingActivity() : base("Listing", "Write down as many responses as you can to a given prompt.") { }

    public override void Run()
    {
        // Ask user for the duration in seconds
        Console.WriteLine("Enter the time in seconds for your response period:");
        if (!int.TryParse(Console.ReadLine(), out int duration))
        {
            Console.WriteLine("Invalid time input. Please enter a valid number.");
            return;
        }

        string prompt = GetRandomPrompt();
        Console.WriteLine(prompt);
        Console.WriteLine($"You have {duration} seconds to respond. Start listing!");

        // Wait for user to input responses
        List<string> responses = GetListFromUser(duration);
        _count = responses.Count;

        // Show the list of responses after the time is up
        Console.WriteLine("\nHere are your responses:");
        foreach (var response in responses)
        {
            Console.WriteLine($"- {response}");
        }

        Console.WriteLine("Press Enter to finish.");
        Console.ReadLine();  // Wait for user to press Enter
    }

    private string GetRandomPrompt()
    {
        Random rand = new Random();
        return _prompts[rand.Next(_prompts.Count)];
    }

    private List<string> GetListFromUser(int duration)
    {
        List<string> responses = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(duration);

        Console.WriteLine("Start listing your responses (press Enter after each response):");

        // Collect user input until the time is up
        while (DateTime.Now < endTime)
        {
            string response = Console.ReadLine();
            if (string.IsNullOrEmpty(response)) break;  // Stop on empty input (optional)
            responses.Add(response);
        }

        return responses;
    }
}
