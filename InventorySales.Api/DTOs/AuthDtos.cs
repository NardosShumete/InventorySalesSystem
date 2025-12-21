using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InventorySales.Api.DTOs
{
    public class LoginDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }

    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        [Browsable(false)]
        public string Token { get; set; } // Simplified JWT or Session token
        public int PerformancePoints { get; set; }
    }
}
