using EN.Client.Models;

namespace EN.Client.Services
{
    public interface IBingMapAutoSuggestService
    {
        Task<List<BusinessAddress>> GetBusinessAddressesAsync(string query, string latitude, string longitude);
    }
}