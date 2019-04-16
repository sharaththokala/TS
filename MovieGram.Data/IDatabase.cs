using Microsoft.EntityFrameworkCore;

namespace MovieGram.Data
{
    public interface IDatabase
    {
        DbSet<Movie> Movies { get; set; }
        DbSet<ShowTime> ShowTimes { get; set; }
        DbSet<Cinema> Cinemas { get; set; }
    }
}