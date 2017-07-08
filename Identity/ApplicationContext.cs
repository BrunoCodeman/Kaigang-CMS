using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace kaigang.Identity
{
    public class ApplicationContext : IdentityDbContext
    
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=172.17.0.2;database=kaigang;uid=root;pwd=root;");
        }
          protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}