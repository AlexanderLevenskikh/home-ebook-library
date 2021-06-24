using Application.Envelopes.Base;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Web.ContainerConfig
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.ConfigureDatabase();
            
            services.AddMediatR(typeof(ListEnvelope).Assembly);
            
            services.AddAutoMapper(services.GetType().Assembly);
            
            services.AddControllersWithViews();
            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/build"; });

            return services;
        }

        private static IServiceCollection ConfigureDatabase(this IServiceCollection services)
        {
            services.AddDbContext<EbookLibraryContext>(c =>
                c.UseInMemoryDatabase("EbookLibraryConnection"));

            return services;
        }
    }
}