using System;

/// <summary>
/// ETERNAL QUEST - A Goal Tracking Program with Gamification
/// 
/// CREATIVITY & FEATURES BEYOND CORE REQUIREMENTS:
/// 1. LEVEL SYSTEM: Users level up as they earn points (1 level per 500 points)
///    This adds a long-term progression goal alongside individual goals
/// 
/// 2. MILESTONE BONUSES: Every 1000 points, users receive a +100 bonus
///    This rewards consistent progress and provides satisfying checkpoints
/// 
/// 3. VISUAL FEEDBACK: The program uses celebration emojis and clear feedback
///    when achieving milestones and leveling up, making accomplishments feel rewarding
/// 
/// 4. PERSISTENT STATE: Not only goals are saved, but also the user's score and level
///    allowing players to maintain their progression across sessions
/// 
/// These features turn the program from a simple tracker into an engaging gamified experience
/// that motivates users to maintain their goals by showing visible progress and achievements.
/// </summary>

class Program
{
    static void Main(string[] ney_args)
    {
        GoalTracker ney_tracker = new GoalTracker();
        const string _ney_saveFile = "goals.txt";

        ney_tracker.LoadFromFile(_ney_saveFile);

        bool ney_running = true;
        while (ney_running)
        {
            Console.WriteLine("\n=== Eternal Quest Menu ===");
            Console.WriteLine("1. Create a new goal");
            Console.WriteLine("2. List goals");
            Console.WriteLine("3. Record a goal event");
            Console.WriteLine("4. Show score");
            Console.WriteLine("5. Save and quit");
            Console.Write("Choose an option: ");

            string ney_choice = Console.ReadLine();

            switch (ney_choice)
            {
                case "1":
                    CreateNewGoal(ney_tracker);
                    break;
                case "2":
                    ney_tracker.DisplayGoals();
                    break;
                case "3":
                    RecordGoalEvent(ney_tracker);
                    break;
                case "4":
                    ney_tracker.DisplayScore();
                    break;
                case "5":
                    ney_tracker.SaveToFile(_ney_saveFile);
                    ney_running = false;
                    Console.WriteLine("Thank you for playing Eternal Quest!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void CreateNewGoal(GoalTracker ney_tracker)
    {
        Console.WriteLine("\n=== Create a New Goal ===");
        Console.WriteLine("1. Simple Goal (complete once, gain points)");
        Console.WriteLine("2. Eternal Goal (never complete, gain points each time)");
        Console.WriteLine("3. Checklist Goal (complete X times, gain points each time + bonus)");
        Console.Write("Choose goal type: ");

        string ney_goalType = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string ney_name = Console.ReadLine();

        Console.Write("Enter goal description: ");
        string ney_description = Console.ReadLine();

        Console.Write("Enter points for this goal: ");
        int ney_points = int.Parse(Console.ReadLine());

        switch (ney_goalType)
        {
            case "1":
                ney_tracker.AddGoal(new SimpleGoal(ney_name, ney_description, ney_points));
                Console.WriteLine("Simple goal created!");
                break;

            case "2":
                ney_tracker.AddGoal(new EternalGoal(ney_name, ney_description, ney_points));
                Console.WriteLine("Eternal goal created!");
                break;

            case "3":
                Console.Write("Enter the number of times this goal must be completed: ");
                int ney_requiredAmount = int.Parse(Console.ReadLine());

                Console.Write("Enter bonus points for completing the goal: ");
                int ney_bonusPoints = int.Parse(Console.ReadLine());

                ney_tracker.AddGoal(new ChecklistGoal(ney_name, ney_description, ney_points, ney_requiredAmount, ney_bonusPoints));
                Console.WriteLine("Checklist goal created!");
                break;

            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }

    static void RecordGoalEvent(GoalTracker ney_tracker)
    {
        ney_tracker.DisplayGoals();

        Console.Write("Enter the number of the goal to record: ");
        int ney_goalNumber = int.Parse(Console.ReadLine()) - 1;

        ney_tracker.RecordGoalEvent(ney_goalNumber);
    }
}
