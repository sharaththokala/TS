using Microsoft.AspNetCore.Mvc;
using MovieGram.Api.Controllers.Version1.Services;

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
        [HttpGet]
        [Route("{movieName}/search")]
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

        [HttpGet("{id}")]
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
