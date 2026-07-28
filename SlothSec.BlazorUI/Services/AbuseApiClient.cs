using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using SlothSec.RiskCore.Models;

public class AbuseApiClient
{
    private readonly HttpClient _http;

    public AbuseApiClient(HttpClient http)
    {
        _http = http;
    }

    public async Task<AbuseIpResult?> CheckIpAsync(string ip)
    {
        return await _http.GetFromJsonAsync<AbuseIpResult>(
            $"api/Abuse/check?ip={ip}"
        );
    }
}
