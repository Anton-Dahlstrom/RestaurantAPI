using RestaurantAPI.DTOs;
using RestaurantAPI.Models;

namespace RestaurantAPI.Services.IServices
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(RegisterDTO dto);
        Task<string?> LoginAsync(LoginDTO dto);
    }
}
