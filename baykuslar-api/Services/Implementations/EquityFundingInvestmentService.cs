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
    }
}