using E_Commerce_App.Data;
using E_Commerce_App.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_App.Models.Services
{
	public class OrderService : IOrder
    {
        private readonly E_CommerceDBContext _context;

        public OrderService(E_CommerceDBContext context)
        {
            _context = context;
        }

        public async Task AddOrder(Order order)
        {
            await _context.AddAsync(order);

            await _context.SaveChangesAsync();  
        }

        public async Task<List<Order>> GetAllSuccessOrders()
        {
            return await _context.Orders.Include(c=> c.Items)
                .Where(s=> s.Status == "Completed")
                .ToListAsync();
        }

        public async Task<Order> GetOrderBySessionId(string SessionID)
        {
            var order = await _context.Orders
                .Include(o => o.Items) // Eager load the Items property
                .FirstOrDefaultAsync(x => x.SessionID == SessionID);

            return order;
        }

        public async Task UpdateOrder(string sessionId, Order order)
        {
            var orderBySession = await _context.Orders.FirstOrDefaultAsync(s => s.SessionID == sessionId);
            if (orderBySession != null)
            {
                orderBySession.Status = order.Status;
                _context.Entry(orderBySession).State = EntityState.Modified;

                await _context.SaveChangesAsync();
            }

        }
    }
}
