using System;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public interface IDbContextMigrate : IDisposable
    {
        Task MigrateAsync();
    }
}