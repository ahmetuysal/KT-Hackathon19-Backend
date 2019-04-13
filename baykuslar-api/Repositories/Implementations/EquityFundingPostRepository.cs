using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using baykuslar_api.Data;
using baykuslar_api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace baykuslar_api.Repositories.Implementations
{
    public class EquityFundingPostRepository : IEquityFundingPostRepository
    {
        private readonly BaykuslarDbContext _dbContext;
        private readonly ILogger<EquityFundingPostRepository> _logger;

        public EquityFundingPostRepository(BaykuslarDbContext dbContext, ILogger<EquityFundingPostRepository> logger)
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
                _logger.LogError(e, $"An error occured when saving records on {nameof(EquityFundingPostRepository)}");
                return false;
            }
        }

        public async Task<bool> PostEquityFundingPostAsync(EquityFundingPostEntity entity)
        {
            await _dbContext.EquityFundingPosts.AddAsync(entity);

            return await SaveAsync();        
        }

        public async Task<List<EquityFundingPostEntity>> GetEquityFundingPostsHomeScreenAsync()
        {
            return await _dbContext.EquityFundingPosts
                .Where(efp => efp.Deadline.Ticks > DateTime.UtcNow.Ticks)
                .Take(50)
                .Include(efp => efp.EquityFundingInvestments)
                .ToListAsync();
        }
    }
}