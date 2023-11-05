using EN.Shared;

namespace Server.Repositories
{
    public interface ICustomerRepository
    {        
        Task<List<Customer>> GetCustomersAsync();
        Task<List<Customer>> GetCustomersAsync(int pageNumber, int pageSize);
        Task<Customer> GetCustomerAsync(Guid id);
        Task InsertCustomerAsync(Customer customer);
        Task UpdateCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(Guid id);   
        Task<int> GetCustomersCountAsync();
    }
}