using EN.Shared;
using Microsoft.EntityFrameworkCore;
using Server.Data;

namespace Server.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;
        public CustomerRepository(DataContext context)
        {
            _context = context;
        }

        public async Task DeleteCustomerAsync(Guid id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if(customer is null)
                throw new BadHttpRequestException("Customer Not Found");

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<Customer> GetCustomerAsync(Guid id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await _context.Customers.ToListAsync();   
        }

        public async Task<List<Customer>> GetCustomersAsync(int pageNumber, int pageSize)
        {
            return await _context.Customers
                            .Skip((pageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToListAsync();   
        }

        public async Task InsertCustomerAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            var customerToSave = await _context.Customers.FindAsync(customer.Id);
            
            if (customerToSave is null)
                throw new BadHttpRequestException("Customer Not Found");

            _context.Entry(customerToSave).CurrentValues.SetValues(customer);
            _context.Entry(customerToSave).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task<int> GetCustomersCountAsync()
        {
            return await _context.Customers.CountAsync();
        }
    }
}