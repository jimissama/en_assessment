using EN.Shared;

namespace Server.Repositories
{
    public interface ICustomerRepository
    {   
        /// <summary>
        /// Gets all the customers from the DB
        /// </summary>
        /// <returns>List of the customers</returns>
        Task<List<Customer>> GetCustomersAsync();

        /// <summary>
        /// Gets the customers of page number and paze size from the DB
        /// </summary>
        /// <param name="pageNumber">paze number</param>
        /// <param name="pageSize">page size</param>
        /// <returns>List of the customers</returns>
        Task<List<Customer>> GetCustomersAsync(int pageNumber, int pageSize);

        /// <summary>
        /// Gets a customer from the DB
        /// </summary>
        /// <param name="id">customers id</param>
        /// <returns>a customer</returns>
        Task<Customer> GetCustomerAsync(Guid id);

        /// <summary>
        /// Insert a customer to the DB
        /// </summary>
        /// <param name="customer">customer</param>
        /// <returns></returns>
        Task InsertCustomerAsync(Customer customer);

        /// <summary>
        /// Update a customer to the DB
        /// </summary>
        /// <param name="customer">customer</param>
        /// <returns></returns>
        Task UpdateCustomerAsync(Customer customer);

        /// <summary>
        /// Delete a customer from the DB
        /// </summary>
        /// <param name="id">customer id</param>
        /// <returns></returns>
        Task DeleteCustomerAsync(Guid id);   

        /// <summary>
        /// Get customer's total count from the DB
        /// </summary>
        /// <returns>customers' total count</returns>
        Task<int> GetCustomersCountAsync();
    }
}