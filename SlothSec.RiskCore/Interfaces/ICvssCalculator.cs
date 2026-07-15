namespace SlothSec.RiskCore.InterFaces;

using SlothSec.RiskCore.Models;

public interface ICvssCalculator
{
    double CalculateBaseScore(CvssMetrics metrics);
}