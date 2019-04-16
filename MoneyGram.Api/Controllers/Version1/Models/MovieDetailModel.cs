using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieGram.Api.Controllers.Version1.Models
{
    public class MovieDetailModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FullImageUrl { get; set; }
        public string Plot { get; set; }
        public int Rating { get; set; }
        public ICollection<ShowTimeModel> ShowTimes { get; set; }
    }
}
