using baykuslar_api.Contract.Models;

namespace baykuslar_api.Contract.Request
{
    public class PostEquityFundingPostRequest : RequestBase
    {
        public EquityFundingPostModel EquityFundingPost { get; set; }
    }
}