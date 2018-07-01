using Kaigang.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Kaigang.Models
{
    public class KaigangDbContext : DbContext 
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=172.17.0.2;database=kaigang;uid=root;pwd=root;");
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