

namespace E_Commerce_Console_App.Models
{
    public enum Roles
    {
        Admin=1,
        Customer=2,
        Seller=3
    }
    public class AddUsers
    {
     
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Roles Roles { get; set; }

    }
}
