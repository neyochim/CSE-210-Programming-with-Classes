using System;

/// <summary>
/// Abstract base class for all types of goals.
/// Uses polymorphism to allow different goal types to handle events differently.
/// </summary>
public abstract class Goal
{
    protected string _ney_name;
    protected string _ney_description;
    protected int _ney_points;

    public Goal(string ney_name, string ney_description, int ney_points)
    {
        _ney_name = ney_name;
        _ney_description = ney_description;
        _ney_points = ney_points;
    }

    /// <summary>
    /// Records that the user has accomplished this goal.
    /// Returns the points earned from this event.
    /// </summary>
    public abstract int RecordEvent();

    /// <summary>
    /// Determines if this goal is complete.
    /// </summary>
    public abstract bool IsComplete();

    /// <summary>
    /// Gets a string representation showing the goal status.
    /// </summary>
    public abstract string GetDetailsString();

    /// <summary>
    /// Gets the short status indicator for the goal.
    /// </summary>
    public virtual string GetStatusIndicator()
    {
        return IsComplete() ? "[X]" : "[ ]";
    }

    public string GetName() => _ney_name;
    public string GetDescription() => _ney_description;
    public int GetPoints() => _ney_points;
}
