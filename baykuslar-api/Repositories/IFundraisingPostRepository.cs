using System.Collections.Generic;
using System.Threading.Tasks;
using baykuslar_api.Data.Entities;

namespace baykuslar_api.Repositories
{
    public interface IFundraisingPostRepository : IRepository
    {
        Task<bool> PostFundraisingPostAsync(FundraisingPostEntity entity);
        Task<List<FundraisingPostEntity>> GetFundraisingPostsHomeScreenAsync();
    }
}