using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Core.Entities.Base;

namespace Core.Repositories.Base
{
    public interface IRepository<T> where T : Entity
    {
        public Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default);

        public Task<IReadOnlyList<T>> GetAsync(
            Expression<Func<T, bool>> predicate,
            CancellationToken cancellationToken = default
        );

        public Task<IReadOnlyList<T>> GetAsync(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeString = null,
            bool disableTracking = true,
            CancellationToken cancellationToken = default
        );

        public Task<IReadOnlyList<T>> GetAsync(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            List<Expression<Func<T, object>>> includes = null,
            bool disableTracking = true,
            CancellationToken cancellationToken = default
        );

        public Task<T> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);
        public Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);

        public Task<IEnumerable<T>> AddRangeAsync(
            IEnumerable<T> entities,
            CancellationToken cancellationToken = default
        );

        public Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
        public Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
        public Task RemoveAsync(T entity, CancellationToken cancellationToken = default);
        public Task RemoveRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
    }
}
