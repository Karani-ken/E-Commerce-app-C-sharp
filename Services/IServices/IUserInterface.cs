using E_Commerce_Console_App.Models;


namespace E_Commerce_Console_App.Services.IServices
{
    public interface IUserInterface
    {
        //add a user
        Task<Message> AddUserAsync(AddUsers user);
        //update a user
        Task<Message> UpdateUserAsync(Users user);
        //view users
        Task<List<Users>> GetAllUsersAsync();
        //remove a user
        Task<Message> RemoveUserAsync(string id);
    }
}
