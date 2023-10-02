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

        [BindProperty]
        public int quantityNumber { get; set; }

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
            var Username = User.Identity.Name;

            var product = await _product.GetProductAsync(productID);

            if (Username == null)
            {
                return RedirectToAction("Login", "User");
            }
            if (_cart.IfNotExsit(Username, productID))
            {


                var cartItem = new ShoppingCartItem
                {
                    ProductId = productID,
                    username = Username,
                    ProductName = product.Name,
                    ProductPrice = product.Price,
                    ProductDiscount = product.Discount,
                    ProductUrl = product.ImageURL,
                    Quantity = quantityNumber,
                    DepartmentName = product.Department.Name
                };
                _cart.AddToCart(Username, cartItem);
            }
            else
            {
                var shoppingCartItem = _cart.GetCartItemFromCookie(Username, productID);
                shoppingCartItem.Quantity += quantityNumber;
                _cart.UpdateCart(Username, shoppingCartItem);
            }
            return RedirectToPage("/ShopList");
        }

    }
}
