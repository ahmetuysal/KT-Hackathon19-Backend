namespace baykuslar_api.Contract.Response
{
    public class CheckUserNameResponse : ResponseBase
    {
        public bool IsUserNameAvailable { get; set; }
    }
}