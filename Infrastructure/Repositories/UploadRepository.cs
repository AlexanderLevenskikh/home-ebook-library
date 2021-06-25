using Core.Entities;
using Core.Repositories;
using Infrastructure.Data;
using Infrastructure.Repositories.Base;

namespace Infrastructure.Repositories
{
    public class UploadRepository : Repository<Upload>, IUploadRepository
    {
        public UploadRepository(EbookLibraryContext context) : base(context)
        {
        }
    }
}
