using System;

/// <summary>
/// A ChecklistGoal is a goal that must be completed a certain number of times.
/// Each time it is recorded, the user receives a set number of points.
/// When the goal reaches the target number of times, the user receives a bonus.
/// </summary>
public class ChecklistGoal : Goal
{
    private int _ney_amountCompleted;
    private int _ney_requiredAmount;
    private int _ney_bonusPoints;

    public ChecklistGoal(string ney_name, string ney_description, int ney_points, int ney_requiredAmount, int ney_bonusPoints)
        : base(ney_name, ney_description, ney_points)
    {
        _ney_amountCompleted = 0;
        _ney_requiredAmount = ney_requiredAmount;
        _ney_bonusPoints = ney_bonusPoints;
    }

    public override int RecordEvent()
    {
        int ney_pointsEarned = 0;

        if (!IsComplete())
        {
            _ney_amountCompleted++;
            ney_pointsEarned = _ney_points;

            // Check if we just completed the goal
            if (_ney_amountCompleted == _ney_requiredAmount)
            {
                ney_pointsEarned += _ney_bonusPoints;
            }
        }

        return ney_pointsEarned;
    }

    public override bool IsComplete() => _ney_amountCompleted >= _ney_requiredAmount;

    public override string GetDetailsString()
    {
        return $"{GetStatusIndicator()} {_ney_name} ({_ney_description}) - Completed {_ney_amountCompleted}/{_ney_requiredAmount} times";
    }

    public string GetStateForSaving()
    {
        return _ney_amountCompleted.ToString();
    }

    public void RestoreState(int ney_amountCompleted)
    {
        _ney_amountCompleted = ney_amountCompleted;
    }

    public int GetAmountCompleted() => _ney_amountCompleted;
    public int GetRequiredAmount() => _ney_requiredAmount;
    public int GetBonusPoints() => _ney_bonusPoints;
}
