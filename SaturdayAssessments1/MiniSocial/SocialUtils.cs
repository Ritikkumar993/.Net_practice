namespace MiniSocialMedia
{
    static class SocialUtils
    {
        public static string FormatTimeAgo(this DateTime pastTime)
        {
            var diff = DateTime.UtcNow - pastTime;

            if (diff.TotalSeconds < 60)
            {
                return "Just now";
            }
            if (diff.TotalMinutes < 60)
            {
                return $"{(int)diff.TotalMinutes} min ago";
            }
            if (diff.TotalHours < 24)
            {
                return $"{(int)diff.TotalHours} h ago";
            }

            return pastTime.ToString("MMM dd");
        }
    }
}