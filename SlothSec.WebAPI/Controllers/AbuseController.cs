using Microsoft.AspNetCore.Mvc;
using SlothSec.RiskCore.Models;

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
        public async Task<IActionResult> Check(string ip)
        {
            var result = await _lookup.CheckIpAsync(ip);
            return Ok(result);
        }
    }
}