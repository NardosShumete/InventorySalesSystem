namespace InventorySales.Desktop
{
    public static class Session
    {
        public static int UserId { get; set; }
        public static string Role { get; set; } = "User"; // Default to restricted
        public static string Username { get; set; }
        public static bool IsAdmin => Role == "Admin";
    }
}
