using SlothSec.RiskCore;
using Xunit;

public class InputHelperTests
{
    [Fact]
    public void TryReadDouble_ReturnsFalse_OnInvalidInput()
    {
        var result = InputHelper.TryReadDouble("q", out double value);
        Assert.False(result);
    }

    [Fact]
    public void TryReadDouble_ReturnsTrue_OnValidInput()
    {
        var result = InputHelper.TryReadDouble("5.0", out double value);
        Assert.True(result);
        Assert.Equal(5.0, value);
    }

    [Fact]
    public void TryReadInt_ReturnFalse_OnInvalidInput()
    {
        var result = InputHelper.TryReadInt("abc", out int value);
        Assert.False(result);
    }

    [Fact]
    public void TryReadInt_ReturnsTrue_OnValidInput()
    {
        var result = InputHelper.TryReadInt("7", out int value);
        Assert.True(result);
        Assert.Equal(7, value);
    }
}