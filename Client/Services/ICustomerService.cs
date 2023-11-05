using EN.Shared;

namespace EN.Client.Services
{
    public interface ICustomerService
    {
        Task<CustomerPaginateResult> GetCustomers(int pageNumber, int pageSize);
        
        Task InsertCustomer(Customer customer);

        Task UpdateCustomer(Customer customer);

        Task DeleteCustomer(Guid CustomerId);
    }
}