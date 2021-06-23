using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class EbookLibraryContext : DbContext
    {
        public EbookLibraryContext(DbContextOptions options) : base(options)
        {
        }
    }
}