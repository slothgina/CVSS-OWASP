using System.Net.Http.Json;
using SlothSec.RiskCore.Models;

namespace SlothSec.BlazorUI.Services;

public class CvssApiService
{
    private readonly HttpClient _http;

    public CvssApiService(HttpClient http)
    {
        _http = http;
    }

    public async Task<double> GetCvssScore(CvssMetrics metrics)
    {
        var response = await _http.PostAsJsonAsync("/api/cvss/score", metrics);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<double>();
    }
}