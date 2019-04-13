using System.Threading.Tasks;
using baykuslar_api.Contract.Request;
using baykuslar_api.Contract.Response;

namespace baykuslar_api.Services
{
    public interface IEquityFundingPostService : IService
    {
        Task<PostEquityFundingPostResponse> PostEquityFundingPostAsync(PostEquityFundingPostRequest request, string userId);
        Task<GetEquityFundingPostsResponse> GetEquityFundingPostsHomeScreen();
    }
}