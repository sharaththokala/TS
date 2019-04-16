using FluentAssertions;
using Moq;
using MovieGram.Api.Controllers.Version1.Models;
using MovieGram.Api.Controllers.Version1.Services;
using MovieGram.Core.Filters;
using MovieGram.Data;
using MovieGram.Data.Repository;
using System;
using System.Collections.Generic;
using Xunit;

namespace MoneyGram.Tests.Api.Version1
{
    public class MoneyServiceTests
    {
        [Fact]
        public void SearchMovieMapsToModel()
        {
            //Arrange
            var movieList = new List<Movie> {
                new Movie { Id = 1, Name = "Movie1", Plot = "Plot1", Rating = 4, FullImageUrl = "http://test.com/content/images/Movie1.png", ThumbnailUrl = "http://test.com/content/thumbs/Movie1.png",
                    ShowTimes = new List<ShowTime> { new ShowTime { Id = 1, MovieId = 1, CinemaId = 1, Time = new DateTime(2019, 5, 1, 14, 0, 0, 0), Cinema = new Cinema { Id = 1, Name = "Cinema1" } },
                                                     new ShowTime { Id = 2, MovieId = 1, CinemaId = 2, Time = new DateTime(2019, 6, 2, 14, 0, 0, 0),Cinema = new Cinema { Id = 2, Name = "Cinema2" } } }
                }
            };

            var mockMovieRepository = new Mock<IMovieRepository>();
            mockMovieRepository.Setup(x => x.GetFilteredMovies(It.IsAny<MovieFilter>())).Returns(movieList);

            var movieService = new MovieService(mockMovieRepository.Object);

            //Act
            var result = movieService.SearchMovie("movie");

            //Assert
            result.Should().NotBeEmpty()
               .And.HaveCount(1)
               .And.ContainItemsAssignableTo<MovieListItemModel>()
               .And.Subject.Should().AllBeEquivalentTo(new MovieListItemModel
               {
                   Id = movieList[0].Id,
                   ThumbnailUrl = movieList[0].ThumbnailUrl,
                   Name = movieList[0].Name,
                   ShowTimes = new List<ShowTimeModel> { new ShowTimeModel { CinemaName = "Cinema1", Time = new DateTime(2019, 5, 1, 14, 0, 0, 0) }, new ShowTimeModel { CinemaName = "Cinema2", Time = new DateTime(2019, 6, 2, 14, 0, 0, 0) } }
               });
            mockMovieRepository.Verify(x => x.GetFilteredMovies(It.IsAny<MovieFilter>()), Times.Once);
        }

        [Fact]
        public void WhenNoMovieRecordsFoundSearchMovieShouldReturnNull()
        {
            //Arrange
            var mockMovieRepository = new Mock<IMovieRepository>();
            mockMovieRepository.Setup(x => x.GetFilteredMovies(It.IsAny<MovieFilter>())).Returns<List<Movie>>(null);

            var movieService = new MovieService(mockMovieRepository.Object);

            //Act
            var result = movieService.SearchMovie("movie");

            //Assert
            result.Should().BeNull();
            mockMovieRepository.Verify(x => x.GetFilteredMovies(It.IsAny<MovieFilter>()), Times.Once);
        }
    }
}
