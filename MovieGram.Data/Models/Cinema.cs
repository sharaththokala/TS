using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieGram.Data
{
    [Table("Cinema")]
    public class Cinema
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
