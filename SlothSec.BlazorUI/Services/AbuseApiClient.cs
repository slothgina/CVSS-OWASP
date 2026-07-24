using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using SlothSec.BlazorUI.Models;

public class AbuseApiClient
{
    private readonly HttpClient _http;

    public AbuseApiClient(HttpClient _http)
    {
        _http = http;
    }

    public async Task<AbuseIpResult> CheckIpAsync(string ip)
    {
        return await _http.GetFromJsonAsync<AbuseIpResult>(

        $"api/Abuse/check?ip={ip}"
        );
    }
}
