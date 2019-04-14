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
    [Route("v1/fundraising-donations")]
    public class FundraisingDonationController : ApiControllerBase
    {
        private readonly IFundraisingDonationService _fundraisingDonationService;

        public FundraisingDonationController(IFundraisingDonationService fundraisingDonationService
        )
        {
            _fundraisingDonationService = fundraisingDonationService;
        }
        
        [HttpPost]
        public async Task<IActionResult> PostEFundraisingDonation([FromBody] PostFundraisingDonationRequest request)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null || userId != request.FundraisingDonation.UserId ) return Unauthorized();
            
            var response = await _fundraisingDonationService.PostFundraisingDonationAsync(request);

            return GenerateResponse(response);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetEquityFundingPosts()
        {            
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            
            if (userId == null ) return Unauthorized();

            var response = await _fundraisingDonationService.GetFundraisingDonationsFromUserIdAsync(userId);

            return GenerateResponse(response);
        }
        
    }
}