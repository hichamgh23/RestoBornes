using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestoBorne.Application.Interfaces;
using RestoBorne.Domain.Entities;

namespace RestoBorne.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly List<Order> _orders = new();

        public async Task<Order?> GetByIdAsync(Guid id)
        {
            return await Task.FromResult(_orders.FirstOrDefault(o => o.Id == id));
        }

        public Task AddAsync(Order order)
        {
            _orders.Add(order);
            return Task.CompletedTask;
        }
    }
}