using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Web.ContainerConfig
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            return services.ConfigureDatabase();
        }

        private static IServiceCollection ConfigureDatabase(this IServiceCollection services)
        {
            services.AddDbContext<EbookLibraryContext>(c =>
                c.UseInMemoryDatabase("EbookLibraryConnection"));

            return services;
        }
    }
}