namespace SlothSec.WebAPI.Models;

public class RiskRecord
{
    public int Id { get; set; }
    public double Cvss { get; set; }
    public double Owasp { get; set; }
    public double Combined { get; set; }
}