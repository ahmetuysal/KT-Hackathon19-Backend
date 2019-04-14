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
    [Route("v1/equity-funding-investments")]
    public class EquityFundingInvestmentController : ApiControllerBase
    {
        private readonly IEquityFundingInvestmentService _equityFundingInvestmentService;

        public EquityFundingInvestmentController(IEquityFundingInvestmentService equityFundingInvestmentService
        )
        {
            _equityFundingInvestmentService = equityFundingInvestmentService;
        }
        
        [HttpPost]
        public async Task<IActionResult> PostEquityFundingInvestment([FromBody] PostEquityFundingInvestmentRequest request)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null || userId != request.EquityFundingInvestment.UserId ) return Unauthorized();
            
            var response = await _equityFundingInvestmentService.PostEquityFundingInvestmentAsync(request);

            return GenerateResponse(response);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetEquityFundingPosts()
        {            
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            
            if (userId == null ) return Unauthorized();

            var response = await _equityFundingInvestmentService.GetEquityFundingInvestmentsFromUserIdAsync(userId);

            return GenerateResponse(response);
        }
        
    }

}