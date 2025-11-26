using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment a1 = new Assignment("Robert Mora", "Multiplication");
        Console.WriteLine(a1.GetSummary());

        MathAssignment a2 = new MathAssignment("Wilmy Capellan", "Fractions", "7.3", "8-19");
        Console.WriteLine(a2.GetSummary());
        Console.WriteLine(a2.GetHomeworkList());

        WritingAssignment a3 = new WritingAssignment("Reinin de la Rosa", "Social Culture", "Why to get Married");
        Console.WriteLine(a3.GetSummary());
        Console.WriteLine(a3.GetWritingInformation());
    }
}