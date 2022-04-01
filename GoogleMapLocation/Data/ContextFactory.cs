using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GoogleMapLocation.Data
{
    public class ContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

            var builder = new DbContextOptionsBuilder<RepositoryContext>();
            var connectionString = configuration.GetConnectionString("GoogleMapLocationCS");

            builder.UseSqlServer(
                connectionString,
                x => x.MigrationsAssembly("GoogleMapLocation"));
            //builder.UseNpgsql(connectionString);

            return new RepositoryContext(builder.Options);
        }
    }
}
