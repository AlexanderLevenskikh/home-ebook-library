using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Entities;
using Core.Filters;
using Core.Repositories;
using Infrastructure.Data;
using Infrastructure.Extensions.Data;
using Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private readonly EbookLibraryContext _context;
        public BookRepository(EbookLibraryContext context) : base(context)
        {
            _context = context;
        }
        
        public async Task<long> CountByFilterAsync(BooksFilter filter, CancellationToken cancellationToken = default)
        {
            return await _context.Books.FilterBy(filter)
                .CountAsync(cancellationToken: cancellationToken);
        }

        public async Task<List<Book>> FindByFilterAsync(
            BooksFilter filter,
            CancellationToken cancellationToken = default
        )
        {
            return await _context.Books.FilterBy(filter)
                .ToListAsync(cancellationToken: cancellationToken);
        }

        public async Task<Book> FindFirstOrDefaultByFilterAsync(
            BooksFilter filter,
            CancellationToken cancellationToken = default
        )
        {
            return await _context.Books.FilterBy(filter)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }
    }
}
