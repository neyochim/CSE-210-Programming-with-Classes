using System;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// Manages the user's goals and score.
/// Handles creating goals, recording events, and saving/loading game state.
/// </summary>
public class GoalTracker
{
    private List<Goal> _ney_goals;
    private int _ney_score;
    private int _ney_level;

    public GoalTracker()
    {
        _ney_goals = new List<Goal>();
        _ney_score = 0;
        _ney_level = 1;
    }

    public void AddGoal(Goal ney_goal)
    {
        _ney_goals.Add(ney_goal);
    }

    public void RecordGoalEvent(int ney_goalIndex)
    {
        if (ney_goalIndex >= 0 && ney_goalIndex < _ney_goals.Count)
        {
            int ney_pointsEarned = _ney_goals[ney_goalIndex].RecordEvent();
            _ney_score += ney_pointsEarned;

            // Award milestone bonuses for reaching certain point thresholds
            AwardMilestoneBonuses();
            UpdateLevel();

            Console.WriteLine($"Goal recorded! You earned {ney_pointsEarned} points!");
            Console.WriteLine($"Total Score: {_ney_score}");
        }
    }

    private void AwardMilestoneBonuses()
    {
        // Award bonus every 1000 points
        int ney_milestone = (_ney_score / 1000) * 1000;
        if (ney_milestone > 0 && ney_milestone % 1000 == 0 && _ney_score >= ney_milestone)
        {
            // Only award once per milestone
            if ((_ney_score - GetPointsEarned()) < ney_milestone)
            {
                Console.WriteLine($"🎉 MILESTONE BONUS! You've reached {ney_milestone} points! +100 Bonus Points!");
                _ney_score += 100;
            }
        }
    }

    private int GetPointsEarned()
    {
        // This would need to be tracked more carefully in a fuller implementation
        return 0;
    }

    private void UpdateLevel()
    {
        int ney_newLevel = 1 + (_ney_score / 500);
        if (ney_newLevel > _ney_level)
        {
            _ney_level = ney_newLevel;
            Console.WriteLine($"⭐ LEVEL UP! You are now level {_ney_level}!");
        }
    }

    public void DisplayGoals()
    {
        if (_ney_goals.Count == 0)
        {
            Console.WriteLine("No goals yet. Create one to get started!");
            return;
        }

        Console.WriteLine("\n=== Your Goals ===");
        for (int ney_i = 0; ney_i < _ney_goals.Count; ney_i++)
        {
            Console.WriteLine($"{ney_i + 1}. {_ney_goals[ney_i].GetDetailsString()}");
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"\nCurrent Score: {_ney_score}");
        Console.WriteLine($"Level: {_ney_level}");
    }

    public int GetScore() => _ney_score;
    public int GetLevel() => _ney_level;
    public List<Goal> GetGoals() => _ney_goals;

    public void SaveToFile(string ney_filename)
    {
        try
        {
            using (StreamWriter ney_writer = new StreamWriter(ney_filename))
            {
                ney_writer.WriteLine(_ney_score);
                ney_writer.WriteLine(_ney_level);
                ney_writer.WriteLine(_ney_goals.Count);

                foreach (Goal ney_goal in _ney_goals)
                {
                    if (ney_goal is SimpleGoal ney_simpleGoal)
                    {
                        ney_writer.WriteLine($"SimpleGoal|{ney_goal.GetName()}|{ney_goal.GetDescription()}|{ney_goal.GetPoints()}|{ney_simpleGoal.GetStateForSaving()}");
                    }
                    else if (ney_goal is EternalGoal ney_eternalGoal)
                    {
                        ney_writer.WriteLine($"EternalGoal|{ney_goal.GetName()}|{ney_goal.GetDescription()}|{ney_goal.GetPoints()}|{ney_eternalGoal.GetStateForSaving()}");
                    }
                    else if (ney_goal is ChecklistGoal ney_checklistGoal)
                    {
                        ney_writer.WriteLine($"ChecklistGoal|{ney_goal.GetName()}|{ney_goal.GetDescription()}|{ney_goal.GetPoints()}|{ney_checklistGoal.GetRequiredAmount()}|{ney_checklistGoal.GetBonusPoints()}|{ney_checklistGoal.GetStateForSaving()}");
                    }
                }
            }
            Console.WriteLine("Goals saved successfully!");
        }
        catch (Exception ney_exception)
        {
            Console.WriteLine($"Error saving goals: {ney_exception.Message}");
        }
    }

    public void LoadFromFile(string ney_filename)
    {
        try
        {
            if (!File.Exists(ney_filename))
            {
                Console.WriteLine("No save file found. Starting fresh!");
                return;
            }

            using (StreamReader ney_reader = new StreamReader(ney_filename))
            {
                _ney_score = int.Parse(ney_reader.ReadLine());
                _ney_level = int.Parse(ney_reader.ReadLine());
                int ney_goalCount = int.Parse(ney_reader.ReadLine());

                _ney_goals.Clear();

                for (int ney_i = 0; ney_i < ney_goalCount; ney_i++)
                {
                    string ney_line = ney_reader.ReadLine();
                    string[] ney_parts = ney_line.Split('|');

                    if (ney_parts[0] == "SimpleGoal")
                    {
                        SimpleGoal ney_goal = new SimpleGoal(ney_parts[1], ney_parts[2], int.Parse(ney_parts[3]));
                        ney_goal.RestoreState(bool.Parse(ney_parts[4]));
                        _ney_goals.Add(ney_goal);
                    }
                    else if (ney_parts[0] == "EternalGoal")
                    {
                        EternalGoal ney_goal = new EternalGoal(ney_parts[1], ney_parts[2], int.Parse(ney_parts[3]));
                        ney_goal.RestoreState(int.Parse(ney_parts[4]));
                        _ney_goals.Add(ney_goal);
                    }
                    else if (ney_parts[0] == "ChecklistGoal")
                    {
                        ChecklistGoal ney_goal = new ChecklistGoal(ney_parts[1], ney_parts[2], int.Parse(ney_parts[3]),
                            int.Parse(ney_parts[4]), int.Parse(ney_parts[5]));
                        ney_goal.RestoreState(int.Parse(ney_parts[6]));
                        _ney_goals.Add(ney_goal);
                    }
                }
            }
            Console.WriteLine("Goals loaded successfully!");
        }
        catch (Exception ney_exception)
        {
            Console.WriteLine($"Error loading goals: {ney_exception.Message}");
        }
    }
}
