using Microsoft.EntityFrameworkCore;
using RestoBorne.Application.Interfaces;
using RestoBorne.Domain.Entities;
using RestoBorne.Infrastructure.Persistence;

namespace RestoBorne.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly RestoBorneDbContext _context;

        public OrderRepository(RestoBorneDbContext context)
        {
            _context = context;
        }

        public async Task<Order?> GetByIdAsync(Guid id)
        {
            return await _context.Orders
                .Include(o => o.Items)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }
    }
}