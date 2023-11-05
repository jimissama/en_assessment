using System.Net.Http.Json;
using EN.Client.Models;
using EN.Shared;

namespace EN.Client.Services
{
    public class BingMapAutoSuggestService : IBingMapAutoSuggestService
    {
        private readonly HttpClient _http;
        public BingMapAutoSuggestService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<BingMapAutoSuggestValue>> GetBusinessAddressesAsync(string query, string latitude, string longitude)
        {
            var requestBody = new BingMapAutoSuggestRequest{
                query = query, 
                userLocation = $"{latitude},{longitude}", 
                includeEntityTypes= "Business,Place,Address"};

                var response = await _http.PostAsJsonAsync<BingMapAutoSuggestRequest>($"BingMapAutoSuggest", requestBody);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<List<BingMapAutoSuggestValue>>();
        }
    }
}