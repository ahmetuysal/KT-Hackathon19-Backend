using baykuslar_api.Contract.Models;

namespace baykuslar_api.Contract.Request
{
    public class PostEquityFundingInvestmentRequest : RequestBase
    {
        public EquityFundingInvestmentModel EquityFundingInvestment { get; set; }
    }
}