using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Enhancement: Load scriptures from file and pick one at random
        List<Scripture> scriptures = LoadScriptures("scriptures.txt");
        Random rand = new Random();
        Scripture scripture = scriptures[rand.Next(scriptures.Count)];

        while (!scripture.AllWordsHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit:");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit") break;

            scripture.HideRandomWords(3); // Hide 3 new words per round
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nAll words are hidden. Goodbye!");
    }

    // Enhancement: Load scriptures from a file
    static List<Scripture> LoadScriptures(string filePath)
    {
        var scriptures = new List<Scripture>();
        foreach (var line in File.ReadAllLines(filePath))
        {
            var parts = line.Split('|');
            if (parts.Length == 2)
            {
                Reference reference = Reference.Parse(parts[0]);
                scriptures.Add(new Scripture(reference, parts[1]));
            }
        }
        return scriptures;
    }
}