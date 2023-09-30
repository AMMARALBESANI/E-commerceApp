using E_Commerce_App.Models;
using E_Commerce_App.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace E_Commerce_App.Components
{
    public class CartViewComponent : ViewComponent
    {
        private readonly IProduct _product;

        private readonly ICart _cart;

        public CartViewComponent(IProduct product , ICart cart)
        {
            _product = product;
            _cart = cart;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var Username = User.Identity.Name;

            var cartItems = _cart.GetCartItems(Username);

            return View(cartItems);

            //var CookiesData = HttpContext.Request.Cookies["CartCookie_" + Username.ToString()];

            //if (CookiesData != null)
            //{
            //   var ProductIds = JsonConvert.DeserializeObject<List<int>>(CookiesData);
            //    List<Product> Product = new List<Product>();
            //    foreach (var item in ProductIds)
            //    {
            //       var x = await _product.GetProductAsync(item);
            //        Product.Add(x);
                    
            //    }
            //    return View(Product);
               
            //}
            //else
            //{
            //    return View();

            //}

        }
    }
}
