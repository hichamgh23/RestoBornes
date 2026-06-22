using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestoBorne.Application.Interfaces;
using RestoBorne.Domain.Entities;

namespace RestoBorne.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        // Une liste statique pour simuler une base de données en mémoire
        private readonly List<Product> _products = new()
        {
            new Product { Id = Guid.NewGuid(), Name = "Burger Classic", Description = "Le classique", Price = 10.5m },
            new Product { Id = Guid.NewGuid(), Name = "Frites", Description = "Frites croustillantes", Price = 3.5m }
        };

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            // Simule une requête asynchrone
            return await Task.FromResult(_products);
        }

        public async Task<Product?> GetByIdAsync(Guid id)
        {
            // Cherche le produit par son ID
            return await Task.FromResult(_products.FirstOrDefault(p => p.Id == id));
        }
    }
}