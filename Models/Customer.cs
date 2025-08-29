using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Models
{
    public class Customer 
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string? Name { get; set; }

        [StringLength(40)]
        public string? PhoneNumber { get; set; }
    }
}
