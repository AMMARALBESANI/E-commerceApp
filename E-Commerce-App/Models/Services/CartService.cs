using E_Commerce_App.Models.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace E_Commerce_App.Models.Services
{
    public class CartService : ICart
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int GetTotalItemCount(string userName)
        {
            var cart = GetCartFromCookies(userName);
            return cart.Count;
        }
        public double GetTotalPrice(string userName)
        {
            var cart = GetCartFromCookies(userName);
            return cart.Sum(item => item.ProductPrice);
        }
        public void AddToCart(string userName, ShoppingCartItem item)
        {
            List<ShoppingCartItem> cart = GetCartFromCookies(userName);

            var existingItem = cart.FirstOrDefault(x => x.ProductId == item.ProductId);

            cart.Add(item);


            SaveCartToCookies(userName, cart);
        }

        public void UpdateCart(string userName, ShoppingCartItem item)
        {
            List<ShoppingCartItem> cart = GetCartFromCookies(userName);

            var existingItem = cart.FirstOrDefault(x => x.ProductId == item.ProductId);

            SaveCartToCookies(userName, cart);
        }

        public void RemoveFromCart(string userName, int productId)
        {
            List<ShoppingCartItem> cart = GetCartFromCookies(userName);

            var existingItem = cart.FirstOrDefault(x => x.ProductId == productId);
            if (existingItem != null)
            {
                cart.Remove(existingItem);
            }

            SaveCartToCookies(userName, cart);
        }

        public void RemoveAllCart(string userName)
        {
            List<ShoppingCartItem> cart = GetCartFromCookies(userName);
            var itemsToRemove = new List<ShoppingCartItem>();

            foreach (var cartItem in cart)
            {
                itemsToRemove.Add(cartItem);
            }

            foreach (var itemToRemove in itemsToRemove)
            {
                cart.Remove(itemToRemove);
            }

            SaveCartToCookies(userName, cart);
        }

        public List<ShoppingCartItem> GetCartItems(string userName)
        {
            return GetCartFromCookies(userName);
        }

        private List<ShoppingCartItem> GetCartFromCookies(string userName)
        {
            var cartCookie = _httpContextAccessor.HttpContext.Request.Cookies[$"Cart_{userName}"];
            if (cartCookie != null)
            {
                var cartJson = Encoding.UTF8.GetString(Convert.FromBase64String(cartCookie));
                return JsonConvert.DeserializeObject<List<ShoppingCartItem>>(cartJson);
            }
            return new List<ShoppingCartItem>();
        }

        private void SaveCartToCookies(string userName, List<ShoppingCartItem> cart)
        {
            var cartJson = JsonConvert.SerializeObject(cart);
            var cartCookie = new CookieOptions
            {
                Path = "/",
                Expires = DateTime.UtcNow.AddMonths(1) // Adjust the expiration as needed
            };
            _httpContextAccessor.HttpContext.Response.Cookies.Append($"Cart_{userName}", Convert.ToBase64String(Encoding.UTF8.GetBytes(cartJson)), cartCookie);
        }
    }
}
