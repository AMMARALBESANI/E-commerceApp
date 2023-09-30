namespace E_Commerce_App.Models.Interfaces
{
    public interface ICart
    {
        void AddToCart(string userName, ShoppingCartItem item);

        void UpdateCart(string userName, ShoppingCartItem item);

        void RemoveFromCart(string userName, int productId);

        void RemoveAllCart(string userName);

        List<ShoppingCartItem> GetCartItems(string userName);

        double GetTotalPrice(string userName);

        int GetTotalItemCount(string userName);
    }
}
