using Core.Entities;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class UploadConfiguration : IEntityTypeConfiguration<Upload>
    {
        public void Configure(EntityTypeBuilder<Upload> builder)
        {
            builder.Property(t => t.Name)
                .HasMaxLength(500)
                .TrimmingConversion()
                .IsRequired();
            builder.Property(t => t.ContentType)
                .HasMaxLength(255)
                .TrimmingConversion()
                .IsRequired();
        }
    }
}