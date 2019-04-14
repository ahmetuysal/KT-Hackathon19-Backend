using System.Collections.Generic;
using System.Threading.Tasks;
using baykuslar_api.Data.Entities;

namespace baykuslar_api.Repositories
{
    public interface IEquityFundingInvestmentRepository : IRepository
    {
        Task<bool> PostEquityFundingInvestmentAsync(EquityFundingInvestmentEntity entity);

        Task<List<EquityFundingInvestmentEntity>> GetEquityFundingInvestmentsFromUserId(string userId);

    }
}