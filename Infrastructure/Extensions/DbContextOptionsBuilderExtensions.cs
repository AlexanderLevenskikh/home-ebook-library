using Infrastructure.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Extensions
{
    public static class DbContextOptionsBuilderExtensions
    {
        public static void SetFactoringDbContextParameters(
            this DbContextOptionsBuilder builder,
            IConfiguration configuration
        )
        {
            if (configuration.GetSection(ConfigurationConstants.IsInMemoryDatabase)
                .Value.ToLowerInvariant() == "true")
            {
                builder.UseInMemoryDatabase("EbookLibraryConnection");
                return;
            }
            
            builder.UseNpgsql(
                configuration.GetSection(ConfigurationConstants.DatabaseConnectionString)
                    .Value,
                b => { b.MigrationsAssembly("Infrastructure"); }
            );

            builder.EnableSensitiveDataLogging();
        }
    }
}
