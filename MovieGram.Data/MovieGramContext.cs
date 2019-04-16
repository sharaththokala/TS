using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace MovieGram.Data
{
    public class MovieGramContext : DbContext, IDatabase
    {
        public MovieGramContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<ShowTime> ShowTimes { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cinemas = new List<Cinema> {
                new Cinema { Id = 1, Name = "Cinema1" },
                new Cinema { Id = 2, Name = "Cinema2" },
                new Cinema { Id = 3, Name = "Cinema3" },
                new Cinema { Id = 4, Name = "Cinema4" },
                new Cinema { Id = 5, Name = "Cinema5" }
            };

            var movies = new List<Movie> {
                new Movie { Id = 1, Name = "Movie1", Plot = "Plot1", Rating = 4, FullImageUrl = "http://test.com/content/images/Movie1.png", ThumbnailUrl = "http://test.com/content/thumbs/Movie1.png" },
                new Movie { Id = 2, Name = "Movie2", Plot = "Plot2", Rating = 3, FullImageUrl = "http://test.com/content/images/Movie2.png", ThumbnailUrl = "http://test.com/content/thumbs/Movie2.png" },
                new Movie { Id = 3, Name = "Movie3", Plot = "Plot3", Rating = 2, FullImageUrl = "http://test.com/content/images/Movie3.png", ThumbnailUrl = "http://test.com/content/thumbs/Movie3.png" },
                new Movie { Id = 4, Name = "Movie4", Plot = "Plot4", Rating = 1, FullImageUrl = "http://test.com/content/images/Movie4.png", ThumbnailUrl = "http://test.com/content/thumbs/Movie4.png" },
                new Movie { Id = 5, Name = "Movie5", Plot = "Plot5", Rating = 5, FullImageUrl = "http://test.com/content/images/Movie5.png", ThumbnailUrl = "http://test.com/content/thumbs/Movie5.png" }
            };

            modelBuilder.Entity<Movie>().HasData(movies);
            modelBuilder.Entity<Cinema>().HasData(cinemas);

            modelBuilder.Entity<Movie>().OwnsMany(m => m.ShowTimes).HasData(
                new ShowTime { Id = 1, MovieId = 1, CinemaId = 1, Time = new DateTime(2019, 5, 1, 14, 0, 0, 0) },
                new ShowTime { Id = 2, MovieId = 1, CinemaId = 1, Time = new DateTime(2019, 6, 1, 14, 0, 0, 0) },
                new ShowTime { Id = 3, MovieId = 1, CinemaId = 1, Time = new DateTime(2019, 7, 1, 14, 0, 0, 0) },
                new ShowTime { Id = 4, MovieId = 2, CinemaId = 5, Time = new DateTime(2019, 5, 1, 14, 0, 0, 0) },
                new ShowTime { Id = 5, MovieId = 3, CinemaId = 4, Time = new DateTime(2019, 5, 1, 14, 0, 0, 0) },
                new ShowTime { Id = 6, MovieId = 3, CinemaId = 3, Time = new DateTime(2019, 5, 1, 14, 0, 0, 0) },
                new ShowTime { Id = 7, MovieId = 4, CinemaId = 4, Time = new DateTime(2019, 5, 1, 14, 0, 0, 0) },
                new ShowTime { Id = 8, MovieId = 4, CinemaId = 3, Time = new DateTime(2019, 6, 1, 14, 0, 0, 0) },
                new ShowTime { Id = 9, MovieId = 4, CinemaId = 2, Time = new DateTime(2019, 6, 1, 14, 0, 0, 0) },
                new ShowTime { Id = 10, MovieId = 5, CinemaId = 2, Time = new DateTime(2019, 6, 1, 14, 0, 0, 0) }
                );
        }
    }
}
