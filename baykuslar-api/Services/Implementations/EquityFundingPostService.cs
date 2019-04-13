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
    }
}