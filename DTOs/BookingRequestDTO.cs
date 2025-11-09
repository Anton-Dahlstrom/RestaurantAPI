namespace RestaurantAPI.DTOs
{
	public class BookingRequestDTO
	{
		public required string Name { get; set; }
		public required string PhoneNumber { get; set; }

		public required DateTime DateTime { get; set; }
		public required int GuestCount { get; set; }
		public required int TableId { get; set; }
	}
}