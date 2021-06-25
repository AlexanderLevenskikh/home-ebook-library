using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Core.Entities;
using Core.Repositories;
using Infrastructure.Data;
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

        public async Task<Author> FindByTitleAsync(string title, CancellationToken cancellationToken)
        {
            return await _context.Authors.FirstOrDefaultAsync(
                a => a.Title == title,
                cancellationToken: cancellationToken
            );
        }
    }
}
