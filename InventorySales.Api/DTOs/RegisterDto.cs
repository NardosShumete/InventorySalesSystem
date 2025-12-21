namespace InventorySales.Api.DTOs
{
    public class RegisterDto
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string Username { get; set; } = string.Empty;

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.EmailAddress]
        public string Email { get; set; } = string.Empty;

        [System.ComponentModel.DataAnnotations.MinLength(8, ErrorMessage = "Password must be at least 8 characters.")]
        public string? Password { get; set; } // Nullable because it's optional for updates

        public string Role { get; set; } = "User";
    }
}
