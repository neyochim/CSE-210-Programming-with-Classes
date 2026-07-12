using System;
using System.Collections.Generic;

class Comment
{
    public string ney_Name { get; set; }
    public string ney_Text { get; set; }

    public Comment(string ney_name, string ney_text)
    {
        ney_Name = ney_name;
        ney_Text = ney_text;
    }
}

class Video
{
    public string ney_Title { get; set; }
    public string ney_Author { get; set; }
    public int ney_LengthSeconds { get; set; }
    private List<Comment> _ney_Comments;

    public Video(string ney_title, string ney_author, int ney_lengthSeconds)
    {
        ney_Title = ney_title;
        ney_Author = ney_author;
        ney_LengthSeconds = ney_lengthSeconds;
        _ney_Comments = new List<Comment>();
    }

    public void AddComment(Comment ney_comment)
    {
        _ney_Comments.Add(ney_comment);
    }

    public int GetCommentCount()
    {
        return _ney_Comments.Count;
    }

    public List<Comment> GetComments()
    {
        return _ney_Comments;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Video> ney_videos = new List<Video>();

        Video ney_video1 = new Video("How to Bake Bread", "Ava Baker", 420);
        ney_video1.AddComment(new Comment("Mia", "This recipe worked really well for me!"));
        ney_video1.AddComment(new Comment("Noah", "Clear steps and great results."));
        ney_video1.AddComment(new Comment("Liam", "I learned a lot from this video."));
        ney_videos.Add(ney_video1);

        Video ney_video2 = new Video("Building a Birdhouse", "Carson Crafts", 615);
        ney_video2.AddComment(new Comment("Emma", "My kids loved helping with this."));
        ney_video2.AddComment(new Comment("Sophia", "The measurements were perfect."));
        ney_video2.AddComment(new Comment("Olivia", "Thanks for the helpful tips!"));
        ney_video2.AddComment(new Comment("Ethan", "I made one this weekend."));
        ney_videos.Add(ney_video2);

        Video ney_video3 = new Video("Morning Workout Routine", "Zoe Fitness", 300);
        ney_video3.AddComment(new Comment("Ava", "Short and effective workout."));
        ney_video3.AddComment(new Comment("Lucas", "Exactly what I needed today."));
        ney_video3.AddComment(new Comment("Isabella", "Great pacing and instructions."));
        ney_videos.Add(ney_video3);

        Video ney_video4 = new Video("Intro to Photography", "Nora Lens", 780);
        ney_video4.AddComment(new Comment("James", "Very helpful for beginners."));
        ney_video4.AddComment(new Comment("Charlotte", "I finally understand aperture now."));
        ney_video4.AddComment(new Comment("Benjamin", "Nice examples throughout."));
        ney_videos.Add(ney_video4);

        foreach (Video ney_video in ney_videos)
        {
            Console.WriteLine($"Title: {ney_video.ney_Title}");
            Console.WriteLine($"Author: {ney_video.ney_Author}");
            Console.WriteLine($"Length: {ney_video.ney_LengthSeconds} seconds");
            Console.WriteLine($"Comments: {ney_video.GetCommentCount()}");

            foreach (Comment ney_comment in ney_video.GetComments())
            {
                Console.WriteLine($"  {ney_comment.ney_Name}: {ney_comment.ney_Text}");
            }

            Console.WriteLine();
        }
    }
}