using Microsoft.AspNetCore.Mvc;
using SlothSec.RiskCore.Interfaces;
using SlothSec.RiskCore.Models;
using SlothSec.RiskCore.Services;

namespace SlothSec.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OwaspController : ControllerBase
{
    private readonly IOwaspRiskEngine _engine;

    public OwaspController(IOwaspRiskEngine engine)
    {
        _engine = engine;
    }

    [HttpPost("risk")]
    public IActionResult Risk([FromBody] OwaspRiskInput input)

    {
        var risk = _engine.CalculateRisk(input);
        return Ok(risk);
    }
}




