using System.Threading.Tasks;

namespace SlothSec.RiskCore.Interfaces
{
    public interface IAbuseIpLookup
    {
        Task<string> CheckIpAsync(string ip);
    }
}