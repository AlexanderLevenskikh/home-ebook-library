using System.Collections.Generic;
using System.Linq;
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
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        private readonly EbookLibraryContext _context;

        public AuthorRepository(EbookLibraryContext context) : base(context)
        {
            _context = context;
        }

        public async Task<long> CountByFilterAsync(AuthorsFilter filter, CancellationToken cancellationToken = default)
        {
            return await _context.Authors.FilterBy(filter)
                .CountAsync(cancellationToken: cancellationToken);
        }

        public async Task<List<Author>> FindByFilterAsync(
            AuthorsFilter filter,
            CancellationToken cancellationToken = default
        )
        {
            return await _context.Authors.FilterBy(filter)
                .ToListAsync(cancellationToken: cancellationToken);
        }

        public async Task<Author> FindFirstOrDefaultByFilterAsync(
            AuthorsFilter filter,
            CancellationToken cancellationToken = default
        )
        {
            return await _context.Authors.FilterBy(filter)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }
    }
}
