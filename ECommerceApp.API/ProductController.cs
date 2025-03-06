using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Description = "High-performance laptop with 16GB RAM and 512GB SSD", Price = 1299.99m, ImageUrl = "https://static.digit.in/default/63043a830597c650a77e5b892de23c519eb5100e.jpeg", Category = "Electronics" },
            new Product { Id = 2, Name = "Smartphone", Description = "Latest smartphone with 6.7-inch display and 5G capability", Price = 999.99m, ImageUrl = "https://static.digit.in/default/63043a830597c650a77e5b892de23c519eb5100e.jpeg", Category = "Electronics" },
            new Product { Id = 3, Name = "Headphones", Description = "Noise-cancelling wireless headphones", Price = 249.99m, ImageUrl = "https://i.pinimg.com/736x/c7/ab/40/c7ab40dd5251db60967ef6da3ddb85d1.jpg", Category = "Audio" },
            new Product { Id = 4, Name = "Coffee Maker", Description = "Premium coffee maker with grinder", Price = 199.99m, ImageUrl = "https://cdn.dashhudson.com/media/full/1696622941.558451796940.jpeg", Category = "Kitchen" },
            new Product { Id = 5, Name = "Running Shoes", Description = "Comfortable running shoes with cushioned soles", Price = 129.99m, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSDKVvhYn1gVrD1NtJnAEESWwF_QCl6jSbnlw&s", Category = "Sports" }
        };

        // GET: api/products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return _products;
        }

        // GET: api/products/5
        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        public static List<Product> GetProductsList()
{
    return _products;
}
        // GET: api/products/category/Electronics
        [HttpGet("category/{category}")]
        public ActionResult<IEnumerable<Product>> GetProductsByCategory(string category)
        {
            var products = _products.Where(p => p.Category.ToLower() == category.ToLower()).ToList();
            
            if (!products.Any())
            {
                return NotFound();
            }

            return Ok(products);
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Category { get; set; }
    }
}