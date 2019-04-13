using System;
using System.Threading.Tasks;

namespace baykuslar_api.Repositories
{
    public interface IRepository : IDisposable
    {
        Task<bool> SaveAsync();
    }
}