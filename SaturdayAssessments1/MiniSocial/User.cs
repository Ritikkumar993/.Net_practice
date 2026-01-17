using System.Text.RegularExpressions;

namespace MiniSocialMedia
{
    public partial class User : IPostable, IComparable<User>
    {
        public string Username { get; init; }
        public string Email { get; init; }
        private List<Post> _posts = new();
        private readonly HashSet<string>? _following = new(StringComparer.OrdinalIgnoreCase);
        public event Action<Post>? OnNewPost;

        public User(string username, string email)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentNullException("Invalid Username: " + username);
            }
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            if (!Regex.IsMatch(email, pattern))
            {
                throw new SocialException("Invalid Email Format");
            }
            Username = username.Trim().ToLower();
            Email = email.Trim().ToLower();
            Console.WriteLine("User is created successfully.");

        }

        public void Follow(string username)
        {
            if (string.Equals(username, Username, StringComparison.OrdinalIgnoreCase))
            {
                throw new SocialException("Cannot Follow Yourself!");
            }

            _following.Add(username.ToLower());

        }

        public bool IsFollowing(string username) => _following.Contains(username.ToLower());

        public void AddPost(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                throw new ArgumentNullException("Post content cannot be empty");
            }
            if (content.Length > 280)
            {
                throw new SocialException("Post too long (max 280 characters)");
            }

            var post = new Post(this, content.Trim());
            _posts.Add(post);

            OnNewPost?.Invoke(post);

        }

        public IReadOnlyList<Post> GetPosts()
        {
            return _posts.AsReadOnly();
        }

        public int CompareTo(User? other)
        {
            if (other == null)
            {
                return 1;
            }

            return string.Compare(Username, other.Username, StringComparison.OrdinalIgnoreCase);

        }

        public override string ToString()
        {
            return "@" + Username;
        }

    }

    public partial class User
    {
        public string GetDisplayName()
        {
            return $"User: {Username} <{Email}>";
        }
    }
}