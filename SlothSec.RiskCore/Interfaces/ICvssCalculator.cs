namespace SlothSec.RiskCore.Interfaces;

using SlothSec.RiskCore.Models;

public interface ICvssCalculator
{
    double CalculateBaseScore(CvssMetrics metrics);
}