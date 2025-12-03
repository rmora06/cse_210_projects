class ChecklistGoal : Goal
{
    private int targetCount;
    private int currentCount;
    private int bonusPoints;

    public ChecklistGoal(string name, string description, int points, int targetCount, int currentCount, int bonusPoints) : base(name, description, points)
    {
        this.targetCount = targetCount;
        this.currentCount = currentCount;
        this.bonusPoints = bonusPoints;
        if (currentCount >= targetCount)
            completed = true;
    }

    public override int RecordEvent()
    {
        if (completed) return 0;

        currentCount++;
        int totalPoints = points;
        if (currentCount >= targetCount)
        {
            completed = true;
            totalPoints += bonusPoints;
        }
        return totalPoints;
    }

    public override string GetStatus()
    {
        return completed ? $"[X] Completed {currentCount}/{targetCount} times" : $"[ ] Completed {currentCount}/{targetCount} times";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{name}|{description}|{points}|{targetCount}|{currentCount}|{bonusPoints}";
    }
}
