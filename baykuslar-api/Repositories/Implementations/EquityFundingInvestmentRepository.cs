using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using baykuslar_api.Data;
using baykuslar_api.Data.Entities;
using Microsoft.Extensions.Logging;

namespace baykuslar_api.Repositories.Implementations
{
    public class EquityFundingInvestmentRepository : IEquityFundingInvestmentRepository
    {
        private readonly BaykuslarDbContext _dbContext;
        private readonly ILogger<EquityFundingInvestmentRepository> _logger;

        public EquityFundingInvestmentRepository(BaykuslarDbContext dbContext, ILogger<EquityFundingInvestmentRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        public async Task<bool> SaveAsync()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"An error occured when saving records on {nameof(EquityFundingInvestmentRepository)}");
                return false;
            }
        }

        public async Task<bool> PostEquityFundingInvestmentAsync(EquityFundingInvestmentEntity entity)
        {
            await _dbContext.EquityFundingInvestments.AddAsync(entity);

            return await SaveAsync();
        }

        public async Task<List<EquityFundingInvestmentEntity>> GetEquityFundingInvestmentsFromUserId(string userId)
        {
            return _dbContext.EquityFundingInvestments.Where(efi => efi.UserId == userId).ToList();
        }
    }
}