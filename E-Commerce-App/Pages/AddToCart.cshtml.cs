using E_Commerce_App.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Commerce_App.Pages
{
    public class AddToCartModel : PageModel
    {
        private readonly ICart _cart;
        public AddToCartModel(ICart cart)
        {
            _cart = cart;
        }
        public void OnGet()
        {
        }
        public void OnPostAddToCart(int productId) 
        {

        }
    }
}
