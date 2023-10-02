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

		private readonly ICart _cart;

        public AddProductToCartViewComponent(IProduct product, ICart cart)
        {
            _product = product;
            _cart = cart;
        }
        public async Task<IViewComponentResult> InvokeAsync(int productID)
		{
			var product = await _product.GetProductAsync(productID);

			var Username = User.Identity.Name;

			if (Username == null)
			{
				return View("/user/login");
			}

			var cartItem = new ShoppingCartItem
			{
				ProductId = productID,
				ProductName = product.Name,
				ProductPrice = product.Price,
				ProductDiscount = product.Discount,
				ProductUrl = product.ImageURL,
				DepartmentName = product.Department.Name
			};
			if(cartItem.ProductUrl == null)
			{
				cartItem.ProductUrl = "https://lab29images.blob.core.windows.net/images/defaultImage.png";

            }
			_cart.AddToCart(Username, cartItem);

			return View();

			//         var CookiesData = HttpContext.Request.Cookies["CartCookie_" + Username.ToString()];
			//         List<int> ProductIds;
			//if (CookiesData != null) 
			//{
			//             ProductIds = JsonConvert.DeserializeObject<List<int>>(CookiesData);
			//}
			//else
			//{
			//	ProductIds = new List<int>();

			//}
			//ProductIds.Add(productID);
			//var options = new CookieOptions
			//{
			//	Expires = DateTime.Now.AddDays(7),

			//};
			//         HttpContext.Response.Cookies.Append("CartCookie_" +Username.ToString(), JsonConvert.SerializeObject(ProductIds), options);

			//return View();
		}
	}
}
