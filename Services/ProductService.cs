using E_Commerce_Console_App.Models;
using E_Commerce_Console_App.Services.IServices;
using Newtonsoft.Json;
using System.Text;

namespace E_Commerce_Console_App.Services
{
    public class ProductService : IProductInterface

    {
        private readonly HttpClient _httpClient;
        private readonly string _url = "http://localhost:3000/products";
        public ProductService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<Message> CreateProductAsync(AddProduct product)
        {
            var content = JsonConvert.SerializeObject(product);
            var bodyContent = new StringContent(content, Encoding.UTF8,"application/json");
            var response = await _httpClient.PostAsync(_url, bodyContent);
            if (response.IsSuccessStatusCode)
            {
                return new Message { InfoMessage="Product added successfully"};
            }

            throw new Exception("Product not added");
        }

        public async Task<Message> DeleteProductAsync(string id)
        {
            var response = await _httpClient.DeleteAsync(_url + "/" + id);
            if (response.IsSuccessStatusCode)
            {
                return new Message { InfoMessage = "Product deleted successfully" };
            }
            throw new Exception("Product not deleted");
        }

        public async Task<List<Product>> GetAllProductAsync()
        {
            var response = await _httpClient.GetAsync(_url);
            var products = JsonConvert.DeserializeObject<List<Product>>(await response.Content.ReadAsStringAsync());
            if (response.IsSuccessStatusCode)
            {
                return products;
            }
            throw new Exception("Could not fetch products");
        }

        public async Task<Product> GetProductAsync(string id)
        {

            var response = await _httpClient.GetAsync(_url + "/" + id);
            var product = JsonConvert.DeserializeObject<Product>(await response.Content.ReadAsStringAsync());
            if (response.IsSuccessStatusCode)
            {
                return product;
            }
            throw new Exception("Could not fetch product");
        }

        public Task<Message> PurchaseProductAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Message> UpdateProductAsync(Product product)
        {
            var content = JsonConvert.SerializeObject(product);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(_url + "/" + product.Id, bodyContent);
            if (response.IsSuccessStatusCode)
            {
                return new Message { InfoMessage = "Product updated successfully" };
            }

            throw new Exception("Product not updated");
        }
    }
}
