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
    public class EquityFundingInvestmentService : IEquityFundingInvestmentService
    {
        private readonly ILogger<EquityFundingInvestmentService> _logger;
        private readonly IEquityFundingInvestmentRepository _equityFundingInvestmentRepository;
        private readonly IEquityFundingInvestmentMapper _equityFundingInvestmentMapper;


        public EquityFundingInvestmentService(IEquityFundingInvestmentRepository equityFundingInvestmentRepository,
            IEquityFundingInvestmentMapper equityFundingInvestmentMapper, ILogger<EquityFundingInvestmentService> logger)
        {
            _equityFundingInvestmentRepository = equityFundingInvestmentRepository;
            _equityFundingInvestmentMapper = equityFundingInvestmentMapper;
            _logger = logger;
        }

        public void Dispose()
        {
            _equityFundingInvestmentRepository.Dispose();
        }

        public async Task<PostEquityFundingInvestmentResponse> PostEquityFundingInvestmentAsync(PostEquityFundingInvestmentRequest request)
        {
            var result = await _equityFundingInvestmentRepository.PostEquityFundingInvestmentAsync(
                _equityFundingInvestmentMapper.ToEntity(request.EquityFundingInvestment));
            
            if (!result)
                return new PostEquityFundingInvestmentResponse
                {
                    StatusCode = (int) HttpStatusCode.Unauthorized
                };

            var response = new PostEquityFundingInvestmentResponse {StatusCode = (int) HttpStatusCode.Created};

            return response;
        }

        public async Task<GetEquityFundingInvestmentsResponse> GetEquityFundingInvestmentsFromUserIdAsync(string userId)
        {
            var userEquityInvestments =
                await _equityFundingInvestmentRepository.GetEquityFundingInvestmentsFromUserId(userId);

            var models = userEquityInvestments.Select(efi => _equityFundingInvestmentMapper.ToModel(efi)).ToList();

            var response = new GetEquityFundingInvestmentsResponse
            {
                StatusCode = (int) HttpStatusCode.OK,
                EquityFundingInvestments = models
            };

            return response;
        }
    }
}