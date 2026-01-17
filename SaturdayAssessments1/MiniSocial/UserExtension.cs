using System.Reflection;

namespace MiniSocialMedia
{
    public static class UserExtensions
    {
        public static IEnumerable<string> GetFollowingNames(this User user)
        {
            Type userType = typeof(User);

            FieldInfo field = userType.GetField("_following", BindingFlags.NonPublic | BindingFlags.Instance);

            var following = field?.GetValue(user) as HashSet<string>;

            return following ?? Enumerable.Empty<string>();

        }
    }
}