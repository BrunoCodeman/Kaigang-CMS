using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace kaigang.Models.Entities
{
    public class KaigangContext : DbContext 
    {
        public DbSet<Post> Posts;
        public DbSet<User> Users;
        public DbSet<Page> Pages;
        public DbSet<Poll> Polls;
        public DbSet<Comment> Comments;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=<ip>;database=kaigang;uid=<user>;pwd=<password>;");
        }
          protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Page>().ToTable("Pages");
            modelBuilder.Entity<User>().ToTable("Users").HasAlternateKey(u => u.Email);
            modelBuilder.Entity<Poll>().ToTable("Polls");
            modelBuilder.Entity<Post>().ToTable("Posts");
            modelBuilder.Entity<Comment>().ToTable("Comments");
            
        }
    }
}