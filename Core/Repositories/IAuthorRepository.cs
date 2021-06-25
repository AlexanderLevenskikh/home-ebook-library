using System.Threading;
using System.Threading.Tasks;
using Core.Entities;
using Core.Repositories.Base;

namespace Core.Repositories
{
    public interface IAuthorRepository : IRepository<Author>
    {
        public Task<Author> FindByTitleAsync(string title, CancellationToken cancellationToken);
    }
}
