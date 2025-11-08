using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> prompts;
    private Random random;

    public PromptGenerator()
    {
        prompts = new List<string>
        {
            "¿Who was the most interesting person I spoke to today",
            "¿Which was the best part of my day?",
            "¿How did I see the hand of God today?",
            "¿Which was the stronges emotion I felt today?",
            "¿If I could repeat something that I did today, what would it be?"
        };

        random = new Random();
    }

    public string GetRandomPrompt()
    {
        int index = random.Next(prompts.Count);
        return prompts[index];
    }
}