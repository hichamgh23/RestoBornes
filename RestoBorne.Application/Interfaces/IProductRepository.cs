using System;
using System.Collections.Generic;
using RestoBorne.Domain.Entities;
using System.Threading.Tasks;

namespace RestoBorne.Application.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(Guid id);
    }
}