using Server.Models;

namespace Server.Services.BingMap
{
    public interface IBingMapAutoSuggestService
    {
        /// <summary>
        /// Gets the Bing Map Autosuggest records for the Business type
        /// </summary>
        /// <param name="query">user's search text</param>
        /// <param name="latitude">user's location's latitude</param>
        /// <param name="longitude">user's location's longitude</param>
        /// <returns>List of business addresses</returns>
        Task<List<BingMapAutoSuggestAddress>> GetBusinessAddressDataAsync(string query, string latitude, string longitude);     
    }
}