using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.DTOs
{
	public class MenuItemCreateDTO
	{
		[Required]
		[StringLength(255)]
		public string? Name { get; set; } = default;

		[Required]
		[Range(0.01, 10000)]
		public decimal? Price { get; set; } = default;

		[StringLength(2047)]
		public string? Description { get; set; }

		[StringLength(2047)]
		public string? ImageUrl { get; set; }
	}
}