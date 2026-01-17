using System.Collections.Generic;

namespace MiniSocialMedia
{
    public interface IPostable
    {
        public void AddPost(string content);
        public IReadOnlyList<Post> GetPosts();
    }
}