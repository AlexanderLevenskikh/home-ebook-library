using System.Reflection;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class EbookLibraryContext : DbContext, IDbContextSet, IDbContextMigrate
    {
        public EbookLibraryContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books => Set<Book>();
        public DbSet<Chapter> Chapters => Set<Chapter>();
        public DbSet<Author> Authors => Set<Author>();
        public DbSet<Upload> Uploads => Set<Upload>();
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public async Task MigrateAsync()
        {
            await Database.MigrateAsync();
        }
    }
}