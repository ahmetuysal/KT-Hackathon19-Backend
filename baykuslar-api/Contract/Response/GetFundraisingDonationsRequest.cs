using System.Collections.Generic;
using baykuslar_api.Contract.Models;

namespace baykuslar_api.Contract.Response
{
    public class GetFundraisingDonationsResponse: ResponseBase
    {
        public List<FundraisingDonationModel> FundraisingDonations { get; set; }
    }
}