using E_Commerce_Console_App.Helpers;
using E_Commerce_Console_App.Models;
using E_Commerce_Console_App.Services;


namespace E_Commerce_Console_App.Controllers
{
    public class ProductController
    {

        ProductService productService = new ProductService();
        UserService userService = new UserService();
             
        public async Task AddnewProduct(string userId)
        {
            Console.WriteLine("Enter the product details:");
            
            Console.WriteLine("Product Name:");
            var productName = Console.ReadLine();
            Console.WriteLine("Description");
            var productDescription = Console.ReadLine();
            Console.WriteLine("Category:");
            var productCategory = Console.ReadLine();
            Console.WriteLine("Price:");
            var productPrice = Console.ReadLine();
            var user = await userService.GetUserById(userId);
            var newProduct = new AddProduct()
            {
                ProductName = productName,
                Description=productDescription,
                Category=productCategory,
                Price=productPrice,
                Seller = new Users()
                {
                    Username=user.Username,
                    Id=user.Id
                }
            };
            var res = await productService.CreateProductAsync(newProduct);
            await Console.Out.WriteLineAsync(res.InfoMessage);
        }
        public async Task ViewProducts()        {
            
            try
            {
                var products = await productService.GetAllProductAsync();
                foreach(var product in products)
                {
                    await Console.Out.WriteLineAsync($"Id:{product.Id}\tname:{product.ProductName}\tDescription:{product.Description}\t Category:{product.Category}\tPrice:{product.Price}\n");
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }
        public async Task UpdateProduct()
        {
            await ViewProducts();
            Console.WriteLine("Enter Id of the product to Update:");
            var id = Console.ReadLine();
            Console.WriteLine("Product Name:");
            var productName = Console.ReadLine();
            Console.WriteLine("Description");
            var productDescription = Console.ReadLine();
            Console.WriteLine("Category:");
            var productCategory = Console.ReadLine();
            Console.WriteLine("Price:");
            var productPrice = Console.ReadLine();

            var UpdateProduct = new Product()
            {
                Id=id,
                ProductName = productName,
                Description = productDescription,
                Category = productCategory,
                Price = productPrice
            };
            try
            {
                var res = await productService.UpdateProductAsync(UpdateProduct);
                await Console.Out.WriteLineAsync(res.InfoMessage);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public async Task DeleteProduct()
        {
            await ViewProducts();
            Console.WriteLine("Enter Id of the product to delete:");
            var id = Console.ReadLine();
            try
            {
                var res = await productService.DeleteProductAsync(id);
                await Console.Out.WriteLineAsync(res.InfoMessage);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
          
        }
        public async Task PurchaseProduct(string Product_id,string userId)
        {

            var product = await productService.GetProductAsync(Product_id);
            var user = await userService.GetUserById(userId);

            var newPurchase = new Purchases()
            {
                Product = product,
                users = new Users () {
                   Username = user.Username,
                    Id = user.Id
                }

            };
            try
            {
                var res = await productService.PurchaseProductAsync(newPurchase);
                await Console.Out.WriteLineAsync(res.InfoMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
        public async Task PurchaseHistory(string userId)
        {
            try
            {
                var Purchases = await productService.GetAllPurchasesAsync();
                var myPurchases = Purchases.FindAll(x => x.users.Id.Contains(userId));
                await Console.Out.WriteLineAsync("My purchase History");
                foreach (var  purchase in myPurchases)
                {
                    await Console.Out.WriteLineAsync($"{purchase.Product.Id}.{purchase.Product.ProductName}\t{purchase.Product.ProductName}\t" +
                        $"{purchase.users.Username}");
                }
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
        }
    }
}
