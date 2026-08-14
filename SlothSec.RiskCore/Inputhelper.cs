namespace SlothSec.RiskCore;

public static class InputHelper
{
    public static bool TryReadDouble(string input, out double value)
    {
        return double.TryParse(input, out value);
    }

    public static bool TryReadInt(string input, out int value)
    {
        return int.TryParse(input, out value);
    }   
}