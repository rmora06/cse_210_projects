public class Cycling : Activity
{
    private double _speed; // kph

    public Cycling(string date, int minutes, double speed)
        : base(date, minutes)
    {
        _speed = speed;
    }

    public override double GetSpeed() => _speed;

    public override double GetDistance()
    {
        return (_speed * Minutes) / 60.0;
    }

    public override double GetPace()
    {
        return Minutes / GetDistance();
    }
}
