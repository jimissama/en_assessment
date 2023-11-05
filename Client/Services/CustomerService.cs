using EN.Shared;
using System.Net.Http.Json;

namespace EN.Client.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _http;
        public CustomerService(HttpClient http)
        {
            _http = http;
        }

        public async Task<CustomerPaginateResult> GetCustomers(int pageNumber, int pageSize)
        {            
            return await _http.GetFromJsonAsync<CustomerPaginateResult>($"Customer/{pageNumber}/{pageSize}");
        }

        public async Task InsertCustomer(Customer customer)
        {
            await _http.PostAsJsonAsync<Customer>($"Customer", customer);
        }

        public async Task UpdateCustomer(Customer customer)
        {
            await _http.PutAsJsonAsync<Customer>("Customer", customer); 
        }

        public async Task DeleteCustomer(Guid CustomerId)
        {
            await _http.DeleteAsync($"Customer/{CustomerId}");
        }
    }
}