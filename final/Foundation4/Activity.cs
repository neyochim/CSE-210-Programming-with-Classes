using System;

abstract class Activity
{
    private DateTime _ney_date;
    private double _ney_minutes;

    public DateTime ney_Date => _ney_date;
    public double ney_Minutes => _ney_minutes;

    public Activity(DateTime date, double minutes)
    {
        _ney_date = date;
        _ney_minutes = minutes;
    }

    public virtual double GetDistance() => 0.0;
    public virtual double GetSpeed() => 0.0;
    public virtual double GetPace() => 0.0;

    public virtual string GetSummary()
    {
        string dateStr = ney_Date.ToString("dd MMM yyyy");
        string type = this.GetType().Name;
        return $"{dateStr} {type} ({ney_Minutes} min): Distance {GetDistance():0.0} miles, Speed {GetSpeed():0.0} mph, Pace: {GetPace():0.00} min per mile";
    }
}
