using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Entities;
using Core.Filters;
using Core.Repositories.Base;

namespace Core.Repositories
{
    public interface IChapterRepository : IRepository<Chapter>
    {
        public Task<long> CountByFilterAsync(
            ChaptersFilter filter,
            CancellationToken cancellationToken = default
        );

        public Task<List<Chapter>> FindByFilterAsync(
            ChaptersFilter filter,
            CancellationToken cancellationToken = default
        );

        public Task<Chapter> FindFirstOrDefaultByFilterAsync(
            ChaptersFilter filter,
            CancellationToken cancellationToken = default
        );
    }
}
