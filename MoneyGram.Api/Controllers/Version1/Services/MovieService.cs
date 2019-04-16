using MovieGram.Api.Controllers.Version1.Models;
using MovieGram.Core.Filters;
using MovieGram.Data.Repository;
using System.Collections.Generic;
using System.Linq;

namespace MovieGram.Api.Controllers.Version1.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            this._movieRepository = movieRepository;
        }
        public List<MovieListItemModel> SearchMovie(string movieName)
        {
            var filter = new MovieFilter { MovieName = movieName };

            var result = this._movieRepository.GetFilteredMovies(filter);

            if (result != null)
            {
                return result.Select(x => new MovieListItemModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ThumbnailUrl= x.ThumbnailUrl,
                    ShowTimes = x.ShowTimes?.Select(t => new ShowTimeModel
                    {
                        CinemaName = t.Cinema?.Name,
                        Time = t.Time
                    })
                    .ToList()
                }).ToList();
            }

            return null;
        }

        public MovieDetailModel GetMovieDetails(int movieId)
        {
            var result = this._movieRepository.GetMovieById(movieId);
            if (result != null)
            {
                return new MovieDetailModel
                {
                    Id = result.Id,
                    Name = result.Name,
                    FullImageUrl = result.FullImageUrl,
                    Plot = result.Plot,
                    Rating = result.Rating,
                    ShowTimes = result.ShowTimes?.Select(t => new ShowTimeModel
                    {
                        CinemaName = t.Cinema?.Name,
                        Time = t.Time
                    })
                    .ToList()
                };
            }

            return null;
        }
    }
}
