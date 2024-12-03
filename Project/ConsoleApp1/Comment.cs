namespace ConsoleApp1;

public class Comment
{
    public User Commenter { get; set; }
    public string Message { get; set; }
    public int Likes { get; set; }
    public DateTime Date { get; set; }
    public Post CommentedPost { get; set; }
    public List<User> Likers { get; set; } = new List<User>();
    public List<Comment> Replies { get; set; } = new List<Comment>();

    public Comment(Post post, User user, string comment)
    {
        CommentedPost = post;
        Commenter = user;
        Message = comment;
        Date = DateTime.Now;
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