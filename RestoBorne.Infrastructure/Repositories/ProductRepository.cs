using Microsoft.EntityFrameworkCore;
using RestoBorne.Application.Interfaces;
using RestoBorne.Domain.Entities;
using RestoBorne.Infrastructure.Persistence;

namespace RestoBorne.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly RestoBorneDbContext _context;

        public ProductRepository(RestoBorneDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(Guid id)
        {
            return await _context.Products.FindAsync(id);
        }
    }
}