﻿// See https://aka.ms/new-console-template for more information
using MiniSocialMedia;
using System.IO;
using System.Text.Json;

class Program
{
    static Repository<User> _users = new();
    static User? _currentUser;
    static readonly string _dataFile = "data.json";
    

    public static void Main()
    {

        Console.Title = "MiniSocial - Console Edition";
        Console.WriteLine("Welcome to Mini Social Media App!");
        Console.WriteLine("=== MiniSocial ===");

        LoadData();


        while (true)
        {
            try
            {
                if(_currentUser == null)
                {
                    ShowLoginMenu();
                }
                else
                {
                    ShowMainMenu();
                }
            }catch(SocialException ex)
            {
                ConsoleColorWrite(ConsoleColor.Red, $"Error: {ex.Message}");
            }
        }

    }
    

    public static void ShowLoginMenu()
    {
        Console.WriteLine("1. Register \n2. Login \n3.Exit");
        var choice = Console.ReadLine();

        if(choice == "1") Register();
        else if(choice == "2") Login();
        else if(choice == "3")
        {
            SaveData();
            Environment.Exit(0);
        }
    }
    public static void Register()
    {
        Console.Write("Username: ");
        var username = Console.ReadLine();

        Console.Write("Email: ");
        var email = Console.ReadLine();

        if(_users.Find(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)) != null)
        {
            throw new SocialException("Username already Exists.");
        }

        var user = new User(username, email);
        _users.Add(user);

        Console.WriteLine("User Registered Successfully!");

    }

    public static void Login()
    {
        Console.WriteLine("Username: ");
        var username = Console.ReadLine();

        var user = _users.Find(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

        if(user == null)
        {
            throw new SocialException("User not found");
        }

        _currentUser = user;
        Console.WriteLine($"Welcome {_currentUser}");

        _currentUser.OnNewPost += (post) =>
        {
            ConsoleColorWrite(ConsoleColor.Cyan, $"New Post By {post.Author}: " + $"{(post.Content.Length > 40 ? post.Content[..40] + "...": post.Content)}");
        };
    }
    public static void ShowMainMenu()
    {
        Console.WriteLine($"Logged in as {_currentUser}");
        Console.WriteLine("1. Post Message \n2. View Own Posts \n3. View Timeline \n4. Follow User \n5. List Users \n6. Logout \n7. Exit and save.");

        var choice = int.Parse(Console.ReadLine());

        // if(choice == "1") PostMessage();
        // else if(choice == "2") ShowTimeline();
        // else if(choice == "3") FollowUser();
        // else if(choice == "4") ListUsers();
        // else if(choice == "5") _currentUser = null;

        switch (choice)
        {
            case 1:
                PostMessage();
                break;
            case 2:
                ShowPosts(_currentUser.GetPosts());
                break;
            case 3:
                ShowTimeline();
                break;
            case 4:
                FollowUser();
                break;
            case 5:
                ListUsers();
                break;
            case 6:
                _currentUser = null;
                break;
            case 7:
                SaveData();
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid Input!");
                break;

        }


    }
    public static void PostMessage()
    {
        if(_currentUser != null)
        {
            Console.Write("Enter content: ");
            var content = Console.ReadLine();

            _currentUser.AddPost(content);
            Console.WriteLine("Post Uploaded Successfulyy!");
            
        }
    }
    public static void ShowTimeline()
    {
        if (_currentUser == null) return;

        Console.WriteLine("=== Your Timeline ===");

        var timeline = new List<Post>();

        timeline.AddRange(_currentUser.GetPosts());

        foreach (var username in _currentUser.GetFollowingNames())
        {
            var user = _users.Find(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
            if (user != null)
                timeline.AddRange(user.GetPosts());
        }

        var sorted = timeline.OrderByDescending(p => p.CreatedAt);
        ShowPosts(sorted);
    }
    public static void ShowPosts(IEnumerable<Post> posts)
    {
        int cnt = 0;

        foreach(var post in posts.Take(20))
        {
            Console.WriteLine(post);
            Console.WriteLine(post.CreatedAt.FormatTimeAgo());
            Console.WriteLine("------------------------------");
            cnt++;
        }
        if(cnt == 0)
        {
            Console.WriteLine("No Posts Yet.");
        }
    }

    public static void FollowUser()
    {
        if(_currentUser != null)
        {
            Console.Write("Enter Username to Follow: ");
            var username = Console.ReadLine();

            if(username == null)
            {
                Console.WriteLine("Invalid Input!, Need username: ");
                return;
            }
            if(username == _currentUser.Username)
            {
                Console.WriteLine("You are trying to follow your own account!");
                return;
            }

            var target = _users.Find(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

            if (target == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            _currentUser.Follow(username);
            Console.WriteLine("Followed Successfully!");
        }
        else
        {
            Console.WriteLine("You need to Login First!");
        }
    }
    public static void ListUsers()
    {
        Console.WriteLine("Registered users:");

        foreach (var user in _users.GetAll().OrderBy(u => u))
        {
            Console.WriteLine($"{user,-20} {user.Email}");
        }
    }
    public static void SaveData()
    {
        try
        {
            var data = _users.GetAll().Select(u => new
            {
                u.Username,
                u.Email,
                Following = u.GetFollowingNames(),
                Posts = u.GetPosts().Select(p => new
                {
                    p.Content,
                    p.CreatedAt
                })
            });

            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(_dataFile, json);
            Console.WriteLine("Data saved.");
        }
        catch
        {
            Console.WriteLine("Failed to save data.");
        }
    }

    public static void LoadData()
    {
        if (!File.Exists(_dataFile)) return;

        var json = File.ReadAllText(_dataFile);
        var users = JsonSerializer.Deserialize<User[]>(json);

        if (users != null)
        {
            foreach (var u in users)
            {
                _users.Add(u);
            }
        }
    }
    static void ConsoleColorWrite(ConsoleColor color, string msg)
    {
        var old = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.WriteLine(msg);
        Console.ForegroundColor = old;
    }
}