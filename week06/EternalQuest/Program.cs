using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to 'Eternal Quest Program' !");
        Console.WriteLine("Track your goals and level up on your yourney to become better every day!.");
        Console.WriteLine("-----------------------------------");

        GoalManager manager = new GoalManager();
        manager.Start();

        Console.WriteLine("Goodbye, see you soon!");
    }
}