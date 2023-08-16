

using E_Commerce_Console_App.Helpers;
using E_Commerce_Console_App.Services;

namespace E_Commerce_Console_App.Controllers
{
    public class UserController
    {
        UserService userService = new UserService();

        public async static Task Initialize()
        {
            Console.WriteLine("Welcome to Naivas Console Users Panel. Select an option. " +
                "\n 1. Create Account.\n 2.Update details\n 3.Delete account\n 4.GetAllUsers");
            var input = Console.ReadLine();
            var ValidateResult = Validator.Validation(new List<string> { input });
            if (!ValidateResult)
            {
                await UserController.Initialize();
            }
            else
            {
                await new UserController().Menus(input);
            }
        }
        public async Task Menus(string Id)
        {
            switch (Id)
            {
                case "1":
                    await CreateAccount();
                    break;
                case "2":
                    await UpdateDetails();
                    break;
                case "3":
                    await DeleteAccount();
                    break;
                case "4":
                    await GetAllUsers();
                    break;
                default:
                    UserController.Initialize();
                    break;

            }
        }
        public async Task CreateAccount()
        {

        }
        public async Task UpdateDetails()
        {

        }
        public async Task DeleteAccount()
        {

        }
        public async Task GetAllUsers()
        {

        }
    }
}

