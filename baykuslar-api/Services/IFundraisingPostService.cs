using System.Threading.Tasks;
using baykuslar_api.Contract.Request;
using baykuslar_api.Contract.Response;

namespace baykuslar_api.Services
{
    public interface IFundraisingPostService : IService
    {
        Task<PostFundraisingPostResponse> PostFundraisingPostAsync(PostFundraisingPostRequest request, string userId);
        Task<GetFundraisingPostsResponse> GetFundraisingPostsHomeScreen();
    }
}