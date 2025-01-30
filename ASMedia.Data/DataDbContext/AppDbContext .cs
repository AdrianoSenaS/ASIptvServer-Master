﻿using ASMedia.Shared.Model;
using ASMedia.Shared.Model.Movies;
using ASMedia.Shared.Model.Series;
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserCreate>()
                .ToTable("Users");
            modelBuilder.Entity<MoviesResponse>()
                .HasMany(movies=> movies.Genres)
                .WithOne()
                .HasForeignKey("Movies");
            modelBuilder.Entity<SeriesResponse>()
                .HasMany(series=>series.Genres)
                .WithOne()
                .HasForeignKey("Series");
        }
    }
}
