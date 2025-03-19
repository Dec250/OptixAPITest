using Microsoft.EntityFrameworkCore;
using Optix_Technical_Test.Domain.Entites;
using Optix_Technical_Test.Application.Interfaces;

namespace Optix_Technical_Test.Infastruture.Repositories
{
    public class MovieRepository : IMovieRepository
    {

        private readonly ILogger<MovieRepository> _logger;
        private readonly MoviesDbContext _dbContext;


        /// <summary>
        /// Basic constructor for MovieRepository
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="databaseConnection"></param>
        public MovieRepository(ILogger<MovieRepository> logger, MoviesDbContext dbContext)
        {

            _logger = logger;
            _dbContext = dbContext;
        }

        /// <summary>
        /// Returns movies from database, applies that have been provided and returns list of movies.
        /// </summary>
        /// <returns></returns>
        public IQueryable<Movie>? GetMovies(string? title = null, string? genre = null, DateTime? releaseDate = null)
        {
            try
            {

                var movies = _dbContext.mymoviedb.AsQueryable() //Get data from Movies database as an IQueryable for dynamic queries
                         ?? throw new ArgumentException(); //If null throw argument exception

                //Filter for title
                if (!string.IsNullOrEmpty(title))
                    movies = movies.Where(m => m.Title.Contains(title));

                //Filter for genre
                if (!string.IsNullOrEmpty(genre))
                    movies = movies.Where(m => m.Genre.Contains(genre));

                //Filtre for release date 
                if (releaseDate.HasValue)
                    movies = movies.Where(m => m.Release_Date == releaseDate);

                //The breif states that you'd like one for actors but the dataset that was provided does not have actors.
                //If i was to add a filter for actors, I'd add another parameter above and add this filter
                // if (!string.IsNullOrEmpty(actor))
                //   movies = movies.Where(m => m.actor == actor);

                return movies;

            }
            catch (ArgumentException ex)
            {
                //Log as warning as not always an error, could just be there is nothing in the database.
                _logger.LogWarning($"GetMoviesAsync has returned null, {ex.Message + ex.StackTrace}");
                return default;
            }
            catch (Exception ex)
            {
                //Log as any other errors; 
                _logger.LogError(ex.Message + ex.StackTrace);
                return default;
            }
        }
    }
}
