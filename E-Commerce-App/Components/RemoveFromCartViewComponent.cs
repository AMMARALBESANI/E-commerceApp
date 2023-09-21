using E_Commerce_App.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace E_Commerce_App.Components
{
    public class RemoveFromCartViewComponent : ViewComponent
    {
        private readonly IProduct _product;
        public RemoveFromCartViewComponent(IProduct product)
        {
            _product = product;
        }

        public async Task<IViewComponentResult> InvokeAsync(int productID)
        {
            var CookiesData = HttpContext.Request.Cookies["CartCookie"];
            List<int> ProductIds;
            if (CookiesData != null)
            {
                ProductIds = JsonConvert.DeserializeObject<List<int>>(CookiesData);
                if (ProductIds.Contains(productID))
                {
                    ProductIds.Remove(productID);
                    var options = new CookieOptions
                    {
                        Expires = DateTime.Now.AddDays(7),

                    };
                    HttpContext.Response.Cookies.Append("CartCookie", JsonConvert.SerializeObject(ProductIds), options);
                }
            }


            return View();
        }
    }
}
