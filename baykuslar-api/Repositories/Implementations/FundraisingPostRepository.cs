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
    public class FundraisingPostRepository : IFundraisingPostRepository
    { 
        private readonly BaykuslarDbContext _dbContext;
        private readonly ILogger<FundraisingPostRepository> _logger;

        public FundraisingPostRepository(BaykuslarDbContext dbContext, ILogger<FundraisingPostRepository> logger)
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
                _logger.LogError(e, $"An error occured when saving records on {nameof(FundraisingPostRepository)}");
                return false;
            }
        }

        public async Task<bool> PostFundraisingPostAsync(FundraisingPostEntity entity)
        {
            await _dbContext.FundraisingPosts.AddAsync(entity);

            return await SaveAsync();
        }

        public async Task<List<FundraisingPostEntity>> GetFundraisingPostsHomeScreenAsync()
        {
            
            return await _dbContext.FundraisingPosts
                .Where(fp => fp.Deadline.CompareTo(DateTime.UtcNow) > 0 )
                .Take(50)
                .Include(fp => fp.FundraisingDonations)
                .ToListAsync();
        }
    }
}