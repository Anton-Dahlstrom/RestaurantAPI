
using RestaurantAPI.DTOs;

namespace RestaurantAPI.Services.IServices
{
    public interface ITableService 
    {
        Task<List<TableDTO>> GetAllTablesAsync();
        Task<List<TableDTO>> GetAvailableTablesAsync(DateTime dateTime, int guests);
    }
}
