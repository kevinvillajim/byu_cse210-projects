using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<int> listNumbers = new List<int>();
        List<int> listNumbersSorted = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int number;
        do
        {
            Console.Write("Enter a number: ");
            string input = Console.ReadLine();
            number = int.Parse(input);
            if (number != 0)
            {
                listNumbers.Add(number);
            }
        } while (number != 0);


        int sum = 0;
        int largest = 0;
        int? smallestPositive = listNumbers.Where(n => n > 0).OrderBy(n => n).FirstOrDefault();

        listNumbersSorted = listNumbers;
        listNumbersSorted.Sort();

        foreach (int num in listNumbers)
        {
            sum += num;
            
            if (num > largest)
            {
                largest = num;
            }
        }

        float average = (float)sum / listNumbers.Count;
        
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The Average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");
        Console.WriteLine($"The smallest positive number is: {(smallestPositive.HasValue ? smallestPositive.Value : "No positive numbers")}");
        Console.WriteLine($"The sorted list is:");
        foreach (int num in listNumbersSorted)
        {
            Console.WriteLine(num);
        }

    }
}