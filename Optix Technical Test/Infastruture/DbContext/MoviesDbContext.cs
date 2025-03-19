using Microsoft.EntityFrameworkCore;
using Optix_Technical_Test.Domain.Entites;

namespace Optix_Technical_Test.Infastruture
{
    public partial class MoviesDbContext : DbContext
    {

        public MoviesDbContext(DbContextOptions<MoviesDbContext> options)
          : base(options)
        {
        }


        public virtual DbSet<Movie> mymoviedb { get; set; }


        /// <summary>
        /// Sets all the primary key values for entities.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>().HasKey(m => m.MovieId);

        }
    }
}
