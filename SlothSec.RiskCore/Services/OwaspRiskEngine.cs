namespace SlothSec.RiskCore.Services;

using SlothSec.RiskCore.Interfaces;
using SlothSec.RiskCore.Models;

public class OwaspRiskEngine : IOwaspRiskEngine
{
    public double CalculateRisk(OwaspRiskInput input)
    {
        //placeholder
        return input.Likelihood * input.Impact;
    }
}