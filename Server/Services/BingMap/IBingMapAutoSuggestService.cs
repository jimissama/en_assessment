using Server.Models;

namespace Server.Services.BingMap
{
    public interface IBingMapAutoSuggestService
    {
        Task<List<BingMapAutoSuggestAddress>> GetBusinessAddressDataAsync(string query, string latitude, string longitude);
        string Get(string query, string latitude, string longitude);
    }
}