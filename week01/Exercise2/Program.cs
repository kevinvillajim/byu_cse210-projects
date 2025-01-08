using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Please, Enter the percentage grade: ");
        string input = Console.ReadLine();
        int percentage = int.Parse(input);
        string letter = "";
        string notes = "";
        string passed = "";
        string sign = "";

        if (percentage >= 70)
        {
            passed = "Aproved";
        }
        else
        {
            passed = "Reproved";
        }

        if (percentage >= 90)
        {
            letter = "A";
            notes = "Excelent, Good Job";
        }
        else if (percentage >= 80)
        {
            letter = "B";
            notes = "Great";
        }
        else if (percentage >= 70)
        {
            letter = "C";
            notes = "But you can do it better";
        }
        else if (percentage >= 60)
        {
            letter = "D";
            notes = "You have study more";
        }
        else
        {
            letter = "F";
            notes = "You need to improve, you can do it!";
        }


        int lastDigit = percentage % 10;
        if (letter != "A" && letter != "F")
        {
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit <= 3)
            {
                sign = "-";
            }
        }

        Console.Write($"Your score is: {letter}{sign}. {passed}, {notes}");
    }
}