// GroundingActivity.cs (extra activity for creativity)
using System;

public class GroundingActivity : BaseActivity
{
    public GroundingActivity(SessionLog log)
        : base(
            name: "Grounding Activity (5-4-3-2-1)",
            description: "This activity helps you ground yourself by noticing 5 things you see, 4 things you feel, 3 things you hear, 2 things you smell, and 1 thing you taste.",
            log: log)
    { }

    protected override void ExecuteCore()
    {
        var steps = new (string prompt, int count)[]
        {
            ("Name 5 things you can see:", 5),
            ("Name 4 things you can feel:", 4),
            ("Name 3 things you can hear:", 3),
            ("Name 2 things you can smell:", 2),
            ("Name 1 thing you can taste:", 1),
        };

        var end = DateTime.UtcNow.AddSeconds(DurationSeconds);
        foreach (var (prompt, count) in steps)
        {
            if (DateTime.UtcNow >= end) break;
            Console.WriteLine(prompt);
            for (int i = 1; i <= count; i++)
            {
                if (DateTime.UtcNow >= end) break;
                Console.Write($"- {i}: ");
                var input = Console.ReadLine();
            }
            Console.WriteLine();
        }
        PauseWithSpinner(3);
        Console.WriteLine("Notice your breath and your surroundings.");
    }
}