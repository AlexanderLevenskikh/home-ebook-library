using Application.Content;
using Application.Envelopes.Base;
using Core.Entities;
using Core.Repositories;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Web.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureServices(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services
                .ConfigureDatabase()
                .AddMediatR(typeof(ListEnvelope).Assembly)
                .AddAutoMapper(
                    services.GetType()
                        .Assembly
                )
                .AddServices();

            services.AddControllersWithViews();
            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(c => { c.RootPath = "ClientApp/build"; });

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services.AddSingleton<IContentService, ContentService>()
                .AddSingleton<IContentPathProvider, ContentPathProvider>()
                .AddScoped<IBookRepository, BookRepository>()
                .AddScoped<IChapterRepository, ChapterRepository>()
                .AddScoped<IUploadRepository, UploadRepository>();
        }

        private static IServiceCollection ConfigureDatabase(this IServiceCollection services)
        {
            services.AddDbContext<EbookLibraryContext>(c => c.UseInMemoryDatabase("EbookLibraryConnection"));

            return services;
        }
    }
}
