using System;

class Swimming : Activity
{
    private int _ney_laps;
    public int ney_Laps => _ney_laps;

    public Swimming(DateTime date, double minutes, int laps) : base(date, minutes)
    {
        _ney_laps = laps;
    }

    public override double GetDistance()
    {
        // laps * 50 meters -> km = *50/1000. Convert km to miles using 0.62 as specified.
        return _ney_laps * 50.0 / 1000.0 * 0.62;
    }

    public override double GetSpeed() => (GetDistance() / ney_Minutes) * 60.0;
    public override double GetPace() => ney_Minutes / GetDistance();
}
