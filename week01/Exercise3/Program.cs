using System;

class Program
{
    static void Main(string[] args)
    {
        string finish = "";
        do
        {
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 100);
            string hint = "";
            int numberTry = 1;

            Console.Write("Try to find the magic number, please enter a number: ");
            string input2 = Console.ReadLine();
            int userTry = int.Parse(input2);
            do
            {
                numberTry = numberTry + 1;
                if (userTry < magicNumber)
                {
                    hint = "increase";
                }
                else if (userTry > magicNumber)
                {
                    hint = "decrease";
                }
                Console.Write($"You need to {hint} that number to find magic, please try again: ");
                input2 = Console.ReadLine();
                userTry = int.Parse(input2);


            }
            while (userTry != magicNumber);

            Console.WriteLine("Congratulations!, you found the magic number");
            Console.WriteLine($"You take {numberTry} times to found the magic number.");
            Console.Write($"Do you want to play again? (yes)/(no)");
            string input3 = Console.ReadLine();
            finish = input3; 
        }
        while (finish == "yes");
    }
}