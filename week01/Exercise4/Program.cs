using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise4 Project.");
        List<int> numbers = new List<int>();

        int number = -1;
        int sum = 0;
        int largest = 0;

        Console.WriteLine("Enter a list of numbers, type 0 when finished. ");
        while (number != 0)
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());

            if (number != 0)
            {
                numbers.Add(number);
                sum = sum + number;
                if (number > largest)
                {
                    largest = number;
                }
            }
        }

        Console.WriteLine($"The sum is: {sum}");
        
        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");
        Console.WriteLine("The sorted list is:");
        
        foreach (int num in numbers)
        {
             Console.WriteLine(num);
        }
    }
}