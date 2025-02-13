class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "Focus on your breathing. Inhale and exhale slowly.") { }

    public override void Run()
    {
        for (int i = 0; i < _duration / 6; i++)
        {
            Console.WriteLine("Breathe in...");
            ShowCountdown(3);
            Console.WriteLine("Breathe out...");
            ShowCountdown(3);
        }
    }
}
