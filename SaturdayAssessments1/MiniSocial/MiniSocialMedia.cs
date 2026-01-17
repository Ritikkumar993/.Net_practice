using System.Collections;
using System.Text;
using System.Text.RegularExpressions;

namespace MiniSocialMedia
{
//     class SocialException:Exception
//     {
//         public SocialException(string message){ }
//         public SocialException(string message, Exception inner):base(message,inner){ }        
//     }

//     interface IPostable
//     {
//         public void AddPost(string content);
        
//         public IReadOnlyList<Post> GetPost();
    
//     }

//     class Post
//     {
//         public User Author{get;}
//         public string Content{get;}
//         public DateTime CreatedAt{get;}


//         public Post(User author, string content)
//         {
//             if (author == null)
//             {
//                 throw new ArgumentNullException("author in null");
//             }

//             Author = author;
//             Content = content;
//             CreatedAt=DateTime.Now; 
//         }

//         public override string ToString()
//         {
//             StringBuilder sb = new StringBuilder();

//             sb.AppendLine($"{Author} • {CreatedAt:MMM dd HH:mm}");
//             sb.AppendLine(Content);

//             string hashtagPattern=@"^#[A-Za-z]+";
//             MatchCollection hashtags =Regex.Matches(Content,hashtagPattern);
        
//             if (hashtags.Count > 0)
//             {
//                 sb.Append("Tags: ");  
//                 sb.AppendJoin(",", hashtags.Cast<Match>().Select(m => m.Value));
//             }
//             return sb.ToString();
//         }
//     }


//     // IPostable, IReadOnlyList<Post>
//     partial class User: IPostable,  IComparable<User>
//     {
//         public string Username{get; init;}
//         public string Email{get; init;}
//         private readonly List<Post> _posts= new List<Post>();

//         private readonly HashSet<string> _following = new(StringComparer.OrdinalIgnoreCase);
//         public event Action<Post>? OnNewPost;

//         public User (string? username, string? email)
//         {
//             if (string.IsNullOrWhiteSpace(username))
//             {
//                 throw new ArgumentException($"{username} is Invalid");
//             }

//             // string emailPattern = @"^(?!\.)(?!.*\.\.)[a-zA-Z0-9._%+-]+@[a-zA-Z0-9-]+(\.[a-zA-Z]{2,})+$";

//             string emailPattern = @"[a-zA-Z]+[a-zA-Z0-9._%+-]+[a-zA-Z0-9]+@[a-zA-Z0-9-]+(\.[a-zA-Z]{2,})+$";

//             if (!Regex.IsMatch(email, emailPattern))
//             {
//                 throw new Exception("Invalid email format");
//             }

//             Username= username.Trim();

//             Email= email.Trim().ToLower();
        
//         }

//         public void Follow(string username)
//         {
//             if(string.Compare(Username,username,StringComparison.OrdinalIgnoreCase)==0)
//                 throw new Exception("Cannot follow yourself");
   
//             _following.Add(username); 
                       
            
//         }

//         public bool IsFollowing(string username) => _following.Contains(username.ToLower());
        
//         public void AddPost(string? content)
//         {
//             if(string.IsNullOrWhiteSpace(content))
//                 throw new ArgumentException("Post content cannot be empty");
            
//             if(content.Length>280)
//                 throw new Exception("Post too long (max 280 characters)");

            
//             Post post = new Post(this,content.Trim());
//             // Console.WriteLine("Post is created successfully.");
//             _posts.Add(post);
//             // Console.WriteLine("Post is added to the user’s post list.");

//             OnNewPost?.Invoke(post);
//             // Console.WriteLine("Notification event is triggered.");

//         }

//         public IReadOnlyList<Post> GetPosts()
//         {
//             return _posts;
//         }

//         public int CompareTo(User? other)
//         {
//             if (other == null)
//             {
//                 return 1;
//             }
//             return string.Compare(this.Username,other.Username,StringComparison.OrdinalIgnoreCase);
//         }

//         public override string ToString()
//         {
//             return $"@{Username}";
//         }


        
//     }

//     partial class User
//     {
            
//         public string GetDisplayName()
//         {
//             StringBuilder sb = new StringBuilder();
//             sb.AppendLine($"User: {Username} <{Email}>");

//             return sb.ToString();
//         }
            
//     }    

//     class Repository<T> where T :class
//     {
//         private List<T> _items =new List<T>();

//         public void Add(T item) => _items.Add(item) ;

//         public IReadOnlyList<T> GetAll() => _items;

//         public T? Find(Predicate<T> match) => _items.Find(match);       
        

//     }
    
//     public static class SocialUtils
//     {
//         public static string FormatTimeAgo(this DateTime pastTime){
//             DateTime utcTime = DateTime.UtcNow;
//             TimeSpan diff = utcTime - pastTime;

//             string res ="";

//             if (diff < TimeSpan.FromSeconds(60))
//             {
//                 res="Just now";
//             }
//             else if (diff < TimeSpan.FromMinutes(60))
//             {
//                 res=$"{diff:mm} min ago";
//             }
//             else if (diff< TimeSpan.FromHours(24))
//             {
//                 res=$"{diff:HH} h ago";
//             }
//             else if(diff> TimeSpan.FromHours(24))
//             {
//                 res=$"{diff:MMM dd}";            
//             }
            
//             return res;

//         }
//     }


    

    

    
}