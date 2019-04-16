using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieGram.Data
{
    [Table("ShowTime")]
    public class ShowTime
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Movie")]
        public int MovieId { get; set; }

        [ForeignKey("Cinema")]
        public int CinemaId { get; set; }
        public DateTime Time { get; set; }
        public Movie Movie { get; set; }
        public Cinema Cinema { get; set; }
    }
}
