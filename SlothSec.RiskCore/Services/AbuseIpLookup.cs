using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SlothSec.RiskCore.Interfaces;

namespace SlothSec.RiskCore.Services
{
    public class AbuseIpLookup : IAbuseIpLookup
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public AbuseIpLookup(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _apiKey = config["AbuseIpDb:ApiKey"];
        }

        public async Task<string> CheckIpAsync(string ip)
        {
            var url = $"https://api.abuseipdb.com/api/v2/check?ipAddress={ip}&maxAgeInDays=90";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Key", _apiKey);
            request.Headers.Add("Accept", "application/json");

            var response = await _httpClient.SendAsync(request);
            return await response.Content.ReadAsStringAsync();
        }
    }
}