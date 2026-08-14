using Microsoft.AspNetCore.Mvc;
using SlothSec.WebAPI.Data;
using SlothSec.WebAPI.Models;

namespace SlothSec.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RiskController : ControllerBase
{
    [HttpPost]
    public IActionResult Create(RiskRecord record)
    {
        record.Id = RiskStore.Records.Count + 1;
        RiskStore.Records.Add(record);
        return Ok(record);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(RiskStore.Records);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var record = RiskStore.Records.FirstOrDefault(r => r.Id == id);
        if (record == null) return NotFound();
        return Ok(record);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, RiskRecord updated)
    {
        var record = RiskStore.Records.FirstOrDefault(r => r.Id == id);
        if (record == null) return NotFound();

        record.Cvss = updated.Cvss;
        record.Owasp = updated.Owasp;
        record.Combined = updated.Combined;

        return Ok(record);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var record = RiskStore.Records.FirstOrDefault(r => r.Id == id);
        if (record == null) return NotFound();

        RiskStore.Records.Remove(record);
        return Ok(record);
    }
}
