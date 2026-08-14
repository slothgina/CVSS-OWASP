using SlothSec.RiskCore.Models;
using SlothSec.RiskCore.Services;
using Xunit;

public class OwaspRiskEngineTests
{
    [Fact]
    public void CalculateRisk_MultipliesLikelihoodAndImpact()
    {
        var input = new OwaspRiskInput
        {
            Likelihood = 8,
            Impact = 9
        };

    var engine = new OwaspRiskEngine();
    var score = engine.CalculateRisk(input);
    Assert.Equal(72, score);
    }
}