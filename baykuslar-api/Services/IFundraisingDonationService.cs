using System.Threading.Tasks;
using baykuslar_api.Contract.Request;
using baykuslar_api.Contract.Response;

namespace baykuslar_api.Services
{
    public interface IFundraisingDonationService : IService
    {
        Task<PostFundraisingDonationResponse> PostFundraisingDonationAsync(PostFundraisingDonationRequest request);
        Task<GetFundraisingDonationsResponse> GetFundraisingDonationsFromUserIdAsync(string userId);
    }
}