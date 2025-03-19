using Optix_Technical_Test.Application.Interfaces;
using Optix_Technical_Test.Domain.Entites;

namespace Optix_Technical_Test.Application.Services
{
    public class MoviesService : IMovieService
    {

        private readonly ILogger<MoviesService> _logger;
        private readonly IMovieRepository _movieRepository;

        public MoviesService(ILogger<MoviesService> logger, IMovieRepository movieRepository)
        {
            _logger = logger;
            _movieRepository = movieRepository;
        }

        /// <summary>
        /// Returns either an entire list of movies or filtered if parameters passed.
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="title"></param>
        /// <param name="genre"></param>
        /// <param name="releaseDate"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="NotImplementedException"></exception>
        public List<Movie>? GetMovies(int pageNum, int pageSize, string? title = null, string? genre = null, DateTime? releaseDate = null)
        {

            try
            {
                List<Movie>? movies;

                //Get entire movie list or movie list which is filtered.
                var movieList = _movieRepository.GetMovies(title, genre, releaseDate) //Get data or filtered data.
                                 ?? throw new ArgumentException(); //throw error if null

                //Apply pagination to movies and return as list.
                movies = movieList.Skip((pageNum - 1) * pageSize) //Gets next page for movies
                                .Take(pageSize)
                                .ToList(); //Limit returned results to users selected page size;;

                //return the movies
                return movies;

            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning($"GetMovies has returned null, {ex.Message + ex.StackTrace}");
                return default;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + ex.StackTrace);
                return default;
            }

        }
    }
}
