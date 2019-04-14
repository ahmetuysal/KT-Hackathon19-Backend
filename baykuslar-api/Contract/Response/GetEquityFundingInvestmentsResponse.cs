using System.Collections.Generic;
using baykuslar_api.Contract.Models;

namespace baykuslar_api.Contract.Response
{
    public class GetEquityFundingInvestmentsResponse : ResponseBase
    {
        public List<EquityFundingInvestmentModel> EquityFundingInvestments { get; set; }
    }
}