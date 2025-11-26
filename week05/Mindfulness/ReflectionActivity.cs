// ReflectionActivity.cs
using System;

public class ReflectionActivity : BaseActivity
{
    private readonly RandomCycle _prompts;
    private readonly RandomCycle _questions;
    private int _questionsAsked = 0;

    public ReflectionActivity(SessionLog log)
        : base(
            name: "Reflection Activity",
            description: "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.",
            log: log)
    {
        _prompts = new RandomCycle(new[]
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        });

        _questions = new RandomCycle(new[]
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        });
    }

    protected override void ExecuteCore()
    {
        Console.WriteLine("Consider this prompt:");
        Console.WriteLine($"- {_prompts.Next()}");
        Console.WriteLine("Hold the experience in your mind.");
        PauseWithSpinner(5);
        Console.WriteLine();

        var start = DateTime.UtcNow;

        while ((DateTime.UtcNow - start).TotalSeconds < DurationSeconds)
        {
            string q = _questions.Next();
            Console.WriteLine(q);
            _questionsAsked++;
            PauseWithSpinner(6);
            Console.WriteLine();
        }
    }

    protected override string GetExtraMetricForLog() => $"questions={_questionsAsked}";
}