using Optix_Technical_Test.Domain.Entites;

namespace Optix_Technical_Test.Application.Interfaces
{
    public interface IMovieRepository
    {
        IQueryable<Movie>? GetMovies(string? title = null, string? genre = null, DateTime? releaseDate = null);
    }
}
