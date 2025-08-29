using RestaurantAPI.DTOs;
using RestaurantAPI.Models;

namespace RestaurantAPI.Services.IServices
{
    public interface IBookingService
    {
        Task<List<BookingDTO>> GetAllBookingsAsync();
        Task<Booking?> CreateBookingWithCustomerAsync(BookingRequestDTO dto);
        Task<bool> DeleteBookingAsync(int id);
    }
}
