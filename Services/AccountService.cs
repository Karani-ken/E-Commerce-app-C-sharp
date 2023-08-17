using E_Commerce_Console_App.Models;
using E_Commerce_Console_App.Services.IServices;
using Newtonsoft.Json;
using System.Security.Principal;
using System.Text;

namespace E_Commerce_Console_App.Services
{
    public class AccountService : IAccountInterface
    {
        private readonly HttpClient _httpClient;
        private readonly string _url = "http://localhost:3000/Account";
        public AccountService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<Message> CreateAccountAsync(Account account)
        {
            var content = JsonConvert.SerializeObject(account);
            var bodyContent = new StringContent(content,Encoding.UTF8,"application/json");

            var response = await _httpClient.PostAsync(_url,bodyContent);
            if (response.IsSuccessStatusCode)
            {
                return new Message { InfoMessage = "Created successfully" };
            }
            throw new Exception("Account not Created");
        }

        public async Task<List<Account>> CheckBalanceAsync()
        {
            var response = await _httpClient.GetAsync(_url);
            var accounts = JsonConvert.DeserializeObject<List<Account>>(await response.Content.ReadAsStringAsync());
            if (response.IsSuccessStatusCode)
            {
                return accounts;
            }
            throw new Exception("Account not found");           
        }      

        public async Task<Message> UpdateBalanceAsync( Account account)
        {
            var content = JsonConvert.SerializeObject(account);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(_url + "/" + account.Id, bodyContent);
            if (response.IsSuccessStatusCode)
            {
                return new Message { InfoMessage = "Deposit was successful" };
            }
            throw new Exception("Depositing funds Failed");

        }

       
    }
}
