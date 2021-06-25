using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(t => t.Caption)
                .HasMaxLength(500)
                .IsRequired();
            builder.Property(t => t.Description)
                .HasMaxLength(2000);
            
            builder.HasKey(t => t.Id);
            builder.HasOne(t => t.Upload)
                .WithMany()
                .HasForeignKey(t => t.UploadId)
                .IsRequired();
        }
    }
}