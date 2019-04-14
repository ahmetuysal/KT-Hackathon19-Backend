using System.Linq;
using baykuslar_api.Contract.Models;
using baykuslar_api.Data.Entities;

namespace baykuslar_api.Mappers.Implementations
{
    public class FundraisingPostMapper : IFundraisingPostMapper
    {
        public FundraisingPostModel ToModel(FundraisingPostEntity entity)
        {
            var model = new FundraisingPostModel
            {
                Deadline = entity.Deadline,
                Description = entity.Description,
                Id = entity.Id,
                Image = entity.Image,
                TargetAmount = entity.TargetAmount,
                TargetIban = entity.TargetIban,
                Title = entity.Title,
                UserId = entity.UserId
            };

            if (entity.FundraisingDonations != null && entity.FundraisingDonations.Any())
            {
                model.FundedAmount = entity.FundraisingDonations.Sum(fd => fd.Amount);
            }
            
            return model;
        }

        public FundraisingPostEntity ToEntity(FundraisingPostModel model)
        {
            return new FundraisingPostEntity
            {
                Deadline = model.Deadline,
                Description = model.Description,
                Id = model.Id,
                Image = model.Image,
                TargetAmount = model.TargetAmount,
                TargetIban = model.TargetIban,
                Title = model.Title,
                UserId = model.UserId
            };
        }
    }
}