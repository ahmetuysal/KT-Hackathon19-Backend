using baykuslar_api.Contract;
using Microsoft.AspNetCore.Mvc;

namespace baykuslar_api.Common
{
    public class ApiControllerBase : ControllerBase
    {
        [NonAction]
        public IActionResult GenerateResponse(ResponseBase response)
        {
            return StatusCode(response.StatusCode, response);
        }
    }
}