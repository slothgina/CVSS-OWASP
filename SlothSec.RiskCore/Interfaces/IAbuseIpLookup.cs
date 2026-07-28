using System.Threading.Tasks;

namespace SlothSec.RiskCore.Models
{
    public interface IAbuseIpLookup
    {
        Task<AbuseIpResult?> CheckIpAsync(string ip);
    }
}