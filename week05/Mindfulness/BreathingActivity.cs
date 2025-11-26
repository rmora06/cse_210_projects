// BreathingActivity.cs
using System;

public class BreathingActivity : BaseActivity
{
    public BreathingActivity(SessionLog log)
        : base(
            name: "Breathing Activity",
            description: "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.",
            log: log)
    { }

    protected override void ExecuteCore()
    {
        int elapsed = 0;
        int segment = 4; // seconds per inhale/exhale segment

        while (elapsed < DurationSeconds)
        {
            int remaining = DurationSeconds - elapsed;
            int inhale = Math.Min(segment, remaining);
            Console.Write("Breathe in");
            PaceBreath(" ", inhale);
            elapsed += inhale;
            if (elapsed >= DurationSeconds) break;

            remaining = DurationSeconds - elapsed;
            int exhale = Math.Min(segment, remaining);
            Console.Write("Breathe out");
            PaceBreath(" ", exhale);
            elapsed += exhale;
        }
    }
}