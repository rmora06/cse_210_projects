using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");

        Console.Write("Enter your grade: ");
        string value = Console.ReadLine();
        int grade = int.Parse(value);

        string letter = "";

        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80 && grade < 90)
        {
            letter = "B";
        }
        else if (grade >= 70 && grade < 80)
        {
            letter = "C";
        }
        else if (grade >= 60 && grade < 70)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }
        Console.WriteLine($"Your Final Grade is '{letter}'");

        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! YOU PASSED");
        }
        else
        {
            Console.WriteLine("Sorry! You did not pass. Try your best next time");
        }
    }
}