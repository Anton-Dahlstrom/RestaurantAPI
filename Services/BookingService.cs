using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Data;
using RestaurantAPI.DTOs;
using RestaurantAPI.Models;
using RestaurantAPI.Services.IServices;

namespace RestaurantAPI.Services
{
	public class BookingService(AppDBContext context) : IBookingService
	{
		private async Task<bool> IsTableAvailableAsync(int tableId, DateTime desiredTime)
		{
			var tableExists = await context.Tables.AnyAsync(t => t.Id == tableId);
			if (!tableExists)
			{
				return false;
			}

			DateTime start = desiredTime.AddHours(-2);
			DateTime end = desiredTime.AddHours(2);

			return !await context.Bookings
				.AnyAsync(b => b.TableIdFk == tableId && b.DateTime > start && b.DateTime < end);
		}

		public async Task<List<BookingDTO>> GetAllBookingsAsync()
		{
			var bookings = await context.Bookings.ToListAsync();

			var bookingDTO = bookings.Select(b => new BookingDTO
			{
				Id = b.Id,
				CustomerIdFk = b.CustomerIdFk,
				TableIdFk = b.TableIdFk,
				DateTime = b.DateTime,
				GuestCount = b.GuestCount
			}).ToList();

			return bookingDTO;
		}

		public async Task<Booking?> CreateBookingWithCustomerAsync(BookingRequestDTO dto)
		{
			if (!await IsTableAvailableAsync(dto.TableId, dto.DateTime))
			{
				return null;
			}

			var customer = new Customer
			{
				Name = dto.Name,
				PhoneNumber = dto.PhoneNumber
			};

			context.Customers.Add(customer);
			await context.SaveChangesAsync();

			var booking = new Booking
			{
				CustomerIdFk = customer.Id,
				TableIdFk = dto.TableId,
				DateTime = dto.DateTime,
				GuestCount = dto.GuestCount
			};

			context.Bookings.Add(booking);
			await context.SaveChangesAsync();

			return booking;
		}
		public async Task<bool> DeleteBookingAsync(int id)
		{
			var existing = await context.Bookings.FindAsync(id);
			if (existing == null) return false;

			context.Bookings.Remove(existing);
			await context.SaveChangesAsync();
			return true;
		}
	}
}