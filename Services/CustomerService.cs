using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Data;
using RestaurantAPI.DTOs;
using RestaurantAPI.Services.IServices;

namespace RestaurantAPI.Services
{
    public class CustomerService(AppDBContext context) : ICustomerService
    {
        public async Task<List<CustomerDTO>> GetAllCustomersAsync()
        {
            var users = await context.Customers.ToListAsync();

            var usersDTO = users.Select(u => new CustomerDTO 
            {
                Id = u.Id,
                Name = u.Name,
                PhoneNumber = u.PhoneNumber
            }).ToList();

            return usersDTO;
        }
    }
}
