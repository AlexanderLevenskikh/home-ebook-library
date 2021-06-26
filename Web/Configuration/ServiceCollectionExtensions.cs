using Application.Content;
using Application.Envelopes.Base;
using Core.Entities;
using Core.Repositories;
using Infrastructure.Constants;
using Infrastructure.Data;
using Infrastructure.Extensions;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Infrastructure.Services.Ebook;
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
            services.ConfigureDatabase(configuration)
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
                .AddSingleton<IEBookParser, EbookParser>()
                .AddScoped<IBookRepository, BookRepository>()
                .AddScoped<IChapterRepository, ChapterRepository>()
                .AddScoped<IUploadRepository, UploadRepository>()
                .AddScoped<IAuthorRepository, AuthorRepository>();
        }

        private static IServiceCollection ConfigureDatabase(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            return services.AddDbContext<EbookLibraryContext>(
                builder => builder.SetFactoringDbContextParameters(configuration)
            );
        }
    }
}
