namespace SlothSec.RiskCore.Services;

using SlothSec.RiskCore.Interfaces;
using SlothSec.RiskCore.Models;

public class CvssCalculator : ICvssCalculator
{
    public double CalculateBaseScore(CvssMetrics m)
    {
        //placeholder
        return (m.AttackVector + m.AttackComplexity + m.PrivilegesRequired) / 3.0;
    }
}
