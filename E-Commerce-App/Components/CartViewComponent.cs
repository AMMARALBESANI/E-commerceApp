using E_Commerce_App.Models;
using E_Commerce_App.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace E_Commerce_App.Components
{
    public class CartViewComponent : ViewComponent
    {
        private readonly IProduct _product;

        public CartViewComponent(IProduct product)
        {
            _product = product;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var CookiesData = HttpContext.Request.Cookies["CartCookie"];
           
            if (CookiesData != null)
            {
               var ProductIds = JsonConvert.DeserializeObject<List<int>>(CookiesData);
                List<Product> Product = new List<Product>();
                foreach (var item in ProductIds)
                {
                    await _product.GetProductAsync(item);
                    
                }
               
            }
            else
            {
                return Content("");

            }

        }
    }
}
