using System.Collections.Generic;
using System.Threading.Tasks;
using baykuslar_api.Data.Entities;

namespace baykuslar_api.Repositories
{
    public interface IFundraisingDonationRepository : IRepository
    {
        Task<bool> PostFundraisingDonationAsync(FundraisingDonationEntity entity);

        Task<List<FundraisingDonationEntity>> GetFundraisingDonationsFromUserId(string userId);
    }
}