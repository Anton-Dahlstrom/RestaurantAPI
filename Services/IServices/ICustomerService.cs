using RestaurantAPI.DTOs;

namespace RestaurantAPI.Services.IServices
{
    public interface ICustomerService
    {
        Task<List<CustomerDTO>> GetAllCustomersAsync();
    }
}
