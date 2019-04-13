using System;
using System.Threading.Tasks;
using baykuslar_api.Contract.Request;
using baykuslar_api.Contract.Response;

namespace baykuslar_api.Services
{
    public interface IAccountService : IDisposable
    {
        Task<LoginResponse> PasswordLoginAsync(LoginRequest request);

        Task<SignUpResponse> SignUpAsync(SignUpRequest request);

        Task<CheckUserNameResponse> CheckUserNameAsync(CheckUserNameRequest request);

        Task<GetUserResponse> GetUserFromIdAsync(string userId);

    }
}