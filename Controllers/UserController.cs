

using E_Commerce_Console_App.Helpers;
using E_Commerce_Console_App.Models;
using E_Commerce_Console_App.Services;
using System;

namespace E_Commerce_Console_App.Controllers
{
    public class UserController
    {
        UserService userService = new UserService();
        ProductController productController = new ProductController();
        PurchasesController purchasesController = new PurchasesController();
      
       
        public async Task CreateAccount()
        {
            Console.WriteLine("Enter your Details:");
            Console.WriteLine("user name:");
            var userName = Console.ReadLine();
            Console.WriteLine("password:");
            var password = Console.ReadLine();
            Console.WriteLine("Confirm password:");
            var Confirmpassword = Console.ReadLine();
            Console.WriteLine("Email:");
            var userEmail = Console.ReadLine();
            var detailsValidation = new Validator().DetailsChecker(userName,password,Confirmpassword,userEmail);
            if (!detailsValidation)
            {
                await CreateAccount();
            }
            else
            {
                var newUser = new AddUsers()
                {
                    Username=userName,
                    Password=password,
                    Email=userEmail,
                    Roles=Roles.Customer
                };
                var res = await userService.AddUserAsync(newUser);
                await Console.Out.WriteLineAsync(res.InfoMessage);
            }
        }
        public async Task UpdateDetails(string id)
        {
            await GetUserById(id);
            Console.WriteLine("Enter your Details:");
            Console.WriteLine("user name:");
            var userName = Console.ReadLine();
            Console.WriteLine("password:");
            var password = Console.ReadLine();
            Console.WriteLine("Confirm password:");
            var Confirmpassword = Console.ReadLine();
            Console.WriteLine("Email:");
            var userEmail = Console.ReadLine();
            var detailsValidation = new Validator().DetailsChecker(userName, password, Confirmpassword, userEmail);
            if (!detailsValidation)
            {
                await UpdateDetails(id);
            }
            else
            {
                var UpdatedUser = new Users()
                {
                    Id=id,
                    Username = userName,
                    Password = password,
                    Email = userEmail,
                    Roles = Roles.Seller
                };
                var res = await userService.UpdateUserAsync(UpdatedUser);
                await Console.Out.WriteLineAsync(res.InfoMessage);
            }

        }
        public async Task DeleteAccount()
        {
            await GetAllUsers();
            Console.WriteLine("enter user Id to delete");
            var id = Console.ReadLine();
            try
            {
                var res = await userService.RemoveUserAsync(id);
                await Console.Out.WriteLineAsync(res.InfoMessage);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public async Task GetAllUsers()
        {
            try
            {
                var users = await userService.GetAllUsersAsync();

                foreach(var user in users)
                {
                    await Console.Out.WriteLineAsync($"Id:{user.Id}.\tname:{user.Username}\tEmail:{user.Email}\n");
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public async Task<Users> GetUserById(string id)
        {
            var user = await userService.GetUserById(id);
            return user;
        }
        public async Task GetUserByRole(string id)
        {
          
            try
            {
                var user = await userService.GetUserByRole(id);
                if (user.Roles == Roles.Admin)
                {
                    await Console.Out.WriteLineAsync($"{user.Username} . {user.Roles}");
                    Console.WriteLine("Welcome to Naivas Console Admin Panel. Select an option. " +
                   "\n 1.Add a Seller.\n 2.View Sellers\n 3.Delete a seller\n " +
                   "\n 4.Edit admin account");
                    var input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            await CreateAccount();
                            break;
                        case "2":
                            await GetAllUsers();
                            break;
                        case "3":
                            await DeleteAccount();
                            break;
                        case "4":
                            await GetAllUsers();
                            break;                       
                        default:
                            //UserController.Initialize();
                            break;

                    }
                }
                else if (user.Roles == Roles.Seller)
                {
                    await Console.Out.WriteLineAsync($"{user.Username} . {user.Roles}");
                    Console.WriteLine("Welcome to Naivas Console Sellers Panel. Select an option. " +
                     "\n 1.Add a Product.\n 2.View Products\n 3.Edit a product\n 4.Delete a product\n " +
                     "5.Edit account details\n 6.View sales History");
                    var input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            await productController.AddnewProduct(user.Id);
                            break;
                        case "2":
                            await productController.ViewProducts();
                            break;
                        case "3":
                            await productController.UpdateProduct();
                            break;
                        case "4":
                            await productController.DeleteProduct();
                            break;
                        case "5":
                            await UpdateDetails(user.Id);
                            break;
                        case "6":
                            //view sales history
                            break;
                    }
                }
                else
                {
                    await Console.Out.WriteLineAsync($"{user.Username} . {user.Roles}");
                    Console.WriteLine("Welcome to Naivas Console Customers Panel. Select an option. " +
                     "\n 1.View Products .\n 2.My Bank\n 3.Edit Account Details\n 4.View Purchase History");
                    var input = Console.ReadLine();

                    switch (input)
                    {
                        case "1":
                            await productController.ViewProducts();
                            await Console.Out.WriteLineAsync("Enter a product Id to purchase the product:");
                            var productId = Console.ReadLine();
                            await productController.PurchaseProduct(productId, user.Id);
                            break;
                        case "2":
                            //add Funds
                            Console.WriteLine("Welcome to Naivas Console Customers Panel. Select an option. " +
                            "\n 1.Deposit Funds .\n 2.Create Account\n 3.Check balance");
                            var option = Console.ReadLine();
                            if(option == "1")
                            {
                                await Console.Out.WriteLineAsync("Enter Amount to Deposit");
                                var Amount =Convert.ToInt32( Console.ReadLine());
                                await purchasesController.DepositFunds(Amount, user.Id);

                            }else if (option == "2")
                            {
                                await Console.Out.WriteLineAsync("Enter Initial Deposit");
                                int amount = Convert.ToInt32(Console.ReadLine());
                                await purchasesController.CreateAccount(amount, user.Id);
                            }else if(option == "3")
                            {
                                await purchasesController.GetAccountBalance(user.Id);
                            }
                            else
                            {
                                await Console.Out.WriteLineAsync("Invalid option");
                            }

                            break;
                        case "3":
                            await UpdateDetails(user.Id.ToString());
                            break;
                        case "4":
                            //Purchase History;
                           await productController.PurchaseHistory(user.Id);
                            break;


                    }
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

