using Core.Entities;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(t => t.Title)
                .HasMaxLength(500)
                .TrimmingConversion()
                .IsRequired();

            builder.HasMany(t => t.Books)
                .WithMany(t => t.Authors)
                .UsingEntity(t => t.ToTable("AuthorsWithBooks"));
        }
    }
}
