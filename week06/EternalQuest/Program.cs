// Bonus added for completing the checklist Goal
using System;

class Program
{
static List<Goal> goals = new List<Goal>();
    static int totalScore = 0;
    const string saveFile = "goals.txt";

    static void Main(string[] args)
    {
        //LoadGoals();
        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Eternal Quest - Gamified Goal Tracking");
            Console.WriteLine($"Total Score: {totalScore}");
            Console.WriteLine("1. Show Goals");
            Console.WriteLine("2. Create New Goal");
            Console.WriteLine("3. Register Goal Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Exit");
            Console.Write(" Choose an option: ");
            string choice = Console.ReadLine();

            switch(choice)
            {
                case "1":
                    ShowGoals();
                    break;
                case "2":
                    CreateGoal();
                    break;
                case "3":
                    RecordGoalEvent();
                    break;
                case "4":
                    SaveGoals();
                    break;
                case "5":
                    LoadGoals();
                    break;
                case "6":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Press ENTER to continue");
                    Console.ReadLine();
                    break;
            }
        }
    }

    static void ShowGoals()
    {
        Console.Clear();
        Console.WriteLine("List of Goals:");
        for (int i = 0; i < goals.Count; i++)
        {
            Goal g = goals[i];
            Console.WriteLine($"{i + 1}. {g.GetStatus()} {g.Name} - {g.Description}");
        }
        Console.WriteLine("Press ENTER to continue.");
        Console.ReadLine();
    }

    static void CreateGoal()
    {
        Console.Clear();
        Console.WriteLine("Create new Goal");
        Console.WriteLine("Types of Goals:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Select the type of Goal: ");
        string type = Console.ReadLine();

        Console.Write("Name of the Goal: ");
        string name = Console.ReadLine();
        Console.Write("Description: ");
        string description = Console.ReadLine();
        Console.Write("Point per event: ");
        int points = int.Parse(Console.ReadLine());

        switch(type)
        {
            case "1":
                goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("Times to complete: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Bonus points when done: ");
                int bonus = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(name, description, points, target, 0, bonus));
                break;
            default:
                Console.WriteLine("Invalid. Press ENTER to continue");
                Console.ReadLine();
                return;
        }
        Console.WriteLine("Goal created. Press ENTER to continue");
        Console.ReadLine();
    }

    static void RecordGoalEvent()
    {
        Console.Clear();
        Console.WriteLine("Register Goal event");
        ShowGoals();
        Console.Write("Select the type of Goal ");
        int index;
        if (int.TryParse(Console.ReadLine(), out index) && index > 0 && index <= goals.Count)
        {
            int earned = goals[index - 1].RecordEvent();
            totalScore += earned;
            Console.WriteLine($"Event registered. Points earned: {earned}");
        }
        else
        {
            Console.WriteLine("Invalid selecction.");
        }
        Console.WriteLine("Press ENTER to continue.");
        Console.ReadLine();
    }

    static void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter(saveFile))
        {
            writer.WriteLine(totalScore);
            foreach (Goal g in goals)
            {
                writer.WriteLine(g.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goal saved.");
        Console.ReadLine();
    }

    static void LoadGoals()
    {
        goals.Clear();
        totalScore = 0;
        if (File.Exists(saveFile))
        {
            string[] lines = File.ReadAllLines(saveFile);
            if (lines.Length > 0)
            {
                int.TryParse(lines[0], out totalScore);
                for (int i = 1; i < lines.Length; i++)
                {
                    try
                    {
                        Goal g = Goal.CreateGoalFromString(lines[i]);
                        goals.Add(g);
                    }
                    catch
                    {

                    }
                }
            }
        }
    }
}