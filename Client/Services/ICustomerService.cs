using EN.Shared;

namespace EN.Client.Services
{
    public interface ICustomerService
    {
        /// <summary>
        /// Gets the customers by page number and page size
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns>List of the customers</returns>
        Task<CustomerPaginateResult> GetCustomers(int pageNumber, int pageSize);
        
        /// <summary>
        /// Insert a customer
        /// </summary>
        /// <param name="customer">customer</param>
        /// <returns></returns>
        Task InsertCustomer(Customer customer);

        /// <summary>
        /// Update a customer
        /// </summary>
        /// <param name="customer">customer</param>
        /// <returns></returns>
        Task UpdateCustomer(Customer customer);

        /// <summary>
        /// Delete a customer
        /// </summary>
        /// <param name="id">customer id</param>
        /// <returns></returns>
        Task DeleteCustomer(Guid CustomerId);
    }
}