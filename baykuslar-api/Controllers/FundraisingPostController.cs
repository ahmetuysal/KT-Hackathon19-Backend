using System.Security.Claims;
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
    [Route("v1/fundraising-post")]
    public class FundraisingPostController : ApiControllerBase
    {
        private readonly IFundraisingPostService _fundraisingPostService;

        public FundraisingPostController(IFundraisingPostService fundraisingPostService
        )
        {
            _fundraisingPostService = fundraisingPostService;
        }
        
        [HttpPost]
        public async Task<IActionResult> PostFundraisingPost([FromBody] PostFundraisingPostRequest request)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null) return Unauthorized();
            
            var response = await _fundraisingPostService.PostFundraisingPostAsync(request, userId);

            return GenerateResponse(response);
        }
        
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetEquityFundingPosts()
        {            
            var response = await _fundraisingPostService.GetFundraisingPostsHomeScreen();

            return GenerateResponse(response);
        }
        
    }
}