using System.Text;
using System.Text.RegularExpressions;
namespace MiniSocialMedia
{
    public class Post
    {
        public readonly User Author;
        public readonly string Content;
        public DateTime CreatedAt;

        public Post(User author, string content)
        {
            if (author == null)
            {
                throw new ArgumentNullException(nameof(author));
            }
            Author = author;
            Content = content;
            CreatedAt = DateTime.UtcNow;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Author} • {CreatedAt:MMM dd HH:mm}");
            sb.AppendLine(Content);

            var matches = Regex.Matches(Content, @"#[A-Za-z]+");
            if (matches.Count > 0)
            {
                sb.Append("Tags: ");
                sb.AppendJoin(", ", matches.Cast<Match>().Select(m => m.Value));
            }

            return sb.ToString().TrimEnd();
        }

    }
}