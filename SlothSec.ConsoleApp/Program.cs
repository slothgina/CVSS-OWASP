using SlothSec.RiskCore.Models;
using SlothSec.RiskCore.Services;

var cvss = new CvssCalculator();

var metrics = new CvssMetrics
{
    AttackVector = 5,
    AttackComplexity = 4,
    PrivilegesRequired = 3 
};

Console.WriteLine($"CVSS Score: {cvss.CalculateBaseScore(metrics)}");



