using System;

/// <summary>
/// An EternalGoal is never finished, but the user can record that they did this goal.
/// Each time the goal is recorded, the user receives the specified points.
/// </summary>
public class EternalGoal : Goal
{
    private int _ney_timesCompleted;

    public EternalGoal(string ney_name, string ney_description, int ney_points)
        : base(ney_name, ney_description, ney_points)
    {
        _ney_timesCompleted = 0;
    }

    public override int RecordEvent()
    {
        _ney_timesCompleted++;
        return _ney_points;
    }

    public override bool IsComplete() => false; // Eternal goals are never complete

    public override string GetDetailsString()
    {
        return $"{GetStatusIndicator()} {_ney_name} ({_ney_description}) - Times completed: {_ney_timesCompleted}";
    }

    public string GetStateForSaving()
    {
        return _ney_timesCompleted.ToString();
    }

    public void RestoreState(int ney_timesCompleted)
    {
        _ney_timesCompleted = ney_timesCompleted;
    }

    public int GetTimesCompleted() => _ney_timesCompleted;
}
