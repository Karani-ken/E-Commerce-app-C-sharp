using E_Commerce_Console_App.Models;
using E_Commerce_Console_App.Services;


namespace E_Commerce_Console_App.Controllers
{
    public class PurchasesController
    {
        AccountService accountService = new AccountService();
        UserController userController = new UserController();
        public async Task CreateAccount(int amount,string userId)
        {
            var user = await userController.GetUserById(userId);
            var newAccount = new Account()
            {
                Balance = amount,
                user = new Users()
                {
                    Username = user.Username,
                    Id = user.Id
                }
            };
            try
            {
                var res = await accountService.CreateAccountAsync(newAccount);
                await Console.Out.WriteLineAsync(res.InfoMessage);
            }
            catch(Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
        }
        public async Task<Account> GetAccountBalance(string id)
        {
            var user = await userController.GetUserById(id);

            var accounts = await accountService.CheckBalanceAsync();
            var userAccount =  accounts.Find(x => x.user.Id.Contains(id));
            if(userAccount == null)
            {
                Console.WriteLine("You have no account yet");
            }
            await Console.Out.WriteLineAsync($"Account Name:{userAccount.user.Username} \n Account Balance:{userAccount.Balance}");
            return userAccount;
        }
        public async Task DepositFunds(int amount,string Account_Id)
        {
            var account = await GetAccountBalance(Account_Id);
            var balance = account.Balance;
            var updatedBalance = balance + amount;
            var updatedAccount = new Account()
            {
                Balance = updatedBalance
            };
            try
            {
                var res = await accountService.UpdateBalanceAsync(updatedAccount);
                await Console.Out.WriteLineAsync(res.InfoMessage);
            }
            catch(Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
        }
        public async Task PurchaseProduct(int amount, string Account_Id)
        {
            var account = await GetAccountBalance(Account_Id);
            var balance = account.Balance;
            var updatedBalance = balance - amount;
            var updatedAccount = new Account()
            {
                Balance = updatedBalance
            };
            try
            {
                var res = await accountService.UpdateBalanceAsync(updatedAccount);
                await Console.Out.WriteLineAsync(res.InfoMessage);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
        }
    }
}
