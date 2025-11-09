using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.DTOs
{
	public class MenuItemUpdateDTO
	{
		[StringLength(255)]
		public string? Name { get; set; }

		[Range(0.01, 10000)]
		public decimal? Price { get; set; }

		[StringLength(2047)]
		public string? Description { get; set; }

		public bool? IsPopular { get; set; }

		[StringLength(2047)]
		public string? ImageUrl { get; set; }
	}
}