using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using baykuslar_api.Data;
using baykuslar_api.Data.Entities;
using Microsoft.Extensions.Logging;

namespace baykuslar_api.Repositories.Implementations
{
    public class FundraisingDonationRepository : IFundraisingDonationRepository
    {
        private readonly BaykuslarDbContext _dbContext;
        private readonly ILogger<FundraisingDonationRepository> _logger;

        public FundraisingDonationRepository(BaykuslarDbContext dbContext, ILogger<FundraisingDonationRepository> logger)
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
                _logger.LogError(e, $"An error occured when saving records on {nameof(FundraisingDonationRepository)}");
                return false;
            }
        }

        public async Task<bool> PostFundraisingDonationAsync(FundraisingDonationEntity entity)
        {
            await _dbContext.FundraisingDonations.AddAsync(entity);

            return await SaveAsync();
        }

        public async Task<List<FundraisingDonationEntity>> GetFundraisingDonationsFromUserId(string userId)
        {
            return _dbContext.FundraisingDonations.Where(fd => fd.UserId == userId).ToList();
        }
    }
}