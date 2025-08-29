using RestaurantAPI.DTOs;
using RestaurantAPI.Models;

namespace RestaurantAPI.Services.IServices
{
    public interface IMenuService
    {
        Task<List<MenuItem>> GetAllMenuItemsAsync();
        Task<MenuItem?> GetMenuItemByIdAsync(int id);
        Task<MenuItem> CreateMenuItemAsync(MenuItemCreateDTO item);
        Task<MenuItem?> UpdateMenuItemAsync(int id, MenuItemUpdateDTO updated);
        Task<bool> DeleteMenuItemAsync(int id);
    }
}
