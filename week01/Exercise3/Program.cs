using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");

        Random randomGenerator = new Random();
        int magic = randomGenerator.Next(1, 100);

        int guess = 0;

        while (guess != magic)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());
            if (guess < magic)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magic)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.Write("You guessed it!");

            }
        }
    }
}