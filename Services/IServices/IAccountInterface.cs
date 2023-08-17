using E_Commerce_Console_App.Models;


namespace E_Commerce_Console_App.Services.IServices
{
    public interface IAccountInterface
    {
        //Add create Account
        Task<Message> CreateAccountAsync(Account account);
        //Check Balance
        Task<Account> CheckBalanceAsync();
        //Update balance
        Task<Message> UpdateBalanceAsync(Account account);

    }
}
