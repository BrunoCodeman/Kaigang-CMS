using Microsoft.EntityFrameworkCore;

namespace kaigang.Models.Entities
{
    public class KaigangContext : DbContext 
    {
        public DbSet<Post> Posts;
        public DbSet<User> Users;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("");
        }
          protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().ToTable("Posts");
            modelBuilder.Entity<User>().ToTable("Users");
        }
    }
}