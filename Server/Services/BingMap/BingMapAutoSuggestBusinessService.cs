using Server.Helpers;
using Server.Models;
using Newtonsoft.Json;
using EN.Shared;

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
        
        public async Task<List<BingMapAutoSuggestValue>> GetValuesAsync(IBingMapAutoSuggestRequest request)
        {
            request.key = _bingMapAuth.Key;
            var uri = UriBingMapAutosuggestHelper.CreateQueryUri(request);
            var responseString = await GetBingMapAutosuggestResponseString(uri);
            var response = GetResponseFromString(responseString);

            if (IsResponseNull(response))
                throw new HttpRequestException("Data Not Found!", null, System.Net.HttpStatusCode.NotFound);

            return GetValuesFromResponse(response);
        }

        private async Task<string> GetBingMapAutosuggestResponseString(string requestUri)
        {
            return await _httpClient.GetStringAsync(requestUri);
        }

        private BingMapAutoSuggestResponse GetResponseFromString(string response)
        {
            return JsonConvert.DeserializeObject<BingMapAutoSuggestResponse>(response);
        }

        private bool IsResponseNull(BingMapAutoSuggestResponse response)
        {
            return response is null;
        }

        private List<BingMapAutoSuggestValue> GetValuesFromResponse(BingMapAutoSuggestResponse response)
        {
            return response.resourceSets[0].resources[0].value;
        }

    }
}