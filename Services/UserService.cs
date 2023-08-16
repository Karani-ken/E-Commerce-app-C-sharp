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
        private readonly HttpClient _httpClient;
        private readonly string _url = "http://localhost:3000/users";

        public UserService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<Message> AddUserAsync(AddUsers user)
        {
            var content = JsonConvert.SerializeObject(user);
            var bodyContent = new StringContent(content, Encoding.UTF8,"application/json");
            var response = await _httpClient.PostAsync(_url, bodyContent);
            if (response.IsSuccessStatusCode)
            {
                return new Message { InfoMessage = "User Added successfully" };
            }
            throw new Exception("User not Added");
        }

        public async Task<List<Users>> GetAllUsersAsync()
        {
            var response = await _httpClient.GetAsync(_url);
            var Users = JsonConvert.DeserializeObject<List<Users>>(await response.Content.ReadAsStringAsync());
            if (response.IsSuccessStatusCode)
            {
                return Users;
            }
            throw new Exception("Could fetch Users");
        }

        public async Task<Message> RemoveUserAsync(string id)
        {
            var response = await _httpClient.DeleteAsync(_url + "/"+id);
            if (response.IsSuccessStatusCode)
            {
                return new Message { InfoMessage = "User deleted successfully" };
            }
            throw new Exception("Could not delete user");
        }

        public async Task<Message> UpdateUserAsync(Users user)
        {
            var content = JsonConvert.SerializeObject(user);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(_url + "/" + user.Id,bodyContent);
            if(response.IsSuccessStatusCode)
            {
                return new Message { InfoMessage = "User info Updated" };
            }
            throw new Exception("User Info failed to update");
        }
    }
}
