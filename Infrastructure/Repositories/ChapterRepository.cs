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
    public class ChapterRepository : Repository<Chapter>, IChapterRepository
    {
        private readonly EbookLibraryContext _context;
        public ChapterRepository(EbookLibraryContext context) : base(context)
        {
            _context = context;
        }
        
        public async Task<long> CountByFilterAsync(ChaptersFilter filter, CancellationToken cancellationToken = default)
        {
            return await _context.Chapters.FilterBy(filter)
                .CountAsync(cancellationToken: cancellationToken);
        }

        public async Task<List<Chapter>> FindByFilterAsync(
            ChaptersFilter filter,
            CancellationToken cancellationToken = default
        )
        {
            return await _context.Chapters.FilterBy(filter)
                .ToListAsync(cancellationToken: cancellationToken);
        }

        public async Task<Chapter> FindFirstOrDefaultByFilterAsync(
            ChaptersFilter filter,
            CancellationToken cancellationToken = default
        )
        {
            return await _context.Chapters.FilterBy(filter)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }
    }
}
