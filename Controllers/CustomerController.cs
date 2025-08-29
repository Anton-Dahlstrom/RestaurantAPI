using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.DTOs;
using RestaurantAPI.Services.IServices;

namespace RestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(ICustomerService customerService, IConfiguration config) : ControllerBase
    {
        private readonly ICustomerService _customerService = customerService;
        private readonly IConfiguration _config = config;

        [HttpGet]
        public async Task<ActionResult<List<CustomerDTO>>> GetAllCustomers()
        {
            List<CustomerDTO> customers = await _customerService.GetAllCustomersAsync();

            return Ok(customers);
        }
    }
}
