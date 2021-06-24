using System;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public interface IDbContextSet : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}