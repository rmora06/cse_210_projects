public abstract class Activity
{
    private string _date;
    private int _minutes;

    public Activity(string date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public string Date => _date;
    public int Minutes => _minutes;

    public abstract double GetDistance(); // km o miles
    public abstract double GetSpeed();    // kph o mph
    public abstract double GetPace();     // min por km/milla

    public virtual string GetSummary()
    {
        return $"{Date} {GetType().Name} ({Minutes} min) - " +
               $"Distance {GetDistance():0.0}, " +
               $"Speed {GetSpeed():0.0}, " +
               $"Pace {GetPace():0.0}";
    }
}
