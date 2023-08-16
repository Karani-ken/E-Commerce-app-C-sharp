using E_Commerce_Console_App.Helpers;
using E_Commerce_Console_App.Models;
using E_Commerce_Console_App.Services;


namespace E_Commerce_Console_App.Controllers
{
    public class ProductController
    {

        ProductService productService = new ProductService();
        public async static Task Initialize()
        {
            Console.WriteLine("Welcome to Naivas Console Admin Panel. Select an option. " +
                "\n 1. Add a product.\n 2.View Products\n 3.Edit a product\n 4.Delete a Product.");

            var input = Console.ReadLine();
            var ValidateResult = Validator.Validation(new List<string> {input});
            if (!ValidateResult)
            {
                await ProductController.Initialize();
            }
            else
            {
                await new ProductController().Menus(input);
            }
        }

        public async Task Menus(string Id)
        {
            switch(Id)
            {
                case "1":
                    await AddnewProduct();
                    break;
                case "2":
                    await ViewProducts();
                    break;
                case "3":
                    await UpdateProduct();
                    break;
                case "4":
                    await DeleteProduct();
                    break;
                default:
                    ProductController.Initialize();
                    break;
            }
        }
        public async Task AddnewProduct()
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

            var newProduct = new AddProduct()
            {
                ProductName = productName,
                Description=productDescription,
                Category=productCategory,
                Price=productPrice
            };
            var res = await productService.CreateProductAsync(newProduct);
            await Console.Out.WriteLineAsync(res.InfoMessage);
        }
        public async Task ViewProducts()
        {
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
    }
}
