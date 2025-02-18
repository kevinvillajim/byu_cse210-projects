using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2025, 2, 18), 30, 3.0),
            new Cycling(new DateTime(2025, 2, 11), 45, 15.0),
            new Swimming(new DateTime(2025, 2, 6), 60, 20)
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}