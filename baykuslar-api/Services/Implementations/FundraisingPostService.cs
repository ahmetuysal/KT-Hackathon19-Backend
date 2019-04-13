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
    }
}