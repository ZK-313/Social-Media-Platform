namespace ConsoleApp1;

public class Notification
{
    public enum NotificationType
    {
        LikeComment,
        LikePost,
        Comment,
        Follow,
        FollowRequest,
        Reply
    }
    public User Person { get; private set; }
    public String Content { get; private set; }
    public NotificationType Type { get; private set; }

    public bool Read { get; private set; } = false;
    public DateTime Date { get; private set; }
    public Post? RelatedPost { get; private set; }
    public Comment? RelatedComment { get; private set; }

    public Notification(User user, NotificationType notificationType)
    {
        Person = user;
        Person.Notifications.Add(this);
        Type = notificationType;
        Date = DateTime.Now;
    }
    public Notification(User user, NotificationType notificationType, Post post)
    {
        if (notificationType != NotificationType.LikePost)
        {
            throw new ArgumentException("Invalid notification type");
        }
        Person = user;
        Person.Notifications.Add(this);
        Type = notificationType;
        Date = DateTime.Now;
        RelatedPost = post;
    }
    public Notification(User user, NotificationType notificationType, Post post, Comment comment)
    {
        if (notificationType != NotificationType.Comment)
        {
            throw new ArgumentException("Invalid notification type");
        }
        Person = user;
        Person.Notifications.Add(this);
        Type = notificationType;
        Date = DateTime.Now;
        RelatedPost = post;
        RelatedComment = comment;
    }
    public Notification(User user, NotificationType notificationType, Comment comment)
    {
        if (notificationType != NotificationType.LikeComment && notificationType != NotificationType.Reply)
        {
            throw new ArgumentException("Invalid notification type");
        }
        Person = user;
        Person.Notifications.Add(this);
        Type = notificationType;
        Date = DateTime.Now;
        RelatedComment = comment;
    }

    public void isRead()
    {
        Read = !Read;
    }
}