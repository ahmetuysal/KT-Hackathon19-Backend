using baykuslar_api.Contract.Models;

namespace baykuslar_api.Contract.Request
{
    public class PostFundraisingPostRequest : RequestBase
    {
        public FundraisingPostModel FundraisingPost { get; set; }
    }
}