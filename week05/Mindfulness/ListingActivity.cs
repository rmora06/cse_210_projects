// ListingActivity.cs
using System;
using System.Collections.Generic;

public class ListingActivity : BaseActivity
{
    private readonly RandomCycle _prompts;
    private int _count = 0;

    public ListingActivity(SessionLog log)
        : base(
            name: "Listing Activity",
            description: "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.",
            log: log)
    {
        _prompts = new RandomCycle(new[]
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        });
    }

    protected override void ExecuteCore()
    {
        Console.WriteLine("Prompt:");
        Console.WriteLine($"- {_prompts.Next()}");
        Console.WriteLine("You will have a moment to prepare...");
        Countdown(5, "Starting in ");

        Console.WriteLine("\nStart listing. Enter one item per line. Press Enter after each item.");
        Console.WriteLine("(The session will end automatically after the chosen duration.)\n");

        var items = new List<string>();
        var end = DateTime.UtcNow.AddSeconds(DurationSeconds);

        while (DateTime.UtcNow < end)
        {
            if (Console.KeyAvailable)
            {
                string? line = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(line))
                {
                    items.Add(line.Trim());
                    _count = items.Count;
                }
            }
            else
            {
                // Light spinner so user sees time is passing, without blocking input
                PauseWithSpinner(1);
            }
        }

        Console.WriteLine($"\nYou entered {_count} items.");
    }

    protected override string GetExtraMetricForLog() => $"items={_count}";
}