using baykuslar_api.Contract.Models;

namespace baykuslar_api.Contract.Request
{
    public class PostFundraisingDonationRequest : RequestBase
    {
        public FundraisingDonationModel FundraisingDonation { get; set; }
    }
}