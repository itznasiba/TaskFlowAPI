using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using youtubeAPI.Core.Entities;

namespace YoutubeAPI.Core.Product
{
    public class ProductSaveDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? Deadline { get; set; }
    }
}
