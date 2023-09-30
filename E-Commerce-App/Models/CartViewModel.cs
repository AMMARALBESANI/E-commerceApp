namespace E_Commerce_App.Models
{
    public class CartViewModel
    {
        public List<ShoppingCartItem> CartItems { get; set; }

        public double OrderTotal { get; set; }

        public Order OrderInformation { get; set; }
    }
}
