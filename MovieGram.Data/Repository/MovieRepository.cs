using Microsoft.EntityFrameworkCore;
using MovieGram.Core.Filters;
using System.Collections.Generic;
using System.Linq;

namespace MovieGram.Data.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly IDatabase _database;

        public MovieRepository(IDatabase database)
        {
            this._database = database;
        }

        public IEnumerable<Movie> GetFilteredMovies(MovieFilter filter)
        {
            var query = this._database.Movies.AsQueryable();

            query = ApplyFilter(query, filter);

            return query.Include(p => p.ShowTimes).ThenInclude(p => p.Cinema).ToList();
        }

        public Movie GetMovieById(int id)
        {
            return this._database.Movies.Include(p => p.ShowTimes).ThenInclude(p => p.Cinema).FirstOrDefault(x => x.Id == id);
        }

        private static IQueryable<Movie> ApplyFilter(IQueryable<Movie> query, MovieFilter filter)
        {
            if (!string.IsNullOrWhiteSpace(filter.MovieName))
            {
                query = query.Where(x => x.Name.Contains(filter.MovieName));
            }
            return query;
        }
    }
}
