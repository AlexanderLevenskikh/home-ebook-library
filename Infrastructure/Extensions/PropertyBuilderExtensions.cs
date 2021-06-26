using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Extensions
{
    public static class PropertyBuilderExtensions
    {
        public static PropertyBuilder<TProperty> TrimmingConversion<TProperty>(
            this PropertyBuilder<TProperty> builder
        )
        {
            return builder.HasConversion(
                new ValueConverter<string, string>(v => v.TrimEnd(), v => v.TrimEnd())
            );
        }
    }
}
