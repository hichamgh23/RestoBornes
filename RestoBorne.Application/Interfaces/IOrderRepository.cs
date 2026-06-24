using System;
using System.Threading.Tasks;
using RestoBorne.Domain.Entities;

namespace RestoBorne.Application.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order?> GetByIdAsync(Guid id);
        Task AddAsync(Order order);
    }
}