using SlothSec.WebAPI.Models;

namespace SlothSec.WebAPI.Data;

public static class RiskStore
{
    public static List<RiskRecord> Records { get; } = new();
}