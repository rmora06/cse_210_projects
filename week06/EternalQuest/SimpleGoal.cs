class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points) : base(name, description, points) {}

    public SimpleGoal(string name, string description, int points, bool completed) : base(name, description, points)
    {
        this.completed = completed;
    }

    public override int RecordEvent()
    {
        if (!completed)
        {
            completed = true;
            return points;
        }
        return 0;
    }

    public override string GetStatus()
    {
        return completed ? "[X]" : "[ ]";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal|{name}|{description}|{points}|{completed}";
    }
}