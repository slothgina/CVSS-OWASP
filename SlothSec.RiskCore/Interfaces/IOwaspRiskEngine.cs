namespace SlothSec.RiskCore.Interfaces;

using SlothSec.RiskCore.Models;

public interface IOwaspRiskEngine
{
    double CalculateRisk(OwaspRiskInput input);
}