namespace SlothSec.BlazorUI.Services
{
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;
    using SlothSec.RiskCore.Models;

    public class CvssApiService
    {
        private readonly HttpClient _http;

        public CvssApiService(HttpClient http)
        {
            _http = http;
        }

        public async Task<double?> GetCvssScore(CvssMetrics metrics)
        {
            var response = await _http.PostAsJsonAsync("api/cvss/calculate", metrics);

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<double>();
        }
    }
}
