using System.Linq;
using System.Net;
using System.Threading.Tasks;
using baykuslar_api.Contract.Request;
using baykuslar_api.Contract.Response;
using baykuslar_api.Data;
using baykuslar_api.Mappers;
using baykuslar_api.Repositories;
using Microsoft.Extensions.Logging;

namespace baykuslar_api.Services.Implementations
{
    public class EquityFundingPostService : IEquityFundingPostService
    {
        private readonly ILogger<EquityFundingPostService> _logger;
        private readonly IEquityFundingPostRepository _equityFundingPostRepository;
        private readonly IEquityFundingPostMapper _equityFundingPostMapper;

        public EquityFundingPostService(IEquityFundingPostRepository equityFundingPostRepository,
            IEquityFundingPostMapper equityFundingPostMapper, ILogger<EquityFundingPostService> logger)
        {
            _logger = logger;
            _equityFundingPostRepository = equityFundingPostRepository;
            _equityFundingPostMapper = equityFundingPostMapper;
        }

        public void Dispose()
        {
            _equityFundingPostRepository.Dispose();
        }

        public async Task<PostEquityFundingPostResponse> PostEquityFundingPostAsync(PostEquityFundingPostRequest request, string userId)
        {
            var entity = _equityFundingPostMapper.ToEntity(request.EquityFundingPost);
            entity.UserId = userId;
            var result = await _equityFundingPostRepository.PostEquityFundingPostAsync(entity);

            if (!result)
                return new PostEquityFundingPostResponse
                {
                    StatusCode = (int) HttpStatusCode.Unauthorized
                };

            var response = new PostEquityFundingPostResponse {StatusCode = (int) HttpStatusCode.Created};

            return response;
        }

        public async Task<GetEquityFundingPostsResponse> GetEquityFundingPostsHomeScreen()
        {
            var equityFundingPosts = await _equityFundingPostRepository.GetEquityFundingPostsHomeScreenAsync();
            
            var response = new GetEquityFundingPostsResponse
            {
                StatusCode = (int) HttpStatusCode.OK,
                EquityFundingPosts = equityFundingPosts.Select(efp => _equityFundingPostMapper.ToModel(efp)).ToList()
            };

            return response;
        }
    }
}