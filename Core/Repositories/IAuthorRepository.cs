using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Entities;
using Core.Filters;
using Core.Repositories.Base;

namespace Core.Repositories
{
    public interface IAuthorRepository : IRepository<Author>
    {
        public Task<long> CountByFilterAsync(AuthorsFilter filter, CancellationToken cancellationToken = default);
        public Task<List<Author>> FindByFilterAsync(AuthorsFilter filter, CancellationToken cancellationToken = default);
        public Task<Author> FindFirstOrDefaultByFilterAsync(AuthorsFilter filter, CancellationToken cancellationToken = default);
    }
}
