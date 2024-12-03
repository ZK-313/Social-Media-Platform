namespace ConsoleApp1;
using BCrypt.Net;

public class User
{
    private string _password;

    public string FirstName{ get; set; }
    public string LastName{ get; set; }
    public string Email{ get; set; }
    public string Username{ get; set; }

    public string Password
    {
        get { return _password; }
        set
        {
            if (value.Length < 6)
            {
                throw new ArgumentException("Password must be at least 6 characters long!");
            }
            else
            {
                foreach (char c in value)
                {
                    if (char.IsUpper(c))
                    {
                        _password = HashPassword(value);
                        return;
                    }
                }
                throw new ArgumentException("Password must contain an uppercase letter!");
            }
            
        }
    }
    
    public List<User> FollowingList { get; private set; }= new List<User>();
    public List<User> FollowersList { get; private set; }= new List<User>();
    public List<Post> Posts { get; set; }= new List<Post>();
    public List<Comment> Comments{ get; set; }= new List<Comment>();


    public User(string firstName, string lastName, string email, string password, string username)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        Username = username;
    }

    public void CreatePost(string message)
    {
        Post p = new Post(this, message);
        Posts.Add(p);
    }

    public void CreateComment(string message, Post post)
    {
        Comment c = new Comment(post, this, message);
        Comments.Add(c);
        post.AddComment(c);
    }

    public void RemoveComment(Comment comment)
    {
        Comments.Remove(comment);
        comment.CommentedPost.RemoveComment(comment);
    }

    public void LikePost(Post post)
    {
        post.Like(this);
    }

    public void LikeComment(Comment comment)
    {
        comment.Like(this);
    }

    private void AddFollower(User user)
    {
        FollowersList.Add(user);
    }

    private void RemoveFollower(User user)
    {
        FollowersList.Remove(user);
    }

    public void Follow(User user)
    {
        if (!FollowingList.Contains(user))
        {
            FollowingList.Add(user);
            user.AddFollower(this);
        }
    }

    public void Unfollow(User user)
    {
        if (FollowingList.Contains(user))
        {
            FollowingList.Remove(user);
            user.RemoveFollower(this);
        }
    }
    private string HashPassword(string password)
    {
        return BCrypt.HashPassword(password);
    }
    public bool CheckPassword(string password)
    {
        return BCrypt.Verify(password, _password);
    }

    
}