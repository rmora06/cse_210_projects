// Program.cs
// EXCEED REQUIREMENTS REPORT:
// - Added GroundingActivity (5-4-3-2-1) as a new activity type.
// - Implemented SessionLog with CSV save/load to track activity history.
// - Ensured prompts/questions do not repeat until all are used via RandomCycle.
// - Provided meaningful animations: spinner, countdown, and paced breathing timing.
// - Menu option to view session history summary.
// - Clear separation of concerns and encapsulation, with private fields and shared base behaviors.
//
// How to run:
// dotnet run
//
// Files overview:
// - Program.cs (menu and orchestration)
// - BaseActivity.cs (common behavior & animations)
// - BreathingActivity.cs
// - ReflectionActivity.cs
// - ListingActivity.cs
// - GroundingActivity.cs (extra)
// - RandomCycle.cs (no-repeat random selection)
// - SessionLog.cs (CSV persistence)

using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        var log = new SessionLog("session_log.csv");

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness App");
            Console.WriteLine("---------------");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Grounding Activity (5-4-3-2-1)");
            Console.WriteLine("5. View session history summary");
            Console.WriteLine("6. Exit");
            Console.Write("\nChoose an option: ");

            var choice = Console.ReadLine();
            BaseActivity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity(log);
                    break;
                case "2":
                    activity = new ReflectionActivity(log);
                    break;
                case "3":
                    activity = new ListingActivity(log);
                    break;
                case "4":
                    activity = new GroundingActivity(log);
                    break;
                case "5":
                    Console.Clear();
                    Console.WriteLine("Session History Summary");
                    Console.WriteLine("-----------------------");
                    log.LoadIfExists();
                    Console.WriteLine(log.GetSummaryText());
                    Console.WriteLine("\nPress Enter to return to menu...");
                    Console.ReadLine();
                    continue;
                case "6":
                    return;
                default:
                    continue;
            }

            try
            {
                activity.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nAn error occurred: {ex.Message}");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }
    }
}