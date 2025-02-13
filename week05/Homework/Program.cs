using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment = new Assignment("Kevin Villacreses", "Factoring");
        Console.WriteLine(assignment.GetSummary());

        MathAssignment mathA = new MathAssignment("Juan Perez", "Graphics", "5.2.1", "10-15");
        Console.WriteLine(mathA.GetHomeworkList());

        WritingAssignment writingA = new WritingAssignment("Pedro Sanchez", "English", "Advanced Speaking for Programming");
        Console.WriteLine(writingA.GetSummary());
        Console.WriteLine(writingA.GetWritingInformation());
    }
}