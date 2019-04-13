using System.Threading.Tasks;
using baykuslar_api.Common;
using baykuslar_api.Contract.Request;
using baykuslar_api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace baykuslar_api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("v1/account")]
    public class AccountController : ApiControllerBase
    {
        private readonly IAccountService _accountService;
        
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var response = await _accountService.PasswordLoginAsync(request);
            return GenerateResponse(response);
        }

        [AllowAnonymous]
        [HttpPost("signUp")]
        public async Task<IActionResult> SignUp([FromBody] SignUpRequest request)
        {
            var response = await _accountService.SignUpAsync(request);
            return GenerateResponse(response);
        }        
        
    }
}