using EN.Shared;
using Microsoft.AspNetCore.Mvc;
using Server.Services;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _customerService.GetCustomersAsync());
        }

        [HttpGet("{pageNumber}/{pageSize}")]
        public async Task<IActionResult> GetCustomers(int pageNumber, int pageSize)
        {
            var customers = await _customerService.GetCustomersAsync(pageNumber, pageSize);
            var customersTotalCount = await _customerService.GetCustomersCountAsync();

            var result = new CustomerPaginateResult
            {
                Data = customers,
                TotalCount = customersTotalCount
            };
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(Guid id)
        {
            var customer = await _customerService.GetCustomerAsync(id);

            if(customer is null)
                return NotFound("Customer Not Found!");

            return Ok(await _customerService.GetCustomerAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> InsertCustomer(Customer customer)
        {
            await _customerService.InsertCustomerAsync(customer);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(Customer customer)
        {
            await _customerService.UpdateCustomerAsync(customer);
            return Ok();            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            await _customerService.DeleteCustomerAsync(id);
            return Ok();
        }
        
    }
}