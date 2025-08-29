using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Models
{
    public class MenuItem
    {
        public int Id { get; set; }

        [StringLength(255)]
        public required string Name { get; set; }

        [Range(0.01, 10000)]
        public required decimal Price { get; set; }

        [StringLength(2047)]
        public string? Description { get; set; }

        public bool IsPopular { get; set; } = false;

        [StringLength(2047)]
        public string? ImageUrl { get; set; }
    }
}
