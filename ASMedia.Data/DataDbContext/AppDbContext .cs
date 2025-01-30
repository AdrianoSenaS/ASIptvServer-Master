using ASMedia.Shared.Model.Movies;
using ASMedia.Shared.Model.Series;
using ASMedia.Shared.Model.Tv;
using ASMedia.Shared.Model.Users;
using Microsoft.EntityFrameworkCore;

namespace ASMedia.Data.DataDbContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<UserCreate> Users { get; set; }
        public DbSet<MoviesResponse> Movies { get; set; }
        public DbSet<SeriesResponse> Series { get; set; }
        public DbSet<TvResponse> Tv { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserCreate>()
                .HasMany(user => user.Permissions)
                .WithOne()
                .HasForeignKey("Users");
            modelBuilder.Entity<MoviesResponse>()
                .HasMany(movies=> movies.Genres)
                .WithOne()
                .HasForeignKey("Movies");
            modelBuilder.Entity<SeriesResponse>()
                .HasMany(series=>series.Genres)
                .WithOne()
                .HasForeignKey("Series");
            modelBuilder.Entity<TvResponse>()
                .ToTable("Tv");
        }
    }
}
