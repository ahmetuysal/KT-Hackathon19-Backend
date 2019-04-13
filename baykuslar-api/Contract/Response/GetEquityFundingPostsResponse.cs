using System.Collections.Generic;
using baykuslar_api.Contract.Models;

namespace baykuslar_api.Contract.Response
{
    public class GetEquityFundingPostsResponse : ResponseBase
    {
        public List<EquityFundingPostModel> EquityFundingPosts { get; set; } 
    }
}