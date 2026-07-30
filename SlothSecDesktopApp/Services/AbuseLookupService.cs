using SlothSec.RiskCore.Services;
using SlothSec.RiskCore.Models;

namespace SlothSecDesktopApp.Services;

public class AbuseLookupService
{
    private readonly AbuseIpLookup _lookup;

    public AbuseLookupService()
    {
        _lookup = new AbuseIpLookup();
    }

    public async Task<AbuseIpResults?> LookupAsync(string ip)
    {
        if (string.IsNullOrWhiteSpace(ip))
            return null;

        return await _lookup.CheckIpAsync(ip);
    }
}
