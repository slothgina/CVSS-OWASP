using SlothSec.RiskCore.Models;
using SlothSec.RiskCore.Services;
using Xunit;

public class CvssCalculatorTests
{
    [Fact]
    public void CalculateBaseScore_ReturnsExpectedAverage()
    {
        var calculator = new CvssCalculator();
        var metrics = new CvssMetrics
        {
            AttackVector = 5,
            AttackComplexity = 4,
            PrivilegesRequired = 3,
            UserInteraction = 2
        };

        var score = calculator.CalculateBaseScore(metrics);

        Assert.Equal((5 + 4 + 3) / 3.0, score);
    }
}
//Test placeholder formula