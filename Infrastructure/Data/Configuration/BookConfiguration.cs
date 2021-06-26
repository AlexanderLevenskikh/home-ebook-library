using Core.Entities;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(t => t.Title)
                .HasMaxLength(500)
                .TrimmingConversion()
                .IsRequired();
            
            builder.HasKey(t => t.Id);
            builder.HasOne(t => t.Content)
                .WithMany()
                .HasForeignKey(t => t.ContentId)
                .IsRequired();
            builder.HasOne(t => t.Image)
                .WithMany()
                .HasForeignKey(t => t.ImageId)
                .IsRequired();
        }
    }
}