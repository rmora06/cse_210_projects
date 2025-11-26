// BaseActivity.cs
using System;
using System.Threading;

public abstract class BaseActivity
{
    private readonly string _name;
    private readonly string _description;
    private int _durationSeconds;
    private readonly SessionLog _log;

    protected BaseActivity(string name, string description, SessionLog log)
    {
        _name = name;
        _description = description;
        _log = log;
    }

    public void Start()
    {
        ShowStartingMessage();
        SetDuration();
        PrepareToBegin();
        ExecuteCore();
        Finish();
    }

    protected abstract void ExecuteCore();

    protected void ShowStartingMessage()
    {
        Console.Clear();
        Console.WriteLine(_name);
        Console.WriteLine(new string('-', _name.Length));
        Console.WriteLine(_description);
        Console.WriteLine();
    }

    protected void SetDuration()
    {
        while (true)
        {
            Console.Write("Set the duration (seconds, 10–600 recommended): ");
            var input = Console.ReadLine();
            if (int.TryParse(input, out var seconds) && seconds > 0)
            {
                _durationSeconds = seconds;
                break;
            }
            Console.WriteLine("Please enter a valid positive integer.");
        }
    }

    protected void PrepareToBegin()
    {
        Console.WriteLine("Get ready to begin...");
        PauseWithSpinner(3);
        Console.Clear();
    }

    protected void Finish()
    {
        Console.WriteLine("Great job. Take a moment to notice how you feel.");
        PauseWithSpinner(3);
        Console.WriteLine($"You completed: {_name} for {_durationSeconds} seconds.");
        PauseWithSpinner(3);

        // Record to log
        _log.Append(new SessionLogEntry
        {
            DateUtc = DateTime.UtcNow,
            ActivityName = _name,
            DurationSeconds = _durationSeconds,
            ExtraMetric = GetExtraMetricForLog()
        });
        _log.Save();
    }

    protected int DurationSeconds => _durationSeconds;

    // Optional metric hook for subclasses (e.g., count of items listed)
    protected virtual string GetExtraMetricForLog() => "";

    protected void PauseWithSpinner(int seconds)
    {
        var end = DateTime.UtcNow.AddSeconds(seconds);
        var frames = new[] { "|", "/", "-", "\\" };
        var idx = 0;

        while (DateTime.UtcNow < end)
        {
            Console.Write($"\r{frames[idx++ % frames.Length]} ");
            Thread.Sleep(120);
        }
        Console.Write("\r  \r");
    }

    protected void Countdown(int seconds, string prefix = "")
    {
        for (int s = seconds; s >= 1; s--)
        {
            Console.Write($"\r{prefix}{s}s   ");
            Thread.Sleep(1000);
        }
        Console.Write("\r               \r");
    }

    protected void PaceBreath(string message, int seconds)
    {
        // Slightly smoother pacing: fast at start, slower near end
        Console.Write(message);
        int steps = Math.Max(4, seconds * 2);
        for (int i = 1; i <= steps; i++)
        {
            double t = (double)i / steps;
            int delay = (int)(200 + 600 * t); // 200ms -> 800ms
            Console.Write(".");
            Thread.Sleep(delay);
        }
        Console.WriteLine();
    }
}