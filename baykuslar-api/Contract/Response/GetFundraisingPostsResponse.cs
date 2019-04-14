using System.Collections.Generic;
using baykuslar_api.Contract.Models;

namespace baykuslar_api.Contract.Response
{
    public class GetFundraisingPostsResponse : ResponseBase
    {
        public List<FundraisingPostModel> FundraisingPosts { get; set; }
    }
}