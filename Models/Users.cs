

namespace E_Commerce_Console_App.Models
{
    public class Users
    {
        public string Id { get; set; }
        public Roles Roles { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
