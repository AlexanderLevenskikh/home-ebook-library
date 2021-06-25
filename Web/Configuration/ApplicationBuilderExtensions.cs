using Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Web.Configuration
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseEbookContext(this IApplicationBuilder builder)
        {
            var db = builder.ApplicationServices.GetRequiredService<EbookLibraryContext>();
            db.Database.MigrateAsync()
                .GetAwaiter()
                .GetResult();

            return builder;
        }
    }
}
