using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SlothSec.RiskCore.Interfaces;

namespace SlothSec.RiskCore.Models;

    public class AbuseIpLookup : IAbuseIpLookup
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public AbuseIpLookup(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _apiKey = config["AbuseIpDb:ApiKey"] ?? string.Empty;
        }

        public async Task<AbuseIpResult?> CheckIpAsync(string ip)
        {
            var url = $"https://api.abuseipdb.com/api/v2/check?ipAddress={ip}&maxAgeInDays=90";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Key", _apiKey);
            request.Headers.Add("Accept", "application/json");

            var response = await _httpClient.SendAsync(request);
            
            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<AbuseIpResult>();
        }
    }