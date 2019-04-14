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
    public class FundraisingDonationService : IFundraisingDonationService
    {
        private readonly ILogger<FundraisingDonationService> _logger;
        private readonly IFundraisingDonationRepository _fundraisingDonationRepository;
        private readonly IFundraisingDonationMapper _fundraisingDonationMapper;

        public FundraisingDonationService(IFundraisingDonationRepository fundraisingDonationRepository,
            IFundraisingDonationMapper fundraisingDonationMapper, ILogger<FundraisingDonationService> logger)
        {
            _logger = logger;
            _fundraisingDonationRepository = fundraisingDonationRepository;
            _fundraisingDonationMapper = fundraisingDonationMapper;
        }

        public void Dispose()
        {
            _fundraisingDonationRepository.Dispose();
        }

        public async Task<PostFundraisingDonationResponse> PostFundraisingDonationAsync(PostFundraisingDonationRequest request)
        {
            var result = await _fundraisingDonationRepository.PostFundraisingDonationAsync(
                _fundraisingDonationMapper.ToEntity(request.FundraisingDonation));
            
            if (!result)
                return new PostFundraisingDonationResponse
                {
                    StatusCode = (int) HttpStatusCode.Unauthorized
                };

            var response = new PostFundraisingDonationResponse {StatusCode = (int) HttpStatusCode.Created};

            return response;
        }

        public async Task<GetFundraisingDonationsResponse> GetFundraisingDonationsFromUserIdAsync(string userId)
        {
            var userDonations =
                await _fundraisingDonationRepository.GetFundraisingDonationsFromUserId(userId);

            var models = userDonations.Select(fd => _fundraisingDonationMapper.ToModel(fd)).ToList();

            var response = new GetFundraisingDonationsResponse
            {
                StatusCode = (int) HttpStatusCode.OK,
                FundraisingDonations = models
            };

            return response;        }
    }
}