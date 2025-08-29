using RestaurantAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public required string Username { get; set; }
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;
        public Role Role { get; set; } = Role.User;
    }
}
