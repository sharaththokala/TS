using MovieGram.Core.Filters;
using System.Collections.Generic;

namespace MovieGram.Data.Repository
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetFilteredMovies(MovieFilter filter);

        Movie GetMovieById(int id);
    }
}