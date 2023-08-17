using E_Commerce_Console_App.Models;


namespace E_Commerce_Console_App.Services.IServices
{
    public interface IProductInterface
    {
        //Add a Product
        Task<Message> CreateProductAsync(AddProduct product);
        //Update a product
        Task<Message> UpdateProductAsync(Product product);
        //View Products
        Task<List<Product>> GetAllProductAsync();
        //view a product
        Task<Product> GetProductAsync(string id);
        //Delete a product
        Task<Message>DeleteProductAsync(string id);
        //Purchase product
        Task<Message>PurchaseProductAsync(Purchases purchase);
        //get all purchases
        Task<List<Purchases>> GetAllPurchasesAsync();
        
    }
}
