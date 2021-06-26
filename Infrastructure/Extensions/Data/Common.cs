using System.Linq;

namespace Infrastructure.Extensions.Data
{
    public static partial class DbContextExtensions
    {
        public static IQueryable<T> Take<T>(
            this IQueryable<T> query,
            int? take,
            int? maxTake)
        {
            if (take.HasValue)
            {
                if (maxTake.HasValue && take.Value > maxTake.Value)
                {
                    take = maxTake.Value;
                }
            }
            else
            {
                take = maxTake;
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query;
        }
    }
}
