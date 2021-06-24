using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class EbookLibraryContext : DbContext
    {
        public EbookLibraryContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; } = default!;

        public DbSet<Chapter> Chapters { get; set; } = default!;

        public DbSet<Upload> Uploads { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(
                b =>
                {
                    b.HasKey(t => t.Id);
                    b.HasOne(t => t.Upload).WithMany().HasForeignKey(t => t.UploadId);
                    b.HasMany(t => t.Chapters).WithOne(t => t.Book).HasForeignKey(t => t.BookId);
                }
            );
        }
    }
}
