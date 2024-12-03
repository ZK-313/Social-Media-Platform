namespace ConsoleApp1;

public class Post
{
    public string Content { get; private set; }
    public DateTime Date { get; private set; }
    public int Likes { get; private set; } = 0;
    public List<Comment> Comments { get; private set; } = new List<Comment>();
    public List<User> Likers { get; private set; } = new List<User>();

    public User Poster { get; private set; }

    public Post(User poster, string content)
    {
        Poster = poster;
        Content = content;
        Date = DateTime.Now;
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public void RemoveComment(Comment comment)
    {
        Comments.Remove(comment);
    }

    public void Like(User user)
    {
        if (Likers.Contains(user))
        {
            Likers.Remove(user);
            Likes--;
        }
        else
        {
            Likers.Add(user);
            Likes++;
        }
    }
    
}