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
    }
}