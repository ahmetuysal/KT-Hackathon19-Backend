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
    public class FundraisingPostService : IFundraisingPostService
    {
        private readonly ILogger<FundraisingPostService> _logger;
        private readonly IFundraisingPostRepository _fundraisingPostRepository;
        private readonly IFundraisingPostMapper _fundraisingPostMapper;
        
        public FundraisingPostService(IFundraisingPostRepository fundraisingPostRepository,
            IFundraisingPostMapper fundraisingPostMapper, ILogger<FundraisingPostService> logger)
        {
            _fundraisingPostRepository = fundraisingPostRepository;
            _fundraisingPostMapper = fundraisingPostMapper;
            _logger = logger;
        }

        public void Dispose()
        {
            _fundraisingPostRepository.Dispose();
        }

        public async Task<PostFundraisingPostResponse> PostFundraisingPostAsync(PostFundraisingPostRequest request, string userId)
        {
            var entity = _fundraisingPostMapper.ToEntity(request.FundraisingPost);
            entity.UserId = userId;
            var result = await _fundraisingPostRepository.PostFundraisingPostAsync(entity);

            if (!result)
                return new PostFundraisingPostResponse
                {
                    StatusCode = (int) HttpStatusCode.Unauthorized
                };

            var response = new PostFundraisingPostResponse {StatusCode = (int) HttpStatusCode.Created};

            return response;        
        }

        public async Task<GetFundraisingPostsResponse> GetFundraisingPostsHomeScreen()
        {
            throw new System.NotImplementedException();
        }
    }
}