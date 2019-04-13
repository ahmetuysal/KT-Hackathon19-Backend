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
    [Route("v1/equity-funding-post")]
    public class EquityFundingPostController : ApiControllerBase
    {
        private readonly IEquityFundingPostService _equityFundingPostService;

        public EquityFundingPostController(IEquityFundingPostService equityFundingPostService
        )
        {
            _equityFundingPostService = equityFundingPostService;
        }
        
        [HttpPost]
        public async Task<IActionResult> PostEquityFundingPost([FromBody] PostEquityFundingPostRequest request)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null) return Unauthorized();
            
            var response = await _equityFundingPostService.PostEquityFundingPostAsync(request, userId);

            return GenerateResponse(response);
        }
        
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetEquityFundingPosts()
        {            
            var response = await _equityFundingPostService.GetEquityFundingPostsHomeScreen();

            return GenerateResponse(response);
        }
        
    }
}