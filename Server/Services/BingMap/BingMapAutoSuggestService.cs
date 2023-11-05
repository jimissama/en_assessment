using System.Collections.Specialized;
using Server.Helpers;
using Server.Models;
using Newtonsoft.Json;

namespace Server.Services.BingMap
{
    public class BingMapAutoSuggestService : IBingMapAutoSuggestService
    {
        private readonly HttpClient _httpClient;
        private readonly BingMapAuth _bingMapAuth;
        public BingMapAutoSuggestService(HttpClient httpClient, BingMapAuth bingMapAuth)
        {
            _bingMapAuth = bingMapAuth;
            _httpClient = httpClient;
            
        }
        public async Task<List<BingMapAutoSuggestAddress>> GetBusinessAddressDataAsync(string query, string latitude, string longitude)
        {
            var baseUrl = "http://dev.virtualearth.net/REST/v1/Autosuggest";
            NameValueCollection queryString = new NameValueCollection();
            queryString.Add("query", query);
            queryString.Add("userLocation", $"{latitude},{longitude}");
            queryString.Add("includeEntityTypes", "Business");
            queryString.Add("key", _bingMapAuth.Key);
            var parameterString = UriQueryHelper.ToQueryString(queryString);
            var response = await _httpClient.GetStringAsync($"{baseUrl}{parameterString}");

            var bingMapBusinessResponse = JsonConvert.DeserializeObject<BingMapBusinessAutoResponse>(response);

            if (bingMapBusinessResponse is null)
                throw new BadHttpRequestException("Not Found");

            return bingMapBusinessResponse.resourceSets[0].resources[0].value.Select(v=>v.address).ToList();
        }

        public string Get(string query, string latitude, string longitude)
        {
            var baseUrl = "http://dev.virtualearth.net/REST/v1/Autosuggest";
            NameValueCollection queryString = new NameValueCollection();
            queryString.Add("query", query);
            queryString.Add("userLocation", $"{latitude},{longitude}");
            queryString.Add("includeEntityTypes", "Business");
            queryString.Add("key", _bingMapAuth.Key);
            var parameterString = UriQueryHelper.ToQueryString(queryString);
            return $"{baseUrl}{parameterString}";

        }
    }
}