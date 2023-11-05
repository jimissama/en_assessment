using EN.Shared;
using Server.Repositories;

namespace Server.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task DeleteCustomerAsync(Guid id)
        {
            await _customerRepository.DeleteCustomerAsync(id);
        }

        public async Task<Customer> GetCustomerAsync(Guid id)
        {
            return await _customerRepository.GetCustomerAsync(id);
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await _customerRepository.GetCustomersAsync();
        }

        public async Task<List<Customer>> GetCustomersAsync(int pageNumber, int pageSize)
        {
            return await _customerRepository.GetCustomersAsync(pageNumber, pageSize);
        }

        public async Task InsertCustomerAsync(Customer customer)
        {
            await _customerRepository.InsertCustomerAsync(customer);
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            await _customerRepository.UpdateCustomerAsync(customer);
        }

        public async Task<int> GetCustomersCountAsync()
        {
            return await _customerRepository.GetCustomersCountAsync();
        }
    }
}