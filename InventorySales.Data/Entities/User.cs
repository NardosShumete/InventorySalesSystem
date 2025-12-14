using System.ComponentModel.DataAnnotations;

namespace InventorySales.Data.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [MaxLength(20)]
        public string Role { get; set; } = "User"; // Admin, User
    }
}
