using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private static Dictionary<string, List<CartItem>> _carts = new Dictionary<string, List<CartItem>>();
        private static List<Product> _products = ProductsController.GetProductsList();

        // GET: api/cart/{sessionId}
        [HttpGet("{sessionId}")]
        public ActionResult<IEnumerable<CartItem>> GetCart(string sessionId)
        {
            if (!_carts.ContainsKey(sessionId))
            {
                _carts[sessionId] = new List<CartItem>();
            }

            return Ok(_carts[sessionId]);
        }

        // POST: api/cart/{sessionId}/add
        [HttpPost("{sessionId}/add")]
        public ActionResult AddToCart(string sessionId, [FromBody] AddToCartRequest request)
        {
            var product = _products.FirstOrDefault(p => p.Id == request.ProductId);
            if (product == null)
            {
                return NotFound("Product not found");
            }

            if (!_carts.ContainsKey(sessionId))
            {
                _carts[sessionId] = new List<CartItem>();
            }

            var cart = _carts[sessionId];
            var existingItem = cart.FirstOrDefault(item => item.Product.Id == request.ProductId);

            if (existingItem != null)
            {
                existingItem.Quantity += request.Quantity;
            }
            else
            {
                cart.Add(new CartItem
                {
                    Product = product,
                    Quantity = request.Quantity
                });
            }

            return Ok(cart);
        }

        // PUT: api/cart/{sessionId}/update
        [HttpPut("{sessionId}/update")]
        public ActionResult UpdateCartItem(string sessionId, [FromBody] UpdateCartRequest request)
        {
            if (!_carts.ContainsKey(sessionId))
            {
                return NotFound("Cart not found");
            }

            var cart = _carts[sessionId];
            var item = cart.FirstOrDefault(i => i.Product.Id == request.ProductId);

            if (item == null)
            {
                return NotFound("Product not found in cart");
            }

            if (request.Quantity <= 0)
            {
                cart.Remove(item);
            }
            else
            {
                item.Quantity = request.Quantity;
            }

            return Ok(cart);
        }

        // DELETE: api/cart/{sessionId}/remove/{productId}
        [HttpDelete("{sessionId}/remove/{productId}")]
        public ActionResult RemoveFromCart(string sessionId, int productId)
        {
            if (!_carts.ContainsKey(sessionId))
            {
                return NotFound("Cart not found");
            }

            var cart = _carts[sessionId];
            var item = cart.FirstOrDefault(i => i.Product.Id == productId);

            if (item == null)
            {
                return NotFound("Product not found in cart");
            }

            cart.Remove(item);
            return Ok(cart);
        }

        // DELETE: api/cart/{sessionId}/clear
        [HttpDelete("{sessionId}/clear")]
        public ActionResult ClearCart(string sessionId)
        {
            if (_carts.ContainsKey(sessionId))
            {
                _carts[sessionId].Clear();
            }
            else
            {
                _carts[sessionId] = new List<CartItem>();
            }

            return Ok(_carts[sessionId]);
        }
    }

    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }

    public class AddToCartRequest
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class UpdateCartRequest
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}