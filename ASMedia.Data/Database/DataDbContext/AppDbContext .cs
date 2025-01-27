using ASMedia.Data.Model.Users;
using Microsoft.EntityFrameworkCore;

namespace ASMedia.Data.Database.DataDbContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<UsersModel> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<UsersModel>().ToTable("Users");
        }
    }
}
