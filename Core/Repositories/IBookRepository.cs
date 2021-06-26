using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Entities;
using Core.Filters;
using Core.Repositories.Base;

namespace Core.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        public Task<long> CountByFilterAsync(
            BooksFilter filter,
            CancellationToken cancellationToken = default
        );

        public Task<List<Book>> FindByFilterAsync(
            BooksFilter filter,
            CancellationToken cancellationToken = default
        );

        public Task<Book> FindFirstOrDefaultByFilterAsync(
            BooksFilter filter,
            CancellationToken cancellationToken = default
        );
    }
}
