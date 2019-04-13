using System.Collections.Generic;
using System.Threading.Tasks;
using baykuslar_api.Contract.Models;
using baykuslar_api.Data.Entities;

namespace baykuslar_api.Repositories
{
    public interface IEquityFundingPostRepository : IRepository
    {
        Task<bool> PostEquityFundingPostAsync(EquityFundingPostEntity entity);

        Task<List<EquityFundingPostEntity>> GetEquityFundingPostsHomeScreenAsync();
            
    }
}