using System.Net.Http.Json;
using SlothSec.RiskCore.Models;

namespace SlothSec.BlazorUI.Services;

public class OwaspApiService
{
    private readonly HttpClient _http;

    public OwaspApiService(HttpClient http)
    {
        _http = http;
    }

    public async Task<double> GetOwaspRisk(OwaspRiskInput input)
    {
        var response = await _http.PostAsJsonAsync("/api/owasp/risk", input);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<double>();
    }
}

