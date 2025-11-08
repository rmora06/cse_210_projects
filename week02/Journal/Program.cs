using System;

// added the option to save as a CSV file
class Program
{
    static Journal journal = new Journal();
    static PromptGenerator promptGenerator = new PromptGenerator();

    static void Main(string[] args)
    {
        string choice = "";

        while (choice != "6")
        {
            Console.WriteLine("\nJournal:");
            Console.WriteLine("1. Write something new");
            Console.WriteLine("2. View Journal");
            Console.WriteLine("3. Save Journal into a file");
            Console.WriteLine("4. Load journal from a file");
            Console.WriteLine("5. Guardar como archivo CSV");
            Console.WriteLine("6. Close");
            Console.Write("Choose an option: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry();
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    Console.Write("Name of the file to save: ");
                    journal.SaveToFile(Console.ReadLine());
                    break;
                case "4":
                    Console.Write("Name of the file to save to load: ");
                    journal.LoadFromFile(Console.ReadLine());
                    break;
                case "5":
                    Console.Write("Name of the CSV file (ej. journal.csv): ");
                    string csvFile = Console.ReadLine();
                    journal.SaveToCsvFile(csvFile);
                    break;

            }
        }
    }

    static void WriteNewEntry()
    {
        string prompt = promptGenerator.GetRandomPrompt();

        Console.WriteLine($"\nQuestion: {prompt}");
        Console.Write("Your answer: ");
        string response = Console.ReadLine();

        string date = DateTime.Now.ToString("yyyy-MM-dd");

        Entry newEntry = new Entry(prompt, response, date);
        journal.AddEntry(newEntry);
    }
}