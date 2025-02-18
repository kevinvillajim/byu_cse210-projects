using System;
using System.IO;
using System.Collections.Generic;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }
    public void Start()
    {
        bool quit = false;
        while (!quit)
        {
            DisplayMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    DisplayPlayerInfo();
                    break;
                case "7":
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice please try again.");
                    break;
            }
        }
    }

    private void DisplayMenu()
    {
        Console.WriteLine();
        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine();
        Console.WriteLine("Menu Options:");
        Console.WriteLine("  1. Create New Goal");
        Console.WriteLine("  2. List Goals");
        Console.WriteLine("  3. Save Goals");
        Console.WriteLine("  4. Load Goals");
        Console.WriteLine("  5. Record Event");
        Console.WriteLine("  6. Display Player Info");
        Console.WriteLine("  7. Quit");
        Console.Write("Select a choice from the menu: ");
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou have {_score} points");

        //Display levels as a videogame
        if (_score >= 100)
        {
            Console.WriteLine("Congratulations! you have reached Level 1: Novice Adventurer");
        }
        if (_score >= 1000)
        {
            Console.WriteLine("Congratulations! you have reached Level 2: Dedicated Disciple");
        }

        if (_score >= 3000)
        {
            Console.WriteLine("Amazing! you have reached Level 3: Steadfast Seeker");
        }

        if (_score >= 5000)
        {
            Console.WriteLine("Outstanding! you have reached Level 4: Noble Knigth!");
        }

        if (_score >= 10000)
        {
            Console.WriteLine("You are a legend! you have reached Level 5: Exalted Champion!");
        }
    }

    public void ListGoalNames()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to list.");
            return;
        }

        Console.WriteLine("Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}.- {_goals[i].GetName()}");
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet.");
            return;
        }

        Console.WriteLine("Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        string choice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid goal type. Please try again.");
                break;
        }

        Console.WriteLine($"Goal '{name}' created successfully.");
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet.");
            return;
        }

        ListGoalNames();

        Console.Write("Which goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < _goals.Count)
        {
            Goal goal = _goals[index];
            int pointsEarned = goal.RecordEvent();
            _score += pointsEarned;

            Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
            Console.WriteLine($"You have now {_score} points.");

            if (_score >= 100 && _score < 100 + pointsEarned)

            {
                Console.WriteLine("Level Up! Now you are Level 1: Novice Adventurer");
            }
            else if (_score >= 1000 && _score < 1000 + pointsEarned)
            {
                Console.WriteLine("Level Up! Now you are Level 2: Dedicated Disciple");
            }

            else if (_score >= 3000 && _score < 3000 + pointsEarned)
            {
                Console.WriteLine("Level Up! Now you are Level 3: Steadfast Seeker");
            }

            else if (_score >= 5000 && _score < 5000 + pointsEarned)
            {
                Console.WriteLine("Level Up! Now you are Level 4: Noble Knigth!");
            }

            else if (_score >= 10000 && _score < 10000 + pointsEarned)
            {
                Console.WriteLine("Level Up! Now you are Level 5: Exalted Champion!");
            }
        }
        else
        {
            Console.WriteLine("Invalid goal index. Please try again.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFIle = new StreamWriter(filename))
        {
            outputFIle.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFIle.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File no found. Please try again.");
            return;
        }

        _goals.Clear();

        string[] lines = File.ReadAllLines(filename);

        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] parts = line.Split(':');

            string type = parts[0];
            string goalData = parts[1];
            string[] goalParts = goalData.Split(',');

            switch (type)
            {
                case "SimpleGoal":
                    _goals.Add(new SimpleGoal(
                        goalParts[0],
                        goalParts[1],
                        int.Parse(goalParts[2]),
                        bool.Parse(goalParts[3])));
                    break;
                case "EternalGoal":
                    _goals.Add(new EternalGoal(
                        goalParts[0],
                        goalParts[1],
                        int.Parse(goalParts[2])));
                    break;
                case "ChecklistGoal":
                    _goals.Add(new ChecklistGoal(
                        goalParts[0],
                        goalParts[1],
                        int.Parse(goalParts[2]),
                        int.Parse(goalParts[3]),
                        int.Parse(goalParts[4]),
                        int.Parse(goalParts[5])));
                    break;
                default:
                    Console.WriteLine($"Invalid goal type '{type}'.");
                    break;
            }
        }

        Console.WriteLine("Goals loaded successfully.");
    }
}