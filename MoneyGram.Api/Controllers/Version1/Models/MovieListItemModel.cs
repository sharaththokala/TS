using System.Collections.Generic;

namespace MovieGram.Api.Controllers.Version1.Models
{
    public class MovieListItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ThumbnailUrl { get; set; }
        public ICollection<ShowTimeModel> ShowTimes { get; set; }
    }
}
