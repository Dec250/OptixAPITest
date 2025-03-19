using Microsoft.AspNetCore.Mvc;
using Optix_Technical_Test.Application.Interfaces;
using Optix_Technical_Test.Domain.Entites;

namespace Optix_Technical_Test.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly ILogger<MovieController> _logger;
        private readonly IMovieService _movieService;

        public MovieController(ILogger<MovieController> logger, IMovieService movieService)
        {
            _logger = logger;
            _movieService = movieService;
        }

 
        /// <summary>
        /// Controller for movies
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="title"></param>
        /// <param name="genre"></param>
        /// <param name="releaseDate"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Exception"></exception>
        [HttpGet]
        [Route("getmovies")]
        public IActionResult Movies([FromQuery] int pageNum, [FromQuery] int pageSize, [FromQuery] string? title, [FromQuery] string? genre, [FromQuery] DateTime? releaseDate)
        {
            try
            {

                List<Movie>? movies = _movieService.GetMovies(pageNum, pageSize, title, genre, releaseDate)
                                        ?? throw new ArgumentException();

                return Ok(movies);

            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning($"Movies returned null{ex.Message + ex.StackTrace}");
                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + ex.StackTrace);
                return StatusCode(500, "An unexpected error has occured");
            }
        }
    }
}
