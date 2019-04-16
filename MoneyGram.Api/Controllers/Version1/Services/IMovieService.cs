using MovieGram.Api.Controllers.Version1.Models;
using System.Collections.Generic;

namespace MovieGram.Api.Controllers.Version1.Services
{
    public interface IMovieService
    {
        List<MovieListItemModel> SearchMovie(string movieName);

        MovieDetailModel GetMovieDetails(int movieId);
    }
}