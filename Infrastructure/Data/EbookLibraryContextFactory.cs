using System.IO;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Data
{
    public class EbookLibraryContextFactory: IDesignTimeDbContextFactory<EbookLibraryContext>
    {
        public EbookLibraryContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EbookLibraryContext>();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.GetFullPath(@"..\Web"))
                .AddJsonFile("appsettings.json")
                .Build();
            
            optionsBuilder.SetFactoringDbContextParameters(configuration);
            
            return new EbookLibraryContext(optionsBuilder.Options);
        }
    }
}
