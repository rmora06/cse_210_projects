// RandomCycle.cs
using System;
using System.Collections.Generic;

public class RandomCycle
{
    private readonly List<string> _source;
    private readonly Queue<string> _queue = new();
    private readonly Random _rng = new();

    public RandomCycle(IEnumerable<string> items)
    {
        _source = new List<string>(items);
        RefillQueue();
    }

    public string Next()
    {
        if (_queue.Count == 0)
            RefillQueue();
        return _queue.Dequeue();
    }

    private void RefillQueue()
    {
        var shuffled = new List<string>(_source);
        for (int i = 0; i < shuffled.Count; i++)
        {
            int j = _rng.Next(i, shuffled.Count);
            (shuffled[i], shuffled[j]) = (shuffled[j], shuffled[i]);
        }
        foreach (var s in shuffled)
            _queue.Enqueue(s);
    }
}