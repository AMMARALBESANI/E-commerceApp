using E_Commerce_App.Models.Interfaces;
using E_Commerce_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace E_Commerce_App.Pages
{
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)] // Disable caching

    public class ShopListModel : PageModel
    {
        private readonly IProduct _product;

        private readonly ICart _cart;

        public List<Product> Products { get; set; }

        public ShopListModel(IProduct product, ICart cart)
        {
            _product = product;
            _cart = cart;
            
        }
        
        
        public async Task OnGet()
        {
            Products = await _product.GetAllProducts();
        }
        public async Task<IActionResult> OnPostAddToProduct(int productID) 
        {
            var product = await _product.GetProductAsync(productID);

            var Username = User.Identity.Name;

            if (Username == null)
            {
                return RedirectToAction("Login", "User");
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

            _cart.AddToCart(Username, cartItem);
            return RedirectToPage("/ShopList");
        }
    }
}
