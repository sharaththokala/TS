using Microsoft.AspNetCore.Mvc;
using MovieGram.Api.Controllers.Version1.Models;
using MovieGram.Api.Controllers.Version1.Services;
using System.Collections.Generic;

namespace MovieGram.Api.Controllers.Version1
{
    [Route("api/v1/movies")]
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            this._movieService = movieService;
        }

        /// <summary>
        /// Searches movie by movie name.
        /// </summary>
        /// <param name="movieName">Movie name to search</param>
        /// <returns>List of matched movies</returns>
        /// <response code="200">Movie list successfully resturned</response>
        /// <response code="400">Invalid request</response>
        /// <response code="404">No movies found</response>
        /// <response code="500">Internal server error</response>
        /// 
        [HttpGet]
        [Route("{movieName}/search")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<MovieListItemModel>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult SearchMovie(string movieName)
        {
            try
            {
                if (string.IsNullOrEmpty(movieName))
                    return BadRequest("Search criteria cannot be empty");

                var serviceResult = this._movieService.SearchMovie(movieName);
                if (serviceResult == null)
                    return NotFound();

                return Ok(serviceResult);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// get movie detail by movie id
        /// </summary>
        /// <param name="id">Movie Id</param>
        /// <returns>Returns movie details</returns>
        /// <response code="200">Movie details successfully resturned</response>
        /// <response code="400">Invalid request</response>
        /// <response code="404">Movie not found</response>
        /// <response code="500">Internal server error</response>
        /// 
        [HttpGet("{id:int}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(MovieDetailModel), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Get(int id)
        {
            try
            {
                var serviceResult = this._movieService.GetMovieDetails(id);
                if (serviceResult == null)
                    return NotFound();

                return Ok(serviceResult);
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
