using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace kaigang.Identity
{
    public class ApplicationContext : IdentityDbContext
    
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=<ip>;database=kaigang;uid=<user>;pwd=<password>;");
        }
          protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}