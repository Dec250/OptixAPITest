using Optix_Technical_Test.Domain.Entites;

namespace Optix_Technical_Test.Application.Interfaces
{
    public interface IMovieService
    {
        List<Movie>? GetMovies(int pageNum, int pageSize, string? title = null, string? genre = null, DateTime? releaseDate = null);

    }
}
