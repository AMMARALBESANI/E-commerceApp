namespace E_Commerce_App.Models.Interfaces
{
    public interface IOrder
    {
        public Task AddOrder(Order order);

        public Task<Order> GetOrderBySessionId(string SessionID);

        public Task<List<Order>> GetAllSuccessOrders();

        public Task UpdateOrder(string sessionId, Order order);
    }
}
