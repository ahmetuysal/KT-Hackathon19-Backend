using System.Threading.Tasks;
using baykuslar_api.Contract.Request;
using baykuslar_api.Contract.Response;

namespace baykuslar_api.Services
{
    public interface IEquityFundingInvestmentService : IService
    {
        Task<PostEquityFundingInvestmentResponse> PostEquityFundingInvestmentAsync(PostEquityFundingInvestmentRequest request);
        Task<GetEquityFundingInvestmentsResponse> GetEquityFundingInvestmentsFromUserIdAsync(string userId);
    }
}