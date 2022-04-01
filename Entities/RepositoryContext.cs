using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<UserLocation> UserLocation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=.;Database=GoogleMapLocation;Trusted_Connection=True;Integrated Security=True;",
                b => b.MigrationsAssembly("GoogleMapLocation"));
        }        
    }
}
