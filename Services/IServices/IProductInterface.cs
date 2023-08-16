using E_Commerce_Console_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Console_App.Services.IServices
{
    public interface IProductInterface
    {
        //Add a Product
        Task<Message> CreateProductAsync(Product product);
        //Update a product
        Task<Message> UpdateProductAsync(UpdateProduct product);
        //View Products
        Task<List<Product>> GetAllProductAsync();
        //view a product
        Task<Product> GetProductAsync(string id);
        //Delete a product
        Task<Message>DeleteProductAsync(string id);
        //Purchase product
        Task<Message>PurchaseProductAsync(string id);
    }
}
