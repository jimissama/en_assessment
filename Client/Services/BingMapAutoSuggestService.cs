using System.Net.Http.Json;
using EN.Client.Models;

namespace EN.Client.Services
{
    public class BingMapAutoSuggestService : IBingMapAutoSuggestService
    {
        private readonly HttpClient _http;
        public BingMapAutoSuggestService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<BusinessAddress>> GetBusinessAddressesAsync(string query, string latitude, string longitude)
        {
            return await _http.GetFromJsonAsync<List<BusinessAddress>>($"BingMapAutoSuggest/{query}/{latitude}/{longitude}");
        }
    }
}