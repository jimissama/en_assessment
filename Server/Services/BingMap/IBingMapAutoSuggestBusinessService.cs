using EN.Shared;
using Server.Models;

namespace Server.Services.BingMap
{
    public interface IBingMapAutoSuggestService
    {   
        /// <summary>
        /// Gets the Bing Map Autosuggest records
        /// </summary>
        /// <param name="request">request params</param>
        /// <returns>List of values</returns>
        Task<List<BingMapAutoSuggestValue>> GetValuesAsync(IBingMapAutoSuggestRequest request); 
    }
}