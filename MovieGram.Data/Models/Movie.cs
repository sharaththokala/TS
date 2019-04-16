using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieGram.Data
{
    [Table("Movie")]
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ThumbnailUrl { get; set; }
        public string FullImageUrl { get; set; }
        public string Plot { get; set; }
        [Range(1, 5)]
        public int Rating { get; set; }
        public ICollection<ShowTime> ShowTimes { get; set; }
    }
}
