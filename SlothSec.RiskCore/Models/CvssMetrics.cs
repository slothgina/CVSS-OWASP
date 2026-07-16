namespace SlothSec.RiskCore.Models;

public class CvssMetrics
{
    public double AttackVector { get; set; }
    public double AttackComplexity { get; set; }
    public double PrivilegesRequired { get; set; }
    public double UserInteraction { get; set; }
}