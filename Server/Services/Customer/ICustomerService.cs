
using EN.Shared;

namespace Server.Services
{
    public interface ICustomerService
    {
        /// <summary>
        /// Gets All the customers
        /// </summary>
        /// <returns>List of customers</returns>
        Task<List<Customer>> GetCustomersAsync();

        /// <summary>
        /// Gets the customers by page number and page size
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns>List of the customers</returns>
        Task<List<Customer>> GetCustomersAsync(int pageNumber, int pageSize);
        
        /// <summary>
        /// Gets a customer
        /// </summary>
        /// <param name="id">customer id</param>
        /// <returns>a customer</returns>
        Task<Customer> GetCustomerAsync(Guid id);

        /// <summary>
        /// Insert a customer
        /// </summary>
        /// <param name="customer">customer</param>
        /// <returns></returns>
        Task InsertCustomerAsync(Customer customer);

        /// <summary>
        /// Update a customer
        /// </summary>
        /// <param name="customer">customer</param>
        /// <returns></returns>
        Task UpdateCustomerAsync(Customer customer);

        /// <summary>
        /// Delete a customer
        /// </summary>
        /// <param name="id">customer id</param>
        /// <returns></returns>
        Task DeleteCustomerAsync(Guid id);

        /// <summary>
        /// Gets customers' total count
        /// </summary>
        /// <returns>customers' total count</returns>
        Task<int> GetCustomersCountAsync();
    }
}