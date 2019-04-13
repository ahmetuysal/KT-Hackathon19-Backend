using System.Linq;
using baykuslar_api.Contract.Models;
using baykuslar_api.Data.Entities;

namespace baykuslar_api.Mappers.Implementations
{
    public class EquityFundingPostMapper : IEquityFundingPostMapper
    {
        public EquityFundingPostModel ToModel(EquityFundingPostEntity entity)
        {
            var model = new EquityFundingPostModel
            {
                UserId = entity.UserId,
                Deadline = entity.Deadline,
                Description = entity.Description,
                Id = entity.Id,
                Image = entity.Image,
                SharePrice = entity.SharePrice,
                TargetShare = entity.TargetShare,
                Title = entity.Title
            };

            if (entity.EquityFundingInvestments != null && entity.EquityFundingInvestments.Any())
            {
                model.SoldShare = entity.EquityFundingInvestments.Sum(efi => efi.ShareCount);
            }

            return model;
        }

        public EquityFundingPostEntity ToEntity(EquityFundingPostModel model)
        {
            return new EquityFundingPostEntity
            {
                UserId = model.UserId,
                Deadline = model.Deadline,
                Description = model.Description,
                Id = model.Id,
                Image = model.Image,
                SharePrice = model.SharePrice,
                TargetShare = model.TargetShare,
                Title = model.Title
            };
            
        }
    }
}