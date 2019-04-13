using baykuslar_api.Contract.Models;
using baykuslar_api.Data.Entities;

namespace baykuslar_api.Mappers.Implementations
{
    public class FundraisingDonationMapper: IFundraisingDonationMapper
    {
        public FundraisingDonationModel ToModel(FundraisingDonationEntity entity)
        {
            return new FundraisingDonationModel
            {
                Amount = entity.Amount,
                Date = entity.Date,
                FundraisingPostId = entity.FundraisingPostId,
                Message = entity.Message,
                UserId = entity.UserId
            };
        }

        public FundraisingDonationEntity ToEntity(FundraisingDonationModel model)
        {
            return new FundraisingDonationEntity
            {
                Amount = model.Amount,
                Date = model.Date,
                FundraisingPostId = model.FundraisingPostId,
                Message = model.Message,
                UserId = model.UserId
            };
        }
    }
}