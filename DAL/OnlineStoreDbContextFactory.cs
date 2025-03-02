using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DAL
{
    public class OnlineStoreDbContextFactory : IDesignTimeDbContextFactory<OnlineStoreDbContext>
    {
        public OnlineStoreDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<OnlineStoreDbContext>();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("Default"));

            return new OnlineStoreDbContext(optionsBuilder.Options);
        }
    }
}