using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.DTOs;
using RestaurantAPI.Models;
using RestaurantAPI.Services.IServices;

namespace RestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController(IBookingService bookingService) : ControllerBase
    {
        [Authorize(Roles = "Admin")]
        [HttpGet("Bookings")]
        public async Task<ActionResult<List<BookingDTO>>> GetAllBookings()
        {
            List<BookingDTO> bookings = await bookingService.GetAllBookingsAsync();

            return Ok(bookings);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("CreateBookingWithCustomer")] 
        public async Task<ActionResult<List<BookingDTO>>> CreateBookingWithCustomer(BookingRequestDTO dto)
        {
            Booking? booking = await bookingService.CreateBookingWithCustomerAsync(dto);
            if (booking == null) return BadRequest();

            return Ok(booking);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBooking(int id)
        {
            var success = await bookingService.DeleteBookingAsync(id);

            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
