using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantAPI.Models
{
	public class Booking
	{
		public int Id { get; set; }

		[ForeignKey("Customer")]
		public required int CustomerIdFk { get; set; }
		public Customer? Customer { get; set; }

		[ForeignKey("Table")]
		public required int TableIdFk { get; set; }
		public Table? Table { get; set; }

		public required DateTime DateTime { get; set; }

		[Range(1, 24)]
		public required int GuestCount { get; set; }
	}
}