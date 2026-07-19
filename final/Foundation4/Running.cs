using System;

class Running : Activity
{
    private double _ney_distance; // miles
    public double ney_Distance => _ney_distance;

    public Running(DateTime date, double minutes, double distance) : base(date, minutes)
    {
        _ney_distance = distance;
    }

    public override double GetDistance() => _ney_distance;
    public override double GetSpeed() => (GetDistance() / ney_Minutes) * 60.0;
    public override double GetPace() => ney_Minutes / GetDistance();
}
