using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class ChapterConfiguration : IEntityTypeConfiguration<Chapter>
    {

        public void Configure(EntityTypeBuilder<Chapter> builder)
        {
            builder.Property(t => t.Description)
                .HasMaxLength(2000);
            
            builder.HasOne(t => t.Book)
                .WithMany()
                .HasForeignKey(t => t.BookId)
                .IsRequired();
        }
    }
}