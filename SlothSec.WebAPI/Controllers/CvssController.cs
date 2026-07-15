using Microsoft.AspNetCore.Mvc;
using SlothSec.RiskCore.Interfaces;
using SlothSec.RiskCore.Models;
using SlothSec.RiskCore.Services;

namespace SlothSec.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CvssController : ControllerBase
{
    private readonly ICvssCalculator _calc;

    public CvssController(ICvssCalculator calc)
    {
        _calc = calc;
    }

    [HttpPost("score")]
    public IActionResult Score([FromBody] CvssMetrics metrics)
    {
        var score = _calc.CalculateBaseScore(metrics);
        return Ok(score);
    }
}
