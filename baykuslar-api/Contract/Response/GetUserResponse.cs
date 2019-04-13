using baykuslar_api.Contract.Models;

namespace baykuslar_api.Contract.Response
{
    public class GetUserResponse : ResponseBase
    {
        public UserModel User { get; set; }
    }
}