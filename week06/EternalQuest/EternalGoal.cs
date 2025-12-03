class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points) {}

    public override int RecordEvent()
    {
        return points;
    }

    public override string GetStatus()
    {
        return "[∞]";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal|{name}|{description}|{points}";
    }
}
