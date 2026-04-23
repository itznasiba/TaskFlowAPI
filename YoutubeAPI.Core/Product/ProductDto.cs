using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeAPI.Core.User;

namespace YoutubeAPI.Core.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public DateTime? Deadline { get; set; }
        public bool IsTaken { get; set; } = false;
        public int? AppUserId { get; set; }
        public UserDto? AppUser { get; set; }
    }
}
