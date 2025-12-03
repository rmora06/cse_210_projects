abstract class Goal
{
    protected string name;
    protected string description;
    protected int points;
    protected bool completed;

    public Goal(string name, string description, int points)
    {
        this.name = name;
        this.description = description;
        this.points = points;
        this.completed = false;
    }

    public string Name { get { return name; } }
    public string Description { get { return description; } }
    public int Points { get { return points; } }
    public bool Completed { get { return completed; } }

    public abstract int RecordEvent();

    public abstract string GetStatus();

    public abstract string GetStringRepresentation();

    public static Goal CreateGoalFromString(string data)
    {
        string[] parts = data.Split('|');
        string type = parts[0];
        switch(type)
        {
            case "SimpleGoal":
                return new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4]));
            case "EternalGoal":
                return new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
            case "ChecklistGoal":
                return new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6]));
            default:
                throw new Exception("Unknown type of Goal");
        }
    }
}
