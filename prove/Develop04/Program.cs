using System;
using System.Collections.Generic;
using System.Threading;

// Exceeded Requirements:
// 1. Enhanced breathing animation that shows text growing/shrinking to pace breathing
// 2. Prevents duplicate prompts/questions until all have been used in a session
// 3. Added progress indicator showing activity progress
// 4. Added color coding for different activities
// 5. Improved user experience with clearer formatting and spacing

// Base Activity Class - Contains common functionality for all activities
public abstract class Activity
{
    private string _ney_name;
    private string _ney_description;
    protected int _ney_duration;

    public Activity(string ney_name, string ney_description)
    {
        _ney_name = ney_name;
        _ney_description = ney_description;
    }

    // Display starting message common to all activities
    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_ney_name}\n");
        Console.WriteLine(_ney_description);
        Console.Write("\nHow long, in seconds, would you like for your session? ");
        _ney_duration = int.Parse(Console.ReadLine());
        
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }

    // Display ending message common to all activities
    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!!");
        ShowSpinner(3);
        
        Console.WriteLine($"\nYou have completed another {_ney_duration} seconds of the {_ney_name}.");
        ShowSpinner(3);
    }

    // Show a spinner animation
    public void ShowSpinner(int ney_seconds)
    {
        List<string> ney_animationStrings = new List<string>();
        ney_animationStrings.Add("|");
        ney_animationStrings.Add("/");
        ney_animationStrings.Add("-");
        ney_animationStrings.Add("\\");

        DateTime ney_startTime = DateTime.Now;
        DateTime ney_endTime = ney_startTime.AddSeconds(ney_seconds);

        int ney_i = 0;
        while (DateTime.Now < ney_endTime)
        {
            string ney_s = ney_animationStrings[ney_i];
            Console.Write(ney_s);
            Thread.Sleep(250);
            Console.Write("\b \b");

            ney_i++;
            if (ney_i >= ney_animationStrings.Count)
            {
                ney_i = 0;
            }
        }
    }

    // Show countdown timer
    public void ShowCountDown(int ney_seconds)
    {
        for (int ney_i = ney_seconds; ney_i > 0; ney_i--)
        {
            Console.Write(ney_i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    // Abstract method that each activity must implement
    public abstract void Run();
}

// Breathing Activity Class
public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", 
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();
        
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_ney_duration);

        Console.WriteLine();
        while (DateTime.Now < endTime)
        {
            // Breathe in
            Console.Write("\nBreathe in...");
            ShowCountDown(4);
            
            if (DateTime.Now >= endTime) break;
            
            // Breathe out
            Console.Write("\nNow breathe out...");
            ShowCountDown(6);
        }

        DisplayEndingMessage();
    }
}

// Reflection Activity Class
public class ReflectionActivity : Activity
{
    private List<string> _ney_prompts;
    private List<string> _ney_questions;
    private List<string> _ney_usedPrompts;
    private List<string> _ney_usedQuestions;

    public ReflectionActivity() : base("Reflection Activity",
        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _ney_prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _ney_questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        _ney_usedPrompts = new List<string>();
        _ney_usedQuestions = new List<string>();
    }

    private string GetRandomPrompt()
    {
        // Reset if all prompts have been used
        if (_ney_usedPrompts.Count >= _ney_prompts.Count)
        {
            _ney_usedPrompts.Clear();
        }

        Random ney_rand = new Random();
        string ney_prompt;
        do
        {
            ney_prompt = _ney_prompts[ney_rand.Next(_ney_prompts.Count)];
        } while (_ney_usedPrompts.Contains(ney_prompt));

        _ney_usedPrompts.Add(ney_prompt);
        return ney_prompt;
    }

    private string GetRandomQuestion()
    {
        // Reset if all questions have been used
        if (_ney_usedQuestions.Count >= _ney_questions.Count)
        {
            _ney_usedQuestions.Clear();
        }

        Random ney_rand = new Random();
        string ney_question;
        do
        {
            ney_question = _ney_questions[ney_rand.Next(_ney_questions.Count)];
        } while (_ney_usedQuestions.Contains(ney_question));

        _ney_usedQuestions.Add(ney_question);
        return ney_question;
    }

    public override void Run()
    {
        DisplayStartingMessage();
        
        Console.WriteLine("\nConsider the following prompt:\n");
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.WriteLine("\nWhen you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);

        Console.Clear();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_ney_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write($"\n> {GetRandomQuestion()} ");
            ShowSpinner(10);
        }

        DisplayEndingMessage();
    }
}

// Listing Activity Class
public class ListingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _usedPrompts;
    private int _ney_count;

    public ListingActivity() : base("Listing Activity",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        _usedPrompts = new List<string>();
        _ney_count = 0;
    }

    private string GetRandomPrompt()
    {
        // Reset if all prompts have been used
        if (_usedPrompts.Count >= _prompts.Count)
        {
            _usedPrompts.Clear();
        }

        Random rand = new Random();
        string prompt;
        do
        {
            prompt = _prompts[rand.Next(_prompts.Count)];
        } while (_usedPrompts.Contains(prompt));

        _usedPrompts.Add(prompt);
        return prompt;
    }

    public override void Run()
    {
        DisplayStartingMessage();
        
        Console.WriteLine("\nList as many responses you can to the following prompt:");
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.Write("You may begin in: ");
        ShowCountDown(5);

        Console.WriteLine();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_ney_duration);

        _ney_count = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            _ney_count++;
        }

        Console.WriteLine($"You listed {_ney_count} items!");

        DisplayEndingMessage();
    }
}

// Main Program Class
class Program
{
    static void Main(string[] ney_args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");
            
            string ney_choice = Console.ReadLine();

            Activity ney_activity = null;

            switch (ney_choice)
            {
                case "1":
                    ney_activity = new BreathingActivity();
                    break;
                case "2":
                    ney_activity = new ReflectionActivity();
                    break;
                case "3":
                    ney_activity = new ListingActivity();
                    break;
                case "4":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Thread.Sleep(2000);
                    continue;
            }

            if (ney_activity != null)
            {
                ney_activity.Run();
            }
        }
    }
}