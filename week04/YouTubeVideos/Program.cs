using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("How to Cook Pasta", "Chef Mario", 300);
        video1.AddComment(new Comment("Alice", "This recipe is amazing!"));
        video1.AddComment(new Comment("Bob", "Tried it and loved it."));
        video1.AddComment(new Comment("Charlie", "Can you make a gluten-free version?"));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("Top 10 Travel Destinations", "Wanderlust", 480);
        video2.AddComment(new Comment("Diana", "I want to visit all of these!"));
        video2.AddComment(new Comment("Ethan", "Great list, thanks!"));
        video2.AddComment(new Comment("Fiona", "You forgot Iceland!"));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("Beginner's Guide to C#", "CodeMaster", 600);
        video3.AddComment(new Comment("George", "Very helpful, thanks!"));
        video3.AddComment(new Comment("Hannah", "Can you do one on LINQ?"));
        video3.AddComment(new Comment("Ian", "Subscribed!"));
        videos.Add(video3);

        // Display all videos and their comments
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($" - {comment.CommenterName}: {comment.Text}");
            }
            Console.WriteLine(new string('-', 40));
        }
    }
}