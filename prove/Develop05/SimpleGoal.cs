using System;

/// <summary>
/// A SimpleGoal can be completed once and then is never done again.
/// When completed, the user receives the specified points.
/// </summary>
public class SimpleGoal : Goal
{
    private bool _ney_isComplete;

    public SimpleGoal(string ney_name, string ney_description, int ney_points)
        : base(ney_name, ney_description, ney_points)
    {
        _ney_isComplete = false;
    }

    public override int RecordEvent()
    {
        if (!_ney_isComplete)
        {
            _ney_isComplete = true;
            return _ney_points;
        }
        return 0; // Already complete, no more points
    }

    public override bool IsComplete() => _ney_isComplete;

    public override string GetDetailsString()
    {
        return $"{GetStatusIndicator()} {_ney_name} ({_ney_description})";
    }

    public string GetStateForSaving()
    {
        return _ney_isComplete.ToString();
    }

    public void RestoreState(bool ney_isComplete)
    {
        _ney_isComplete = ney_isComplete;
    }
}
