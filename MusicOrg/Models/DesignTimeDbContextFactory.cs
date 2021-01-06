using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
// we need this code so that our application can properly find our database context

namespace MusicOrg.Models
{
    public class MusicOrgContextFactory : IDesignTimeDbContextFactory<MusicOrgContext>
    {
        MusicOrgContext IDesignTimeDbContextFactory<MusicOrgContext>.CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<MusicOrgContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseMySql(connectionString);

            return new MusicOrgContext(builder.Options);
        }
    }
}