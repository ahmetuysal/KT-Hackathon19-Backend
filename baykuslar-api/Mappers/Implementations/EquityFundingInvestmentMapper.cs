using baykuslar_api.Contract.Models;
using baykuslar_api.Data.Entities;

namespace baykuslar_api.Mappers.Implementations
{
    public class EquityFundingInvestmentMapper : IEquityFundingInvestmentMapper
    {
        public EquityFundingInvestmentModel ToModel(EquityFundingInvestmentEntity entity)
        {
            return new EquityFundingInvestmentModel
            {
                UserId = entity.UserId,
                Date = entity.Date,
                EquityFundingPostId = entity.EquityFundingPostId,
                Message = entity.Message,
                ShareCount = entity.ShareCount
            };
        }

        public EquityFundingInvestmentEntity ToEntity(EquityFundingInvestmentModel model)
        {
            return new EquityFundingInvestmentEntity
            {
                UserId = model.UserId,
                Date = model.Date,
                EquityFundingPostId = model.EquityFundingPostId,
                Message = model.Message,
                ShareCount = model.ShareCount
            };        
        }
    }
}