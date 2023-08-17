

using E_Commerce_Console_App.Helpers;
using E_Commerce_Console_App.Services;

namespace E_Commerce_Console_App.Controllers
{
    public class LoginController
    {
     UserService userService = new UserService();
    UserController userController = new UserController();
        public async static Task Initial()
        {
            await Console.Out.WriteLineAsync("Welcome to Naivas console shopping app\n" +
                "select an option to continue\n 1.Login\n 2.Create Account");
            var option = Console.ReadLine();
            var validateOption = Validator.Validation(new List<string>{ option});
            if (!validateOption)
            {
                await LoginController.Initial();
            }
            else
            {
                await new LoginController().OptionSwitch(option);
            }
        }
        public async Task OptionSwitch(string option)
        {
            switch(option)
            {
                case "1":
                    await LoginUser();
                    break;
                case "2":
                    await CreateAccount();
                    break;
                default:
                    await LoginController.Initial();
                    break;
            }

        }
        public async Task LoginUser()
        {
            await Console.Out.WriteLineAsync("username:");
            var username = Console.ReadLine();
            await Console.Out.WriteLineAsync("password:");
            var password = Console.ReadLine();
            var users = await userService.GetAllUsersAsync();
            var user =  users.Find(x => x.Username.ToLower().Contains(username) && x.Password.ToLower().Contains(password));
            if(user != null)
            {

               await  userController.GetUserByRole(user.Id);
            }
            else
            {
                Console.WriteLine("User not found");
            }


        }
        public async Task CreateAccount()
        {
            await userController.CreateAccount();
        }
    }
}
