namespace ConsoleApp1;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // var users = new List<User>();
        // var posts = new List<Post>();
        //
        // while (true)
        // {
        //     Console.WriteLine("Social Media App");
        //     Console.WriteLine("1. Register");
        //     Console.WriteLine("2. Login");
        //     Console.WriteLine("3. Exit");
        //     Console.Write("Choose an option: ");
        //     var choice = Console.ReadLine();
        //
        //     switch (choice)
        //     {
        //         case "1":
        //             Console.Write("Enter First Name: ");
        //             var firstname = Console.ReadLine();
        //             Console.Write("Enter Last Name: ");
        //             var lastname = Console.ReadLine();
        //             Console.Write("Enter username: ");
        //             var username = Console.ReadLine();
        //             Console.Write("Enter email: ");
        //             var email = Console.ReadLine();
        //             Console.Write("Enter password: ");
        //             var password = Console.ReadLine();
        //
        //             var user = new User(firstname, lastname, email, password, username);
        //             users.Add(user);
        //
        //             Console.WriteLine("User registered successfully!");
        //             break;
        //
        //         case "2":
        //             Console.Write("Enter username: ");
        //             username = Console.ReadLine();
        //             Console.Write("Enter password: ");
        //             password = Console.ReadLine();
        //
        //             user = users.Find(u => u.Username == username && u.CheckPassword(password));
        //
        //             if (user != null)
        //             {
        //                 Console.WriteLine($"Welcome {user.Username}!");
        //                 UserMenu(user, posts);
        //             }
        //             else
        //             {
        //                 Console.WriteLine("Invalid credentials!");
        //             }
        //             break;
        //
        //         case "3":
        //             return;
        //
        //         default:
        //             Console.WriteLine("Invalid choice!");
        //             break;
        //     }
        // }
        User user1 = new User("Zulfiqar", "Khan", "zk@zk.com", "MyPassword123@", "Crain");
        User user2 = new User("Stacy", "Jane", "sjxo@gmail.com", "iLikeCats153@", "Staxy");
        user2.CreatePost("Heyyyyyy this is my first post!");
       // Console.WriteLine("Post: "+user2.Posts[0].Content+"\nLikes: "+user2.Posts[0].Likes);
        user1.LikePost(user2.Posts[0]);
        user1.CreateComment("Hello Stacy!", user2.Posts[0]);
        Console.WriteLine(user2.Posts[0].Comments[0].Commenter.Username +": "+user2.Posts[0].Comments[0].Message);
    }
    

    static void UserMenu(User user, List<Post> posts)
    {
        while (true)
        {
            Console.WriteLine("\nUser Menu");
            Console.WriteLine("1. Create Post");
            Console.WriteLine("2. View Posts");
            Console.WriteLine("3. Logout");
            Console.Write("Choose an option: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter post content: ");
                    var content = Console.ReadLine();
                    var post = new Post(user, content);
                    user.CreatePost(content);
                    posts.Add(post);

                    Console.WriteLine("Post created!");
                    break;

                case "2":
                    foreach (var p in posts)
                    {
                        Console.WriteLine($"\nPost by {p.Poster.Username}");
                        Console.WriteLine(p.Content);
                        Console.WriteLine($"Likes: {p.Likes}, Comments: {p.Comments.Count}");
                    }
                    break;

                case "3":
                    return;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }
}

