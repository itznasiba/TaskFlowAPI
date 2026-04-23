using YoutubeAPI.Core.User;

namespace YoutubeAPI.Core.Product
{
    public class Product
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public DateTime? Deadline { get; set; }
        public bool IsTaken { get; set; } = false;
        public int? AppUserId { get; set; }
        public UserDto? AppUser { get; set; }
        // documented url, created at, userid, etc. can be added later

    }
}
