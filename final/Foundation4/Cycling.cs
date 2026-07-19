using System;

class Cycling : Activity
{
    private double _ney_speed; // mph
    public double ney_Speed => _ney_speed;

    public Cycling(DateTime date, double minutes, double speed) : base(date, minutes)
    {
        _ney_speed = speed;
    }

    public override double GetDistance() => ney_Speed * ney_Minutes / 60.0;
    public override double GetSpeed() => ney_Speed;
    public override double GetPace() => ney_Minutes / GetDistance();
}
