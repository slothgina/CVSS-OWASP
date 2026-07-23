using Microsoft.AspNetCore.Mvc;
using SlothSec.RiskCore.Interfaces;

namespace SlothSec.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AbuseController : ControllerBase
    {
        private readonly IAbuseIpLookup _lookup;

        public AbuseController(IAbuseIpLookup lookup)
        {
            _lookup = lookup;
        }

        [HttpGet("check")]
        public async Task<IActionResult> CheckIp([FromQuery] string ip)
        {
            var result = await _lookup.CheckIpAsync(ip);
            return Content(result, "application/json");
        }
    }
}