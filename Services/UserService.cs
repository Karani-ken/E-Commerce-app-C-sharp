using E_Commerce_Console_App.Models;
using E_Commerce_Console_App.Services.IServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Console_App.Services
{
    public class UserService : IUserInterface
    {
        public Task<Message> AddUserAsync(AddUsers user)
        {
            var content = JsonConvert.SerializeObject(user);
            var bodyContent = new StringContent(content, Encoding.UTF8,"application/json");
            throw new NotImplementedException();
        }

        public Task<List<Users>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Message> RemoveUserAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Message> UpdateUserAsync(Users user)
        {
            throw new NotImplementedException();
        }
    }
}
