using E_Commerce_App.Models;
using E_Commerce_App.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;

namespace E_Commerce_App.Components
{
	public class AddProductToCartViewComponent : ViewComponent
    {
		private readonly IProduct _product;

        public AddProductToCartViewComponent(IProduct product)
        {
            _product= product;
        }
        public async Task<IViewComponentResult> InvokeAsync(int ProductId)
		{
			var CookiesData=HttpContext.Request.Cookies["CartCookie"];
			List<int> ProductIds;
			if (CookiesData != null) 
			{
                ProductIds = JsonConvert.DeserializeObject<List<int>>(CookiesData);

			}
			else
			{
				ProductIds = new List<int>();

			}
			ProductIds.Add(ProductId);
			var options = new CookieOptions
			{
				Expires = DateTime.Now.AddDays(7),

			};
            HttpContext.Response.Cookies.Append("CartCookie", JsonConvert.SerializeObject(ProductIds), options);
            return View();
		}
	}
}
